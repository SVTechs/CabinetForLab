using CabinetMgr.BLL;
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
    public partial class FormRoleEditOld : UIForm
    {

        public static FormRoleEditOld formRoleEdit;

        public FormRoleEditOld()
        {
            InitializeComponent();
        }

        public static FormRoleEditOld Instance(string formTitle = "新建角色")
        {
            if (formRoleEdit == null || formRoleEdit.IsDisposed) formRoleEdit = new FormRoleEditOld();
            formRoleEdit.Text = formTitle;
            return formRoleEdit;
        }

        public void LoadData(string id, string parentId)
        {
            uiTextBoxId.Text = id;
            uiTextBoxParentId.Text = parentId;
            RoleInfo ri = BllRoleInfo.GetRoleInfo(id, out _);
            if (ri == null) return;
            uiTextBoxRoleName.Text = ri.RoleName;
            uiRichTextBoxRoleDesp.Text = ri.RoleDesp;
            uiTextBoxRoleOrder.Text = ri.RoleOrder.ToString();
            uiCheckBoxRoleIsEnable.Checked = ri.IsEnabled == 1;
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            int result = -1;
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
            RoleInfo parentInfo;
            if (uiTextBoxParentId.Text == "-") parentInfo = new RoleInfo() { Id = null, TreeLevel = -1 };
            else parentInfo = BllRoleInfo.GetRoleInfo(uiTextBoxParentId.Text, out exception);
            RoleInfo info = new RoleInfo()
            {
                Id = Guid.NewGuid().ToString(),
                RoleName = uiTextBoxRoleName.Text.Trim(),
                RoleDesp = uiRichTextBoxRoleDesp.Text.Trim(),
                RoleOrder = int.Parse(uiTextBoxRoleOrder.Text),
                IsEnabled = uiCheckBoxRoleIsEnable.Checked ? 1 : 0,
                TreeLevel = parentInfo.TreeLevel + 1,
                TreeParent = parentInfo.Id,
                LastChanged = DateTime.Now
            };
            return BllRoleInfo.SaveRoleInfo(info, out exception);
        }

        private int UpdateEntity(out Exception exception)
        {
            RoleInfo info = BllRoleInfo.GetRoleInfo(uiTextBoxId.Text, out exception);
            info.RoleName = uiTextBoxRoleName.Text.Trim();
            info.RoleDesp = uiRichTextBoxRoleDesp.Text.Trim();
            info.RoleOrder = int.Parse(uiTextBoxRoleOrder.Text);
            info.IsEnabled = uiCheckBoxRoleIsEnable.Checked ? 1 : 0;
            info.LastChanged = DateTime.Now;
            return BllRoleInfo.UpdateRoleInfo(info, out exception);
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            FormReset();
            Hide();
        }

        private void FormReset()
        {
            uiTextBoxId.Text = "";
            uiTextBoxParentId.Text = "";
            uiTextBoxRoleName.Text = "";
            uiRichTextBoxRoleDesp.Text = "";
            uiTextBoxRoleOrder.Text = "0";
            uiCheckBoxRoleIsEnable.Checked = false;
        }
    }
}
