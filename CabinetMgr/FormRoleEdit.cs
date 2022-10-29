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
    public partial class FormRoleEdit : UIForm
    {
        public static FormRoleEdit formRoleEdit;
        public static FormRoleEdit Instance()
        {
            if (formRoleEdit == null || formRoleEdit.IsDisposed) formRoleEdit = new FormRoleEdit();
            return formRoleEdit;
        }

        public FormRoleEdit()
        {
            InitializeComponent();
        }

        private void FormRoleEdit_Shown(object sender, EventArgs e)
        {
            LoadRoleData();
            LoadLatticeData();
        }

        private void LoadRoleData()
        {
            uiTreeViewRole.Nodes.Clear();
            TreeNode root = new TreeNode() { Text = "权限", Tag = "-|1" };
            var node = TreeManager.GetRoleNode();
            foreach (RoleInfo ri in node.TreeChildren)
            {
                TreeNode tn = new TreeNode()
                {
                    Text = ri.RoleName,
                    Tag = ri.Id + "|" + ri.IsProtected
                };
                root.Nodes.Add(tn);
            }
            uiTreeViewRole.Nodes.Add(root);
            uiTreeViewRole.ExpandAll();
        }

        private void LoadLatticeData(string roleId = "")
        {
            IList<LatticePermissionSettings> permissionSettings = BllLatticePermissionSettings.SearchLatticePermissionSettings(roleId, "Role", 0, -1, null, out _);
            uiTreeViewLattice.Nodes.Clear();
            TreeNode root = new TreeNode() { Text = "储物格", Tag = "-" };
            var list = BllLatticeInfo.SearchLatticeInfo(0, -1, null, out _);
            foreach (LatticeInfo li in list)
            {
                LatticePermissionSettings ps = permissionSettings.FirstOrDefault(x => x.LatticeId == li.Id);
                TreeNode tn = new TreeNode()
                {
                    Text = li.CabinetNum + "-" + li.CabinetLatticeNum,
                    Tag = li.Id,
                    Checked = ps != null
                };
                root.Nodes.Add(tn);
            }
            uiTreeViewLattice.Nodes.Add(root);
            uiTreeViewLattice.ExpandAll();
        }

        private void uiTreeViewRole_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var role = e.Node;
            if ((string)role.Tag == "-") return;
            LoadLatticeData((role.Tag as string).Split('|')[0]);
        }

        private void uiButtonAddRole_Click(object sender, EventArgs e)
        {
            SetInputControlVisible(true);

        }

        private void uiButtonRoleDelete_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null) 
            {
                UIMessageBox.Show("请选择需要删除的权限");
                return;
            }
            if((tn.Tag as string).Split('|')[1] == "1")
            {
                UIMessageBox.Show("初始节点不可以删除");
                return;
            }
            if (!UIMessageBox.ShowAsk("该操作不可撤销,是否继续")) return;
            string roleId = (tn.Tag as string).Split('|')[0];
            int result = BllRoleInfo.DeleteRoleInfo(roleId, out Exception ex);
            if(result <= 0)
            {
                UIMessageBox.ShowError($"删除失败，原因为：\n{ex.Message}");
                return;
            }
            LoadRoleData();
            LoadLatticeData();
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            TreeNode tn = uiTreeViewRole.SelectedNode;
            if (tn == null)
            {
                UIMessageBox.Show("请选择需要保存的权限");
                return;
            }
            string roleId = (tn.Tag as string).Split('|')[0];
            var root = uiTreeViewLattice.Nodes;
            if (root[0].Nodes.Count == 0) return;
            List<LatticePermissionSettings> list = new List<LatticePermissionSettings>();
            foreach (TreeNode treeNode in root[0].Nodes)
            {
                if (!treeNode.Checked) continue;
                LatticePermissionSettings info = new LatticePermissionSettings()
                {
                    Id = Guid.NewGuid().ToString(),
                    LatticeId = (long)treeNode.Tag,
                    OwnerId = roleId,
                    OwnerType = "Role",
                    AddTime = DateTime.Now
                };
                list.Add(info);
            }
            if (list.Count == 0)
            {
                UIMessageBox.Show("请选择需要保存的储物格权限"); return;
            }
            int result = BllLatticePermissionSettings.BatchSaveLatticePermissionSettings(roleId, "Role", list, out Exception exception);
            if (result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{exception.Message}", true, true);
            }
            LoadLatticeData();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void uiButtonRoleSave_Click(object sender, EventArgs e)
        {
            string roleName = uiTextBoxRoleName.Text.Trim();
            int roleOrder = int.Parse(uiTextBoxRoleOrder.Text.Trim());
            RoleInfo ri = new RoleInfo()
            {
                Id = Guid.NewGuid().ToString().ToUpper(),
                RoleName = roleName,
                RoleOrder = roleOrder,
                TreeLevel = 0,
                TreeParent = null,
                IsEnabled = 1,
                IsProtected = 0,
                LastChanged = DateTime.Now,
            };
            int result = BllRoleInfo.SaveRoleInfo(ri, out Exception exception);
            if (result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{exception.Message}");
            }
            SetInputControlVisible(false);
            ClearInputControl();
            LoadRoleData();
            LoadLatticeData();
        }

        private void SetInputControlVisible(bool visible)
        {
            uiLabelRoleName.Visible = visible;
            uiTextBoxRoleName.Visible = visible;
            uiLabelRoleOrder.Visible = visible;
            uiTextBoxRoleOrder.Visible = visible;
            uiButtonRoleSave.Visible = visible;
        }

        private void ClearInputControl()
        {
            uiTextBoxRoleName.Text = "";
            uiTextBoxRoleOrder.Text = "0";
        }

        private void uiTextBoxRoleName_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void FormRoleEdit_Click(object sender, EventArgs e)
        {
            Osk.HideInputPanel();
        }
    }
}
