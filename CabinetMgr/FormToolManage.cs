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
    public partial class FormToolManage : UIForm
    {
        public FormToolManage()
        {
            InitializeComponent();
        }

        private void FormToolManage_Load(object sender, EventArgs e)
        {
            LoadToolInfo();
        }

        private void FormToolManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        private void uiButtonAdd_Click(object sender, EventArgs e)
        {
            if (AppRt.RoleSettings.FirstOrDefault(x => x.RoleId == PresetRole.Admin || x.RoleId == PresetRole.ToolEditor) == null)
            {
                UIMessageBox.Show("您的权限不足");
                return;
            }
            FormToolEdit formToolEdit = FormToolEdit.Instance("新建工具");
            formToolEdit.ShowDialog();
            LoadToolInfo();
        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            if (AppRt.RoleSettings.FirstOrDefault(x => x.RoleId == PresetRole.Admin || x.RoleId == PresetRole.ToolEditor) == null)
            {
                UIMessageBox.Show("您的权限不足");
                return;
            }
            var selectRow = uiDataGridViewToolInfo.SelectedRows[0];
            ToolInfo ti = selectRow.DataBoundItem as ToolInfo;
            FormToolEdit formToolEdit = FormToolEdit.Instance("新建工具");
            formToolEdit.LoadData(ti.Id);
            formToolEdit.ShowDialog();
            LoadToolInfo();
        }

        private void uiButtonDel_Click(object sender, EventArgs e)
        {
            if (AppRt.RoleSettings.FirstOrDefault(x => x.RoleId == PresetRole.Admin || x.RoleId == PresetRole.ToolEditor) == null)
            {
                UIMessageBox.Show("您的权限不足");
                return;
            }
            if (uiDataGridViewToolInfo.SelectedRows.Count == 0) { UIMessageBox.ShowError("请选择要删除的工具", true, true); return; }
            if (!UIMessageBox.Show("是否确定删除?该操作不可撤销", "警告", buttons: UIMessageBoxButtons.OKCancel, showMask: true, topMost: true)) return;
            var selectRow = uiDataGridViewToolInfo.SelectedRows[0];
            ToolInfo ti = selectRow.DataBoundItem as ToolInfo;
            int result = BllToolInfo.DeleteToolInfo(ti.Id, out Exception ex);
            if (result <= 0)
            {
                UIMessageBox.ShowError($"删除失败，原因：{ex.Message}", true, true);
                return;
            }
            LoadToolInfo();
        }


        private void LoadToolInfo()
        {

            IList<ToolInfo> toolList = BllToolInfo.SearchToolInfo("", 0, -1, null, out Exception ex);
            uiDataGridViewToolInfo.DataSource = toolList;

            uiDataGridViewToolInfo.Columns["Id"].Visible = false;
            uiDataGridViewToolInfo.Columns["LatticeId"].Visible = false;
            uiDataGridViewToolInfo.Columns["ToolSpec"].Visible = false;
            uiDataGridViewToolInfo.Columns["ToolTypeId"].Visible = false;
            uiDataGridViewToolInfo.Columns["HardwareId"].Visible = false;
            uiDataGridViewToolInfo.Columns["CardId"].Visible = false;
            uiDataGridViewToolInfo.Columns["ToolManager"].Visible = false;
            uiDataGridViewToolInfo.Columns["Operator"].Visible = false;
            uiDataGridViewToolInfo.Columns["ToolStatus"].Visible = false;
            uiDataGridViewToolInfo.Columns["Operator"].Visible = false;

            uiDataGridViewToolInfo.Columns["ToolName"].HeaderText = "工具名称";
            uiDataGridViewToolInfo.Columns["ToolCode"].HeaderText = "工具编号";
            uiDataGridViewToolInfo.Columns["LatticePosition"].HeaderText = "储物柜";
            uiDataGridViewToolInfo.Columns["ToolTypeName"].HeaderText = "工具类型";
            uiDataGridViewToolInfo.Columns["ToolCount"].HeaderText = "工具数量";
            uiDataGridViewToolInfo.Columns["CurrentCount"].HeaderText = "当前数量";
            uiDataGridViewToolInfo.Columns["Comment"].HeaderText = "备注";
            uiDataGridViewToolInfo.Columns["OperatorName"].HeaderText = "修改人";
            uiDataGridViewToolInfo.Columns["OperateTime"].HeaderText = "修改时间";
        }

    }
}
