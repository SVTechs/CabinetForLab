using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Domain.Server.Domain;
using FineUIPro;
using Utilities.DbHelper;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class RoleManage : PageBase
    {
        private const string PmCodeAddRole = "4297F33F-F24F-4785-88F6-3C22BFA19BE6";
        private const string PmCodeModifyRole = "00A0A80D-B7B9-4481-A3BD-1C706FABE867";
        private const string PmCodeSetPerm = "3B7B7DEC-E508-4D7B-98B9-8A9F26DD237D";
        private const string PmCodeDeleteRole = "4FA72BD8-227E-4881-9BFF-D6F105769F03";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGrid();
            }
        }

        protected void MainPanel_PreDataBound(object sender, EventArgs e)
        {

        }

        private void UpdateGrid()
        {
            List<RoleInfo> pNode = TreeManager.GetRoleTable(true);
            MainGrid.DataSource = pNode;
            MainGrid.DataBind();

            EditWindow.Hidden = true;
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            if (dataId == "root")
            {
                Alert.Show("根节点不能进行操作");
                return;
            }
            if (e.CommandName == "Edit")
            {
                EditWindow.Title = "编辑角色";
                FillEdtInfo(dataId);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteInfo(dataId);
            }
            else if (e.CommandName == "Perm")
            {
                treeRole.Nodes.Clear();
                TreeNode permNode;
                IList<PermissionSettings> permList = BllPermissionSettings.GetOwnerPermissionSettings(tbSelectedRowId.Text, out _);
                if (SqlDataHelper.IsDataValid(permList))
                {
                    Hashtable roleTable = new Hashtable();
                    for (int i = 0; i < permList.Count; i++)
                    {
                        roleTable[permList[i].AccessId] = 1;
                    }
                    permNode = TreeManager.GetPermTreeNode(roleTable, true);
                }
                else
                {
                    permNode = TreeManager.GetPermTreeNode(null, true);
                }
                if (permNode.Nodes.Count > 0)
                {
                    for (int i = 0; i < permNode.Nodes.Count; i++)
                    {
                        treeRole.Nodes.Add(permNode.Nodes[i]);
                    }
                }
                PermWindow.Hidden = false;
            }
        }

        private void FillEdtInfo(string infoId)
        {
            RoleInfo di = BllRoleInfo.GetRoleInfo(infoId, out _);
            if (di != null)
            {
                tbRoleId.Text = di.Id;
                tbRoleName.Text = di.RoleName;
                tbRoleOrder.Text = di.RoleOrder.ToString();
                cbIsEnabled.SelectedValue = di.IsEnabled.ToString();
                tbRoleDesp.Text = di.RoleDesp;

                EditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (tbRoleId.Text.Length == 0)
            {
                InsertInfo();
            }
            else
            {
                UpdateInfo();
            }
        }

        private void InsertInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeAddRole))
            {
                Alert.Show("权限不足");
                return;
            }
            int roleLevel = 0;
            string roleParent = tbSelectedRowId.Text;
            if (!string.IsNullOrEmpty(roleParent))
            {
                RoleInfo di = BllRoleInfo.GetRoleInfo(roleParent, out _);
                if (di != null)
                {
                    roleLevel = di.TreeLevel + 1;
                }
            }
            if (!int.TryParse(cbIsEnabled.SelectedValue, out var isEnabled))
            {
                Alert.Show("请选择是否启用");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllRoleInfo.AddRoleInfo(tbRoleName.Text, roleLevel, roleParent,
                int.Parse(tbRoleOrder.Text), tbRoleDesp.Text, isEnabled, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyRole))
            {
                Alert.Show("权限不足");
                return;
            }
            if (!int.TryParse(cbIsEnabled.SelectedValue, out var isEnabled))
            {
                Alert.Show("请选择是否启用");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllRoleInfo.ModifyRoleInfo(tbRoleId.Text, tbRoleName.Text,
                int.Parse(tbRoleOrder.Text), tbRoleDesp.Text, isEnabled, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteRole))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllRoleInfo.DeleteRoleInfo(infoId, userInfo.Id, userInfo.RealName, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }

        protected void btnPermSaveClose_Click(object sender, EventArgs e)
        {
            if (!SessionManager.CheckPermission(PmCodeSetPerm))
            {
                Alert.Show("权限不足");
                return;
            }
            string roleId = tbSelectedRowId.Text;
            string permId = "";
            TreeNode[] nodes = treeRole.GetCheckedNodes();
            if (nodes.Length > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (TreeNode node in nodes)
                {
                    sb.Append(node.NodeID + ",");
                }
                permId = sb.ToString().TrimEnd(',');
            }
            int result = BllPermissionSettings.SetOwnerPermission("Role", roleId, permId);
            if (result <= 0)
            {
                Alert.Show("更新失败");
                return;
            }
            PermWindow.Hidden = true;
        }
    }
}