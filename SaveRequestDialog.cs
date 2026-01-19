namespace APITestTool
{
    /// <summary>
    /// 保存请求对话框
    /// 用于输入请求名称
    /// </summary>
    public partial class SaveRequestDialog : Form
    {
        // 所有控件声明都在 SaveRequestDialog.Designer.cs 中

        public string RequestName => txtName.Text.Trim();

        public SaveRequestDialog()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void SetupEventHandlers()
        {
            btnOk.Click += BtnOk_Click;
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入请求名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
            }
        }
    }
}

