namespace APITestTool
{
    partial class PromptTestForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null!;

        // Dispose 方法在 PromptTestForm.cs 中定义以处理额外资源

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainerMain = new SplitContainer();
            panelLeft = new Panel();
            btnImportPrompts = new Button();
            btnExportPrompts = new Button();
            btnDeletePrompt = new Button();
            btnSavePrompt = new Button();
            lstSavedPrompts = new ListBox();
            lblSavedPrompts = new Label();
            txtSystemPrompt = new TextBox();
            lblSystemPrompt = new Label();
            btnManageTools = new Button();
            cboTools = new ComboBox();
            lblTools = new Label();
            dgvVariables = new DataGridView();
            btnAddVariable = new Button();
            lblVariables = new Label();
            trackTopP = new TrackBar();
            lblTopPValue = new Label();
            lblTopP = new Label();
            numMaxTokens = new NumericUpDown();
            lblMaxTokens = new Label();
            trackTemperature = new TrackBar();
            lblTemperatureValue = new Label();
            lblTemperature = new Label();
            lblParams = new Label();
            btnSettings = new Button();
            cboModel = new ComboBox();
            lblModel = new Label();
            panelRight = new Panel();
            progressBarLoading = new ProgressBar();
            lblStatus = new Label();
            panelInput = new Panel();
            lblToolResponseHint = new Label();
            chkAutoScroll = new CheckBox();
            btnClear = new Button();
            btnSend = new Button();
            txtInput = new TextBox();
            txtConversation = new RichTextBox();
            lblTokenCount = new Label();
            lblConversationTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVariables).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackTopP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackTemperature).BeginInit();
            panelRight.SuspendLayout();
            panelInput.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(0, 0);
            splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(panelLeft);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelRight);
            splitContainerMain.Size = new Size(1600, 1000);
            splitContainerMain.SplitterDistance = 550;
            splitContainerMain.SplitterWidth = 6;
            splitContainerMain.TabIndex = 0;
            // 
            // panelLeft
            // 
            panelLeft.AutoScroll = true;
            panelLeft.BackColor = Color.FromArgb(30, 30, 46);
            panelLeft.Controls.Add(btnImportPrompts);
            panelLeft.Controls.Add(btnExportPrompts);
            panelLeft.Controls.Add(btnDeletePrompt);
            panelLeft.Controls.Add(btnSavePrompt);
            panelLeft.Controls.Add(lstSavedPrompts);
            panelLeft.Controls.Add(lblSavedPrompts);
            panelLeft.Controls.Add(txtSystemPrompt);
            panelLeft.Controls.Add(lblSystemPrompt);
            panelLeft.Controls.Add(btnManageTools);
            panelLeft.Controls.Add(cboTools);
            panelLeft.Controls.Add(lblTools);
            panelLeft.Controls.Add(dgvVariables);
            panelLeft.Controls.Add(btnAddVariable);
            panelLeft.Controls.Add(lblVariables);
            panelLeft.Controls.Add(trackTopP);
            panelLeft.Controls.Add(lblTopPValue);
            panelLeft.Controls.Add(lblTopP);
            panelLeft.Controls.Add(numMaxTokens);
            panelLeft.Controls.Add(lblMaxTokens);
            panelLeft.Controls.Add(trackTemperature);
            panelLeft.Controls.Add(lblTemperatureValue);
            panelLeft.Controls.Add(lblTemperature);
            panelLeft.Controls.Add(lblParams);
            panelLeft.Controls.Add(btnSettings);
            panelLeft.Controls.Add(cboModel);
            panelLeft.Controls.Add(lblModel);
            panelLeft.Dock = DockStyle.Fill;
            panelLeft.Location = new Point(0, 0);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(20);
            panelLeft.Size = new Size(550, 1000);
            panelLeft.TabIndex = 0;
            // 
            // btnImportPrompts
            // 
            btnImportPrompts.BackColor = Color.FromArgb(249, 226, 175);
            btnImportPrompts.Cursor = Cursors.Hand;
            btnImportPrompts.FlatAppearance.BorderSize = 0;
            btnImportPrompts.FlatStyle = FlatStyle.Flat;
            btnImportPrompts.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnImportPrompts.ForeColor = Color.FromArgb(24, 24, 37);
            btnImportPrompts.Location = new Point(320, 130);
            btnImportPrompts.Name = "btnImportPrompts";
            btnImportPrompts.Size = new Size(110, 28);
            btnImportPrompts.TabIndex = 24;
            btnImportPrompts.Text = "📥 导入";
            btnImportPrompts.UseVisualStyleBackColor = false;
            btnImportPrompts.Click += BtnImportPrompts_Click;
            // 
            // btnExportPrompts
            // 
            btnExportPrompts.BackColor = Color.FromArgb(137, 180, 250);
            btnExportPrompts.Cursor = Cursors.Hand;
            btnExportPrompts.FlatAppearance.BorderSize = 0;
            btnExportPrompts.FlatStyle = FlatStyle.Flat;
            btnExportPrompts.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnExportPrompts.ForeColor = Color.FromArgb(24, 24, 37);
            btnExportPrompts.Location = new Point(220, 130);
            btnExportPrompts.Name = "btnExportPrompts";
            btnExportPrompts.Size = new Size(95, 28);
            btnExportPrompts.TabIndex = 23;
            btnExportPrompts.Text = "📤 导出";
            btnExportPrompts.UseVisualStyleBackColor = false;
            btnExportPrompts.Click += BtnExportPrompts_Click;
            // 
            // btnDeletePrompt
            // 
            btnDeletePrompt.BackColor = Color.FromArgb(243, 139, 168);
            btnDeletePrompt.Cursor = Cursors.Hand;
            btnDeletePrompt.FlatAppearance.BorderSize = 0;
            btnDeletePrompt.FlatStyle = FlatStyle.Flat;
            btnDeletePrompt.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnDeletePrompt.ForeColor = Color.FromArgb(24, 24, 37);
            btnDeletePrompt.Location = new Point(120, 130);
            btnDeletePrompt.Name = "btnDeletePrompt";
            btnDeletePrompt.Size = new Size(95, 28);
            btnDeletePrompt.TabIndex = 22;
            btnDeletePrompt.Text = "🗑️ 删除";
            btnDeletePrompt.UseVisualStyleBackColor = false;
            btnDeletePrompt.Click += BtnDeletePrompt_Click;
            // 
            // btnSavePrompt
            // 
            btnSavePrompt.BackColor = Color.FromArgb(166, 227, 161);
            btnSavePrompt.Cursor = Cursors.Hand;
            btnSavePrompt.FlatAppearance.BorderSize = 0;
            btnSavePrompt.FlatStyle = FlatStyle.Flat;
            btnSavePrompt.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnSavePrompt.ForeColor = Color.FromArgb(24, 24, 37);
            btnSavePrompt.Location = new Point(20, 130);
            btnSavePrompt.Name = "btnSavePrompt";
            btnSavePrompt.Size = new Size(95, 28);
            btnSavePrompt.TabIndex = 21;
            btnSavePrompt.Text = "💾 保存";
            btnSavePrompt.UseVisualStyleBackColor = false;
            btnSavePrompt.Click += BtnSavePrompt_Click;
            // 
            // lstSavedPrompts
            // 
            lstSavedPrompts.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSavedPrompts.BackColor = Color.FromArgb(49, 50, 68);
            lstSavedPrompts.BorderStyle = BorderStyle.None;
            lstSavedPrompts.Font = new Font("Cascadia Code", 9F);
            lstSavedPrompts.ForeColor = Color.FromArgb(205, 214, 244);
            lstSavedPrompts.FormattingEnabled = true;
            lstSavedPrompts.Location = new Point(20, 40);
            lstSavedPrompts.Name = "lstSavedPrompts";
            lstSavedPrompts.Size = new Size(510, 80);
            lstSavedPrompts.TabIndex = 20;
            lstSavedPrompts.DoubleClick += LstSavedPrompts_DoubleClick;
            // 
            // lblSavedPrompts
            // 
            lblSavedPrompts.AutoSize = true;
            lblSavedPrompts.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblSavedPrompts.ForeColor = Color.FromArgb(203, 166, 247);
            lblSavedPrompts.Location = new Point(20, 15);
            lblSavedPrompts.Name = "lblSavedPrompts";
            lblSavedPrompts.Size = new Size(159, 18);
            lblSavedPrompts.TabIndex = 19;
            lblSavedPrompts.Text = "📁 已保存的 Prompt";
            // 
            // txtSystemPrompt
            // 
            txtSystemPrompt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSystemPrompt.BackColor = Color.FromArgb(49, 50, 68);
            txtSystemPrompt.BorderStyle = BorderStyle.FixedSingle;
            txtSystemPrompt.Font = new Font("Cascadia Code", 9F);
            txtSystemPrompt.ForeColor = Color.FromArgb(205, 214, 244);
            txtSystemPrompt.Location = new Point(20, 608);
            txtSystemPrompt.Multiline = true;
            txtSystemPrompt.Name = "txtSystemPrompt";
            txtSystemPrompt.ScrollBars = ScrollBars.Vertical;
            txtSystemPrompt.Size = new Size(510, 366);
            txtSystemPrompt.TabIndex = 16;
            // 
            // lblSystemPrompt
            // 
            lblSystemPrompt.AutoSize = true;
            lblSystemPrompt.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblSystemPrompt.ForeColor = Color.FromArgb(137, 180, 250);
            lblSystemPrompt.Location = new Point(20, 576);
            lblSystemPrompt.Name = "lblSystemPrompt";
            lblSystemPrompt.Size = new Size(248, 18);
            lblSystemPrompt.TabIndex = 15;
            lblSystemPrompt.Text = "🎯 System Prompt (支持 {{变量名}} 模板)";
            // 
            // btnManageTools
            // 
            btnManageTools.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnManageTools.BackColor = Color.FromArgb(148, 226, 213);
            btnManageTools.Cursor = Cursors.Hand;
            btnManageTools.FlatAppearance.BorderSize = 0;
            btnManageTools.FlatStyle = FlatStyle.Flat;
            btnManageTools.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnManageTools.ForeColor = Color.FromArgb(24, 24, 37);
            btnManageTools.Location = new Point(440, 539);
            btnManageTools.Name = "btnManageTools";
            btnManageTools.Size = new Size(90, 25);
            btnManageTools.TabIndex = 27;
            btnManageTools.Text = "管理";
            btnManageTools.UseVisualStyleBackColor = false;
            btnManageTools.Click += BtnManageTools_Click;
            // 
            // cboTools
            // 
            cboTools.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboTools.BackColor = Color.FromArgb(49, 50, 68);
            cboTools.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTools.Font = new Font("Cascadia Code", 10F);
            cboTools.ForeColor = Color.FromArgb(205, 214, 244);
            cboTools.FormattingEnabled = true;
            cboTools.Items.AddRange(new object[] { "Function", "MCP Server" });
            cboTools.Location = new Point(20, 539);
            cboTools.Name = "cboTools";
            cboTools.Size = new Size(410, 25);
            cboTools.TabIndex = 26;
            // 
            // lblTools
            // 
            lblTools.AutoSize = true;
            lblTools.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblTools.ForeColor = Color.FromArgb(148, 226, 213);
            lblTools.Location = new Point(20, 514);
            lblTools.Name = "lblTools";
            lblTools.Size = new Size(83, 18);
            lblTools.TabIndex = 25;
            lblTools.Text = "🔧 Tools:";
            // 
            // dgvVariables
            // 
            dgvVariables.AllowUserToAddRows = false;
            dgvVariables.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvVariables.BackgroundColor = Color.FromArgb(49, 50, 68);
            dgvVariables.BorderStyle = BorderStyle.None;
            dgvVariables.ColumnHeadersHeight = 30;
            dgvVariables.GridColor = Color.FromArgb(30, 30, 46);
            dgvVariables.Location = new Point(20, 411);
            dgvVariables.Name = "dgvVariables";
            dgvVariables.RowHeadersVisible = false;
            dgvVariables.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVariables.Size = new Size(510, 91);
            dgvVariables.TabIndex = 14;
            dgvVariables.CellClick += DgvVariables_CellClick;
            // 
            // btnAddVariable
            // 
            btnAddVariable.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddVariable.BackColor = Color.FromArgb(166, 227, 161);
            btnAddVariable.Cursor = Cursors.Hand;
            btnAddVariable.FlatAppearance.BorderSize = 0;
            btnAddVariable.FlatStyle = FlatStyle.Flat;
            btnAddVariable.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnAddVariable.ForeColor = Color.FromArgb(24, 24, 37);
            btnAddVariable.Location = new Point(450, 380);
            btnAddVariable.Name = "btnAddVariable";
            btnAddVariable.Size = new Size(80, 25);
            btnAddVariable.TabIndex = 13;
            btnAddVariable.Text = "+ 添加";
            btnAddVariable.UseVisualStyleBackColor = false;
            btnAddVariable.Click += BtnAddVariable_Click;
            // 
            // lblVariables
            // 
            lblVariables.AutoSize = true;
            lblVariables.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblVariables.ForeColor = Color.FromArgb(245, 194, 231);
            lblVariables.Location = new Point(20, 383);
            lblVariables.Name = "lblVariables";
            lblVariables.Size = new Size(260, 18);
            lblVariables.TabIndex = 12;
            lblVariables.Text = "📝 变量 (使用 {{变量名}} 引用)";
            // 
            // trackTopP
            // 
            trackTopP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackTopP.BackColor = Color.FromArgb(30, 30, 46);
            trackTopP.Location = new Point(268, 341);
            trackTopP.Maximum = 100;
            trackTopP.Name = "trackTopP";
            trackTopP.Size = new Size(206, 45);
            trackTopP.TabIndex = 11;
            trackTopP.TickFrequency = 10;
            trackTopP.Value = 100;
            // 
            // lblTopPValue
            // 
            lblTopPValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTopPValue.AutoSize = true;
            lblTopPValue.Font = new Font("Cascadia Code", 10F);
            lblTopPValue.ForeColor = Color.FromArgb(148, 226, 213);
            lblTopPValue.Location = new Point(480, 345);
            lblTopPValue.Name = "lblTopPValue";
            lblTopPValue.Size = new Size(40, 18);
            lblTopPValue.TabIndex = 10;
            lblTopPValue.Text = "1.00";
            // 
            // lblTopP
            // 
            lblTopP.AutoSize = true;
            lblTopP.Font = new Font("Cascadia Code", 10F);
            lblTopP.ForeColor = Color.FromArgb(166, 173, 200);
            lblTopP.Location = new Point(211, 344);
            lblTopP.Name = "lblTopP";
            lblTopP.Size = new Size(56, 18);
            lblTopP.TabIndex = 9;
            lblTopP.Text = "Top P:";
            // 
            // numMaxTokens
            // 
            numMaxTokens.BackColor = Color.FromArgb(49, 50, 68);
            numMaxTokens.BorderStyle = BorderStyle.FixedSingle;
            numMaxTokens.Font = new Font("Cascadia Code", 10F);
            numMaxTokens.ForeColor = Color.FromArgb(205, 214, 244);
            numMaxTokens.Location = new Point(120, 342);
            numMaxTokens.Maximum = new decimal(new int[] { 128000, 0, 0, 0 });
            numMaxTokens.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMaxTokens.Name = "numMaxTokens";
            numMaxTokens.Size = new Size(75, 23);
            numMaxTokens.TabIndex = 8;
            numMaxTokens.Value = new decimal(new int[] { 4096, 0, 0, 0 });
            // 
            // lblMaxTokens
            // 
            lblMaxTokens.AutoSize = true;
            lblMaxTokens.Font = new Font("Cascadia Code", 10F);
            lblMaxTokens.ForeColor = Color.FromArgb(166, 173, 200);
            lblMaxTokens.Location = new Point(20, 345);
            lblMaxTokens.Name = "lblMaxTokens";
            lblMaxTokens.Size = new Size(96, 18);
            lblMaxTokens.TabIndex = 7;
            lblMaxTokens.Text = "Max Tokens:";
            // 
            // trackTemperature
            // 
            trackTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackTemperature.BackColor = Color.FromArgb(30, 30, 46);
            trackTemperature.Location = new Point(20, 300);
            trackTemperature.Maximum = 200;
            trackTemperature.Name = "trackTemperature";
            trackTemperature.Size = new Size(510, 45);
            trackTemperature.TabIndex = 6;
            trackTemperature.TickFrequency = 20;
            trackTemperature.Value = 70;
            // 
            // lblTemperatureValue
            // 
            lblTemperatureValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTemperatureValue.AutoSize = true;
            lblTemperatureValue.Font = new Font("Cascadia Code", 10F);
            lblTemperatureValue.ForeColor = Color.FromArgb(148, 226, 213);
            lblTemperatureValue.Location = new Point(480, 278);
            lblTemperatureValue.Name = "lblTemperatureValue";
            lblTemperatureValue.Size = new Size(40, 18);
            lblTemperatureValue.TabIndex = 5;
            lblTemperatureValue.Text = "0.70";
            // 
            // lblTemperature
            // 
            lblTemperature.AutoSize = true;
            lblTemperature.Font = new Font("Cascadia Code", 10F);
            lblTemperature.ForeColor = Color.FromArgb(166, 173, 200);
            lblTemperature.Location = new Point(20, 278);
            lblTemperature.Name = "lblTemperature";
            lblTemperature.Size = new Size(104, 18);
            lblTemperature.TabIndex = 4;
            lblTemperature.Text = "Temperature:";
            // 
            // lblParams
            // 
            lblParams.AutoSize = true;
            lblParams.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblParams.ForeColor = Color.FromArgb(249, 226, 175);
            lblParams.Location = new Point(20, 248);
            lblParams.Name = "lblParams";
            lblParams.Size = new Size(103, 18);
            lblParams.TabIndex = 3;
            lblParams.Text = "⚡ 参数设置";
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSettings.BackColor = Color.FromArgb(203, 166, 247);
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnSettings.ForeColor = Color.FromArgb(24, 24, 37);
            btnSettings.Location = new Point(460, 203);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(35, 25);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "⚙️";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click;
            // 
            // cboModel
            // 
            cboModel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cboModel.BackColor = Color.FromArgb(49, 50, 68);
            cboModel.DropDownStyle = ComboBoxStyle.DropDownList;
            cboModel.FlatStyle = FlatStyle.Flat;
            cboModel.Font = new Font("Cascadia Code", 10F);
            cboModel.ForeColor = Color.FromArgb(205, 214, 244);
            cboModel.FormattingEnabled = true;
            cboModel.Location = new Point(20, 203);
            cboModel.Name = "cboModel";
            cboModel.Size = new Size(430, 25);
            cboModel.TabIndex = 1;
            // 
            // lblModel
            // 
            lblModel.AutoSize = true;
            lblModel.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblModel.ForeColor = Color.FromArgb(166, 227, 161);
            lblModel.Location = new Point(20, 178);
            lblModel.Name = "lblModel";
            lblModel.Size = new Size(48, 18);
            lblModel.TabIndex = 0;
            lblModel.Text = "Model";
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(24, 24, 37);
            panelRight.Controls.Add(progressBarLoading);
            panelRight.Controls.Add(lblStatus);
            panelRight.Controls.Add(panelInput);
            panelRight.Controls.Add(txtConversation);
            panelRight.Controls.Add(lblTokenCount);
            panelRight.Controls.Add(lblConversationTitle);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(20);
            panelRight.Size = new Size(1044, 1000);
            panelRight.TabIndex = 0;
            // 
            // progressBarLoading
            // 
            progressBarLoading.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBarLoading.Location = new Point(20, 45);
            progressBarLoading.MarqueeAnimationSpeed = 30;
            progressBarLoading.Name = "progressBarLoading";
            progressBarLoading.Size = new Size(1004, 8);
            progressBarLoading.Style = ProgressBarStyle.Marquee;
            progressBarLoading.TabIndex = 5;
            progressBarLoading.Visible = false;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Cascadia Code", 10F);
            lblStatus.ForeColor = Color.FromArgb(166, 173, 200);
            lblStatus.Location = new Point(23, 977);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(264, 18);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "就绪 - 请配置 API Key 后开始测试";
            // 
            // panelInput
            // 
            panelInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelInput.BackColor = Color.FromArgb(24, 24, 37);
            panelInput.Controls.Add(lblToolResponseHint);
            panelInput.Controls.Add(chkAutoScroll);
            panelInput.Controls.Add(btnClear);
            panelInput.Controls.Add(btnSend);
            panelInput.Controls.Add(txtInput);
            panelInput.Location = new Point(20, 849);
            panelInput.Name = "panelInput";
            panelInput.Size = new Size(1004, 128);
            panelInput.TabIndex = 3;
            // 
            // lblToolResponseHint
            // 
            lblToolResponseHint.AutoSize = true;
            lblToolResponseHint.Font = new Font("Cascadia Code", 9F);
            lblToolResponseHint.ForeColor = Color.FromArgb(203, 166, 247);
            lblToolResponseHint.Location = new Point(0, 0);
            lblToolResponseHint.Name = "lblToolResponseHint";
            lblToolResponseHint.Size = new Size(121, 16);
            lblToolResponseHint.TabIndex = 4;
            lblToolResponseHint.Text = "💬 User Message:";
            // 
            // chkAutoScroll
            // 
            chkAutoScroll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkAutoScroll.AutoSize = true;
            chkAutoScroll.Checked = true;
            chkAutoScroll.CheckState = CheckState.Checked;
            chkAutoScroll.Font = new Font("Cascadia Code", 9F);
            chkAutoScroll.ForeColor = Color.FromArgb(166, 173, 200);
            chkAutoScroll.Location = new Point(834, 81);
            chkAutoScroll.Name = "chkAutoScroll";
            chkAutoScroll.Size = new Size(82, 20);
            chkAutoScroll.TabIndex = 3;
            chkAutoScroll.Text = "自动滚动";
            chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.BackColor = Color.FromArgb(243, 139, 168);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Cascadia Code", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(24, 24, 37);
            btnClear.Location = new Point(924, 25);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(80, 50);
            btnClear.TabIndex = 2;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSend.BackColor = Color.FromArgb(137, 180, 250);
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Cascadia Code", 11F, FontStyle.Bold);
            btnSend.ForeColor = Color.FromArgb(24, 24, 37);
            btnSend.Location = new Point(834, 25);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(80, 50);
            btnSend.TabIndex = 1;
            btnSend.Text = "发送 ↑";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += BtnSend_Click;
            // 
            // txtInput
            // 
            txtInput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtInput.BackColor = Color.FromArgb(49, 50, 68);
            txtInput.BorderStyle = BorderStyle.FixedSingle;
            txtInput.Font = new Font("Cascadia Code", 10F);
            txtInput.ForeColor = Color.FromArgb(205, 214, 244);
            txtInput.Location = new Point(0, 25);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Size = new Size(824, 100);
            txtInput.TabIndex = 0;
            txtInput.KeyDown += TxtInput_KeyDown;
            // 
            // txtConversation
            // 
            txtConversation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtConversation.BackColor = Color.FromArgb(30, 30, 46);
            txtConversation.BorderStyle = BorderStyle.None;
            txtConversation.Font = new Font("Cascadia Code", 10F);
            txtConversation.ForeColor = Color.FromArgb(205, 214, 244);
            txtConversation.Location = new Point(20, 55);
            txtConversation.Name = "txtConversation";
            txtConversation.ReadOnly = true;
            txtConversation.Size = new Size(1004, 789);
            txtConversation.TabIndex = 2;
            txtConversation.Text = "";
            // 
            // lblTokenCount
            // 
            lblTokenCount.AutoSize = true;
            lblTokenCount.Font = new Font("Cascadia Code", 10F);
            lblTokenCount.ForeColor = Color.FromArgb(166, 173, 200);
            lblTokenCount.Location = new Point(220, 23);
            lblTokenCount.Name = "lblTokenCount";
            lblTokenCount.Size = new Size(296, 18);
            lblTokenCount.TabIndex = 1;
            lblTokenCount.Text = "Tokens: 0 (Prompt: 0, Completion: 0)";
            // 
            // lblConversationTitle
            // 
            lblConversationTitle.AutoSize = true;
            lblConversationTitle.Font = new Font("Cascadia Code", 12F, FontStyle.Bold);
            lblConversationTitle.ForeColor = Color.FromArgb(166, 227, 161);
            lblConversationTitle.Location = new Point(20, 20);
            lblConversationTitle.Name = "lblConversationTitle";
            lblConversationTitle.Size = new Size(118, 21);
            lblConversationTitle.TabIndex = 0;
            lblConversationTitle.Text = "💬 对话测试";
            // 
            // PromptTestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 37);
            ClientSize = new Size(1600, 1000);
            Controls.Add(splitContainerMain);
            MinimumSize = new Size(1400, 800);
            Name = "PromptTestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🤖 AI Playground";
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVariables).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackTopP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMaxTokens).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackTemperature).EndInit();
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelInput.ResumeLayout(false);
            panelInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private Panel panelLeft;
        private Label lblModel;
        private ComboBox cboModel;
        private Button btnSettings;
        private Label lblParams;
        private Label lblTools;
        private ComboBox cboTools;
        private Button btnManageTools;
        private Label lblTemperature;
        private Label lblTemperatureValue;
        private TrackBar trackTemperature;
        private Label lblMaxTokens;
        private NumericUpDown numMaxTokens;
        private Label lblTopP;
        private Label lblTopPValue;
        private TrackBar trackTopP;
        private Label lblVariables;
        private Button btnAddVariable;
        private DataGridView dgvVariables;
        private Label lblSystemPrompt;
        private TextBox txtSystemPrompt;
        private Label lblSavedPrompts;
        private ListBox lstSavedPrompts;
        private Button btnSavePrompt;
        private Button btnDeletePrompt;
        private Button btnExportPrompts;
        private Button btnImportPrompts;
        private Panel panelRight;
        private Label lblConversationTitle;
        private Label lblTokenCount;
        private RichTextBox txtConversation;
        private Panel panelInput;
        private TextBox txtInput;
        private Button btnSend;
        private Button btnClear;
        private CheckBox chkAutoScroll;
        private Label lblStatus;
        private ProgressBar progressBarLoading;
        private Label lblToolResponseHint;
    }
}
