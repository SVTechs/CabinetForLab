using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Domain.Server.Domain;
using Domain.Server.Types;
using FineUIPro;
using Utilities.DbHelper;
using Utilities.String;
using WebConsole.BLL;
using WebConsole.Config;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class UserManage : PageBase
    {
        private const string PmCodeAddUser = "7C33BD62-C0C3-4693-9E51-002D4C1601A2";
        private const string PmCodeModifyUser = "1F8AD215-CA41-41E4-A420-4E21547BB7B8";
        private const string PmCodeDeleteUser = "28741EE8-662C-412E-A008-B129462B64F1";
        private const string PmCodeSetPerm = "0120E3E1-8AC4-4EB0-BE10-7291AABE72DD";

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
            string searchUserName = tbSearchUserName.Text;
            string searchRealName = tbSearchRealName.Text;

            MainGrid.RecordCount = BllUserInfo.GetUserCount(searchUserName, searchRealName, null, null, 
                null, null, null, null, out _);
            IList<UserInfo> userList = BllUserInfo.SearchUser(searchUserName, searchRealName, null, null, 
                null, null, null, null,
                MainGrid.PageIndex * MainGrid.PageSize, MainGrid.PageSize, 
                DbOrder.GetOrderList(MainGrid.SortDirection, MainGrid.SortField), out _);
            MainGrid.DataSource = userList;
            MainGrid.DataBind();

            EditWindow.Hidden = true;
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            if (e.CommandName == "Edit")
            {
                EditWindow.Title = "编辑部门";
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
            UserInfo di = BllUserInfo.GetUserInfo(infoId, out _);
            if (di != null)
            {
                tbUserId.Text = di.Id;
                tbUserName.Text = di.UserName;
                tbPassword.Text = "";
                tbRealName.Text = di.RealName;
                tbUserTel.Text = di.UserTel;
                tbUserSex.Text = di.UserSex;
                tbRetireDate.Text = di.RetireDate?.ToString("yyyy-MM-dd");
                tbWorkCard.Text = di.WorkCardCode;
                tbIdentCard.Text = di.IdentCardCode;
                tbAddress.Text = di.Address;
                tbComment.Text = di.Comment;

                EditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (tbUserId.Text.Length == 0)
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
            if (!SessionManager.CheckPermission(PmCodeAddUser))
            {
                Alert.Show("权限不足");
                return;
            }
            if (tbPassword.Text.Length == 0)
            {
                Alert.Show("请输入密码");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            DateTime birthDate = Env.MinTime, retireDate = Env.MinTime;
            if (!string.IsNullOrEmpty(tbIdentCard.Text))
            {
                int codeLength = tbIdentCard.Text.Length;
                if (codeLength != 15 && codeLength != 18)
                {
                    Alert.Show("身份证格式不正确");
                    return;
                }
                DateTime? bornDate = StringHelper.GetBornDate(tbIdentCard.Text);
                if (bornDate != null) birthDate = bornDate.Value;
            }
            if (DateTime.TryParse(tbRetireDate.Text, out var rxDate))
            {
                retireDate = rxDate;
            }
            var existInfo = BllUserInfo.GetUserInfoByUserName(tbUserName.Text, out var ex);
            if (ex != null)
            {
                Alert.Show("查询异常");
                return;
            }
            if (existInfo != null)
            {
                Alert.Show("用户已存在");
                return;
            }
            string result = BllUserInfo.AddUserInfo(tbUserName.Text, tbPassword.Text, tbRealName.Text, tbUserTel.Text,
                tbUserSex.SelectedText, birthDate, retireDate, tbWorkCard.Text, tbIdentCard.Text, tbAddress.Text, tbComment.Text, userInfo, out _);
            if (string.IsNullOrEmpty(result))
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyUser))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            DateTime birthDate = Env.MinTime, retireDate = Env.MinTime;
            if (!string.IsNullOrEmpty(tbIdentCard.Text))
            {
                int codeLength = tbIdentCard.Text.Length;
                if (codeLength != 15 && codeLength != 18)
                {
                    Alert.Show("身份证格式不正确");
                    return;
                }
                DateTime? bornDate = StringHelper.GetBornDate(tbIdentCard.Text);
                if (bornDate != null) birthDate = bornDate.Value;
            }
            var currentInfo = BllUserInfo.GetUserInfo(tbUserId.Text, out var ex);
            if (ex != null)
            {
                Alert.Show("查询异常");
                return;
            }
            var existInfo = BllUserInfo.GetUserInfoByUserName(tbUserName.Text, out ex);
            if (ex != null)
            {
                Alert.Show("查询异常");
                return;
            }
            if (existInfo != null && existInfo.Id != currentInfo.Id)
            {
                Alert.Show("用户已存在");
                return;
            }
            if (DateTime.TryParse(tbRetireDate.Text, out var rxDate))
            {
                retireDate = rxDate;
            }
            int result = BllUserInfo.ModifyUserInfo(tbUserId.Text, tbUserName.Text, tbPassword.Text, tbRealName.Text, tbUserTel.Text,
                tbUserSex.SelectedText, birthDate, retireDate, tbWorkCard.Text, tbIdentCard.Text, tbAddress.Text, tbComment.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteUser))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllUserInfo.DeleteUserInfo(infoId, userInfo.Id, userInfo.RealName, out _);
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
            string userId = tbSelectedRowId.Text;
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
            int result = BllPermissionSettings.SetOwnerPermission("User", userId, permId);
            if (result <= 0)
            {
                Alert.Show("更新失败");
                return;
            }
            PermWindow.Hidden = true;
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        protected void MainGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            UpdateGrid();
        }

        protected void MainGrid_OnSort(object sender, GridSortEventArgs e)
        {
            UpdateGrid();
        }
    }
}