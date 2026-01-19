namespace APITestTool
{
    partial class OpenAISettingsDialog
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null!;

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
            Label lblApiKey = new Label();
            txtApiKey = new TextBox();
            chkUseEnvVar = new CheckBox();
            lblEnvVarName = new Label();
            txtEnvVarName = new TextBox();
            Label lblBaseUrl = new Label();
            txtBaseUrl = new TextBox();
            Label lblOrg = new Label();
            txtOrganization = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblApiKey
            // 
            lblApiKey.AutoSize = true;
            lblApiKey.Font = new Font("Cascadia Code", 10F);
            lblApiKey.ForeColor = Color.FromArgb(205, 214, 244);
            lblApiKey.Location = new Point(20, 20);
            lblApiKey.Name = "lblApiKey";
            lblApiKey.Size = new Size(60, 17);
            lblApiKey.TabIndex = 0;
            lblApiKey.Text = "API Key:";
            // 
            // txtApiKey
            // 
            txtApiKey.BackColor = Color.FromArgb(49, 50, 68);
            txtApiKey.BorderStyle = BorderStyle.FixedSingle;
            txtApiKey.Font = new Font("Cascadia Code", 10F);
            txtApiKey.ForeColor = Color.FromArgb(205, 214, 244);
            txtApiKey.Location = new Point(20, 45);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(440, 23);
            txtApiKey.TabIndex = 1;
            txtApiKey.UseSystemPasswordChar = true;
            // 
            // chkUseEnvVar
            // 
            chkUseEnvVar.AutoSize = true;
            chkUseEnvVar.Font = new Font("Cascadia Code", 9F);
            chkUseEnvVar.ForeColor = Color.FromArgb(205, 214, 244);
            chkUseEnvVar.Location = new Point(20, 75);
            chkUseEnvVar.Name = "chkUseEnvVar";
            chkUseEnvVar.Size = new Size(200, 19);
            chkUseEnvVar.TabIndex = 2;
            chkUseEnvVar.Text = "使用环境变量";
            chkUseEnvVar.UseVisualStyleBackColor = true;
            // 
            // lblEnvVarName
            // 
            lblEnvVarName.AutoSize = true;
            lblEnvVarName.Font = new Font("Cascadia Code", 9F);
            lblEnvVarName.ForeColor = Color.FromArgb(166, 173, 200);
            lblEnvVarName.Location = new Point(40, 100);
            lblEnvVarName.Name = "lblEnvVarName";
            lblEnvVarName.Size = new Size(100, 16);
            lblEnvVarName.TabIndex = 3;
            lblEnvVarName.Text = "环境变量名:";
            // 
            // txtEnvVarName
            // 
            txtEnvVarName.BackColor = Color.FromArgb(49, 50, 68);
            txtEnvVarName.BorderStyle = BorderStyle.FixedSingle;
            txtEnvVarName.Font = new Font("Cascadia Code", 9F);
            txtEnvVarName.ForeColor = Color.FromArgb(205, 214, 244);
            txtEnvVarName.Location = new Point(40, 120);
            txtEnvVarName.Name = "txtEnvVarName";
            txtEnvVarName.Size = new Size(420, 22);
            txtEnvVarName.TabIndex = 4;
            // 
            // lblBaseUrl
            // 
            lblBaseUrl.AutoSize = true;
            lblBaseUrl.Font = new Font("Cascadia Code", 10F);
            lblBaseUrl.ForeColor = Color.FromArgb(205, 214, 244);
            lblBaseUrl.Location = new Point(20, 155);
            lblBaseUrl.Name = "lblBaseUrl";
            lblBaseUrl.Size = new Size(70, 17);
            lblBaseUrl.TabIndex = 5;
            lblBaseUrl.Text = "Base URL:";
            // 
            // txtBaseUrl
            // 
            txtBaseUrl.BackColor = Color.FromArgb(49, 50, 68);
            txtBaseUrl.BorderStyle = BorderStyle.FixedSingle;
            txtBaseUrl.Font = new Font("Cascadia Code", 10F);
            txtBaseUrl.ForeColor = Color.FromArgb(205, 214, 244);
            txtBaseUrl.Location = new Point(20, 180);
            txtBaseUrl.Name = "txtBaseUrl";
            txtBaseUrl.Size = new Size(440, 23);
            txtBaseUrl.TabIndex = 6;
            // 
            // lblOrg
            // 
            lblOrg.AutoSize = true;
            lblOrg.Font = new Font("Cascadia Code", 10F);
            lblOrg.ForeColor = Color.FromArgb(205, 214, 244);
            lblOrg.Location = new Point(20, 220);
            lblOrg.Name = "lblOrg";
            lblOrg.Size = new Size(150, 17);
            lblOrg.TabIndex = 7;
            lblOrg.Text = "Organization (可选):";
            // 
            // txtOrganization
            // 
            txtOrganization.BackColor = Color.FromArgb(49, 50, 68);
            txtOrganization.BorderStyle = BorderStyle.FixedSingle;
            txtOrganization.Font = new Font("Cascadia Code", 10F);
            txtOrganization.ForeColor = Color.FromArgb(205, 214, 244);
            txtOrganization.Location = new Point(20, 245);
            txtOrganization.Name = "txtOrganization";
            txtOrganization.Size = new Size(440, 23);
            txtOrganization.TabIndex = 8;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(166, 227, 161);
            btnOk.DialogResult = DialogResult.OK;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.FromArgb(30, 30, 46);
            btnOk.Location = new Point(280, 290);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 35);
            btnOk.TabIndex = 9;
            btnOk.Text = "保存";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Cursor = Cursors.Hand;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(166, 173, 200);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(30, 30, 46);
            btnCancel.Location = new Point(375, 290);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Cursor = Cursors.Hand;
            // 
            // OpenAISettingsDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            CancelButton = btnCancel;
            ClientSize = new Size(500, 350);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtOrganization);
            Controls.Add(lblOrg);
            Controls.Add(txtBaseUrl);
            Controls.Add(lblBaseUrl);
            Controls.Add(txtEnvVarName);
            Controls.Add(lblEnvVarName);
            Controls.Add(chkUseEnvVar);
            Controls.Add(txtApiKey);
            Controls.Add(lblApiKey);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "OpenAISettingsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "⚙️ OpenAI API 设置";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtApiKey;
        private CheckBox chkUseEnvVar;
        private Label lblEnvVarName;
        private TextBox txtEnvVarName;
        private TextBox txtBaseUrl;
        private TextBox txtOrganization;
        private Button btnOk;
        private Button btnCancel;
    }
}
