using Newtonsoft.Json;

namespace APITestTool
{
    /// <summary>
    /// 文本转JSON字段对话框
    /// 用于将长文本转换为JSON字符串格式，自动处理转义字符
    /// </summary>
    public partial class TextToJsonDialog : Form
    {
        // 所有控件声明都在 TextToJsonDialog.Designer.cs 中

        public string FieldName => txtFieldName.Text.Trim();
        public string ResultJson { get; private set; } = "";

        public TextToJsonDialog()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            txtInputText.TextChanged += (s, e) => UpdatePreview();
            btnConvert.Click += (s, e) => UpdatePreview();
            btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFieldName.Text))
            {
                MessageBox.Show("请输入字段名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            if (string.IsNullOrEmpty(txtInputText.Text))
            {
                txtPreview.Text = "";
                ResultJson = "";
                return;
            }

            // 将文本转换为JSON字符串（自动转义特殊字符）
            ResultJson = JsonConvert.SerializeObject(txtInputText.Text);
            // 移除首尾的引号，因为我们只需要内容
            if (ResultJson.StartsWith("\"") && ResultJson.EndsWith("\""))
            {
                ResultJson = ResultJson[1..^1];
            }

            txtPreview.Text = $"\"{txtFieldName.Text}\": \"{ResultJson}\"";
        }
    }
}

