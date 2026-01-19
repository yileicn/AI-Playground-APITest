using System.Text;
using System.ClientModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI.Chat;

namespace APITestTool
{
    /// <summary>
    /// AI Playground 窗体
    /// </summary>
    public partial class PromptTestForm : Form
    {
        // 所有控件声明都在 PromptTestForm.Designer.cs 中

        #region 字段

        private ChatClient? _chatClient;
        private OpenAISettings _settings;
        private readonly List<ConversationMessage> _conversationHistory = new();
        private List<PromptConfig> _savedPrompts = new();
        private readonly string _savedPromptsFilePath;
        private readonly string _settingsFilePath;
        private CancellationTokenSource? _cancellationTokenSource;
        private int _totalPromptTokens = 0;
        private int _totalCompletionTokens = 0;
        private PromptConfig? _currentPromptConfig = null;
        private ChatCompletionResponse? _lastToolCallResponse = null; // 保存最后一次工具调用响应
        private List<ChatMessage> _assistantMessagesWithToolCalls = new(); // 保存包含 tool_calls 的 assistant 消息，按顺序保存

        // 颜色主题 (Catppuccin Mocha)
        private static readonly Color BgDark = Color.FromArgb(24, 24, 37);
        private static readonly Color BgMedium = Color.FromArgb(30, 30, 46);
        private static readonly Color BgLight = Color.FromArgb(49, 50, 68);
        private static readonly Color TextPrimary = Color.FromArgb(205, 214, 244);
        private static readonly Color TextSecondary = Color.FromArgb(166, 173, 200);
        private static readonly Color AccentGreen = Color.FromArgb(166, 227, 161);
        private static readonly Color AccentBlue = Color.FromArgb(137, 180, 250);
        private static readonly Color AccentPink = Color.FromArgb(245, 194, 231);
        private static readonly Color AccentPurple = Color.FromArgb(203, 166, 247);
        private static readonly Color AccentYellow = Color.FromArgb(249, 226, 175);
        private static readonly Color AccentRed = Color.FromArgb(243, 139, 168);
        private static readonly Color AccentTeal = Color.FromArgb(148, 226, 213);

        #endregion

        public PromptTestForm()
        {
            // 设置文件路径
            var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "APITestTool");
            Directory.CreateDirectory(appDataPath);
            _savedPromptsFilePath = Path.Combine(appDataPath, "saved_prompts.json");
            _settingsFilePath = Path.Combine(appDataPath, "openai_settings.json");

            // 加载设置
            _settings = LoadSettings();
            InitializeChatClient();

            InitializeComponent();
            SetupEventHandlers();
            LoadSavedPrompts();
        }

        private void InitializeChatClient()
        {
            string apiKey = "";
            
            // 如果使用环境变量，从环境变量读取
            if (_settings.UseEnvironmentVariable && !string.IsNullOrWhiteSpace(_settings.EnvironmentVariableName))
            {
                apiKey = Environment.GetEnvironmentVariable(_settings.EnvironmentVariableName) ?? "";
            }
            else
            {
                apiKey = _settings.ApiKey;
            }
            
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                _chatClient = null;
                return;
            }

            // 如果控件还未初始化，使用默认模型
            var model = "gpt-4o";
            if (cboModel != null && cboModel.SelectedItem != null)
            {
                model = cboModel.SelectedItem.ToString() ?? "gpt-4o";
            }
            
