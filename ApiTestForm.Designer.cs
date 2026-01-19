namespace APITestTool
{
    partial class ApiTestForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            splitContainerMain = new SplitContainer();
            panelRequest = new Panel();
            lblSavedRequests = new Label();
            lstSavedRequests = new ListBox();
            btnSaveRequest = new Button();
            btnDeleteRequest = new Button();
            btnExportRequests = new Button();
            btnImportRequests = new Button();
            lblUrl = new Label();
            txtUrl = new TextBox();
            lblMethod = new Label();
            cboMethod = new ComboBox();
            lblHeaders = new Label();
            txtHeaders = new TextBox();
            lblBody = new Label();
            txtBody = new TextBox();
            btnTextToJson = new Button();
            lblCompareFields = new Label();
            txtCompareFields = new TextBox();
            chkCompareFieldsOnly = new CheckBox();
            lblCallCount = new Label();
            numCallCount = new NumericUpDown();
            lblTimeout = new Label();
            numTimeout = new NumericUpDown();
            lblDelay = new Label();
            numDelay = new NumericUpDown();
            chkParallel = new CheckBox();
            btnExecute = new Button();
            btnStop = new Button();
            btnClear = new Button();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            panelResult = new Panel();
            tabControlResult = new TabControl();
            tabPageAllResults = new TabPage();
            dgvResults = new DataGridView();
            tabPageDifferences = new TabPage();
            txtDifferences = new RichTextBox();
            tabPageStatistics = new TabPage();
            txtStatistics = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panelRequest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCallCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTimeout).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDelay).BeginInit();
            panelResult.SuspendLayout();
            tabControlResult.SuspendLayout();
            tabPageAllResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResults).BeginInit();
            tabPageDifferences.SuspendLayout();
            tabPageStatistics.SuspendLayout();
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
            splitContainerMain.Panel1.Controls.Add(panelRequest);
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(panelResult);
            splitContainerMain.Size = new Size(1400, 950);
            splitContainerMain.SplitterDistance = 450;
            splitContainerMain.SplitterWidth = 6;
            splitContainerMain.TabIndex = 0;
            // 
            // panelRequest
            // 
            panelRequest.AutoScroll = true;
            panelRequest.BackColor = Color.FromArgb(30, 30, 46);
            panelRequest.Controls.Add(lblSavedRequests);
            panelRequest.Controls.Add(lstSavedRequests);
            panelRequest.Controls.Add(btnSaveRequest);
            panelRequest.Controls.Add(btnDeleteRequest);
            panelRequest.Controls.Add(btnExportRequests);
            panelRequest.Controls.Add(btnImportRequests);
            panelRequest.Controls.Add(lblUrl);
            panelRequest.Controls.Add(txtUrl);
            panelRequest.Controls.Add(lblMethod);
            panelRequest.Controls.Add(cboMethod);
            panelRequest.Controls.Add(lblHeaders);
            panelRequest.Controls.Add(txtHeaders);
            panelRequest.Controls.Add(lblBody);
            panelRequest.Controls.Add(txtBody);
            panelRequest.Controls.Add(btnTextToJson);
            panelRequest.Controls.Add(lblCompareFields);
            panelRequest.Controls.Add(txtCompareFields);
            panelRequest.Controls.Add(chkCompareFieldsOnly);
            panelRequest.Controls.Add(lblCallCount);
            panelRequest.Controls.Add(numCallCount);
            panelRequest.Controls.Add(lblTimeout);
            panelRequest.Controls.Add(numTimeout);
            panelRequest.Controls.Add(lblDelay);
            panelRequest.Controls.Add(numDelay);
            panelRequest.Controls.Add(chkParallel);
            panelRequest.Controls.Add(btnExecute);
            panelRequest.Controls.Add(btnStop);
            panelRequest.Controls.Add(btnClear);
            panelRequest.Controls.Add(progressBar);
            panelRequest.Controls.Add(lblProgress);
            panelRequest.Dock = DockStyle.Fill;
            panelRequest.Location = new Point(0, 0);
            panelRequest.Name = "panelRequest";
            panelRequest.Padding = new Padding(20);
            panelRequest.Size = new Size(450, 950);
            panelRequest.TabIndex = 0;
            // 
            // lblSavedRequests
            // 
            lblSavedRequests.AutoSize = true;
            lblSavedRequests.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblSavedRequests.ForeColor = Color.FromArgb(203, 166, 247);
            lblSavedRequests.Location = new Point(20, 15);
            lblSavedRequests.Name = "lblSavedRequests";
            lblSavedRequests.Size = new Size(137, 18);
            lblSavedRequests.TabIndex = 0;
            lblSavedRequests.Text = "📁 已保存的请求";
            // 
            // lstSavedRequests
            // 
            lstSavedRequests.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstSavedRequests.BackColor = Color.FromArgb(49, 50, 68);
            lstSavedRequests.BorderStyle = BorderStyle.None;
            lstSavedRequests.Font = new Font("Cascadia Code", 9F);
            lstSavedRequests.ForeColor = Color.FromArgb(205, 214, 244);
            lstSavedRequests.Location = new Point(20, 38);
            lstSavedRequests.Name = "lstSavedRequests";
            lstSavedRequests.Size = new Size(410, 64);
            lstSavedRequests.TabIndex = 0;
            lstSavedRequests.SelectedIndexChanged += LstSavedRequests_SelectedIndexChanged;
            lstSavedRequests.DoubleClick += LstSavedRequests_DoubleClick;
            // 
            // btnSaveRequest
            // 
            btnSaveRequest.BackColor = Color.FromArgb(166, 227, 161);
            btnSaveRequest.Cursor = Cursors.Hand;
            btnSaveRequest.FlatAppearance.BorderSize = 0;
            btnSaveRequest.FlatStyle = FlatStyle.Flat;
            btnSaveRequest.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnSaveRequest.ForeColor = Color.FromArgb(30, 30, 46);
            btnSaveRequest.Location = new Point(20, 107);
            btnSaveRequest.Name = "btnSaveRequest";
            btnSaveRequest.Size = new Size(95, 26);
            btnSaveRequest.TabIndex = 1;
            btnSaveRequest.Text = "💾 保存";
            btnSaveRequest.UseVisualStyleBackColor = false;
            btnSaveRequest.Click += BtnSaveRequest_Click;
            // 
            // btnDeleteRequest
            // 
            btnDeleteRequest.BackColor = Color.FromArgb(243, 139, 168);
            btnDeleteRequest.Cursor = Cursors.Hand;
            btnDeleteRequest.FlatAppearance.BorderSize = 0;
            btnDeleteRequest.FlatStyle = FlatStyle.Flat;
            btnDeleteRequest.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnDeleteRequest.ForeColor = Color.FromArgb(30, 30, 46);
            btnDeleteRequest.Location = new Point(120, 107);
            btnDeleteRequest.Name = "btnDeleteRequest";
            btnDeleteRequest.Size = new Size(95, 26);
            btnDeleteRequest.TabIndex = 2;
            btnDeleteRequest.Text = "🗑️ 删除";
            btnDeleteRequest.UseVisualStyleBackColor = false;
            btnDeleteRequest.Click += BtnDeleteRequest_Click;
            // 
            // btnExportRequests
            // 
            btnExportRequests.BackColor = Color.FromArgb(137, 180, 250);
            btnExportRequests.Cursor = Cursors.Hand;
            btnExportRequests.FlatAppearance.BorderSize = 0;
            btnExportRequests.FlatStyle = FlatStyle.Flat;
            btnExportRequests.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnExportRequests.ForeColor = Color.FromArgb(30, 30, 46);
            btnExportRequests.Location = new Point(220, 107);
            btnExportRequests.Name = "btnExportRequests";
            btnExportRequests.Size = new Size(95, 26);
            btnExportRequests.TabIndex = 3;
            btnExportRequests.Text = "📤 导出";
            btnExportRequests.UseVisualStyleBackColor = false;
            btnExportRequests.Click += BtnExportRequests_Click;
            // 
            // btnImportRequests
            // 
            btnImportRequests.BackColor = Color.FromArgb(249, 226, 175);
            btnImportRequests.Cursor = Cursors.Hand;
            btnImportRequests.FlatAppearance.BorderSize = 0;
            btnImportRequests.FlatStyle = FlatStyle.Flat;
            btnImportRequests.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnImportRequests.ForeColor = Color.FromArgb(30, 30, 46);
            btnImportRequests.Location = new Point(320, 107);
            btnImportRequests.Name = "btnImportRequests";
            btnImportRequests.Size = new Size(110, 26);
            btnImportRequests.TabIndex = 4;
            btnImportRequests.Text = "📥 导入";
            btnImportRequests.UseVisualStyleBackColor = false;
            btnImportRequests.Click += BtnImportRequests_Click;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblUrl.ForeColor = Color.FromArgb(166, 227, 161);
            lblUrl.Location = new Point(20, 145);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(64, 18);
            lblUrl.TabIndex = 5;
            lblUrl.Text = "API URL";
            // 
            // txtUrl
            // 
            txtUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrl.BackColor = Color.FromArgb(49, 50, 68);
            txtUrl.BorderStyle = BorderStyle.FixedSingle;
            txtUrl.Font = new Font("Cascadia Code", 10F);
            txtUrl.ForeColor = Color.FromArgb(205, 214, 244);
            txtUrl.Location = new Point(20, 166);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(410, 23);
            txtUrl.TabIndex = 5;
            txtUrl.Text = "https://api.example.com/endpoint";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblMethod.ForeColor = Color.FromArgb(166, 227, 161);
            lblMethod.Location = new Point(20, 198);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(56, 18);
            lblMethod.TabIndex = 6;
            lblMethod.Text = "Method";
            // 
            // cboMethod
            // 
            cboMethod.BackColor = Color.FromArgb(49, 50, 68);
            cboMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMethod.FlatStyle = FlatStyle.Flat;
            cboMethod.Font = new Font("Cascadia Code", 10F);
            cboMethod.ForeColor = Color.FromArgb(205, 214, 244);
            cboMethod.Items.AddRange(new object[] { "GET", "POST", "PUT", "DELETE", "PATCH", "HEAD", "OPTIONS" });
            cboMethod.Location = new Point(20, 219);
            cboMethod.Name = "cboMethod";
            cboMethod.Size = new Size(120, 25);
            cboMethod.TabIndex = 6;
            // 
            // lblHeaders
            // 
            lblHeaders.AutoSize = true;
            lblHeaders.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblHeaders.ForeColor = Color.FromArgb(166, 227, 161);
            lblHeaders.Location = new Point(20, 252);
            lblHeaders.Name = "lblHeaders";
            lblHeaders.Size = new Size(154, 18);
            lblHeaders.TabIndex = 7;
            lblHeaders.Text = "Headers (JSON格式)";
            // 
            // txtHeaders
            // 
            txtHeaders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtHeaders.BackColor = Color.FromArgb(49, 50, 68);
            txtHeaders.BorderStyle = BorderStyle.FixedSingle;
            txtHeaders.Font = new Font("Cascadia Code", 9F);
            txtHeaders.ForeColor = Color.FromArgb(205, 214, 244);
            txtHeaders.Location = new Point(20, 273);
            txtHeaders.Multiline = true;
            txtHeaders.Name = "txtHeaders";
            txtHeaders.ScrollBars = ScrollBars.Vertical;
            txtHeaders.Size = new Size(410, 80);
            txtHeaders.TabIndex = 7;
            txtHeaders.Text = "{\r\n  \"Content-Type\": \"application/json\",\r\n  \"Authorization\": \"Bearer your-token\"\r\n}";
            // 
            // lblBody
            // 
            lblBody.AutoSize = true;
            lblBody.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblBody.ForeColor = Color.FromArgb(166, 227, 161);
            lblBody.Location = new Point(20, 361);
            lblBody.Name = "lblBody";
            lblBody.Size = new Size(130, 18);
            lblBody.TabIndex = 8;
            lblBody.Text = "Body (JSON格式)";
            // 
            // txtBody
            // 
            txtBody.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBody.BackColor = Color.FromArgb(49, 50, 68);
            txtBody.BorderStyle = BorderStyle.FixedSingle;
            txtBody.Font = new Font("Cascadia Code", 9F);
            txtBody.ForeColor = Color.FromArgb(205, 214, 244);
            txtBody.Location = new Point(20, 382);
            txtBody.Multiline = true;
            txtBody.Name = "txtBody";
            txtBody.ScrollBars = ScrollBars.Both;
            txtBody.Size = new Size(410, 280);
            txtBody.TabIndex = 8;
            txtBody.Text = "{\r\n  \"key\": \"value\"\r\n}";
            // 
            // btnTextToJson
            // 
            btnTextToJson.BackColor = Color.FromArgb(148, 226, 213);
            btnTextToJson.Cursor = Cursors.Hand;
            btnTextToJson.FlatAppearance.BorderSize = 0;
            btnTextToJson.FlatStyle = FlatStyle.Flat;
            btnTextToJson.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnTextToJson.ForeColor = Color.FromArgb(30, 30, 46);
            btnTextToJson.Location = new Point(155, 358);
            btnTextToJson.Name = "btnTextToJson";
            btnTextToJson.Size = new Size(140, 22);
            btnTextToJson.TabIndex = 19;
            btnTextToJson.Text = "📝 文本转JSON";
            btnTextToJson.UseVisualStyleBackColor = false;
            btnTextToJson.Click += BtnTextToJson_Click;
            // 
            // lblCompareFields
            // 
            lblCompareFields.AutoSize = true;
            lblCompareFields.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblCompareFields.ForeColor = Color.FromArgb(245, 194, 231);
            lblCompareFields.Location = new Point(20, 665);
            lblCompareFields.Name = "lblCompareFields";
            lblCompareFields.Size = new Size(161, 18);
            lblCompareFields.TabIndex = 20;
            lblCompareFields.Text = "🎯 对比字段 (可选)";
            // 
            // txtCompareFields
            // 
            txtCompareFields.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCompareFields.BackColor = Color.FromArgb(49, 50, 68);
            txtCompareFields.BorderStyle = BorderStyle.FixedSingle;
            txtCompareFields.Font = new Font("Cascadia Code", 9F);
            txtCompareFields.ForeColor = Color.FromArgb(205, 214, 244);
            txtCompareFields.Location = new Point(20, 686);
            txtCompareFields.Multiline = true;
            txtCompareFields.Name = "txtCompareFields";
            txtCompareFields.ScrollBars = ScrollBars.Vertical;
            txtCompareFields.Size = new Size(410, 50);
            txtCompareFields.TabIndex = 9;
            // 
            // chkCompareFieldsOnly
            // 
            chkCompareFieldsOnly.AutoSize = true;
            chkCompareFieldsOnly.Font = new Font("Cascadia Code", 9F);
            chkCompareFieldsOnly.ForeColor = Color.FromArgb(245, 194, 231);
            chkCompareFieldsOnly.Location = new Point(20, 741);
            chkCompareFieldsOnly.Name = "chkCompareFieldsOnly";
            chkCompareFieldsOnly.Size = new Size(124, 20);
            chkCompareFieldsOnly.TabIndex = 10;
            chkCompareFieldsOnly.Text = "仅对比指定字段";
            // 
            // lblCallCount
            // 
            lblCallCount.AutoSize = true;
            lblCallCount.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblCallCount.ForeColor = Color.FromArgb(249, 226, 175);
            lblCallCount.Location = new Point(20, 771);
            lblCallCount.Name = "lblCallCount";
            lblCallCount.Size = new Size(76, 18);
            lblCallCount.TabIndex = 21;
            lblCallCount.Text = "调用次数";
            // 
            // numCallCount
            // 
            numCallCount.BackColor = Color.FromArgb(49, 50, 68);
            numCallCount.BorderStyle = BorderStyle.FixedSingle;
            numCallCount.Font = new Font("Cascadia Code", 10F);
            numCallCount.ForeColor = Color.FromArgb(205, 214, 244);
            numCallCount.Location = new Point(20, 792);
            numCallCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCallCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCallCount.Name = "numCallCount";
            numCallCount.Size = new Size(100, 23);
            numCallCount.TabIndex = 11;
            numCallCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblTimeout
            // 
            lblTimeout.AutoSize = true;
            lblTimeout.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblTimeout.ForeColor = Color.FromArgb(249, 226, 175);
            lblTimeout.Location = new Point(140, 771);
            lblTimeout.Name = "lblTimeout";
            lblTimeout.Size = new Size(75, 18);
            lblTimeout.TabIndex = 22;
            lblTimeout.Text = "超时(秒)";
            // 
            // numTimeout
            // 
            numTimeout.BackColor = Color.FromArgb(49, 50, 68);
            numTimeout.BorderStyle = BorderStyle.FixedSingle;
            numTimeout.Font = new Font("Cascadia Code", 10F);
            numTimeout.ForeColor = Color.FromArgb(205, 214, 244);
            numTimeout.Location = new Point(140, 792);
            numTimeout.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTimeout.Name = "numTimeout";
            numTimeout.Size = new Size(80, 23);
            numTimeout.TabIndex = 12;
            numTimeout.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // lblDelay
            // 
            lblDelay.AutoSize = true;
            lblDelay.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblDelay.ForeColor = Color.FromArgb(249, 226, 175);
            lblDelay.Location = new Point(240, 771);
            lblDelay.Name = "lblDelay";
            lblDelay.Size = new Size(74, 18);
            lblDelay.TabIndex = 23;
            lblDelay.Text = "间隔(ms)";
            // 
            // numDelay
            // 
            numDelay.BackColor = Color.FromArgb(49, 50, 68);
            numDelay.BorderStyle = BorderStyle.FixedSingle;
            numDelay.Font = new Font("Cascadia Code", 10F);
            numDelay.ForeColor = Color.FromArgb(205, 214, 244);
            numDelay.Location = new Point(240, 792);
            numDelay.Maximum = new decimal(new int[] { 60000, 0, 0, 0 });
            numDelay.Name = "numDelay";
            numDelay.Size = new Size(80, 23);
            numDelay.TabIndex = 13;
            numDelay.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // chkParallel
            // 
            chkParallel.AutoSize = true;
            chkParallel.Font = new Font("Cascadia Code", 10F);
            chkParallel.ForeColor = Color.FromArgb(203, 166, 247);
            chkParallel.Location = new Point(340, 793);
            chkParallel.Name = "chkParallel";
            chkParallel.Size = new Size(91, 22);
            chkParallel.TabIndex = 14;
            chkParallel.Text = "并行执行";
            // 
            // btnExecute
            // 
            btnExecute.BackColor = Color.FromArgb(137, 180, 250);
            btnExecute.Cursor = Cursors.Hand;
            btnExecute.FlatAppearance.BorderSize = 0;
            btnExecute.FlatStyle = FlatStyle.Flat;
            btnExecute.Font = new Font("Cascadia Code", 12F, FontStyle.Bold);
            btnExecute.ForeColor = Color.FromArgb(30, 30, 46);
            btnExecute.Location = new Point(20, 833);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(200, 45);
            btnExecute.TabIndex = 15;
            btnExecute.Text = "▶ 开始测试";
            btnExecute.UseVisualStyleBackColor = false;
            btnExecute.Click += BtnExecute_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(243, 139, 168);
            btnStop.Cursor = Cursors.Hand;
            btnStop.Enabled = false;
            btnStop.FlatAppearance.BorderSize = 0;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Cascadia Code", 12F, FontStyle.Bold);
            btnStop.ForeColor = Color.FromArgb(30, 30, 46);
            btnStop.Location = new Point(230, 833);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(95, 45);
            btnStop.TabIndex = 16;
            btnStop.Text = "■ 停止";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += BtnStop_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(166, 173, 200);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Cascadia Code", 12F, FontStyle.Bold);
            btnClear.ForeColor = Color.FromArgb(30, 30, 46);
            btnClear.Location = new Point(335, 833);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(95, 45);
            btnClear.TabIndex = 17;
            btnClear.Text = "清空";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += BtnClear_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar.Location = new Point(20, 888);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(410, 25);
            progressBar.Style = ProgressBarStyle.Continuous;
            progressBar.TabIndex = 18;
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblProgress.Font = new Font("Cascadia Code", 10F);
            lblProgress.ForeColor = Color.FromArgb(205, 214, 244);
            lblProgress.Location = new Point(20, 918);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(410, 20);
            lblProgress.TabIndex = 24;
            lblProgress.Text = "就绪";
            lblProgress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelResult
            // 
            panelResult.BackColor = Color.FromArgb(24, 24, 37);
            panelResult.Controls.Add(tabControlResult);
            panelResult.Dock = DockStyle.Fill;
            panelResult.Location = new Point(0, 0);
            panelResult.Name = "panelResult";
            panelResult.Padding = new Padding(10);
            panelResult.Size = new Size(944, 950);
            panelResult.TabIndex = 0;
            // 
            // tabControlResult
            // 
            tabControlResult.Controls.Add(tabPageAllResults);
            tabControlResult.Controls.Add(tabPageDifferences);
            tabControlResult.Controls.Add(tabPageStatistics);
            tabControlResult.Dock = DockStyle.Fill;
            tabControlResult.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            tabControlResult.Location = new Point(10, 10);
            tabControlResult.Name = "tabControlResult";
            tabControlResult.SelectedIndex = 0;
            tabControlResult.Size = new Size(924, 930);
            tabControlResult.TabIndex = 0;
            // 
            // tabPageAllResults
            // 
            tabPageAllResults.BackColor = Color.FromArgb(30, 30, 46);
            tabPageAllResults.Controls.Add(dgvResults);
            tabPageAllResults.Location = new Point(4, 26);
            tabPageAllResults.Name = "tabPageAllResults";
            tabPageAllResults.Padding = new Padding(10);
            tabPageAllResults.Size = new Size(916, 900);
            tabPageAllResults.TabIndex = 0;
            tabPageAllResults.Text = "📋 所有结果";
            // 
            // dgvResults
            // 
            dgvResults.AllowUserToAddRows = false;
            dgvResults.AllowUserToDeleteRows = false;
            dgvResults.BackgroundColor = Color.FromArgb(30, 30, 46);
            dgvResults.BorderStyle = BorderStyle.None;
            dgvResults.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvResults.ColumnHeadersHeight = 35;
            dgvResults.Dock = DockStyle.Fill;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.GridColor = Color.FromArgb(49, 50, 68);
            dgvResults.Location = new Point(10, 10);
            dgvResults.Name = "dgvResults";
            dgvResults.ReadOnly = true;
            dgvResults.RowHeadersVisible = false;
            dgvResults.RowTemplate.Height = 30;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.Size = new Size(896, 880);
            dgvResults.TabIndex = 0;
            dgvResults.CellDoubleClick += DgvResults_CellDoubleClick;
            // 
            // tabPageDifferences
            // 
            tabPageDifferences.BackColor = Color.FromArgb(30, 30, 46);
            tabPageDifferences.Controls.Add(txtDifferences);
            tabPageDifferences.Location = new Point(4, 26);
            tabPageDifferences.Name = "tabPageDifferences";
            tabPageDifferences.Padding = new Padding(10);
            tabPageDifferences.Size = new Size(916, 900);
            tabPageDifferences.TabIndex = 1;
            tabPageDifferences.Text = "🔍 差异对比";
            // 
            // txtDifferences
            // 
            txtDifferences.BackColor = Color.FromArgb(30, 30, 46);
            txtDifferences.BorderStyle = BorderStyle.None;
            txtDifferences.Dock = DockStyle.Fill;
            txtDifferences.Font = new Font("Cascadia Code", 10F);
            txtDifferences.ForeColor = Color.FromArgb(205, 214, 244);
            txtDifferences.Location = new Point(10, 10);
            txtDifferences.Name = "txtDifferences";
            txtDifferences.ReadOnly = true;
            txtDifferences.Size = new Size(896, 880);
            txtDifferences.TabIndex = 0;
            txtDifferences.Text = "";
            // 
            // tabPageStatistics
            // 
            tabPageStatistics.BackColor = Color.FromArgb(30, 30, 46);
            tabPageStatistics.Controls.Add(txtStatistics);
            tabPageStatistics.Location = new Point(4, 26);
            tabPageStatistics.Name = "tabPageStatistics";
            tabPageStatistics.Padding = new Padding(10);
            tabPageStatistics.Size = new Size(916, 900);
            tabPageStatistics.TabIndex = 2;
            tabPageStatistics.Text = "📊 统计信息";
            // 
            // txtStatistics
            // 
            txtStatistics.BackColor = Color.FromArgb(30, 30, 46);
            txtStatistics.BorderStyle = BorderStyle.None;
            txtStatistics.Dock = DockStyle.Fill;
            txtStatistics.Font = new Font("Cascadia Code", 10F);
            txtStatistics.ForeColor = Color.FromArgb(205, 214, 244);
            txtStatistics.Location = new Point(10, 10);
            txtStatistics.Name = "txtStatistics";
            txtStatistics.ReadOnly = true;
            txtStatistics.Size = new Size(896, 880);
            txtStatistics.TabIndex = 0;
            txtStatistics.Text = "";
            // 
            // ApiTestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 37);
            ClientSize = new Size(1400, 950);
            Controls.Add(splitContainerMain);
            MinimumSize = new Size(1200, 850);
            Name = "ApiTestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🚀 AI API Stability Test";
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panelRequest.ResumeLayout(false);
            panelRequest.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCallCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTimeout).EndInit();
            ((System.ComponentModel.ISupportInitialize)numDelay).EndInit();
            panelResult.ResumeLayout(false);
            tabControlResult.ResumeLayout(false);
            tabPageAllResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvResults).EndInit();
            tabPageDifferences.ResumeLayout(false);
            tabPageStatistics.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerMain;
        private Panel panelRequest;
        private Panel panelResult;
        
        // 已保存请求控件
        private Label lblSavedRequests;
        private ListBox lstSavedRequests;
        private Button btnSaveRequest;
        private Button btnDeleteRequest;
        private Button btnExportRequests;
        private Button btnImportRequests;
        
        private Label lblUrl;
        private TextBox txtUrl;
        private Label lblMethod;
        private ComboBox cboMethod;
        private Label lblHeaders;
        private TextBox txtHeaders;
        private Label lblBody;
        private TextBox txtBody;
        private Button btnTextToJson;
        
        // 对比字段设置
        private Label lblCompareFields;
        private TextBox txtCompareFields;
        private CheckBox chkCompareFieldsOnly;
        
        private Label lblCallCount;
        private NumericUpDown numCallCount;
        private Label lblTimeout;
        private NumericUpDown numTimeout;
        private Label lblDelay;
        private NumericUpDown numDelay;
        private CheckBox chkParallel;
        private Button btnExecute;
        private Button btnStop;
        private Button btnClear;
        private ProgressBar progressBar;
        private Label lblProgress;
        
        private TabControl tabControlResult;
        private TabPage tabPageAllResults;
        private TabPage tabPageDifferences;
        private TabPage tabPageStatistics;
        private DataGridView dgvResults;
        private RichTextBox txtDifferences;
        private RichTextBox txtStatistics;
    }
}
