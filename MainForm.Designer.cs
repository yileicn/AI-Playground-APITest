namespace APITestTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            panelContent = new Panel();
            lblVersion = new Label();
            lblInfo = new Label();
            panelCardPromptTest = new Panel();
            btnPromptTest = new Button();
            lblCardPromptTestDesc = new Label();
            lblCardPromptTestTitle = new Label();
            panelCardPromptTestTopBar = new Panel();
            panelCardApiTest = new Panel();
            btnApiTest = new Button();
            lblCardApiTestDesc = new Label();
            lblCardApiTestTitle = new Label();
            panelCardApiTestTopBar = new Panel();
            panelHeader.SuspendLayout();
            panelContent.SuspendLayout();
            panelCardPromptTest.SuspendLayout();
            panelCardApiTest.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(30, 30, 46);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(40, 30, 40, 20);
            panelHeader.Size = new Size(900, 150);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Cascadia Code", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(205, 214, 244);
            lblTitle.Location = new Point(40, 35);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(360, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🚀 AI Test Tool";
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.FromArgb(24, 24, 37);
            panelContent.Controls.Add(lblVersion);
            panelContent.Controls.Add(lblInfo);
            panelContent.Controls.Add(panelCardPromptTest);
            panelContent.Controls.Add(panelCardApiTest);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Location = new Point(0, 150);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(40);
            panelContent.Size = new Size(900, 450);
            panelContent.TabIndex = 1;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Cascadia Code", 9F);
            lblVersion.ForeColor = Color.FromArgb(88, 91, 112);
            lblVersion.Location = new Point(600, 380);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(301, 16);
            lblVersion.TabIndex = 3;
            lblVersion.Text = "v1.0.0 | .NET 8.0 | Catppuccin Mocha Theme";
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Cascadia Code", 10F);
            lblInfo.ForeColor = Color.FromArgb(166, 173, 200);
            lblInfo.Location = new Point(40, 300);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(242, 18);
            lblInfo.TabIndex = 2;
            lblInfo.Text = "💡 提示: 选择一个工具开始使用";
            // 
            // panelCardPromptTest
            // 
            panelCardPromptTest.BackColor = Color.FromArgb(30, 30, 46);
            panelCardPromptTest.Controls.Add(btnPromptTest);
            panelCardPromptTest.Controls.Add(lblCardPromptTestDesc);
            panelCardPromptTest.Controls.Add(lblCardPromptTestTitle);
            panelCardPromptTest.Controls.Add(panelCardPromptTestTopBar);
            panelCardPromptTest.Cursor = Cursors.Hand;
            panelCardPromptTest.Location = new Point(440, 40);
            panelCardPromptTest.Name = "panelCardPromptTest";
            panelCardPromptTest.Size = new Size(380, 220);
            panelCardPromptTest.TabIndex = 1;
            // 
            // btnPromptTest
            // 
            btnPromptTest.BackColor = Color.FromArgb(203, 166, 247);
            btnPromptTest.Cursor = Cursors.Hand;
            btnPromptTest.FlatAppearance.BorderSize = 0;
            btnPromptTest.FlatStyle = FlatStyle.Flat;
            btnPromptTest.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnPromptTest.ForeColor = Color.FromArgb(24, 24, 37);
            btnPromptTest.Location = new Point(260, 165);
            btnPromptTest.Name = "btnPromptTest";
            btnPromptTest.Size = new Size(100, 35);
            btnPromptTest.TabIndex = 3;
            btnPromptTest.Text = "打开";
            btnPromptTest.UseVisualStyleBackColor = false;
            btnPromptTest.Click += BtnPromptTest_Click;
            // 
            // lblCardPromptTestDesc
            // 
            lblCardPromptTestDesc.Font = new Font("Cascadia Code", 10F);
            lblCardPromptTestDesc.ForeColor = Color.FromArgb(166, 173, 200);
            lblCardPromptTestDesc.Location = new Point(20, 65);
            lblCardPromptTestDesc.Name = "lblCardPromptTestDesc";
            lblCardPromptTestDesc.Size = new Size(340, 100);
            lblCardPromptTestDesc.TabIndex = 2;
            lblCardPromptTestDesc.Text = "测试和优化 OpenAI Prompt\r\n支持变量模板、参数调节\r\n实时对话测试、Token 统计";
            // 
            // lblCardPromptTestTitle
            // 
            lblCardPromptTestTitle.AutoSize = true;
            lblCardPromptTestTitle.Font = new Font("Cascadia Code", 16F, FontStyle.Bold);
            lblCardPromptTestTitle.ForeColor = Color.FromArgb(203, 166, 247);
            lblCardPromptTestTitle.Location = new Point(20, 25);
            lblCardPromptTestTitle.Name = "lblCardPromptTestTitle";
            lblCardPromptTestTitle.Size = new Size(225, 29);
            lblCardPromptTestTitle.TabIndex = 1;
            lblCardPromptTestTitle.Text = "🤖 AI Playground";
            // 
            // panelCardPromptTestTopBar
            // 
            panelCardPromptTestTopBar.BackColor = Color.FromArgb(203, 166, 247);
            panelCardPromptTestTopBar.Dock = DockStyle.Top;
            panelCardPromptTestTopBar.Location = new Point(0, 0);
            panelCardPromptTestTopBar.Name = "panelCardPromptTestTopBar";
            panelCardPromptTestTopBar.Size = new Size(380, 4);
            panelCardPromptTestTopBar.TabIndex = 0;
            // 
            // panelCardApiTest
            // 
            panelCardApiTest.BackColor = Color.FromArgb(30, 30, 46);
            panelCardApiTest.Controls.Add(btnApiTest);
            panelCardApiTest.Controls.Add(lblCardApiTestDesc);
            panelCardApiTest.Controls.Add(lblCardApiTestTitle);
            panelCardApiTest.Controls.Add(panelCardApiTestTopBar);
            panelCardApiTest.Cursor = Cursors.Hand;
            panelCardApiTest.Location = new Point(40, 40);
            panelCardApiTest.Name = "panelCardApiTest";
            panelCardApiTest.Size = new Size(380, 220);
            panelCardApiTest.TabIndex = 0;
            // 
            // btnApiTest
            // 
            btnApiTest.BackColor = Color.FromArgb(137, 180, 250);
            btnApiTest.Cursor = Cursors.Hand;
            btnApiTest.FlatAppearance.BorderSize = 0;
            btnApiTest.FlatStyle = FlatStyle.Flat;
            btnApiTest.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnApiTest.ForeColor = Color.FromArgb(24, 24, 37);
            btnApiTest.Location = new Point(260, 165);
            btnApiTest.Name = "btnApiTest";
            btnApiTest.Size = new Size(100, 35);
            btnApiTest.TabIndex = 3;
            btnApiTest.Text = "打开";
            btnApiTest.UseVisualStyleBackColor = false;
            btnApiTest.Click += BtnApiTest_Click;
            // 
            // lblCardApiTestDesc
            // 
            lblCardApiTestDesc.Font = new Font("Cascadia Code", 10F);
            lblCardApiTestDesc.ForeColor = Color.FromArgb(166, 173, 200);
            lblCardApiTestDesc.Location = new Point(20, 65);
            lblCardApiTestDesc.Name = "lblCardApiTestDesc";
            lblCardApiTestDesc.Size = new Size(340, 100);
            lblCardApiTestDesc.TabIndex = 2;
            lblCardApiTestDesc.Text = "测试AI API 稳定性和一致性\r\n批量请求、自动对比响应差异\r\n性能统计与详细报告";
            // 
            // lblCardApiTestTitle
            // 
            lblCardApiTestTitle.AutoSize = true;
            lblCardApiTestTitle.Font = new Font("Cascadia Code", 16F, FontStyle.Bold);
            lblCardApiTestTitle.ForeColor = Color.FromArgb(137, 180, 250);
            lblCardApiTestTitle.Location = new Point(20, 25);
            lblCardApiTestTitle.Name = "lblCardApiTestTitle";
            lblCardApiTestTitle.Size = new Size(329, 29);
            lblCardApiTestTitle.TabIndex = 1;
            lblCardApiTestTitle.Text = "🔌 AI API Stability Test";
            // 
            // panelCardApiTestTopBar
            // 
            panelCardApiTestTopBar.BackColor = Color.FromArgb(137, 180, 250);
            panelCardApiTestTopBar.Dock = DockStyle.Top;
            panelCardApiTestTopBar.Location = new Point(0, 0);
            panelCardApiTestTopBar.Name = "panelCardApiTestTopBar";
            panelCardApiTestTopBar.Size = new Size(380, 4);
            panelCardApiTestTopBar.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 37);
            ClientSize = new Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            MinimumSize = new Size(800, 500);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🚀 AI Test Tool";
            Resize += MainForm_Resize;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelContent.ResumeLayout(false);
            panelContent.PerformLayout();
            panelCardPromptTest.ResumeLayout(false);
            panelCardPromptTest.PerformLayout();
            panelCardApiTest.ResumeLayout(false);
            panelCardApiTest.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private Panel panelContent;
        private Panel panelCardApiTest;
        private Panel panelCardApiTestTopBar;
        private Label lblCardApiTestTitle;
        private Label lblCardApiTestDesc;
        private Button btnApiTest;
        private Panel panelCardPromptTest;
        private Panel panelCardPromptTestTopBar;
        private Label lblCardPromptTestTitle;
        private Label lblCardPromptTestDesc;
        private Button btnPromptTest;
        private Label lblInfo;
        private Label lblVersion;
    }
}
