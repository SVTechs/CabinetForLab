using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using Domain.Server.Types;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework.Component
{
    public partial class UserInfoSelector : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["FmUiSearchUserName"] = "";
                Session["FmUiSearchRealName"] = "";

                Session["FmUiSearchDepartId"] = Request.QueryString["DepartId"];
                Session["FmUiSearchExcludeDepartId"] = Request.QueryString["ExcludeDepartId"];
                Session["FmUiSearchRoleId"] = Request.QueryString["RoleId"];
                Session["FmUiSearchExcludeRoleId"] = Request.QueryString["ExcludeRoleId"];
                Session["FmUiSearchDutyId"] = Request.QueryString["DutyId"];
                Session["FmUiSearchExcludeDutyId"] = Request.QueryString["ExcludeDutyId"];

                UpdateGrid();
            }
        }

        protected void MainPanel_PreDataBound(object sender, EventArgs e)
        {

        }

        private void UpdateGrid()
        {
            string searchUserName = (Session["FmUiSearchUserName"] ?? "").ToString();
            string searchRealName = (Session["FmUiSearchRealName"] ?? "").ToString();

            string searchDepartId = (Session["FmUiSearchDepartId"] ?? "").ToString();
            string searchExcludeDepartId = (Session["FmUiSearchExcludeDepartId"] ?? "").ToString();
            string searchRoleId = (Session["FmUiSearchRoleId"] ?? "").ToString();
            string searchExcludeRoleId = (Session["FmUiSearchExcludeRoleId"] ?? "").ToString();
            string searchDutyId = (Session["FmUiSearchDutyId"] ?? "").ToString();
            string searchExcludeDutyId = (Session["FmUiSearchExcludeDutyId"] ?? "").ToString();

            MainGrid.RecordCount = BllUserInfo.GetUserCount(searchUserName, searchRealName, searchDepartId, searchExcludeDepartId,
                searchRoleId, searchExcludeRoleId, searchDutyId, searchExcludeDutyId, out _);
            IList<UserInfo> userList = BllUserInfo.SearchUser(searchUserName, searchRealName, searchDepartId, searchExcludeDepartId,
                searchRoleId, searchExcludeRoleId, searchDutyId, searchExcludeDutyId,
                MainGrid.PageIndex * MainGrid.PageSize, MainGrid.PageSize,
                DbOrder.GetOrderList(MainGrid.SortDirection, MainGrid.SortField), out _);
            MainGrid.DataSource = userList;
            MainGrid.DataBind();
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            if (e.CommandName == "Confirm")
            {
                string name = MainGrid.DataKeys[e.RowIndex][1].ToString();
                PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(dataId, name) +
                                                  "if (parent.onSelectCallback) parent.onSelectCallback();" + ActiveWindow.GetHideReference());
            }
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            Session["FmUiSearchUserName"] = tbSearchUserName.Text;
            Session["FmUiSearchRealName"] = tbSearchRealName.Text;
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