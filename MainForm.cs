namespace APITestTool
{
    /// <summary>
    /// 主导航窗体
    /// </summary>
    public partial class MainForm : Form
    {
        // 颜色主题 (Catppuccin Mocha)
        private static readonly Color BgDark = Color.FromArgb(24, 24, 37);
        private static readonly Color BgMedium = Color.FromArgb(30, 30, 46);
        private static readonly Color BgLight = Color.FromArgb(49, 50, 68);
        private static readonly Color TextPrimary = Color.FromArgb(205, 214, 244);
        private static readonly Color TextSecondary = Color.FromArgb(166, 173, 200);
        private static readonly Color AccentBlue = Color.FromArgb(137, 180, 250);
        private static readonly Color AccentPurple = Color.FromArgb(203, 166, 247);

        public MainForm()
        {
            InitializeComponent();
            SetupCardHoverEffects();
        }

        private void SetupCardHoverEffects()
        {
            // API Stability Test 卡片悬停效果
            panelCardApiTest.MouseEnter += (s, e) => panelCardApiTest.BackColor = BgLight;
            panelCardApiTest.MouseLeave += (s, e) => panelCardApiTest.BackColor = BgMedium;
            foreach (Control ctrl in panelCardApiTest.Controls)
            {
                ctrl.MouseEnter += (s, e) => panelCardApiTest.BackColor = BgLight;
                ctrl.MouseLeave += (s, e) => panelCardApiTest.BackColor = BgMedium;
            }

            // AI Playground 卡片悬停效果
            panelCardPromptTest.MouseEnter += (s, e) => panelCardPromptTest.BackColor = BgLight;
            panelCardPromptTest.MouseLeave += (s, e) => panelCardPromptTest.BackColor = BgMedium;
            foreach (Control ctrl in panelCardPromptTest.Controls)
            {
                ctrl.MouseEnter += (s, e) => panelCardPromptTest.BackColor = BgLight;
                ctrl.MouseLeave += (s, e) => panelCardPromptTest.BackColor = BgMedium;
            }
        }

        private void MainForm_Resize(object? sender, EventArgs e)
        {
            // 重新计算卡片位置以居中显示
            var totalWidth = 380 * 2 + 20; // 两个卡片 + 间距
            var startX = (panelContent.ClientSize.Width - totalWidth) / 2;
            startX = Math.Max(40, startX);

            panelCardApiTest.Location = new Point(startX, panelCardApiTest.Location.Y);
            panelCardPromptTest.Location = new Point(startX + 400, panelCardPromptTest.Location.Y);
        }

        private void BtnApiTest_Click(object? sender, EventArgs e)
        {
            var apiTestForm = new ApiTestForm();
            apiTestForm.Show();
        }

        private void BtnPromptTest_Click(object? sender, EventArgs e)
        {
            var promptTestForm = new PromptTestForm();
            promptTestForm.Show();
        }
    }
}
