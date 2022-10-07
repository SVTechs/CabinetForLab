using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class DepartUser : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["DuDepartId"] = "";

                List<DepartInfo> pNode = TreeManager.GetDepartTable();
                GridDepart.DataSource = pNode;
                GridDepart.DataBind();
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
            Session["DuDepartId"] = rowId;
            UpdateUserGrid();
        }

        private void UpdateUserGrid()
        {
            string userName = (Session["DuSearchUserName"] ?? "").ToString();
            string departId = (Session["DuDepartId"] ?? "").ToString();

            GridUser.RecordCount = BllUserInfo.GetUserCount(userName, "", departId, null, null, null,
                null, null, out _);
            var data = BllUserInfo.SearchUser(userName, "", departId, null, null, null, null, null,
                GridUser.PageIndex * GridUser.PageSize, GridUser.PageSize,
                null, out _);
            GridUser.DataSource = data;
            GridUser.DataBind();
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            Session["DuSearchUserName"] = tbSearchUserName.Text;
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
                if ((Session["DuDepartId"] ?? "").ToString().Length == 0)
                {
                    Alert.Show("数据不正确，请尝试重新打开页面");
                    return;
                }
                DepartSettings ds = BllDepartSettings.GetTargetSetting(dataId, Session["DuDepartId"].ToString(), out _);
                if (ds == null)
                {
                    Alert.Show("数据不正确，请尝试重新打开页面");
                    return;
                }
                UserInfo userInfo = SessionManager.GetUserInfo();
                int result = BllDepartSettings.DeleteDepartSettings(ds.Id, userInfo, out _);
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
            string departId = (Session["DuDepartId"] ?? "").ToString();
            if (departId.Length == 0)
            {
                Alert.Show("请先选择部门");
                return;
            }

            PageContext.RegisterStartupScript(UserSelectWindow.GetSaveStateReference(tbEmployeeId.ClientID, tbEmployeeName.ClientID)
                                              + UserSelectWindow.GetShowReference(UserSelectWindow.IFrameUrl + "?ExcludeDepartId=" + departId));
        }

        protected void SubmitUser()
        {
            //添加用户到部门
            if ((Session["DuDepartId"] ?? "").ToString().Length == 0)
            {
                Alert.Show("请先选择部门");
                return;
            }

            UserInfo userInfo = SessionManager.GetUserInfo();
            string departId = (Session["DuDepartId"] ?? "").ToString();
            int result = BllDepartSettings.AppendDepart(tbEmployeeId.Text, departId, out _);
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