using CabinetMgr.BLL;
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
using Utilities.Control;

namespace CabinetMgr
{
    public partial class FormToolEdit : UIForm
    {

        public static FormToolEdit formToolEdit;

        public FormToolEdit()
        {
            InitializeComponent();
        }

        public static FormToolEdit Instance(string formTitle = "新建工具")
        {
            if (formToolEdit == null || formToolEdit.IsDisposed) formToolEdit = new FormToolEdit();
            formToolEdit.Text = formTitle;
            return formToolEdit;
        }

        private void LoadToolType()
        {
            IList<ToolType> toolTypes = BllToolType.SearchToolType(0, -1, null, out _);
            uiComboBoxToolType.DataSource = toolTypes;
            uiComboBoxToolType.ValueMember = "Id";
            uiComboBoxToolType.DisplayMember = "TypeName";
        }

        private void LoadLattice()
        {
            IList<LatticeInfo> latticeInfos = BllLatticeInfo.SearchLatticeInfo(0, -1, null, out _);
            uiComboBoxToolLattice.DataSource = latticeInfos;
            uiComboBoxToolLattice.ValueMember = "Id";
            uiComboBoxToolLattice.DisplayMember = "LatticePosition";
        }

        public void LoadData(string id)
        {
            uiTextBoxId.Text = id;
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            int result;
            Exception ex;
            if (string.IsNullOrEmpty(uiTextBoxId.Text)) result = InsertEntity(out ex);
            else result = UpdateEntity(out ex);
            if(result <= 0)
            {
                MessageBox.Show(ex.Message, "保存失败");
                return;
            }
            FormReset();
            Hide();
        }

        private int InsertEntity(out Exception exception)
        {
            ToolInfo info = new ToolInfo()
            {
                Id = Guid.NewGuid().ToString(),
                ToolName = uiTextBoxToolName.Text.Trim(),
                ToolCode = uiTextBoxToolCode.Text.Trim(),
                ToolCount = int.Parse(uiTextBoxToolCount.Text.Trim()),
                CurrentCount = int.Parse(uiTextBoxToolCount.Text.Trim()),
                ToolTypeId = (long)uiComboBoxToolType.SelectedValue,
                ToolTypeName = uiComboBoxToolType.Text,
                LatticeId = (long)uiComboBoxToolLattice.SelectedValue,
                LatticePosition = uiComboBoxToolLattice.Text,
                Comment = uiRichTextBoxComment.Text,
                Operator = AppRt.CurUser.ID,
                OperatorName = AppRt.CurUser.FullName,
                OperateTime = DateTime.Now
            };
            return BllToolInfo.SaveToolInfo(info, out exception);
        }

        private int UpdateEntity(out Exception exception)
        {
            ToolInfo info = BllToolInfo.GetToolInfo(uiTextBoxId.Text, out exception);
            info.ToolName = uiTextBoxToolName.Text.Trim();
            info.ToolCode = uiTextBoxToolCode.Text.Trim();
            info.ToolCount = int.Parse(uiTextBoxToolCount.Text.Trim());
            info.CurrentCount = int.Parse(uiTextBoxToolCount.Text.Trim());
            info.ToolTypeId = (long)uiComboBoxToolType.SelectedValue;
            info.ToolTypeName = uiComboBoxToolType.Text;
            info.LatticeId = (long)uiComboBoxToolLattice.SelectedValue;
            info.LatticePosition = uiComboBoxToolLattice.Text;
            info.Comment = uiRichTextBoxComment.Text;

            info.Operator = AppRt.CurUser.ID;
            info.OperatorName = AppRt.CurUser.FullName;
            info.OperateTime = DateTime.Now;
            return BllToolInfo.UpdateToolInfo(info, out exception);
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            FormReset();
            Hide();
        }

        private void FormReset()
        {
            uiTextBoxId.Text = "";
            uiTextBoxToolName.Text = "";
            uiTextBoxToolCode.Text = "";
            uiTextBoxToolCount.Text = "0";
            uiComboBoxToolType.SelectedIndex = -1;
            uiComboBoxToolLattice.SelectedIndex = -1;
            
        }

        private void FormToolEdit_Load(object sender, EventArgs e)
        {
            LoadToolType();
            LoadLattice();
            if (!string.IsNullOrEmpty(uiTextBoxId.Text))
            {
                ToolInfo ti = BllToolInfo.GetToolInfo(uiTextBoxId.Text, out _);
                if (ti == null) return;
                uiTextBoxToolName.Text = ti.ToolName;
                uiTextBoxToolCode.Text = ti.ToolCode;
                uiTextBoxToolCount.Text = ti.ToolCount.ToString();
                uiComboBoxToolType.SelectedValue = ti.ToolTypeId;
                uiComboBoxToolLattice.SelectedValue = ti.LatticeId;
                uiRichTextBoxComment.Text = ti.Comment;
            }
        }

        private void FormToolEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormReset();
            Hide();
        }
    }
}
