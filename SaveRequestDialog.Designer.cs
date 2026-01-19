namespace APITestTool
{
    partial class SaveRequestDialog
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
            Label lblName = new Label();
            txtName = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.Font = new Font("Cascadia Code", 10F);
            lblName.ForeColor = Color.FromArgb(205, 214, 244);
            lblName.Location = new Point(20, 25);
            lblName.Name = "lblName";
            lblName.Size = new Size(80, 20);
            lblName.TabIndex = 0;
            lblName.Text = "请求名称:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(49, 50, 68);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Font = new Font("Cascadia Code", 10F);
            txtName.ForeColor = Color.FromArgb(205, 214, 244);
            txtName.Location = new Point(20, 50);
            txtName.Name = "txtName";
            txtName.Size = new Size(340, 23);
            txtName.TabIndex = 1;
            // 
            // btnOk
            // 
            btnOk.BackColor = Color.FromArgb(166, 227, 161);
            btnOk.DialogResult = DialogResult.OK;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.FromArgb(30, 30, 46);
            btnOk.Location = new Point(180, 95);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(85, 35);
            btnOk.TabIndex = 2;
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
            btnCancel.Location = new Point(275, 95);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(85, 35);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Cursor = Cursors.Hand;
            // 
            // SaveRequestDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            CancelButton = btnCancel;
            ClientSize = new Size(400, 180);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtName);
            Controls.Add(lblName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SaveRequestDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "保存请求";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtName;
        private Button btnOk;
        private Button btnCancel;
    }
}
