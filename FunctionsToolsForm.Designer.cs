namespace APITestTool
{
    partial class FunctionsToolsForm
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
            Label lblTitle = new Label();
            Label lblFunctionList = new Label();
            lstFunctions = new ListBox();
            Label lblFunctionName = new Label();
            txtFunctionName = new TextBox();
            Label lblFunctionDescription = new Label();
            txtFunctionDescription = new TextBox();
            Label lblFunctionParameters = new Label();
            txtFunctionParameters = new TextBox();
            btnAddFunction = new Button();
            btnSaveFunction = new Button();
            btnDeleteFunction = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Cascadia Code", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(166, 227, 161);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔧 Functions 管理";
            // 
            // lblFunctionList
            // 
            lblFunctionList.AutoSize = true;
            lblFunctionList.Font = new Font("Cascadia Code", 10F, FontStyle.Bold);
            lblFunctionList.ForeColor = Color.FromArgb(166, 173, 200);
            lblFunctionList.Location = new Point(20, 60);
            lblFunctionList.Name = "lblFunctionList";
            lblFunctionList.Size = new Size(120, 18);
            lblFunctionList.TabIndex = 1;
            lblFunctionList.Text = "Function 列表:";
            // 
            // lstFunctions
            // 
            lstFunctions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstFunctions.BackColor = Color.FromArgb(49, 50, 68);
            lstFunctions.BorderStyle = BorderStyle.FixedSingle;
            lstFunctions.Font = new Font("Cascadia Code", 9F);
            lstFunctions.ForeColor = Color.FromArgb(205, 214, 244);
            lstFunctions.FormattingEnabled = true;
            lstFunctions.ItemHeight = 16;
            lstFunctions.Location = new Point(20, 85);
            lstFunctions.Name = "lstFunctions";
            lstFunctions.Size = new Size(760, 290);
            lstFunctions.TabIndex = 2;
            lstFunctions.SelectedIndexChanged += LstFunctions_SelectedIndexChanged;
            // 
            // lblFunctionName
            // 
            lblFunctionName.AutoSize = true;
            lblFunctionName.Font = new Font("Cascadia Code", 10F);
            lblFunctionName.ForeColor = Color.FromArgb(166, 173, 200);
            lblFunctionName.Location = new Point(20, 390);
            lblFunctionName.Name = "lblFunctionName";
            lblFunctionName.Size = new Size(100, 18);
            lblFunctionName.TabIndex = 3;
            lblFunctionName.Text = "Function 名称:";
            // 
            // txtFunctionName
            // 
            txtFunctionName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFunctionName.BackColor = Color.FromArgb(49, 50, 68);
            txtFunctionName.BorderStyle = BorderStyle.FixedSingle;
            txtFunctionName.Font = new Font("Cascadia Code", 10F);
            txtFunctionName.ForeColor = Color.FromArgb(205, 214, 244);
            txtFunctionName.Location = new Point(20, 415);
            txtFunctionName.Name = "txtFunctionName";
            txtFunctionName.Size = new Size(760, 23);
            txtFunctionName.TabIndex = 4;
            // 
            // lblFunctionDescription
            // 
            lblFunctionDescription.AutoSize = true;
            lblFunctionDescription.Font = new Font("Cascadia Code", 10F);
            lblFunctionDescription.ForeColor = Color.FromArgb(166, 173, 200);
            lblFunctionDescription.Location = new Point(20, 450);
            lblFunctionDescription.Name = "lblFunctionDescription";
            lblFunctionDescription.Size = new Size(100, 18);
            lblFunctionDescription.TabIndex = 5;
            lblFunctionDescription.Text = "描述:";
            // 
            // txtFunctionDescription
            // 
            txtFunctionDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFunctionDescription.BackColor = Color.FromArgb(49, 50, 68);
            txtFunctionDescription.BorderStyle = BorderStyle.FixedSingle;
            txtFunctionDescription.Font = new Font("Cascadia Code", 10F);
            txtFunctionDescription.ForeColor = Color.FromArgb(205, 214, 244);
            txtFunctionDescription.Location = new Point(20, 475);
            txtFunctionDescription.Multiline = true;
            txtFunctionDescription.Name = "txtFunctionDescription";
            txtFunctionDescription.Size = new Size(760, 60);
            txtFunctionDescription.TabIndex = 6;
            // 
            // lblFunctionParameters
            // 
            lblFunctionParameters.AutoSize = true;
            lblFunctionParameters.Font = new Font("Cascadia Code", 10F);
            lblFunctionParameters.ForeColor = Color.FromArgb(166, 173, 200);
            lblFunctionParameters.Location = new Point(20, 545);
            lblFunctionParameters.Name = "lblFunctionParameters";
            lblFunctionParameters.Size = new Size(200, 18);
            lblFunctionParameters.TabIndex = 7;
            lblFunctionParameters.Text = "参数 (JSON Schema):";
            // 
            // txtFunctionParameters
            // 
            txtFunctionParameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtFunctionParameters.BackColor = Color.FromArgb(49, 50, 68);
            txtFunctionParameters.BorderStyle = BorderStyle.FixedSingle;
            txtFunctionParameters.Font = new Font("Cascadia Code", 9F);
            txtFunctionParameters.ForeColor = Color.FromArgb(205, 214, 244);
            txtFunctionParameters.Location = new Point(20, 570);
            txtFunctionParameters.Multiline = true;
            txtFunctionParameters.Name = "txtFunctionParameters";
            txtFunctionParameters.ScrollBars = ScrollBars.Both;
            txtFunctionParameters.Size = new Size(760, 200);
            txtFunctionParameters.TabIndex = 8;
            // 
            // btnAddFunction
            // 
            btnAddFunction.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddFunction.BackColor = Color.FromArgb(166, 227, 161);
            btnAddFunction.Cursor = Cursors.Hand;
            btnAddFunction.FlatAppearance.BorderSize = 0;
            btnAddFunction.FlatStyle = FlatStyle.Flat;
            btnAddFunction.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnAddFunction.ForeColor = Color.FromArgb(24, 24, 37);
            btnAddFunction.Location = new Point(20, 790);
            btnAddFunction.Name = "btnAddFunction";
            btnAddFunction.Size = new Size(95, 30);
            btnAddFunction.TabIndex = 9;
            btnAddFunction.Text = "➕ 新增";
            btnAddFunction.UseVisualStyleBackColor = false;
            btnAddFunction.Click += BtnAddFunction_Click;
            // 
            // btnSaveFunction
            // 
            btnSaveFunction.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveFunction.BackColor = Color.FromArgb(137, 180, 250);
            btnSaveFunction.Cursor = Cursors.Hand;
            btnSaveFunction.FlatAppearance.BorderSize = 0;
            btnSaveFunction.FlatStyle = FlatStyle.Flat;
            btnSaveFunction.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnSaveFunction.ForeColor = Color.FromArgb(24, 24, 37);
            btnSaveFunction.Location = new Point(125, 790);
            btnSaveFunction.Name = "btnSaveFunction";
            btnSaveFunction.Size = new Size(95, 30);
            btnSaveFunction.TabIndex = 10;
            btnSaveFunction.Text = "💾 保存";
            btnSaveFunction.UseVisualStyleBackColor = false;
            btnSaveFunction.Click += BtnSaveFunction_Click;
            // 
            // btnDeleteFunction
            // 
            btnDeleteFunction.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteFunction.BackColor = Color.FromArgb(243, 139, 168);
            btnDeleteFunction.Cursor = Cursors.Hand;
            btnDeleteFunction.FlatAppearance.BorderSize = 0;
            btnDeleteFunction.FlatStyle = FlatStyle.Flat;
            btnDeleteFunction.Font = new Font("Cascadia Code", 9F, FontStyle.Bold);
            btnDeleteFunction.ForeColor = Color.FromArgb(24, 24, 37);
            btnDeleteFunction.Location = new Point(230, 790);
            btnDeleteFunction.Name = "btnDeleteFunction";
            btnDeleteFunction.Size = new Size(95, 30);
            btnDeleteFunction.TabIndex = 11;
            btnDeleteFunction.Text = "🗑️ 删除";
            btnDeleteFunction.UseVisualStyleBackColor = false;
            btnDeleteFunction.Click += BtnDeleteFunction_Click;
            // 
            // FunctionsToolsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 37);
            ClientSize = new Size(800, 840);
            Controls.Add(btnDeleteFunction);
            Controls.Add(btnSaveFunction);
            Controls.Add(btnAddFunction);
            Controls.Add(txtFunctionParameters);
            Controls.Add(lblFunctionParameters);
            Controls.Add(txtFunctionDescription);
            Controls.Add(lblFunctionDescription);
            Controls.Add(txtFunctionName);
            Controls.Add(lblFunctionName);
            Controls.Add(lstFunctions);
            Controls.Add(lblFunctionList);
            Controls.Add(lblTitle);
            MinimumSize = new Size(800, 840);
            Name = "FunctionsToolsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🔧 Functions 管理工具";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstFunctions;
        private TextBox txtFunctionName;
        private TextBox txtFunctionDescription;
        private TextBox txtFunctionParameters;
        private Button btnAddFunction;
        private Button btnSaveFunction;
        private Button btnDeleteFunction;
    }
}
