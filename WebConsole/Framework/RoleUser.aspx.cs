using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class RoleUser : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["RuRoleId"] = "";

                List<RoleInfo> pNode = TreeManager.GetRoleTable();
                GridRole.DataSource = pNode;
                GridRole.DataBind();
            }
            else
            {
                string arg = GetRequestEventArgument();
                if (arg == "SubmitUser")
                {
                    SubmitUser();
                }
            }
        }

        protected void LeftGrid_RowClick(object sender, GridRowClickEventArgs e)
        {
            string rowId = e.RowID;
            Session["RuRoleId"] = rowId;
            UpdateUserGrid();
        }

        private void UpdateUserGrid()
        {
            string userName = (Session["RuRoleSearchUserName"] ?? "").ToString();
            string roleId = (Session["RuRoleId"] ?? "").ToString();

            GridUser.RecordCount = BllUserInfo.GetUserCount(userName, "", null, null, roleId, null,
                null, null, out _);
            var data = BllUserInfo.SearchUser(userName, "", null, null, roleId, null,
                null, null,
                GridUser.PageIndex * GridUser.PageSize, GridUser.PageSize, null, out _);
            GridUser.DataSource = data;
            GridUser.DataBind();
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            Session["RuRoleSearchUserName"] = tbSearchUserName.Text;
            UpdateUserGrid();
        }

        protected void GridUser_PreDataBound(object sender, EventArgs e)
        {

        }

        protected void GridUser_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = GridUser.SelectedRowID;
            if (e.CommandName == "Delete")
            {
                if ((Session["RuRoleId"] ?? "").ToString().Length == 0)
                {
                    Alert.Show("数据不正确，请尝试重新打开页面");
                    return;
                }
                RoleSettings ds = BllRoleSettings.GetTargetSetting(dataId, Session["RuRoleId"].ToString(), out _);
                if (ds == null)
                {
                    Alert.Show("数据不正确，请尝试重新打开页面");
                    return;
                }
                int result = BllRoleSettings.DeleteRoleSettings(ds.Id, out _);
                if (result <= 0)
                {
                    Alert.Show("删除失败");
                    return;
                }

                UpdateUserGrid();
            }
        }

        protected void GridUser_PageIndexChange(object sender, GridPageEventArgs e)
        {
            UpdateUserGrid();
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            string roleId = (Session["RuRoleId"] ?? "").ToString();
            if (roleId.Length == 0)
            {
                Alert.Show("请先选择角色");
                return;
            }

            PageContext.RegisterStartupScript(UserSelectWindow.GetSaveStateReference(tbEmployeeId.ClientID, tbEmployeeName.ClientID)
                                              + UserSelectWindow.GetShowReference(UserSelectWindow.IFrameUrl + "?ExcludeRoleId=" + roleId));
        }

        protected void SubmitUser()
        {
            //添加用户到角色
            if ((Session["RuRoleId"] ?? "").ToString().Length == 0)
            {
                Alert.Show("请先选择角色");
                return;
            }
            string departId = (Session["RuRoleId"] ?? "").ToString();
            int result = BllRoleSettings.AppendRole(tbEmployeeId.Text, departId, out _);
            if (result <= 0)
            {
                Alert.Show("更新出错");
                return;
            }
            UserSelectWindow.Hidden = true;
            UpdateUserGrid();
        }
    }
}