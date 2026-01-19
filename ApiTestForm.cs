using System.Diagnostics;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APITestTool
{
    public partial class ApiTestForm : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private readonly List<ApiTestResult> _results = new();
        private HttpClient? _httpClient;
        private List<SavedRequest> _savedRequests = new();
        private readonly string _savedRequestsFilePath;

        public ApiTestForm()
        {
            InitializeComponent();
            InitializeDataGridView();
            cboMethod.SelectedIndex = 0;

            // 设置保存文件路径
            var appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "APITestTool");
            Directory.CreateDirectory(appDataPath);
            _savedRequestsFilePath = Path.Combine(appDataPath, "saved_requests.json");

            // 加载已保存的请求
            LoadSavedRequests();

            // 设置对比字段提示
            txtCompareFields.PlaceholderText = "每行一个字段路径，如:\ndata.user.id\ndata.items[0].name\nresult.code";
        }

        private void InitializeDataGridView()
        {
            dgvResults.Columns.Clear();
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Index",
                HeaderText = "#",
                Width = 50
            });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StatusCode",
                HeaderText = "状态码",
                Width = 80
            });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Duration",
                HeaderText = "耗时(ms)",
                Width = 90
            });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ResponseSize",
                HeaderText = "响应大小",
                Width = 100
            });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ResponseHash",
                HeaderText = "响应Hash",
                Width = 120
            });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IsDifferent",
                HeaderText = "差异",
                Width = 60
            });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ResponseBody",
                HeaderText = "响应内容",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        #region 字段路径解析

        /// <summary>
        /// 获取配置的对比字段列表
        /// </summary>
        private List<string> GetCompareFields()
        {
            if (string.IsNullOrWhiteSpace(txtCompareFields.Text))
                return new List<string>();

            return txtCompareFields.Text
                .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(f => f.Trim())
                .Where(f => !string.IsNullOrEmpty(f))
                .ToList();
        }

        /// <summary>
        /// 根据路径从JSON中提取值
        /// 支持格式: data.user.name, items[0].id, result.list[2].value
        /// </summary>
        private JToken? GetValueByPath(JToken root, string path)
        {
            if (root == null || string.IsNullOrEmpty(path))
                return null;

            var current = root;
            var segments = ParsePath(path);

            foreach (var segment in segments)
            {
                if (current == null)
                    return null;

                if (segment.IsArrayIndex)
                {
                    if (current is JArray arr && segment.ArrayIndex >= 0 && segment.ArrayIndex < arr.Count)
                    {
                        current = arr[segment.ArrayIndex];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (current is JObject obj)
                    {
                        current = obj[segment.PropertyName];
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return current;
        }

        /// <summary>
        /// 解析路径为段列表
        /// </summary>
        private List<PathSegment> ParsePath(string path)
        {
            var segments = new List<PathSegment>();
            var i = 0;

            while (i < path.Length)
            {
                // 跳过点号
                if (path[i] == '.')
                {
                    i++;
                    continue;
                }

                // 处理数组索引 [n]
                if (path[i] == '[')
                {
                    var endBracket = path.IndexOf(']', i);
                    if (endBracket > i + 1)
                    {
                        var indexStr = path.Substring(i + 1, endBracket - i - 1);
                        if (int.TryParse(indexStr, out var index))
                        {
                            segments.Add(new PathSegment { IsArrayIndex = true, ArrayIndex = index });
                        }
                        i = endBracket + 1;
                    }
                    else
                    {
                        i++;
                    }
                    continue;
                }

                // 处理属性名
                var start = i;
                while (i < path.Length && path[i] != '.' && path[i] != '[')
                {
                    i++;
                }

                if (i > start)
                {
                    var propName = path.Substring(start, i - start);
                    segments.Add(new PathSegment { IsArrayIndex = false, PropertyName = propName });
                }
            }

            return segments;
        }

        /// <summary>
        /// 提取指定字段的值，返回用于对比的字符串
        /// </summary>
        private string ExtractFieldsForComparison(string jsonResponse, List<string> fields)
        {
            if (fields.Count == 0 || string.IsNullOrWhiteSpace(jsonResponse))
                return jsonResponse;

            try
            {
                var root = JToken.Parse(jsonResponse);
                var extractedValues = new Dictionary<string, string>();

                foreach (var field in fields)
                {
                    var value = GetValueByPath(root, field);
                    extractedValues[field] = value?.ToString() ?? "<null>";
                }

                return JsonConvert.SerializeObject(extractedValues, Formatting.None);
            }
            catch
            {
                return jsonResponse;
            }
        }

        /// <summary>
        /// 提取指定字段的值，返回格式化的JObject用于显示
        /// </summary>
        private JObject? ExtractFieldsAsJson(string jsonResponse, List<string> fields)
        {
            if (fields.Count == 0 || string.IsNullOrWhiteSpace(jsonResponse))
                return null;

            try
            {
                var root = JToken.Parse(jsonResponse);
                var result = new JObject();

                foreach (var field in fields)
                {
                    var value = GetValueByPath(root, field);
                    result[field] = value != null ? JToken.FromObject(value) : JValue.CreateNull();
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        private class PathSegment
        {
            public bool IsArrayIndex { get; set; }
            public int ArrayIndex { get; set; }
            public string PropertyName { get; set; } = "";
        }

        #endregion

        #region 保存请求功能

        private void LoadSavedRequests()
        {
            try
            {
                if (File.Exists(_savedRequestsFilePath))
                {
                    var json = File.ReadAllText(_savedRequestsFilePath);
                    _savedRequests = JsonConvert.DeserializeObject<List<SavedRequest>>(json) ?? new List<SavedRequest>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载保存的请求失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _savedRequests = new List<SavedRequest>();
            }

            RefreshSavedRequestsList();
        }

        private void SaveRequestsToFile()
        {
            try
            {
                var json = JsonConvert.SerializeObject(_savedRequests, Formatting.Indented);
                File.WriteAllText(_savedRequestsFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存请求失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshSavedRequestsList()
        {
            lstSavedRequests.Items.Clear();
            foreach (var request in _savedRequests)
            {
                lstSavedRequests.Items.Add($"[{request.Method}] {request.Name}");
            }
        }

        private void BtnSaveRequest_Click(object? sender, EventArgs e)
        {
            using var dialog = new SaveRequestDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var request = new SavedRequest
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = dialog.RequestName,
                    Url = txtUrl.Text,
                    Method = cboMethod.SelectedItem?.ToString() ?? "GET",
                    Headers = txtHeaders.Text,
                    Body = txtBody.Text,
                    CompareFields = txtCompareFields.Text,
                    CompareFieldsOnly = chkCompareFieldsOnly.Checked,
                    CallCount = (int)numCallCount.Value,
                    Timeout = (int)numTimeout.Value,
                    Delay = (int)numDelay.Value,
                    IsParallel = chkParallel.Checked,
                    CreatedAt = DateTime.Now
                };

                _savedRequests.Add(request);
                SaveRequestsToFile();
                RefreshSavedRequestsList();

                MessageBox.Show($"请求 \"{request.Name}\" 已保存!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDeleteRequest_Click(object? sender, EventArgs e)
        {
            if (lstSavedRequests.SelectedIndex < 0)
            {
                MessageBox.Show("请先选择要删除的请求", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedIndex = lstSavedRequests.SelectedIndex;
            var request = _savedRequests[selectedIndex];

            var result = MessageBox.Show($"确定要删除请求 \"{request.Name}\" 吗?", "确认删除",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _savedRequests.RemoveAt(selectedIndex);
                SaveRequestsToFile();
                RefreshSavedRequestsList();
            }
        }

        private void LstSavedRequests_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // 可以在这里添加预览功能
        }

        private void LstSavedRequests_DoubleClick(object? sender, EventArgs e)
        {
            LoadSelectedRequest();
        }

        private void LoadSelectedRequest()
        {
            if (lstSavedRequests.SelectedIndex < 0) return;

            var request = _savedRequests[lstSavedRequests.SelectedIndex];

            txtUrl.Text = request.Url;
            cboMethod.SelectedItem = request.Method;
            txtHeaders.Text = request.Headers;
            txtBody.Text = request.Body;
            txtCompareFields.Text = request.CompareFields ?? "";
            chkCompareFieldsOnly.Checked = request.CompareFieldsOnly;
            numCallCount.Value = Math.Clamp(request.CallCount, 1, 10000);
            numTimeout.Value = Math.Clamp(request.Timeout, 1, 300);
            numDelay.Value = Math.Clamp(request.Delay, 0, 60000);
            chkParallel.Checked = request.IsParallel;

            lblProgress.Text = $"已加载: {request.Name}";
        }

        private void BtnExportRequests_Click(object? sender, EventArgs e)
        {
            if (_savedRequests.Count == 0)
            {
                MessageBox.Show("没有可导出的请求", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new SaveFileDialog
            {
                Filter = "JSON文件 (*.json)|*.json|所有文件 (*.*)|*.*",
                DefaultExt = "json",
                FileName = $"api_requests_{DateTime.Now:yyyyMMdd_HHmmss}.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = JsonConvert.SerializeObject(_savedRequests, Formatting.Indented);
                    File.WriteAllText(dialog.FileName, json);
                    MessageBox.Show($"已导出 {_savedRequests.Count} 个请求到:\n{dialog.FileName}", "导出成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导出失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnImportRequests_Click(object? sender, EventArgs e)
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
                    var importedRequests = JsonConvert.DeserializeObject<List<SavedRequest>>(json);

                    if (importedRequests == null || importedRequests.Count == 0)
                    {
                        MessageBox.Show("文件中没有有效的请求数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = MessageBox.Show($"发现 {importedRequests.Count} 个请求。\n\n" +
                        "选择 \"是\" 合并到现有请求\n选择 \"否\" 替换现有请求",
                        "导入选项", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // 合并，避免重复
                        foreach (var request in importedRequests)
                        {
                            if (!_savedRequests.Any(r => r.Name == request.Name && r.Url == request.Url))
                            {
                                request.Id = Guid.NewGuid().ToString();
                                _savedRequests.Add(request);
                            }
                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        // 替换
                        _savedRequests = importedRequests;
                        foreach (var request in _savedRequests)
                        {
                            request.Id = Guid.NewGuid().ToString();
                        }
                    }
                    else
                    {
                        return;
                    }

                    SaveRequestsToFile();
                    RefreshSavedRequestsList();
                    MessageBox.Show($"导入完成! 当前共有 {_savedRequests.Count} 个请求", "导入成功",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"导入失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region 执行测试

        private async void BtnExecute_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                MessageBox.Show("请输入API URL", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 验证Headers JSON格式
            Dictionary<string, string>? headers = null;
            if (!string.IsNullOrWhiteSpace(txtHeaders.Text))
            {
                try
                {
                    headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(txtHeaders.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Headers JSON格式错误: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // 清空之前的结果
            _results.Clear();
            dgvResults.Rows.Clear();
            txtDifferences.Clear();
            txtStatistics.Clear();

            // 设置UI状态
            SetUIState(false);
            _cancellationTokenSource = new CancellationTokenSource();

            var callCount = (int)numCallCount.Value;
            var timeout = TimeSpan.FromSeconds((int)numTimeout.Value);
            var delay = (int)numDelay.Value;
            var isParallel = chkParallel.Checked;
            var method = cboMethod.SelectedItem?.ToString() ?? "GET";
            var url = txtUrl.Text.Trim();
            var body = txtBody.Text;

            progressBar.Maximum = callCount;
            progressBar.Value = 0;

            try
            {
                // 每次执行创建新的HttpClient实例，避免"已发送请求后无法修改属性"的错误
                _httpClient?.Dispose();
                _httpClient = new HttpClient { Timeout = timeout };

                if (isParallel)
                {
                    await ExecuteParallelAsync(url, method, headers, body, callCount, _cancellationTokenSource.Token);
                }
                else
                {
                    await ExecuteSequentialAsync(url, method, headers, body, callCount, delay, _cancellationTokenSource.Token);
                }

                // 分析差异
                AnalyzeDifferences();
                ShowStatistics();

                lblProgress.Text = $"完成! 共 {_results.Count} 次请求";
            }
            catch (OperationCanceledException)
            {
                lblProgress.Text = "已停止";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"执行出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblProgress.Text = "执行出错";
            }
            finally
            {
                SetUIState(true);
                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = null;
            }
        }

        private async Task ExecuteSequentialAsync(string url, string method, Dictionary<string, string>? headers,
            string body, int callCount, int delay, CancellationToken cancellationToken)
        {
            for (int i = 0; i < callCount; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var result = await ExecuteSingleRequestAsync(url, method, headers, body, i + 1, cancellationToken);
                AddResultToUI(result);

                progressBar.Value = i + 1;
                lblProgress.Text = $"进度: {i + 1}/{callCount}";

                if (i < callCount - 1 && delay > 0)
                {
                    await Task.Delay(delay, cancellationToken);
                }
            }
        }

        private async Task ExecuteParallelAsync(string url, string method, Dictionary<string, string>? headers,
            string body, int callCount, CancellationToken cancellationToken)
        {
            var tasks = new List<Task<ApiTestResult>>();
            var semaphore = new SemaphoreSlim(10); // 限制并发数

            for (int i = 0; i < callCount; i++)
            {
                var index = i + 1;
                tasks.Add(Task.Run(async () =>
                {
                    await semaphore.WaitAsync(cancellationToken);
                    try
                    {
                        return await ExecuteSingleRequestAsync(url, method, headers, body, index, cancellationToken);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }, cancellationToken));
            }

            var completedCount = 0;
            foreach (var task in tasks)
            {
                var result = await task;
                AddResultToUI(result);
                completedCount++;
                progressBar.Value = completedCount;
                lblProgress.Text = $"进度: {completedCount}/{callCount}";
            }
        }

        private async Task<ApiTestResult> ExecuteSingleRequestAsync(string url, string method,
            Dictionary<string, string>? headers, string body, int index, CancellationToken cancellationToken)
        {
            var result = new ApiTestResult { Index = index };
            var stopwatch = Stopwatch.StartNew();

            try
            {
                using var request = new HttpRequestMessage(new HttpMethod(method), url);

                // 添加Headers
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                        {
                            continue; // Content-Type 会在设置Content时自动添加
                        }
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                // 添加Body (仅对POST, PUT, PATCH)
                if (!string.IsNullOrWhiteSpace(body) &&
                    (method == "POST" || method == "PUT" || method == "PATCH"))
                {
                    var contentType = "application/json";
                    if (headers != null && headers.TryGetValue("Content-Type", out var ct))
                    {
                        contentType = ct;
                    }
                    request.Content = new StringContent(body, Encoding.UTF8, contentType);
                }

                using var response = await _httpClient!.SendAsync(request, cancellationToken);

                stopwatch.Stop();

                result.StatusCode = (int)response.StatusCode;
                result.ResponseBody = await response.Content.ReadAsStringAsync(cancellationToken);
                result.Duration = stopwatch.ElapsedMilliseconds;
                result.ResponseSize = result.ResponseBody.Length;
                result.ResponseHash = ComputeHash(result.ResponseBody);
                result.IsSuccess = true;

                // 尝试格式化JSON
                try
                {
                    var json = JToken.Parse(result.ResponseBody);
                    result.FormattedResponse = json.ToString(Formatting.Indented);
                }
                catch
                {
                    result.FormattedResponse = result.ResponseBody;
                }
            }
            catch (TaskCanceledException)
            {
                stopwatch.Stop();
                result.StatusCode = 0;
                result.ResponseBody = "请求超时";
                result.Duration = stopwatch.ElapsedMilliseconds;
                result.IsSuccess = false;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                result.StatusCode = 0;
                result.ResponseBody = $"错误: {ex.Message}";
                result.Duration = stopwatch.ElapsedMilliseconds;
                result.IsSuccess = false;
            }

            return result;
        }

        private void AddResultToUI(ApiTestResult result)
        {
            if (InvokeRequired)
            {
                Invoke(() => AddResultToUI(result));
                return;
            }

            _results.Add(result);

            var row = dgvResults.Rows.Add();
            dgvResults.Rows[row].Cells["Index"].Value = result.Index;
            dgvResults.Rows[row].Cells["StatusCode"].Value = result.StatusCode;
            dgvResults.Rows[row].Cells["Duration"].Value = result.Duration;
            dgvResults.Rows[row].Cells["ResponseSize"].Value = FormatSize(result.ResponseSize);
            dgvResults.Rows[row].Cells["ResponseHash"].Value = result.ResponseHash?[..Math.Min(12, result.ResponseHash?.Length ?? 0)];
            dgvResults.Rows[row].Cells["IsDifferent"].Value = "";
            dgvResults.Rows[row].Cells["ResponseBody"].Value = TruncateString(result.ResponseBody, 200);

            // 根据状态码设置行颜色
            if (result.StatusCode >= 200 && result.StatusCode < 300)
            {
                dgvResults.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(166, 227, 161); // 绿色
            }
            else if (result.StatusCode >= 400)
            {
                dgvResults.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(243, 139, 168); // 红色
            }
            else if (result.StatusCode == 0)
            {
                dgvResults.Rows[row].DefaultCellStyle.ForeColor = Color.FromArgb(249, 226, 175); // 黄色
            }

            dgvResults.FirstDisplayedScrollingRowIndex = dgvResults.Rows.Count - 1;
        }

        #endregion

        #region 差异分析

        private void AnalyzeDifferences()
        {
            if (_results.Count < 2) return;

            var compareFields = GetCompareFields();
            var useFieldComparison = chkCompareFieldsOnly.Checked && compareFields.Count > 0;

            // 根据是否使用字段对比来计算Hash
            List<IGrouping<string?, ApiTestResult>> groups;

            if (useFieldComparison)
            {
                // 只对比指定字段
                foreach (var result in _results)
                {
                    var fieldContent = ExtractFieldsForComparison(result.ResponseBody ?? "", compareFields);
                    result.CompareHash = ComputeHash(fieldContent);
                }
                groups = _results.GroupBy(r => r.CompareHash).ToList();
            }
            else
            {
                // 对比完整响应
                groups = _results.GroupBy(r => r.ResponseHash).ToList();
            }

            // 标记差异行
            if (groups.Count > 1)
            {
                var mainHash = groups.OrderByDescending(g => g.Count()).First().Key;

                foreach (DataGridViewRow row in dgvResults.Rows)
                {
                    var index = (int)row.Cells["Index"].Value;
                    var result = _results.FirstOrDefault(r => r.Index == index);
                    if (result != null)
                    {
                        var hashToCompare = useFieldComparison ? result.CompareHash : result.ResponseHash;
                        if (hashToCompare != mainHash)
                        {
                            row.Cells["IsDifferent"].Value = "⚠️";
                            row.DefaultCellStyle.BackColor = Color.FromArgb(49, 50, 68);
                            result.IsDifferent = true;
                        }
                    }
                }
            }

            // 生成差异报告
            GenerateDifferenceReport(groups, compareFields, useFieldComparison);
        }

        private void GenerateDifferenceReport(List<IGrouping<string?, ApiTestResult>> groups, List<string> compareFields, bool useFieldComparison)
        {
            txtDifferences.Clear();

            // 显示对比模式
            if (useFieldComparison && compareFields.Count > 0)
            {
                AppendColoredText(txtDifferences, "🎯 对比模式: 仅对比指定字段\n", Color.FromArgb(245, 194, 231));
                AppendColoredText(txtDifferences, "对比字段:\n", Color.FromArgb(166, 173, 200));
                foreach (var field in compareFields)
                {
                    AppendColoredText(txtDifferences, $"  • {field}\n", Color.FromArgb(137, 180, 250));
                }
                AppendColoredText(txtDifferences, "\n", Color.White);
            }
            else
            {
                AppendColoredText(txtDifferences, "🔍 对比模式: 完整响应对比\n\n", Color.FromArgb(166, 173, 200));
            }

            if (groups.Count == 1)
            {
                AppendColoredText(txtDifferences, "✅ 所有响应完全一致!\n\n", Color.FromArgb(166, 227, 161));
                AppendColoredText(txtDifferences, $"共 {_results.Count} 次请求，响应Hash: {groups[0].Key}\n", Color.FromArgb(205, 214, 244));

                // 如果使用字段对比，显示提取的字段值
                if (useFieldComparison && compareFields.Count > 0)
                {
                    var sample = groups[0].First();
                    var extractedJson = ExtractFieldsAsJson(sample.ResponseBody ?? "", compareFields);
                    if (extractedJson != null)
                    {
                        AppendColoredText(txtDifferences, "\n提取的字段值:\n", Color.FromArgb(166, 227, 161));
                        AppendColoredText(txtDifferences, extractedJson.ToString(Formatting.Indented) + "\n", Color.FromArgb(205, 214, 244));
                    }
                }
                return;
            }

            AppendColoredText(txtDifferences, $"⚠️ 发现 {groups.Count} 种不同的响应!\n\n", Color.FromArgb(249, 226, 175));

            int groupIndex = 1;
            foreach (var group in groups.OrderByDescending(g => g.Count()))
            {
                var percentage = (double)group.Count() / _results.Count * 100;
                AppendColoredText(txtDifferences, $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n", Color.FromArgb(69, 71, 90));
                AppendColoredText(txtDifferences, $"📦 响应组 {groupIndex} ", Color.FromArgb(137, 180, 250));
                AppendColoredText(txtDifferences, $"(出现 {group.Count()} 次, {percentage:F1}%)\n", Color.FromArgb(203, 166, 247));
                AppendColoredText(txtDifferences, $"Hash: {group.Key}\n", Color.FromArgb(166, 173, 200));
                AppendColoredText(txtDifferences, $"请求序号: {string.Join(", ", group.Select(r => r.Index))}\n\n", Color.FromArgb(166, 173, 200));

                var sample = group.First();

                // 如果使用字段对比，显示提取的字段值
                if (useFieldComparison && compareFields.Count > 0)
                {
                    var extractedJson = ExtractFieldsAsJson(sample.ResponseBody ?? "", compareFields);
                    if (extractedJson != null)
                    {
                        AppendColoredText(txtDifferences, "提取的字段值:\n", Color.FromArgb(166, 227, 161));
                        AppendColoredText(txtDifferences, extractedJson.ToString(Formatting.Indented) + "\n\n", Color.FromArgb(205, 214, 244));
                    }
                }
                else
                {
                    AppendColoredText(txtDifferences, "响应内容:\n", Color.FromArgb(166, 227, 161));
                    AppendColoredText(txtDifferences, $"{sample.FormattedResponse}\n\n", Color.FromArgb(205, 214, 244));
                }

                groupIndex++;
            }

            // 详细对比
            if (groups.Count == 2)
            {
                AppendColoredText(txtDifferences, "\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n", Color.FromArgb(69, 71, 90));
                AppendColoredText(txtDifferences, "🔍 详细差异对比:\n\n", Color.FromArgb(249, 226, 175));

                if (useFieldComparison && compareFields.Count > 0)
                {
                    // 对比提取的字段
                    var json1 = ExtractFieldsAsJson(groups[0].First().ResponseBody ?? "", compareFields);
                    var json2 = ExtractFieldsAsJson(groups[1].First().ResponseBody ?? "", compareFields);

                    if (json1 != null && json2 != null)
                    {
                        foreach (var field in compareFields)
                        {
                            var val1 = json1[field];
                            var val2 = json2[field];

                            if (!JToken.DeepEquals(val1, val2))
                            {
                                AppendColoredText(txtDifferences, $"字段 [{field}]:\n", Color.FromArgb(166, 173, 200));
                                AppendColoredText(txtDifferences, $"  组1: {val1}\n", Color.FromArgb(243, 139, 168));
                                AppendColoredText(txtDifferences, $"  组2: {val2}\n\n", Color.FromArgb(166, 227, 161));
                            }
                        }
                    }
                }
                else
                {
                    var response1 = groups[0].First().FormattedResponse ?? "";
                    var response2 = groups[1].First().FormattedResponse ?? "";

                    try
                    {
                        var json1 = JToken.Parse(response1);
                        var json2 = JToken.Parse(response2);
                        CompareJson(json1, json2, "");
                    }
                    catch
                    {
                        // 非JSON，进行文本对比
                        var lines1 = response1.Split('\n');
                        var lines2 = response2.Split('\n');

                        for (int i = 0; i < Math.Max(lines1.Length, lines2.Length); i++)
                        {
                            var line1 = i < lines1.Length ? lines1[i] : "";
                            var line2 = i < lines2.Length ? lines2[i] : "";

                            if (line1 != line2)
                            {
                                AppendColoredText(txtDifferences, $"行 {i + 1}:\n", Color.FromArgb(166, 173, 200));
                                AppendColoredText(txtDifferences, $"  - {line1}\n", Color.FromArgb(243, 139, 168));
                                AppendColoredText(txtDifferences, $"  + {line2}\n", Color.FromArgb(166, 227, 161));
                            }
                        }
                    }
                }
            }
        }

        private void CompareJson(JToken token1, JToken token2, string path)
        {
            if (token1.Type != token2.Type)
            {
                AppendColoredText(txtDifferences, $"类型不同 @ {path}:\n", Color.FromArgb(166, 173, 200));
                AppendColoredText(txtDifferences, $"  组1: {token1.Type} = {token1}\n", Color.FromArgb(243, 139, 168));
                AppendColoredText(txtDifferences, $"  组2: {token2.Type} = {token2}\n", Color.FromArgb(166, 227, 161));
                return;
            }

            switch (token1.Type)
            {
                case JTokenType.Object:
                    var obj1 = (JObject)token1;
                    var obj2 = (JObject)token2;
                    var allKeys = obj1.Properties().Select(p => p.Name)
                        .Union(obj2.Properties().Select(p => p.Name));

                    foreach (var key in allKeys)
                    {
                        var newPath = string.IsNullOrEmpty(path) ? key : $"{path}.{key}";
                        var prop1 = obj1[key];
                        var prop2 = obj2[key];

                        if (prop1 == null)
                        {
                            AppendColoredText(txtDifferences, $"新增属性 @ {newPath}:\n", Color.FromArgb(166, 173, 200));
                            AppendColoredText(txtDifferences, $"  + {prop2}\n", Color.FromArgb(166, 227, 161));
                        }
                        else if (prop2 == null)
                        {
                            AppendColoredText(txtDifferences, $"删除属性 @ {newPath}:\n", Color.FromArgb(166, 173, 200));
                            AppendColoredText(txtDifferences, $"  - {prop1}\n", Color.FromArgb(243, 139, 168));
                        }
                        else
                        {
                            CompareJson(prop1, prop2, newPath);
                        }
                    }
                    break;

                case JTokenType.Array:
                    var arr1 = (JArray)token1;
                    var arr2 = (JArray)token2;

                    if (arr1.Count != arr2.Count)
                    {
                        AppendColoredText(txtDifferences, $"数组长度不同 @ {path}:\n", Color.FromArgb(166, 173, 200));
                        AppendColoredText(txtDifferences, $"  组1: {arr1.Count} 个元素\n", Color.FromArgb(243, 139, 168));
                        AppendColoredText(txtDifferences, $"  组2: {arr2.Count} 个元素\n", Color.FromArgb(166, 227, 161));
                    }

                    for (int i = 0; i < Math.Min(arr1.Count, arr2.Count); i++)
                    {
                        CompareJson(arr1[i], arr2[i], $"{path}[{i}]");
                    }
                    break;

                default:
                    if (!JToken.DeepEquals(token1, token2))
                    {
                        AppendColoredText(txtDifferences, $"值不同 @ {path}:\n", Color.FromArgb(166, 173, 200));
                        AppendColoredText(txtDifferences, $"  组1: {token1}\n", Color.FromArgb(243, 139, 168));
                        AppendColoredText(txtDifferences, $"  组2: {token2}\n", Color.FromArgb(166, 227, 161));
                    }
                    break;
            }
        }

        #endregion

        #region 统计信息

        private void ShowStatistics()
        {
            txtStatistics.Clear();

            var successCount = _results.Count(r => r.IsSuccess);
            var failCount = _results.Count - successCount;
            var avgDuration = _results.Average(r => r.Duration);
            var minDuration = _results.Min(r => r.Duration);
            var maxDuration = _results.Max(r => r.Duration);
            var totalSize = _results.Sum(r => r.ResponseSize);

            AppendColoredText(txtStatistics, "📊 测试统计报告\n", Color.FromArgb(137, 180, 250));
            AppendColoredText(txtStatistics, "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n", Color.FromArgb(69, 71, 90));

            AppendColoredText(txtStatistics, "📈 请求统计\n", Color.FromArgb(166, 227, 161));
            AppendColoredText(txtStatistics, $"  总请求数: {_results.Count}\n", Color.FromArgb(205, 214, 244));
            AppendColoredText(txtStatistics, $"  成功请求: {successCount} ", Color.FromArgb(166, 227, 161));
            AppendColoredText(txtStatistics, $"({(double)successCount / _results.Count * 100:F1}%)\n", Color.FromArgb(166, 173, 200));
            AppendColoredText(txtStatistics, $"  失败请求: {failCount} ", Color.FromArgb(243, 139, 168));
            AppendColoredText(txtStatistics, $"({(double)failCount / _results.Count * 100:F1}%)\n\n", Color.FromArgb(166, 173, 200));

            AppendColoredText(txtStatistics, "⏱️ 响应时间\n", Color.FromArgb(249, 226, 175));
            AppendColoredText(txtStatistics, $"  平均耗时: {avgDuration:F2} ms\n", Color.FromArgb(205, 214, 244));
            AppendColoredText(txtStatistics, $"  最小耗时: {minDuration} ms\n", Color.FromArgb(166, 227, 161));
            AppendColoredText(txtStatistics, $"  最大耗时: {maxDuration} ms\n", Color.FromArgb(243, 139, 168));

            // 计算百分位数
            var sortedDurations = _results.Select(r => r.Duration).OrderBy(d => d).ToList();
            var p50 = GetPercentile(sortedDurations, 50);
            var p90 = GetPercentile(sortedDurations, 90);
            var p95 = GetPercentile(sortedDurations, 95);
            var p99 = GetPercentile(sortedDurations, 99);

            AppendColoredText(txtStatistics, $"  P50: {p50:F2} ms\n", Color.FromArgb(205, 214, 244));
            AppendColoredText(txtStatistics, $"  P90: {p90:F2} ms\n", Color.FromArgb(205, 214, 244));
            AppendColoredText(txtStatistics, $"  P95: {p95:F2} ms\n", Color.FromArgb(205, 214, 244));
            AppendColoredText(txtStatistics, $"  P99: {p99:F2} ms\n\n", Color.FromArgb(205, 214, 244));

            AppendColoredText(txtStatistics, "📦 响应数据\n", Color.FromArgb(203, 166, 247));
            AppendColoredText(txtStatistics, $"  总数据量: {FormatSize(totalSize)}\n", Color.FromArgb(205, 214, 244));
            AppendColoredText(txtStatistics, $"  平均大小: {FormatSize((int)(_results.Average(r => r.ResponseSize)))}\n\n", Color.FromArgb(205, 214, 244));

            // 状态码分布
            var statusGroups = _results.GroupBy(r => r.StatusCode).OrderBy(g => g.Key);
            AppendColoredText(txtStatistics, "🔢 状态码分布\n", Color.FromArgb(137, 180, 250));
            foreach (var group in statusGroups)
            {
                var color = group.Key >= 200 && group.Key < 300
                    ? Color.FromArgb(166, 227, 161)
                    : group.Key >= 400
                        ? Color.FromArgb(243, 139, 168)
                        : Color.FromArgb(249, 226, 175);

                AppendColoredText(txtStatistics, $"  {group.Key}: {group.Count()} 次 ", color);
                AppendColoredText(txtStatistics, $"({(double)group.Count() / _results.Count * 100:F1}%)\n", Color.FromArgb(166, 173, 200));
            }

            // 响应一致性
            var compareFields = GetCompareFields();
            var useFieldComparison = chkCompareFieldsOnly.Checked && compareFields.Count > 0;

            int uniqueResponses;
            if (useFieldComparison)
            {
                uniqueResponses = _results.Select(r => r.CompareHash).Distinct().Count();
            }
            else
            {
                uniqueResponses = _results.Select(r => r.ResponseHash).Distinct().Count();
            }

            AppendColoredText(txtStatistics, $"\n🔍 响应一致性", Color.FromArgb(249, 226, 175));
            if (useFieldComparison)
            {
                AppendColoredText(txtStatistics, " (仅对比指定字段)\n", Color.FromArgb(245, 194, 231));
            }
            else
            {
                AppendColoredText(txtStatistics, "\n", Color.FromArgb(249, 226, 175));
            }
            AppendColoredText(txtStatistics, $"  不同响应数: {uniqueResponses}\n", Color.FromArgb(205, 214, 244));

            if (uniqueResponses == 1)
            {
                AppendColoredText(txtStatistics, "  ✅ 所有响应完全一致\n", Color.FromArgb(166, 227, 161));
            }
            else
            {
                AppendColoredText(txtStatistics, $"  ⚠️ 存在 {uniqueResponses} 种不同的响应\n", Color.FromArgb(249, 226, 175));
            }
        }

        private double GetPercentile(List<long> sortedData, int percentile)
        {
            if (sortedData.Count == 0) return 0;
            var index = (int)Math.Ceiling(percentile / 100.0 * sortedData.Count) - 1;
            return sortedData[Math.Max(0, Math.Min(index, sortedData.Count - 1))];
        }

        #endregion

        #region UI辅助方法

        private void AppendColoredText(RichTextBox rtb, string text, Color color)
        {
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;
            rtb.SelectionColor = color;
            rtb.AppendText(text);
            rtb.SelectionColor = rtb.ForeColor;
        }

        private void BtnStop_Click(object? sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
        }

        private void BtnTextToJson_Click(object? sender, EventArgs e)
        {
            using var dialog = new TextToJsonDialog();
            if (dialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dialog.ResultJson))
            {
                // 尝试将结果插入到Body中
                try
                {
                    if (string.IsNullOrWhiteSpace(txtBody.Text) || txtBody.Text.Trim() == "{\r\n  \"key\": \"value\"\r\n}")
                    {
                        // Body为空或默认值，直接创建新JSON
                        var newBody = new JObject
                        {
                            [dialog.FieldName] = dialog.ResultJson
                        };
                        txtBody.Text = newBody.ToString(Formatting.Indented);
                    }
                    else
                    {
                        // 尝试解析现有Body并添加字段
                        var existingBody = JObject.Parse(txtBody.Text);
                        existingBody[dialog.FieldName] = dialog.ResultJson;
                        txtBody.Text = existingBody.ToString(Formatting.Indented);
                    }
                }
                catch
                {
                    // 解析失败，显示结果让用户手动复制
                    MessageBox.Show($"字段名: {dialog.FieldName}\n\n转换后的值已复制到剪贴板:\n{dialog.ResultJson}",
                        "转换结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clipboard.SetText($"\"{dialog.FieldName}\": \"{dialog.ResultJson}\"");
                }
            }
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            _results.Clear();
            dgvResults.Rows.Clear();
            txtDifferences.Clear();
            txtStatistics.Clear();
            progressBar.Value = 0;
            lblProgress.Text = "就绪";
        }

        private void DgvResults_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var index = (int)dgvResults.Rows[e.RowIndex].Cells["Index"].Value;
            var result = _results.FirstOrDefault(r => r.Index == index);

            if (result != null)
            {
                using var detailForm = new Form
                {
                    Text = $"响应详情 - 请求 #{result.Index}",
                    Size = new Size(800, 600),
                    StartPosition = FormStartPosition.CenterParent,
                    BackColor = Color.FromArgb(30, 30, 46)
                };

                var txtDetail = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(30, 30, 46),
                    ForeColor = Color.FromArgb(205, 214, 244),
                    Font = new Font("Cascadia Code", 10F),
                    BorderStyle = BorderStyle.None,
                    ReadOnly = true,
                    Text = $"请求序号: {result.Index}\n" +
                           $"状态码: {result.StatusCode}\n" +
                           $"耗时: {result.Duration} ms\n" +
                           $"响应大小: {FormatSize(result.ResponseSize)}\n" +
                           $"响应Hash: {result.ResponseHash}\n" +
                           $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n\n" +
                           $"{result.FormattedResponse}"
                };

                detailForm.Controls.Add(txtDetail);
                detailForm.ShowDialog();
            }
        }

        private void SetUIState(bool enabled)
        {
            txtUrl.Enabled = enabled;
            cboMethod.Enabled = enabled;
            txtHeaders.Enabled = enabled;
            txtBody.Enabled = enabled;
            txtCompareFields.Enabled = enabled;
            chkCompareFieldsOnly.Enabled = enabled;
            numCallCount.Enabled = enabled;
            numTimeout.Enabled = enabled;
            numDelay.Enabled = enabled;
            chkParallel.Enabled = enabled;
            btnExecute.Enabled = enabled;
            btnStop.Enabled = !enabled;
            btnSaveRequest.Enabled = enabled;
            btnDeleteRequest.Enabled = enabled;
            btnExportRequests.Enabled = enabled;
            btnImportRequests.Enabled = enabled;
            lstSavedRequests.Enabled = enabled;
        }

        private static string ComputeHash(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = md5.ComputeHash(bytes);
            return Convert.ToHexString(hash);
        }

        private static string FormatSize(int bytes)
        {
            if (bytes < 1024) return $"{bytes} B";
            if (bytes < 1024 * 1024) return $"{bytes / 1024.0:F1} KB";
            return $"{bytes / 1024.0 / 1024.0:F2} MB";
        }

        private static string TruncateString(string? str, int maxLength)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return str.Length <= maxLength ? str : str[..maxLength] + "...";
        }

        #endregion
    }
}
