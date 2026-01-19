namespace APITestTool
{
    partial class TextToJsonDialog
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
            Label lblFieldName = new Label();
            txtFieldName = new TextBox();
            Label lblInput = new Label();
            txtInputText = new TextBox();
            btnConvert = new Button();
            Label lblPreview = new Label();
            txtPreview = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblFieldName
            // 
            lblFieldName.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblFieldName.ForeColor = Color.FromArgb(166, 227, 161);
            lblFieldName.Location = new Point(20, 20);
            lblFieldName.Name = "lblFieldName";
            lblFieldName.Size = new Size(100, 20);
            lblFieldName.TabIndex = 0;
            lblFieldName.Text = "字段名称:";
            // 
            // txtFieldName
            // 
            txtFieldName.BackColor = Color.FromArgb(49, 50, 68);
            txtFieldName.BorderStyle = BorderStyle.FixedSingle;
            txtFieldName.Font = new Font("Cascadia Code", 10F);
            txtFieldName.ForeColor = Color.FromArgb(205, 214, 244);
            txtFieldName.Location = new Point(20, 45);
            txtFieldName.Name = "txtFieldName";
            txtFieldName.Size = new Size(300, 23);
            txtFieldName.TabIndex = 1;
            txtFieldName.Text = "Instruction";
            // 
            // lblInput
            // 
            lblInput.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblInput.ForeColor = Color.FromArgb(249, 226, 175);
            lblInput.Location = new Point(20, 85);
            lblInput.Name = "lblInput";
            lblInput.Size = new Size(350, 20);
            lblInput.TabIndex = 2;
            lblInput.Text = "输入文本 (将被转换为JSON字符串):";
            // 
            // txtInputText
            // 
            txtInputText.AcceptsReturn = true;
            txtInputText.AcceptsTab = true;
            txtInputText.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtInputText.BackColor = Color.FromArgb(49, 50, 68);
            txtInputText.BorderStyle = BorderStyle.FixedSingle;
            txtInputText.Font = new Font("Cascadia Code", 9F);
            txtInputText.ForeColor = Color.FromArgb(205, 214, 244);
            txtInputText.Location = new Point(20, 110);
            txtInputText.Multiline = true;
            txtInputText.Name = "txtInputText";
            txtInputText.ScrollBars = ScrollBars.Both;
            txtInputText.Size = new Size(740, 200);
            txtInputText.TabIndex = 3;
            txtInputText.WordWrap = false;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = Color.FromArgb(137, 180, 250);
            btnConvert.FlatAppearance.BorderSize = 0;
            btnConvert.FlatStyle = FlatStyle.Flat;
            btnConvert.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnConvert.ForeColor = Color.FromArgb(30, 30, 46);
            btnConvert.Location = new Point(20, 320);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(120, 30);
            btnConvert.TabIndex = 4;
            btnConvert.Text = "🔄 转换预览";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Cursor = Cursors.Hand;
            // 
            // lblPreview
            // 
            lblPreview.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblPreview.ForeColor = Color.FromArgb(203, 166, 247);
            lblPreview.Location = new Point(20, 360);
            lblPreview.Name = "lblPreview";
            lblPreview.Size = new Size(350, 20);
            lblPreview.TabIndex = 5;
            lblPreview.Text = "转换预览 (转义后的JSON字符串):";
            // 
            // txtPreview
            // 
            txtPreview.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPreview.BackColor = Color.FromArgb(49, 50, 68);
            txtPreview.BorderStyle = BorderStyle.FixedSingle;
            txtPreview.Font = new Font("Cascadia Code", 9F);
            txtPreview.ForeColor = Color.FromArgb(166, 227, 161);
            txtPreview.Location = new Point(20, 385);
            txtPreview.Multiline = true;
            txtPreview.Name = "txtPreview";
            txtPreview.ReadOnly = true;
            txtPreview.ScrollBars = ScrollBars.Both;
            txtPreview.Size = new Size(740, 150);
            txtPreview.TabIndex = 6;
            txtPreview.WordWrap = false;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.BackColor = Color.FromArgb(166, 227, 161);
            btnOk.DialogResult = DialogResult.OK;
            btnOk.FlatAppearance.BorderSize = 0;
            btnOk.FlatStyle = FlatStyle.Flat;
            btnOk.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnOk.ForeColor = Color.FromArgb(30, 30, 46);
            btnOk.Location = new Point(540, 555);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(130, 40);
            btnOk.TabIndex = 7;
            btnOk.Text = "✅ 插入到Body";
            btnOk.UseVisualStyleBackColor = false;
            btnOk.Cursor = Cursors.Hand;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.BackColor = Color.FromArgb(166, 173, 200);
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(30, 30, 46);
            btnCancel.Location = new Point(680, 555);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(80, 40);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "取消";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Cursor = Cursors.Hand;
            // 
            // TextToJsonDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            CancelButton = btnCancel;
            ClientSize = new Size(800, 650);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txtPreview);
            Controls.Add(lblPreview);
            Controls.Add(btnConvert);
            Controls.Add(txtInputText);
            Controls.Add(lblInput);
            Controls.Add(txtFieldName);
            Controls.Add(lblFieldName);
            FormBorderStyle = FormBorderStyle.Sizable;
            MinimumSize = new Size(600, 500);
            Name = "TextToJsonDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "📝 文本转JSON字段";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFieldName;
        private TextBox txtInputText;
        private TextBox txtPreview;
        private Button btnConvert;
        private Button btnOk;
        private Button btnCancel;
    }
}
