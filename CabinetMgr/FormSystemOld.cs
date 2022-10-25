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
    public partial class FormSystemOld : UIForm
    {
        public static FormSystemOld formSystem;

        public static FormSystemOld Instance()
        {
            if (formSystem == null || formSystem.IsDisposed) formSystem = new FormSystemOld();
            return formSystem;
        }

        public FormSystemOld()
        {
            InitializeComponent();
        }

        private void FormSystem_Load(object sender, EventArgs e)
        {
            LoadRoleTree();
            LoadToolType();
        }

        private void FormSystem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        #region Role

        private void LoadRoleTree()
        {

            uiTreeViewRole.Nodes.Clear();
            TreeNode root = new TreeNode() { Text = "角色", Tag = "-|0", };
            var node = TreeManager.GetRoleNode();
            foreach (RoleInfo ri in node.TreeChildren)
            {
                TreeNode tn = new TreeNode()
                {
                    Text = ri.RoleName + (ri.IsEnabled == 1 ? "" : "  (停用)"),
                    Tag = ri.Id + "|" + ri.IsProtected,
                };
                AddChildNode(tn, ri.TreeChildren);
                root.Nodes.Add(tn);
            }
            uiTreeViewRole.Nodes.Add(root);
            uiTreeViewRole.ExpandAll();
        }

        private void AddChildNode(TreeNode parentNode, List<RoleInfo> childrenList)
        {
            foreach (RoleInfo ri in childrenList)
            {
                TreeNode childNode = new TreeNode()
                {
                    Text = ri.RoleName + (ri.IsEnabled == 1 ? "" : "  (停用)"),
                    Tag = ri.Id + "|" + ri.IsProtected,
                };
                parentNode.Nodes.Add(childNode);
                if (ri.TreeChildren.Count > 0) AddChildNode(childNode, ri.TreeChildren);
            }
        }

        private void uiButtonRoleAdd_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) { UIMessageBox.Show("请选择父角色"); return; }
            FormRoleEditOld formRoleEdit = FormRoleEditOld.Instance();
            formRoleEdit.LoadData("", tn.Tag.ToString().Split('|')[0]);
            formRoleEdit.ShowDialog();
            LoadRoleTree();
        }

        private void uiButtonRoleEdit_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) { UIMessageBox.Show("请选择要编辑的角色"); return; }
            if (tn.Tag.ToString().Split('|')[1] == "1")
            {
                UIMessageBox.Show("该节点不可编辑");
                return;
            }
            FormRoleEditOld formRoleEdit = FormRoleEditOld.Instance("编辑角色");
            formRoleEdit.LoadData(tn.Tag.ToString().Split('|')[0], "");
            formRoleEdit.ShowDialog();
            LoadRoleTree();
        }

        private void uiButtonRoleDel_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) { UIMessageBox.Show("请选择要删除的角色"); return; }
            if (tn.Tag.ToString().Split('|')[1] == "1")
            {
                UIMessageBox.Show("该节点不可删除");
                return;
            }
            if (MessageBox.Show(this, "该操作不可撤销，确定删除该节点吗?", "提醒", MessageBoxButtons.YesNo) == DialogResult.No) return;
            if (tn.Tag.ToString().Split('|')[0] == "-") MessageBox.Show("不能删除根节点");
            int result = BllRoleInfo.DeleteRoleInfo(tn.Tag.ToString().Split('|')[0], out _);
            if (result <= 0)
            {
                MessageBox.Show("删除失败");
            }
            LoadRoleTree();
        }

        #endregion


        #region ToolType

        private void LoadToolType()
        {
            IList<ToolType> toolTypeList = BllToolType.SearchToolType(0,-1, null, out _);
            uiDataGridViewToolType.DataSource = toolTypeList;

            uiDataGridViewToolType.Columns["ID"].Visible = false;

            uiDataGridViewToolType.Columns["TypeName"].HeaderText = "工具类型";
            uiDataGridViewToolType.Columns["SortOrder"].HeaderText = "工具排序";
            uiDataGridViewToolType.Columns["CreateTime"].HeaderText = "创建时间";
        }

        private void uiButtonToolTypeAdd_Click(object sender, EventArgs e)
        {
            FormToolTypeEditOld formToolTypeEdit = FormToolTypeEditOld.Instance("新建类型");
            formToolTypeEdit.ShowDialog();
            LoadToolType();
        }

        private void uiButtonToolTypeEdit_Click(object sender, EventArgs e)
        {
            if (uiDataGridViewToolType.SelectedRows.Count == 0) UIMessageBox.ShowError("请选择要编辑的类型", true, true);
            var selectRow = uiDataGridViewToolType.SelectedRows[0];
            ToolType toolType = selectRow.DataBoundItem as ToolType;
            FormToolTypeEditOld formToolTypeEdit = FormToolTypeEditOld.Instance("编辑类型");
            formToolTypeEdit.LoadData(toolType.Id);
            formToolTypeEdit.ShowDialog();
            LoadToolType();
        }

        private void uiButtonToolTypeDel_Click(object sender, EventArgs e)
        {
            if (uiDataGridViewToolType.SelectedRows.Count == 0) { UIMessageBox.ShowError("请选择要删除的类型", true, true); return; }
            if (!UIMessageBox.Show("是否确定删除?该操作不可撤销", "警告", buttons: UIMessageBoxButtons.OKCancel, showMask: true, topMost: true)) return;
            var selectRow = uiDataGridViewToolType.SelectedRows[0];
            ToolType toolType = selectRow.DataBoundItem as ToolType;
            int result = BllToolType.DeleteToolType(toolType.Id, out Exception ex);
            if(result <= 0)
            {
                UIMessageBox.ShowError($"删除失败，原因：{ex.Message}", true, true);
                return;
            }
            LoadToolType();
        }


        #endregion


    }
}
