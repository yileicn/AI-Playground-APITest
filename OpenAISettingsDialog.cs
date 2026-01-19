namespace APITestTool
{
    /// <summary>
    /// OpenAI 设置对话框
    /// </summary>
    public partial class OpenAISettingsDialog : Form
    {
        // 所有控件声明都在 OpenAISettingsDialog.Designer.cs 中

        public OpenAISettings Settings { get; private set; }

        public OpenAISettingsDialog(OpenAISettings currentSettings)
        {
            Settings = currentSettings;
            InitializeComponent();
            SetupEventHandlers();
            LoadInitialValues();
        }

        private void SetupEventHandlers()
        {
            btnOk.Click += BtnOk_Click;
            chkUseEnvVar.CheckedChanged += ChkUseEnvVar_CheckedChanged;
            txtEnvVarName.TextChanged += TxtEnvVarName_TextChanged;
        }

        private void TxtEnvVarName_TextChanged(object? sender, EventArgs e)
        {
            if (chkUseEnvVar.Checked)
            {
                var envVarName = txtEnvVarName.Text.Trim();
                if (!string.IsNullOrWhiteSpace(envVarName))
                {
                    var envValue = Environment.GetEnvironmentVariable(envVarName);
                    txtApiKey.Text = envValue ?? "";
                }
                else
                {
                    txtApiKey.Text = "";
                }
            }
        }

        private void LoadInitialValues()
        {
            chkUseEnvVar.Checked = Settings.UseEnvironmentVariable;
            txtEnvVarName.Text = Settings.EnvironmentVariableName;
            txtApiKey.Text = Settings.ApiKey;
            txtBaseUrl.Text = Settings.BaseUrl;
            txtOrganization.Text = Settings.Organization;
            
            // 如果使用环境变量，尝试从环境变量读取
            if (Settings.UseEnvironmentVariable && !string.IsNullOrWhiteSpace(Settings.EnvironmentVariableName))
            {
                var envValue = Environment.GetEnvironmentVariable(Settings.EnvironmentVariableName);
                if (!string.IsNullOrWhiteSpace(envValue))
                {
                    txtApiKey.Text = envValue;
                }
            }
            
            UpdateControlsVisibility();
        }

        private void ChkUseEnvVar_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateControlsVisibility();
        }

        private void UpdateControlsVisibility()
        {
            bool useEnvVar = chkUseEnvVar.Checked;
            lblEnvVarName.Visible = useEnvVar;
            txtEnvVarName.Visible = useEnvVar;
            txtApiKey.Enabled = !useEnvVar;
            
            if (useEnvVar)
            {
                // 如果启用环境变量，尝试从环境变量读取
                var envVarName = txtEnvVarName.Text.Trim();
                if (!string.IsNullOrWhiteSpace(envVarName))
                {
                    var envValue = Environment.GetEnvironmentVariable(envVarName);
                    txtApiKey.Text = envValue ?? "";
                }
            }
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            string apiKey = "";
            
            if (chkUseEnvVar.Checked)
            {
                // 使用环境变量
                var envVarName = txtEnvVarName.Text.Trim();
                if (string.IsNullOrWhiteSpace(envVarName))
                {
                    MessageBox.Show("请输入环境变量名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
                
                var envValue = Environment.GetEnvironmentVariable(envVarName);
                if (string.IsNullOrWhiteSpace(envValue))
                {
                    var result = MessageBox.Show(
                        $"环境变量 \"{envVarName}\" 未设置或为空。\n\n是否仍要保存此设置？",
                        "警告",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                    
                    if (result == DialogResult.No)
                    {
                        DialogResult = DialogResult.None;
                        return;
                    }
                }
                
                apiKey = envValue ?? "";
            }
            else
            {
                // 直接输入
                apiKey = txtApiKey.Text.Trim();
                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    MessageBox.Show("请输入 API Key", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.None;
                    return;
                }
            }
            
            Settings = new OpenAISettings
            {
                ApiKey = apiKey,
                UseEnvironmentVariable = chkUseEnvVar.Checked,
                EnvironmentVariableName = txtEnvVarName.Text.Trim(),
                BaseUrl = string.IsNullOrWhiteSpace(txtBaseUrl.Text) ? "https://api.openai.com/v1" : txtBaseUrl.Text.Trim(),
                Organization = txtOrganization.Text.Trim()
            };
        }
    }
}
