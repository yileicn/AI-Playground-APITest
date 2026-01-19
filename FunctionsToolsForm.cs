using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace APITestTool
{
    /// <summary>
    /// Functions 工具管理窗体
    /// </summary>
    public partial class FunctionsToolsForm : Form
    {
        private List<FunctionDefinition> _functions = new();
        private FunctionDefinition? _selectedFunction;

        // 颜色主题 (Catppuccin Mocha)
        private static readonly Color BgDark = Color.FromArgb(24, 24, 37);
        private static readonly Color BgMedium = Color.FromArgb(30, 30, 46);
        private static readonly Color BgLight = Color.FromArgb(49, 50, 68);
        private static readonly Color TextPrimary = Color.FromArgb(205, 214, 244);
        private static readonly Color TextSecondary = Color.FromArgb(166, 173, 200);
        private static readonly Color AccentGreen = Color.FromArgb(166, 227, 161);
        private static readonly Color AccentBlue = Color.FromArgb(137, 180, 250);
        private static readonly Color AccentPink = Color.FromArgb(245, 194, 231);
        private static readonly Color AccentPurple = Color.FromArgb(203, 166, 247);
        private static readonly Color AccentYellow = Color.FromArgb(249, 226, 175);
        private static readonly Color AccentRed = Color.FromArgb(243, 139, 168);
        private static readonly Color AccentTeal = Color.FromArgb(148, 226, 213);

        public FunctionsToolsForm(List<FunctionDefinition>? initialFunctions = null)
        {
            InitializeComponent();
            _functions = initialFunctions != null ? new List<FunctionDefinition>(initialFunctions) : new List<FunctionDefinition>();
            RefreshFunctionList();
        }

        private void RefreshFunctionList()
        {
            lstFunctions.Items.Clear();
            foreach (var func in _functions)
            {
                lstFunctions.Items.Add($"{func.Name} - {func.Description}");
            }
        }

        private void BtnAddFunction_Click(object? sender, EventArgs e)
        {
            ClearForm();
            _selectedFunction = null;
        }

        private void BtnSaveFunction_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFunctionName.Text))
            {
                MessageBox.Show("请输入 Function 名称", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFunctionDescription.Text))
            {
                MessageBox.Show("请输入 Function 描述", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFunctionParameters.Text))
            {
                MessageBox.Show("请输入 Function 参数（JSON Schema）", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 验证 JSON 格式
            try
            {
                JsonConvert.DeserializeObject(txtFunctionParameters.Text);
            }
            catch
            {
                MessageBox.Show("参数格式不正确，请输入有效的 JSON Schema", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var function = new FunctionDefinition
            {
                Name = txtFunctionName.Text.Trim(),
                Description = txtFunctionDescription.Text.Trim(),
                Parameters = txtFunctionParameters.Text.Trim()
            };

            if (_selectedFunction != null)
            {
                // 更新现有 Function
                var index = _functions.FindIndex(f => f.Name == _selectedFunction.Name);
                if (index >= 0)
                {
                    _functions[index] = function;
                }
            }
            else
            {
                // 检查名称是否已存在
                if (_functions.Any(f => f.Name == function.Name))
                {
                    MessageBox.Show("Function 名称已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                _functions.Add(function);
            }

            RefreshFunctionList();
            ClearForm();
            MessageBox.Show("Function 保存成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void BtnDeleteFunction_Click(object? sender, EventArgs e)
        {
            if (_selectedFunction == null)
            {
                MessageBox.Show("请先选择一个 Function", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"确定要删除 Function \"{_selectedFunction.Name}\" 吗？",
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                _functions.RemoveAll(f => f.Name == _selectedFunction.Name);
                RefreshFunctionList();
                ClearForm();
                _selectedFunction = null;
                DialogResult = DialogResult.OK;
            }
        }


        private void LstFunctions_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lstFunctions.SelectedIndex >= 0 && lstFunctions.SelectedIndex < _functions.Count)
            {
                _selectedFunction = _functions[lstFunctions.SelectedIndex];
                LoadFunctionToForm(_selectedFunction);
            }
        }

        private void LoadFunctionToForm(FunctionDefinition function)
        {
            txtFunctionName.Text = function.Name;
            txtFunctionDescription.Text = function.Description;
            txtFunctionParameters.Text = function.Parameters;
        }

        private void ClearForm()
        {
            txtFunctionName.Clear();
            txtFunctionDescription.Clear();
            txtFunctionParameters.Clear();
            lstFunctions.ClearSelected();
        }

        /// <summary>
        /// 获取所有 Functions（供外部调用）
        /// </summary>
        public List<FunctionDefinition> GetFunctions()
        {
            return new List<FunctionDefinition>(_functions);
        }
    }
}