            _chatClient = new ChatClient(model: model, apiKey: apiKey);
        }

        private void SetupEventHandlers()
        {
            // TrackBar 事件
            trackTemperature.ValueChanged += (s, e) =>
            {
                lblTemperatureValue.Text = (trackTemperature.Value / 100.0).ToString("F2");
            };
            trackTopP.ValueChanged += (s, e) =>
            {
                lblTopPValue.Text = (trackTopP.Value / 100.0).ToString("F2");
            };

            // 初始化 DataGridView 列
            dgvVariables.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "变量名", Width = 120 });
            dgvVariables.Columns.Add(new DataGridViewTextBoxColumn { Name = "Value", HeaderText = "值", Width = 200 });
            dgvVariables.Columns.Add(new DataGridViewButtonColumn { Name = "Delete", HeaderText = "", Width = 60, Text = "🗑️", UseColumnTextForButtonValue = true });
            
            // 初始化 ComboBox 项
            cboModel.Items.AddRange(new object[] {
                "gpt-4o",
                "gpt-4o-mini",
                "gpt-4-turbo",
                "gpt-4",
                "gpt-3.5-turbo",
                "o1",
                "o1-mini",
                "o1-preview",
                "o3-mini"
            });
            cboModel.SelectedIndex = 0;
        }

        // 所有控件定义都在 PromptTestForm.Designer.cs 中

        private void AppendMessage(string role, string content, Color roleColor)
        {
            if (InvokeRequired)
            {
                Invoke(() => AppendMessage(role, content, roleColor));
                return;
            }

            txtConversation.SelectionStart = txtConversation.TextLength;
            txtConversation.SelectionColor = roleColor;
            txtConversation.AppendText($"\n{role}:\n");

            txtConversation.SelectionStart = txtConversation.TextLength;
            txtConversation.SelectionColor = TextPrimary;
            txtConversation.AppendText($"{content}\n");

            txtConversation.SelectionStart = txtConversation.TextLength;
            txtConversation.SelectionColor = Color.FromArgb(69, 71, 90);
            txtConversation.AppendText("─────────────────────────────────────────\n");

            if (chkAutoScroll.Checked)
            {
                txtConversation.ScrollToCaret();
            }
        }

        private void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateStatus(message));
                return;
            }
            lblStatus.Text = message;
        }

        private void UpdateTokenCount()
        {
            if (InvokeRequired)
            {
                Invoke(UpdateTokenCount);
                return;
            }
            lblTokenCount.Text = $"Tokens: {_totalPromptTokens + _totalCompletionTokens} (Prompt: {_totalPromptTokens}, Completion: {_totalCompletionTokens})";
        }

        /// <summary>
        /// 设置加载状态（显示/隐藏加载动画，启用/禁用按钮）
        /// </summary>
        private void SetLoadingState(bool isLoading)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetLoadingState(isLoading)));
                return;
            }

            if (isLoading)
            {
                // 显示加载动画
                progressBarLoading.Visible = true;
                progressBarLoading.BringToFront();
                
                // 禁用按钮
                btnSend.Enabled = false;
                btnClear.Enabled = false;
                btnSend.Text = "发送中...";
                btnSend.BackColor = Color.FromArgb(100, 100, 120); // 灰色表示禁用
            }
            else
            {
                // 隐藏加载动画
                progressBarLoading.Visible = false;
                
                // 恢复按钮状态
                btnSend.Enabled = true;
                btnClear.Enabled = true;
                btnSend.Text = "发送 ↑";
                btnSend.BackColor = Color.FromArgb(137, 180, 250); // 恢复原色
            }
        }

        private string ReplaceVariables(string text)
        {
            foreach (DataGridViewRow row in dgvVariables.Rows)
            {
                var name = row.Cells["Name"].Value?.ToString() ?? "";
                var value = row.Cells["Value"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(name))
                {
                    text = text.Replace($"{{{{{name}}}}}", value);
                }
            }
            return text;
        }

        #region 设置管理

        private OpenAISettings LoadSettings()
        {
            try
            {
                if (File.Exists(_settingsFilePath))
                {
                    var json = File.ReadAllText(_settingsFilePath);
                    return JsonConvert.DeserializeObject<OpenAISettings>(json) ?? new OpenAISettings();
                }
            }
            catch { }
            return new OpenAISettings();
        }

        private void SaveSettings()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
                File.WriteAllText(_settingsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存设置失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSettings_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenAISettingsDialog(_settings);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _settings = dialog.Settings;
                SaveSettings();
                InitializeChatClient();
                UpdateStatus("API 设置已更新");
            }
        }

        private void BtnManageTools_Click(object? sender, EventArgs e)
        {
            var selectedTool = cboTools.SelectedItem?.ToString();
            
            if (selectedTool == "Function")
            {
                // 获取当前 Prompt 的 Functions，如果没有则创建新的
                var currentFunctions = _currentPromptConfig?.Functions ?? new List<FunctionDefinition>();
                
                using var toolsForm = new FunctionsToolsForm(currentFunctions);
                if (toolsForm.ShowDialog() == DialogResult.OK)
                {
                    // 更新当前 Prompt 的 Functions
                    var updatedFunctions = toolsForm.GetFunctions();
                    
                    // 如果当前有选中的 Prompt，更新它
                    if (_currentPromptConfig != null)
                    {
                        _currentPromptConfig.Functions = updatedFunctions;
                        _currentPromptConfig.UpdatedAt = DateTime.Now;
                        SavePromptsToFile();
                    }
                    else
                    {
                        // 如果没有选中的 Prompt，创建一个临时配置保存 Functions
                        _currentPromptConfig = new PromptConfig
                        {
                            Functions = updatedFunctions
                        };
                    }
                    
                    UpdateStatus($"已保存 {updatedFunctions.Count} 个 Functions");
                    UpdateToolsButtonText(updatedFunctions.Count);
                }
            }
            else if (selectedTool == "MCP Server")
            {
                MessageBox.Show("MCP Server 功能暂未实现", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Prompt 管理

        private void LoadSavedPrompts()
        {
            try
            {
                if (File.Exists(_savedPromptsFilePath))
                {
                    var json = File.ReadAllText(_savedPromptsFilePath);
                    _savedPrompts = JsonConvert.DeserializeObject<List<PromptConfig>>(json) ?? new List<PromptConfig>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载 Prompt 失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _savedPrompts = new List<PromptConfig>();
            }

            RefreshSavedPromptsList();
        }

        private void SavePromptsToFile()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_savedPrompts, Formatting.Indented);
                File.WriteAllText(_savedPromptsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存 Prompt 失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshSavedPromptsList()
        {
            lstSavedPrompts.Items.Clear();
            foreach (var prompt in _savedPrompts)
            {
                lstSavedPrompts.Items.Add($"[{prompt.Model}] {prompt.Name}");
            }
        }

        private void BtnSavePrompt_Click(object? sender, EventArgs e)
        {
            using var dialog = new SaveRequestDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 检查是否已存在同名 Prompt
                var existingPrompt = _savedPrompts.FirstOrDefault(p => p.Name == dialog.RequestName);
                
                if (existingPrompt != null)
                {
                    // 更新现有 Prompt
                    existingPrompt.Model = cboModel.SelectedItem?.ToString() ?? "gpt-4o";
                    existingPrompt.SystemPrompt = txtSystemPrompt.Text;
                    existingPrompt.Temperature = trackTemperature.Value / 100.0;
                    existingPrompt.MaxTokens = (int)numMaxTokens.Value;
                    existingPrompt.TopP = trackTopP.Value / 100.0;
                    existingPrompt.Variables = GetVariablesFromGrid();
                    existingPrompt.Functions = _currentPromptConfig?.Functions ?? new List<FunctionDefinition>();
                    existingPrompt.UpdatedAt = DateTime.Now;
                    
                    _currentPromptConfig = existingPrompt;
                }
                else
                {
                    // 创建新 Prompt
                    var config = new PromptConfig
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = dialog.RequestName,
                        Model = cboModel.SelectedItem?.ToString() ?? "gpt-4o",
                        SystemPrompt = txtSystemPrompt.Text,
                        Temperature = trackTemperature.Value / 100.0,
                        MaxTokens = (int)numMaxTokens.Value,
                        TopP = trackTopP.Value / 100.0,
                        Variables = GetVariablesFromGrid(),
                        Functions = _currentPromptConfig?.Functions ?? new List<FunctionDefinition>(),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    _savedPrompts.Add(config);
                    _currentPromptConfig = config;
                }
                
                SavePromptsToFile();
                RefreshSavedPromptsList();

                MessageBox.Show($"Prompt \"{dialog.RequestName}\" 已保存!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeletePrompt_Click(object? sender, EventArgs e)
        {
            if (lstSavedPrompts.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择要删除的 Prompt", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedIndex = lstSavedPrompts.SelectedIndex;
            var prompt = _savedPrompts[selectedIndex];

            var result = MessageBox.Show($"确定要删除 Prompt \"{prompt.Name}\" 吗?", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _savedPrompts.RemoveAt(selectedIndex);
                SavePromptsToFile();
                RefreshSavedPromptsList();
            }
        }

        private void LstSavedPrompts_DoubleClick(object? sender, EventArgs e)
        {
            if (lstSavedPrompts.SelectedIndex < 0) return;

            var config = _savedPrompts[lstSavedPrompts.SelectedIndex];
            LoadPromptConfig(config);
            UpdateStatus($"已加载: {config.Name}");
        }

        private void LoadPromptConfig(PromptConfig config)
        {
            _currentPromptConfig = config;
            cboModel.SelectedItem = config.Model;
            txtSystemPrompt.Text = config.SystemPrompt;
            trackTemperature.Value = (int)(config.Temperature * 100);
            numMaxTokens.Value = Math.Clamp(config.MaxTokens, 1, 128000);
            trackTopP.Value = (int)(config.TopP * 100);

            // 加载变量
            dgvVariables.Rows.Clear();
            foreach (var variable in config.Variables)
            {
                dgvVariables.Rows.Add(variable.Name, variable.Value);
            }
            
            // 显示 Functions 信息并更新 UI
            var functionsCount = config.Functions?.Count ?? 0;
            UpdateToolsButtonText(functionsCount);
            
            if (functionsCount > 0)
            {
                UpdateStatus($"已加载 Prompt，包含 {functionsCount} 个 Functions");
                // 确保 Tools 下拉框选中 Function，以便用户知道有 Functions 可用
                if (cboTools.Items.Contains("Function"))
                {
                    cboTools.SelectedItem = "Function";
                }
            }
            else
            {
                UpdateStatus($"已加载 Prompt");
                // 如果没有 Functions，清空选择
                cboTools.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// 更新 Tools 管理按钮的文本，显示 Functions 数量
        /// </summary>
        private void UpdateToolsButtonText(int functionsCount)
        {
            if (btnManageTools == null) return;
            
            if (functionsCount > 0)
            {
                btnManageTools.Text = $"管理 ({functionsCount})";
            }
            else
            {
                btnManageTools.Text = "管理";
            }
        }

        private List<PromptVariable> GetVariablesFromGrid()
        {
            var variables = new List<PromptVariable>();
            foreach (DataGridViewRow row in dgvVariables.Rows)
            {
                var name = row.Cells["Name"].Value?.ToString() ?? "";
                var value = row.Cells["Value"].Value?.ToString() ?? "";
                if (!string.IsNullOrEmpty(name))
                {
                    variables.Add(new PromptVariable { Name = name, Value = value });
                }
            }
            return variables;
        }

        private void BtnExportPrompts_Click(object? sender, EventArgs e)
        {
            if (_savedPrompts.Count == 0)
            {
                MessageBox.Show("没有可导出的 Prompt", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "JSON文件 (*.json)|*.json|所有文件 (*.*)|*.*",
                DefaultExt = "json",
                FileName = $"prompts_{DateTime.Now:yyyyMMdd_HHmmss}.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(_savedPrompts, Formatting.Indented);
                    File.WriteAllText(dialog.FileName, json);
                    MessageBox.Show($"已导出 {_savedPrompts.Count} 个 Prompt", "导出成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnImportPrompts_Click(object? sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "JSON文件 (*.json)|*.json|所有文件 (*.*)|*.*",
                DefaultExt = "json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(dialog.FileName);
                    var importedPrompts = JsonConvert.DeserializeObject<List<PromptConfig>>(json);

                    if (importedPrompts == null || importedPrompts.Count == 0)
                    {
                        MessageBox.Show("文件中没有有效的 Prompt 数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = MessageBox.Show($"发现 {importedPrompts.Count} 个 Prompt。\n\n" +
                        "选择 \"是\" 合并到现有 Prompt\n选择 \"否\" 替换现有 Prompt",
                        "导入选项", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        foreach (var prompt in importedPrompts)
                        {
                            if (!_savedPrompts.Any(p => p.Name == prompt.Name))
                            {
                                prompt.Id = Guid.NewGuid().ToString();
                                _savedPrompts.Add(prompt);
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        _savedPrompts = importedPrompts;
                        foreach (var prompt in _savedPrompts)
                        {
                            prompt.Id = Guid.NewGuid().ToString();
                        }
                    }
                    else
                    {
                        return;
                    }

                    SavePromptsToFile();
                    RefreshSavedPromptsList();
                    MessageBox.Show($"导入完成! 当前共有 {_savedPrompts.Count} 个 Prompt", "导入成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导入失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 变量管理

        private void BtnAddVariable_Click(object? sender, EventArgs e)
        {
            dgvVariables.Rows.Add("variable_name", "");
            dgvVariables.CurrentCell = dgvVariables.Rows[dgvVariables.Rows.Count - 1].Cells["Name"];
            dgvVariables.BeginEdit(true);
        }

        private void DgvVariables_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvVariables.Columns["Delete"]!.Index)
            {
                dgvVariables.Rows.RemoveAt(e.RowIndex);
            }
        }

        #endregion

        #region 对话功能

        /// <summary>
        /// 检查是否有待处理的工具调用
        /// </summary>
        private bool HasPendingToolCall()
        {
            return _lastToolCallResponse != null && 
                   _lastToolCallResponse.ToolCalls != null && 
                   _lastToolCallResponse.ToolCalls.Count > 0;
        }

        private void TxtInput_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                // Ctrl+Enter: 发送消息或工具响应
                if (HasPendingToolCall())
                {
                    SendToolResponse();
                }
                else
                {
                    BtnSend_Click(sender, e);
                }
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
            {
                // Enter: 发送消息或工具响应
                e.SuppressKeyPress = true;
                if (HasPendingToolCall())
                {
                    SendToolResponse();
                }
                else
                {
                    BtnSend_Click(sender, e);
                }
            }
        }

        private async void BtnSend_Click(object? sender, EventArgs e)
        {
            // 如果有待处理的工具调用，发送工具响应
            if (HasPendingToolCall())
            {
                SendToolResponse();
                return;
            }

            var userInput = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("请输入消息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(_settings.ApiKey))
            {
                MessageBox.Show("请先配置 OpenAI API Key", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BtnSettings_Click(sender, e);
                return;
            }

            txtInput.Clear();
            
            // 禁用按钮并显示加载效果
            SetLoadingState(true);

            // 显示用户消息
            AppendMessage("👤 User", userInput, AccentBlue);

            // 添加到历史
            _conversationHistory.Add(new ConversationMessage { Role = "user", Content = userInput });

            try
            {
                _cancellationTokenSource = new CancellationTokenSource();
                UpdateStatus("正在生成响应...");

                var response = await SendChatRequestAsync(_cancellationTokenSource.Token);

                // 格式化响应内容
                string responseText = OpenAIChatService.FormatResponse(response);
                
                // 检查是否是工具调用响应
                bool isToolCall = response.ToolCalls != null && response.ToolCalls.Count > 0;
                
                if (isToolCall)
                {
                    AppendMessage("🔧 Tool Call", responseText, AccentPurple);
                    // 保存工具调用响应，显示 Response 输入框
                    _lastToolCallResponse = response;
                    ShowToolResponsePanel(true);
                    // 保存 assistant 消息，包含 ToolCalls 信息
                    // 注意：Content 使用实际内容（可能为空），而不是格式化的 JSON
                    string actualContent = response.Content ?? "";
                    _conversationHistory.Add(new ConversationMessage 
                    { 
                        Role = "assistant", 
                        Content = actualContent, // 使用实际内容，不是格式化的 JSON
                        ToolCalls = response.ToolCalls
                    });
                }
                else
                {
                    AppendMessage("🤖 Assistant", responseText, AccentGreen);
                    // 隐藏 Response 输入框
                    ShowToolResponsePanel(false);
                    _lastToolCallResponse = null;
                    // 保存普通的 assistant 消息
                    _conversationHistory.Add(new ConversationMessage { Role = "assistant", Content = responseText });
                }
                
                UpdateStatus("响应完成");
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("请求已取消");
            }
            catch (Exception ex)
            {
                AppendMessage("❌ Error", ex.Message, AccentRed);
                UpdateStatus($"错误: {ex.Message}");
            }
            finally
            {
                // 恢复按钮状态并隐藏加载效果
                SetLoadingState(false);
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private async Task<ChatCompletionResponse> SendChatRequestAsync(CancellationToken cancellationToken)
        {
            if (_chatClient == null)
            {
                throw new Exception("OpenAI 客户端未初始化，请先配置 API Key");
            }

            var model = cboModel.SelectedItem?.ToString() ?? "gpt-4o";
            
            // 获取 API Key（可能来自环境变量）
            string apiKey = GetApiKey();
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new Exception($"环境变量 \"{_settings.EnvironmentVariableName}\" 未设置或为空");
            }
            
            // 重新创建 ChatClient 以确保使用正确的模型和 API Key
            _chatClient = new ChatClient(model: model, apiKey: apiKey);

            // 构建消息列表
            var systemPrompt = ReplaceVariables(txtSystemPrompt.Text);
            var messages = OpenAIChatService.BuildMessages(systemPrompt, _conversationHistory, _assistantMessagesWithToolCalls);

            // 创建工具列表
            var functions = _currentPromptConfig?.Functions ?? new List<FunctionDefinition>();
            List<ChatTool>? toolsList = null;
            
            if (functions.Count > 0)
            {
                try
                {
                    toolsList = OpenAIChatService.CreateTools(functions);
                    UpdateStatus($"已加载 {toolsList.Count} 个 Functions");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"创建 Tools 失败: {ex.Message}");
                    UpdateStatus($"警告: Tools 创建失败 - {ex.Message}");
                }
            }

            // 创建聊天完成选项
            var options = OpenAIChatService.CreateOptions(
                temperature: trackTemperature.Value / 100.0,
                topP: trackTopP.Value / 100.0,
                maxTokens: (int)numMaxTokens.Value,
                tools: toolsList
            );

            // 发送请求
            var result = await _chatClient.CompleteChatAsync(messages, options, cancellationToken);
            var completion = result.Value;

            // 如果包含 tool_calls，保存原始的 assistant 消息（包含 tool_calls）
            // 这样下次构建消息时可以直接使用，而不需要重新构建
            if (completion.ToolCalls != null && completion.ToolCalls.Count > 0)
            {
                // 从 completion 中提取 assistant 消息内容
                string assistantContent = "";
                if (completion.Content != null && completion.Content.Count > 0)
                {
                    var firstContent = completion.Content[0];
                    var textProp = firstContent.GetType().GetProperty("Text");
                    if (textProp != null)
                    {
                        assistantContent = textProp.GetValue(firstContent)?.ToString() ?? "";
                    }
                }
                
                // 创建包含 tool_calls 的 assistant 消息
                var assistantMessage = ChatMessage.CreateAssistantMessage(assistantContent);
                foreach (var toolCall in completion.ToolCalls)
                {
                    assistantMessage.ToolCalls.Add(toolCall);
                }
                
                // 直接添加到列表（按顺序保存）
                _assistantMessagesWithToolCalls.Add(assistantMessage);
            }

            // 将 ChatCompletion 映射到自定义的响应类
            var response = OpenAIChatService.MapToResponse(completion);
            
            // 更新 Token 统计
            UpdateTokenUsage(response.Usage);
            
            return response;
        }

        private string GetApiKey()
        {
            if (_settings.UseEnvironmentVariable && !string.IsNullOrWhiteSpace(_settings.EnvironmentVariableName))
            {
                return Environment.GetEnvironmentVariable(_settings.EnvironmentVariableName) ?? "";
            }
            return _settings.ApiKey;
        }

        private void UpdateTokenUsage(TokenUsage? usage)
        {
            if (usage == null) return;

            if (usage.PromptTokens.HasValue)
            {
                _totalPromptTokens += usage.PromptTokens.Value;
            }

            if (usage.CompletionTokens.HasValue)
            {
                _totalCompletionTokens += usage.CompletionTokens.Value;
            }

            UpdateTokenCount();
        }


        private void BtnClear_Click(object? sender, EventArgs e)
        {
            _conversationHistory.Clear();
            txtConversation.Clear();
            _totalPromptTokens = 0;
            _totalCompletionTokens = 0;
            _lastToolCallResponse = null;
            _assistantMessagesWithToolCalls.Clear();
            ShowToolResponsePanel(false);
            UpdateTokenCount();
            UpdateStatus("对话已清空");
        }

        private void ShowToolResponsePanel(bool show)
        {
            if (InvokeRequired)
            {
                Invoke(() => ShowToolResponsePanel(show));
                return;
            }

            if (lblToolResponseHint == null)
            {
                return;
            }

            lblToolResponseHint.Visible = true; // 始终显示标签
            if (show)
            {
                lblToolResponseHint.Text = "🔧 Tool Response (JSON):";
                btnSend.Text = "Response";
                btnSend.BackColor = Color.FromArgb(203, 166, 247); // 紫色表示工具响应
                txtInput.Focus();
            }
            else
            {
                lblToolResponseHint.Text = "💬 User Message:";
                btnSend.Text = "发送 ↑";
                btnSend.BackColor = Color.FromArgb(137, 180, 250); // 恢复原色
            }
        }

        private async void SendToolResponse()
        {
            if (!HasPendingToolCall())
            {
                MessageBox.Show("没有待处理的工具调用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var toolResponseText = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(toolResponseText))
            {
                MessageBox.Show("请输入工具调用结果", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 验证 JSON 格式
            try
            {
                JsonConvert.DeserializeObject(toolResponseText);
            }
            catch
            {
                var result = MessageBox.Show("输入的内容不是有效的 JSON，是否继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            // 为每个工具调用添加 tool message
            if (_lastToolCallResponse?.ToolCalls != null)
            {
                foreach (var toolCall in _lastToolCallResponse.ToolCalls)
                {
                    _conversationHistory.Add(new ConversationMessage
                    {
                        Role = "tool",
                        Content = toolResponseText,
                        ToolCallId = toolCall.Id
                    });
                }
            }

            // 显示工具响应
            AppendMessage("🔧 Tool Response", toolResponseText, AccentTeal);

            // 保存当前的 tool call response，因为后续发送请求时需要用到
            var currentToolCallResponse = _lastToolCallResponse;

            // 清空输入框并隐藏提示
            txtInput.Clear();
            ShowToolResponsePanel(false);
            _lastToolCallResponse = null;

            // 继续发送请求
            try
            {
                SetLoadingState(true);
                _cancellationTokenSource = new CancellationTokenSource();
                UpdateStatus("正在处理工具响应...");

                var response = await SendChatRequestAsync(_cancellationTokenSource.Token);

                // 格式化响应内容
                string responseText = OpenAIChatService.FormatResponse(response);

                // 检查是否是工具调用响应
                bool isToolCall = response.ToolCalls != null && response.ToolCalls.Count > 0;

                if (isToolCall)
                {
                    AppendMessage("🔧 Tool Call", responseText, AccentPurple);
                    _lastToolCallResponse = response;
                    ShowToolResponsePanel(true);
                    // 保存 assistant 消息，使用实际内容（不是格式化的 JSON）
                    string actualContent = response.Content ?? "";
                    _conversationHistory.Add(new ConversationMessage 
                    { 
                        Role = "assistant", 
                        Content = actualContent, // 使用实际内容，不是格式化的 JSON
                        ToolCalls = response.ToolCalls
                    });
                }
                else
                {
                    AppendMessage("🤖 Assistant", responseText, AccentGreen);
                    ShowToolResponsePanel(false);
                    _lastToolCallResponse = null;
                    _conversationHistory.Add(new ConversationMessage { Role = "assistant", Content = responseText });
                }

                UpdateStatus("响应完成");
            }
            catch (OperationCanceledException)
            {
                UpdateStatus("请求已取消");
            }
            catch (Exception ex)
            {
                AppendMessage("❌ Error", ex.Message, AccentRed);
                UpdateStatus($"错误: {ex.Message}");
            }
            finally
            {
                SetLoadingState(false);
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        #endregion

        // Dispose 方法在 Designer 文件中定义，这里处理额外的资源释放
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // ChatClient 可能不需要显式释放，但设置为 null
                _chatClient = null;
                _cancellationTokenSource?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

