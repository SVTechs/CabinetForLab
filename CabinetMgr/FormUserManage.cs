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
    public partial class FormUserManage : UIForm
    {
        public FormUserManage()
        {
            InitializeComponent();
        }

        private void FormUserManage_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            IList<UserInfo> userList = BllUserInfo.SearchUserInfo(0, -1, null, out Exception ex);
            uiDataGridViewUser.DataSource = userList;
            uiDataGridViewUser.Columns["ID"].Visible = false;
            uiDataGridViewUser.Columns["Password"].Visible = false;
            uiDataGridViewUser.Columns["Age"].Visible = false;
            uiDataGridViewUser.Columns["Tel"].Visible = false;
            uiDataGridViewUser.Columns["Address"].Visible = false;
            uiDataGridViewUser.Columns["UserState"].Visible = false;
            uiDataGridViewUser.Columns["Image"].Visible = false;
            uiDataGridViewUser.Columns["FaceFeature"].Visible = false;
            uiDataGridViewUser.Columns["FingerFeature"].Visible = false;
            uiDataGridViewUser.Columns["BDFaceFeature"].Visible = false;

            uiDataGridViewUser.Columns["UserName"].HeaderText = "工号";
            uiDataGridViewUser.Columns["FullName"].HeaderText = "姓名";
            uiDataGridViewUser.Columns["Sex"].HeaderText = "性别";
            uiDataGridViewUser.Columns["CreateTime"].HeaderText = "创建时间";
            uiDataGridViewUser.Columns["CreateUser"].HeaderText = "创建人";
            uiDataGridViewUser.Columns["UpdateTime"].HeaderText = "修改时间";
            uiDataGridViewUser.Columns["UpdateUser"].HeaderText = "修改人";
            uiDataGridViewUser.Columns["CardNum"].HeaderText = "卡号";
            uiDataGridViewUser.Columns["UserStateResult"].HeaderText = "状态";
            uiDataGridViewUser.Columns["HasImage"].HeaderText = "面部";
            uiDataGridViewUser.Columns["HasFingerFeature"].HeaderText = "指纹";
        }

        private void uiButtonAdd_Click(object sender, EventArgs e)
        {
            FormUserEdit formUserEdit = FormUserEdit.Instance();
            formUserEdit.ShowDialog();
            LoadUser();
        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            if(uiDataGridViewUser.SelectedRows.Count == 0) UIMessageBox.ShowError("请选择要编辑的人员", true, true);
            var selectRow = uiDataGridViewUser.SelectedRows[0];
            UserInfo ui = selectRow.DataBoundItem as UserInfo;
            FormUserEdit formUserEdit = FormUserEdit.Instance(ui.UserName);
            formUserEdit.ShowDialog();
            LoadUser();
        }

        private void uiButtonDel_Click(object sender, EventArgs e)
        {
            if (uiDataGridViewUser.SelectedRows.Count == 0) { UIMessageBox.ShowError("请选择要删除的人员", true, true); return; }
            if (!UIMessageBox.Show("是否确定删除?该操作不可撤销", "警告", buttons: UIMessageBoxButtons.OKCancel, showMask: true, topMost: true)) return;
            var selectRow = uiDataGridViewUser.SelectedRows[0];
            UserInfo ui = selectRow.DataBoundItem as UserInfo;
            int result = BllUserInfo.DeleteUserInfo(ui.ID, out Exception ex);
            if(result <= 0)
            {
                UIMessageBox.ShowError($"删除失败，原因：{ex.Message}", true, true);
                return;
            }
            LoadUser();

        }

        private void uiButtonRole_Click(object sender, EventArgs e)
        {
            if (uiDataGridViewUser.SelectedRows.Count == 0) UIMessageBox.ShowError("请选择要编辑的人员", true, true);
            var selectRow = uiDataGridViewUser.SelectedRows[0];
            UserInfo ui = selectRow.DataBoundItem as UserInfo;
            FormUserRoleManage formUserRoleManage = FormUserRoleManage.Instance(ui.ID);
            formUserRoleManage.ShowDialog();
        }

        private void uiButtonLattice_Click(object sender, EventArgs e)
        {
            if (uiDataGridViewUser.SelectedRows.Count == 0) UIMessageBox.ShowError("请选择要编辑的人员", true, true);
            var selectRow = uiDataGridViewUser.SelectedRows[0];
            UserInfo ui = selectRow.DataBoundItem as UserInfo;
            FormLatticePermissionManage formLatticePermissionManage = FormLatticePermissionManage.Instance(ui.ID, "UserId");
            formLatticePermissionManage.ShowDialog();
        }
    }
}
