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
    public partial class FormUserRoleManage : UIForm
    {

        private static FormUserRoleManage formUserRoleManage;
        private static string userId;

        public FormUserRoleManage()
        {
            InitializeComponent();
        }

        public static FormUserRoleManage Instance(string id)
        {
            if (formUserRoleManage == null || formUserRoleManage.IsDisposed) formUserRoleManage = new FormUserRoleManage();
            userId = id;
            return formUserRoleManage;
        }

        private void FormUserRoleManage_Load(object sender, EventArgs e)
        {
            LoadRoleInfo();
        }

        private void LoadRoleInfo()
        {
            IList<RoleSettings> roleSettings = BllRoleSettings.SearchRoleSettings(userId, 0, -1, null, out _);
            var node = TreeManager.GetRoleNode();
            uiTreeViewRoleInfo.Nodes.Clear();
            TreeNode root = new TreeNode() { Text = "角色", Tag = "-" };
            foreach (RoleInfo ri in node.TreeChildren)
            {
                TreeNode tn = new TreeNode()
                {
                    Text = ri.RoleName + (ri.IsEnabled == 1 ? "" : "  (停用)"),
                    Tag = ri.Id,
                    Checked = roleSettings.FirstOrDefault(x => x.RoleId == ri.Id) != null
                };
                AddChildNode(tn, ri.TreeChildren, roleSettings);
                root.Nodes.Add(tn);
            }
            uiTreeViewRoleInfo.Nodes.Add(root);
            uiTreeViewRoleInfo.ExpandAll();
        }

        private void AddChildNode(TreeNode parentNode, List<RoleInfo> childrenList, IList<RoleSettings> roleSettings)
        {

            foreach (RoleInfo ri in childrenList)
            {
                TreeNode childNode = new TreeNode()
                {
                    Text = ri.RoleName + (ri.IsEnabled == 1 ? "" : "  (停用)"),
                    Tag = ri.Id,
                    Checked = roleSettings.FirstOrDefault(x => x.RoleId == ri.Id) != null
                };
                parentNode.Nodes.Add(childNode);
                if (ri.TreeChildren.Count > 0) AddChildNode(childNode, ri.TreeChildren, roleSettings);
            }
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            var root = uiTreeViewRoleInfo.Nodes;
            if (root[0].Nodes.Count == 0) return;
            List<RoleSettings> list = new List<RoleSettings>();
            foreach (TreeNode tn in root[0].Nodes)
            {
                if (tn.Checked) 
                {
                    RoleSettings info = new RoleSettings()
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = (string)tn.Tag,
                        UserId = userId,
                        AddTime = DateTime.Now
                    };
                    list.Add(info);
                };
                if (tn.Nodes.Count > 0) AddChildRoleSettings(tn, list);
            }
            int result = BllRoleSettings.BatchSaveRoleSettings(userId, list, out Exception exception);
            if (result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{exception.Message}", true, true);
            }
            Hide();
        }

        private void AddChildRoleSettings(TreeNode tn, List<RoleSettings> list)
        {
            foreach (TreeNode child in tn.Nodes)
            {
                if (child.Checked)
                {
                    RoleSettings info = new RoleSettings()
                    {
                        Id = Guid.NewGuid().ToString(),
                        RoleId = (string)child.Tag,
                        UserId = userId,
                        AddTime = DateTime.Now
                    };
                    list.Add(info);
                };
                if (child.Nodes.Count > 0) AddChildRoleSettings(child, list);
            }
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormUserRoleManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }
    }
}
