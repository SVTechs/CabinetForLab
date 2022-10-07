using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class DutyUser : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["DtuDutyId"] = "";

                List<DutyInfo> pNode = TreeManager.GetDutyTable();
                GridDuty.DataSource = pNode;
                GridDuty.DataBind();
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
            Session["DtuDutyId"] = rowId;
            UpdateUserGrid();
        }

        private void UpdateUserGrid()
        {
            string userName = (Session["DtuDutySearchUserName"] ?? "").ToString();
            string dutyId = (Session["DtuDutyId"] ?? "").ToString();

            GridUser.RecordCount = BllUserInfo.GetUserCount(userName, "", null, null, null, null,
                dutyId, null, out _);
            var data = BllUserInfo.SearchUser(userName, "", null, null, null, null, dutyId, null,
                GridUser.PageIndex * GridUser.PageSize, GridUser.PageSize, null, out _);
            GridUser.DataSource = data;
            GridUser.DataBind();
        }

        protected void btnSearchUser_Click(object sender, EventArgs e)
        {
            Session["DtuDutySearchUserName"] = tbSearchUserName.Text;
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
                if ((Session["DtuDutyId"] ?? "").ToString().Length == 0)
                {
                    Alert.Show("数据不正确，请尝试重新打开页面");
                    return;
                }
                DutySettings ds = BllDutySettings.GetTargetSetting(dataId, Session["DtuDutyId"].ToString(), out _);
                if (ds == null)
                {
                    Alert.Show("数据不正确，请尝试重新打开页面");
                    return;
                }
                int result = BllDutySettings.DeleteDutySettings(ds.Id, out _);
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
            string dutyId = (Session["DtuDutyId"] ?? "").ToString();
            if ((Session["DtuDutyId"] ?? "").ToString().Length == 0)
            {
                Alert.Show("请先选择职务");
                return;
            }

            PageContext.RegisterStartupScript(UserSelectWindow.GetSaveStateReference(tbEmployeeId.ClientID, tbEmployeeName.ClientID)
                                              + UserSelectWindow.GetShowReference(UserSelectWindow.IFrameUrl + "?ExcludeDutyId=" + dutyId));
        }

        protected void SubmitUser()
        {
            //添加用户到职务
            if ((Session["DtuDutyId"] ?? "").ToString().Length == 0)
            {
                Alert.Show("请先选择职务");
                return;
            }
            string departId = (Session["DtuDutyId"] ?? "").ToString();
            int result = BllDutySettings.AppendDuty(tbEmployeeId.Text, departId, out _);
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