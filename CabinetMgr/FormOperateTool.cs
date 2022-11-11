using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormOperateTool : Form
    {
        private static FormOperateTool formOperateTool;
        private static string cabinetName;
        private static string toolId;
        private static string operateType = "Borrow";

        public static FormOperateTool Instance(string inputValue)
        {
            if (formOperateTool == null || formOperateTool.IsDisposed) formOperateTool = new FormOperateTool();
            cabinetName = inputValue.Split('|')[0];
            toolId = inputValue.Split('|')[1];
            return formOperateTool;
        }

        public FormOperateTool()
        {
            InitializeComponent();
            uiRadioButtonBorrrow.CheckedChanged += uiRadioButton_CheckedChanged;
            uiRadioButtonReturn.CheckedChanged += uiRadioButton_CheckedChanged;
            uiRadioButtonRepair.CheckedChanged += uiRadioButton_CheckedChanged;
            uiRadioButtonLack.CheckedChanged += uiRadioButton_CheckedChanged;
        }

        private void FormOperateTool_Shown(object sender, EventArgs e)
        {
            uiLabelCurrentSelect.Text = $"当前选择  {cabinetName}";
            uiRadioButtonBorrrow.Checked = true;
            uiRadioButtonReturn.Checked = false;
            uiRadioButtonRepair.Checked = false;
            uiRadioButtonLack.Checked = false;
            uiTextBoxAmount.Text = "1";
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void uiButtonConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBoxAmount.Text))
            {
                UIMessageBox.ShowWarning("请输入数量");
                return;
            }
            int toolCount = int.Parse(uiTextBoxAmount.Text);
            ToolInfo toolInfo = BllToolInfo.GetToolInfo(toolId, out Exception ex);
            Info info;
            int result = -1;
            switch (operateType)
            {
                case "Borrow":
                    result = BllBorrowRecord.AddBorrowRecord(toolInfo, AppRt.CurUser, out ex, 0, toolCount);
                    if (toolInfo.WarnType == 1 && toolCount > toolInfo.WarnValue) BllInfo.SaveInfo(new Info() { Id = Guid.NewGuid().ToString(), InfoContent = $"{toolInfo.ToolName}借用超量", InfoType = 1, CreateTime = DateTime.Now, IsTop = 0 }, out _);
                    break;
                case "Return":
                    result = BllReturnRecord.AddReturnRecord(toolInfo, AppRt.CurUser, out ex, toolCount);
                    break;
                case "Repair":
                    result = BllBorrowRecord.AddBorrowRecord(toolInfo, AppRt.CurUser, out ex, -10, toolCount);
                    info = new Info()
                    {
                        Id = Guid.NewGuid().ToString().ToUpper(),
                        InfoContent = $"{toolInfo.LatticePosition}的{toolInfo.ToolName}需要维修",
                        InfoType = 1,
                        CreateTime = DateTime.Now
                    };
                    result += BllInfo.SaveInfo(info, out ex);
                    break;
                case "Lack":
                    result = BllBorrowRecord.AddBorrowRecord(toolInfo, AppRt.CurUser, out ex, -20, toolCount);
                    info = new Info()
                    {
                        Id = Guid.NewGuid().ToString().ToUpper(),
                        InfoContent = $"{toolInfo.LatticePosition}缺少{toolInfo.ToolName}",
                        InfoType = 2,
                        CreateTime = DateTime.Now
                    };
                    result += BllInfo.SaveInfo(info, out ex);
                    break;
            }

            if(result <= 0)
            {
                UIMessageBox.ShowError($"提交失败，原因为:\n{ex.Message}");
                return;
            }
            (AppRt.FormMain._loginForm as FormLogin).LoadInfo();
            (AppRt.FormMain._indexForm as FormIndex0).ReloadData();
            Dispose();

        }

        private void uiTextBoxAmount_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void FormOperateTool_FormClosed(object sender, FormClosedEventArgs e)
        {
            Osk.HideInputPanel();
        }

        private void uiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UIRadioButton radioButton = sender as UIRadioButton;
            if (radioButton.Checked) operateType = radioButton.Tag as string;
        }
    }
}
