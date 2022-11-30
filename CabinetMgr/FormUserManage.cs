using CabinetMgr.BLL;
using CabinetMgr.Common;
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
        private static bool firstShown = true;

        public FormUserManage()
        {
            InitializeComponent();
            FormCallback.FormUserManageRefresh += FormRefresh;
            uiDataGridView.DataError += UiDataGridView_DataError;
            FormRefresh();
        }

        private void UiDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void FormUserManage_Load(object sender, EventArgs e)
        {

        }

        private void FormRefresh()
        {
            LoadData();
        }

        private void FormUserManage_Shown(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void LoadData()
        {
            IList<UserInfo> list = BllUserInfo.SearchUserInfo(0, -1, null, out Exception ex);
            ClearColumnsAndSetDataSource(list);
            SetColumns();
            //uiDataGridView.Columns.Clear();
            //uiDataGridView.DataSource = list;

            //uiDataGridView.Columns["ID"].Visible = false;
            //uiDataGridView.Columns["TemplateId"].Visible = false;
            //uiDataGridView.Columns["Password"].Visible = false;
            //uiDataGridView.Columns["Age"].Visible = false;
            //uiDataGridView.Columns["Tel"].Visible = false;
            //uiDataGridView.Columns["Address"].Visible = false;
            //uiDataGridView.Columns["UserState"].Visible = false;
            //uiDataGridView.Columns["Image"].Visible = false;
            //uiDataGridView.Columns["FaceFeature"].Visible = false;
            //uiDataGridView.Columns["FingerFeature"].Visible = false;
            //uiDataGridView.Columns["BDFaceFeature"].Visible = false;
            //uiDataGridView.Columns["IsProtected"].Visible = false;
            //uiDataGridView.Columns["UserStateResult"].Visible = false;
            //uiDataGridView.Columns["Sex"].Visible = false;
            //uiDataGridView.Columns["CreateTime"].Visible = false;
            //uiDataGridView.Columns["CreateUser"].Visible = false;
            //uiDataGridView.Columns["Updatetime"].Visible = false;
            //uiDataGridView.Columns["UpdateUser"].Visible = false;

            //uiDataGridView.Columns["UserName"].HeaderText = "工号";
            //uiDataGridView.Columns["FullName"].HeaderText = "姓名";
            //uiDataGridView.Columns["Sex"].HeaderText = "性别";
            //uiDataGridView.Columns["CreateTime"].HeaderText = "创建时间";
            //uiDataGridView.Columns["CreateUser"].HeaderText = "创建人";
            //uiDataGridView.Columns["UpdateTime"].HeaderText = "修改时间";
            //uiDataGridView.Columns["UpdateUser"].HeaderText = "修改人";
            //uiDataGridView.Columns["CardNum"].HeaderText = "卡号";
            //uiDataGridView.Columns["HasImage"].HeaderText = "面部";
            //uiDataGridView.Columns["HasFingerFeature"].HeaderText = "指纹";

            //DataGridViewButtonColumn column = new DataGridViewButtonColumn();
            //column.Name = "Edit";
            //column.HeaderText = "操作";
            //column.DefaultCellStyle.NullValue = "修改";
            //column.DefaultCellStyle.BackColor = Color.White;
            //column.DefaultCellStyle.ForeColor = Color.FromArgb(13, 71, 161);

            //uiDataGridView.Columns.Add(column);
        }

        private delegate void ClearColumnsAndSetDataSourceDelegate(IList<UserInfo> list);
        private void ClearColumnsAndSetDataSource(IList<UserInfo> list)
        {
            if (uiDataGridView.InvokeRequired)
            {
                ClearColumnsAndSetDataSourceDelegate d = ClearColumnsAndSetDataSource;
                uiDataGridView.Invoke(d, list);
            }
            else
            {
                try
                {
                    uiDataGridView.Columns.Clear();
                    uiDataGridView.DataSource = list;
                }
                catch(Exception ex)
                {

                }
                
            }
        }

        private delegate void SetColumnsDelegate();
        private void SetColumns()
        {
            if (uiDataGridView.InvokeRequired)
            {
                SetColumnsDelegate d = SetColumns;
                uiDataGridView.Invoke(d);
            }
            else
            {
                uiDataGridView.Columns["ID"].Visible = false;
                uiDataGridView.Columns["TemplateId"].Visible = false;
                uiDataGridView.Columns["Password"].Visible = false;
                uiDataGridView.Columns["Age"].Visible = false;
                uiDataGridView.Columns["Tel"].Visible = false;
                uiDataGridView.Columns["Address"].Visible = false;
                uiDataGridView.Columns["UserState"].Visible = false;
                uiDataGridView.Columns["Image"].Visible = false;
                uiDataGridView.Columns["FaceFeature"].Visible = false;
                uiDataGridView.Columns["FingerFeature"].Visible = false;
                uiDataGridView.Columns["BDFaceFeature"].Visible = false;
                uiDataGridView.Columns["IsProtected"].Visible = false;
                uiDataGridView.Columns["UserStateResult"].Visible = false;
                uiDataGridView.Columns["Sex"].Visible = false;
                uiDataGridView.Columns["CreateTime"].Visible = false;
                uiDataGridView.Columns["CreateUser"].Visible = false;
                uiDataGridView.Columns["Updatetime"].Visible = false;
                uiDataGridView.Columns["UpdateUser"].Visible = false;

                uiDataGridView.Columns["UserName"].HeaderText = "工号";
                uiDataGridView.Columns["FullName"].HeaderText = "姓名";
                uiDataGridView.Columns["Sex"].HeaderText = "性别";
                uiDataGridView.Columns["CreateTime"].HeaderText = "创建时间";
                uiDataGridView.Columns["CreateUser"].HeaderText = "创建人";
                uiDataGridView.Columns["UpdateTime"].HeaderText = "修改时间";
                uiDataGridView.Columns["UpdateUser"].HeaderText = "修改人";
                uiDataGridView.Columns["CardNum"].HeaderText = "卡号";
                uiDataGridView.Columns["HasImage"].HeaderText = "面部";
                uiDataGridView.Columns["HasFingerFeature"].HeaderText = "指纹";

                DataGridViewButtonColumn column = new DataGridViewButtonColumn();
                column.Name = "Edit";
                column.HeaderText = "操作";
                column.DefaultCellStyle.NullValue = "修改";
                column.DefaultCellStyle.BackColor = Color.White;
                column.DefaultCellStyle.ForeColor = Color.FromArgb(13, 71, 161);

                uiDataGridView.Columns.Add(column);
            }
        }

        private void uiButtonAddUser_Click(object sender, EventArgs e)
        {
            FormUserEdit formUserEdit = FormUserEdit.Instance("");
            formUserEdit.ShowDialog();
            //LoadData();
        }

        private void uiButtonRoleAdd_Click(object sender, EventArgs e)
        {
            FormRoleEdit formRoleEdit = FormRoleEdit.Instance();
            formRoleEdit.ShowDialog();
        }

        private void uiButtonDel_Click(object sender, EventArgs e)
        {
            if (uiDataGridView.SelectedRows.Count == 0) UIMessageBox.ShowError("请选择要编辑的人员", true, true);
            var selectRow = uiDataGridView.SelectedRows[0];
            UserInfo ui = selectRow.DataBoundItem as UserInfo;
            if (!UIMessageBox.ShowAsk("将删除该人员，该操作无法撤销", true, true)) return;
            int result = BllUserInfo.DeleteUserInfo(ui.ID, out Exception ex);
            if (result <= 0)
            {
                UIMessageBox.ShowError($"删除失败,原因：\n{ex.Message}", true, true);
                return;
            }
            LoadData();
        }

        private void uiDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (uiDataGridView.Columns[e.ColumnIndex].Name != "Edit") return;
            int i = e.RowIndex;
            UserInfo user = (uiDataGridView.DataSource as IList<UserInfo>)[i];
            FormUserEdit formUserEdit = FormUserEdit.Instance(user.ID);
            formUserEdit.ShowDialog();
            //LoadData();
        }

        private void FormUserManage_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && firstShown) { firstShown = false; return; }
            if (Visible) LoadData();
        }
    }
}
