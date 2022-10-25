using CabinetMgr.BLL;
using CabinetMgr.Common;
using Domain.Main.Domain;
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
    public partial class FormRoleManageOld : Form
    {
        public FormRoleManageOld()
        {
            InitializeComponent();
        }

        private void FormRoleManage_Load(object sender, EventArgs e)
        {
            LoadRoleTree();
        }

        private void LoadRoleTree()
        {

            uiTreeViewRole.Nodes.Clear();
            TreeNode root = new TreeNode() { Text = "角色", Tag = "-"};
            var node = TreeManager.GetRoleNode();
            foreach(RoleInfo ri in node.TreeChildren)
            {
                TreeNode tn = new TreeNode() {
                    Text = ri.RoleName + (ri.IsEnabled == 1 ? "" : "  (停用)" ),
                    Tag = ri.Id,
                };
                AddChildNode(tn, ri.TreeChildren);
                root.Nodes.Add(tn);
            }
            uiTreeViewRole.Nodes.Add(root);
            uiTreeViewRole.ExpandAll();
        }

        private void AddChildNode(TreeNode parentNode, List<RoleInfo> childrenList)
        {
            foreach(RoleInfo ri in childrenList)
            {
                TreeNode childNode = new TreeNode()
                {
                    Text = ri.RoleName + (ri.IsEnabled == 1 ? "" : "  (停用)"),
                    Tag = ri.Id,
                };
                parentNode.Nodes.Add(childNode);
                if (ri.TreeChildren.Count > 0) AddChildNode(childNode, ri.TreeChildren);
            }
        }

        private void uiButtonAdd_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) return;
            FormRoleEditOld formRoleEdit = FormRoleEditOld.Instance();
            formRoleEdit.LoadData("", tn.Tag as string);
            formRoleEdit.ShowDialog();
            LoadRoleTree();
        }

        private void uiButtonEdit_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) return;
            FormRoleEditOld formRoleEdit = FormRoleEditOld.Instance("编辑角色");
            formRoleEdit.LoadData(tn.Tag as string, "");
            formRoleEdit.ShowDialog();
            LoadRoleTree();
        }

        private void uiButtonDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "该操作不可撤销，确定删除该节点吗?", "提醒", MessageBoxButtons.YesNo) == DialogResult.No) return;
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) return;
            if (tn.Tag as string == "-") MessageBox.Show("不能删除根节点");
            int result = BllRoleInfo.DeleteRoleInfo(tn.Tag as string, out _);
            if (result <= 0)
            {
                MessageBox.Show("删除失败");
            }
            LoadRoleTree();
        }

        private void uiButtonEditLatticePermission_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) return;
            FormLatticePermissionManageOld formLatticePermissionManage = FormLatticePermissionManageOld.Instance(tn.Tag as string, "Role");
            formLatticePermissionManage.ShowDialog();
        }
    }
}
