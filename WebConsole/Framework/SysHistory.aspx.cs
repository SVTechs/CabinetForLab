using System;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class SysHistory : PageBase
    {
        private const string PmCodeDeleteSysDataHistory = "C829301D-4DDB-4B00-9C12-5073FAC2642A";

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
            MainGrid.RecordCount = BllSysDataHistory.GetSysDataHistoryCount("", out _);
            var data = BllSysDataHistory.SearchSysDataHistory("", MainGrid.PageIndex * MainGrid.PageSize, MainGrid.PageSize, out _);
            MainGrid.DataSource = data;
            MainGrid.DataBind();
        }

        protected void MainGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            UpdateGrid();
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            if (e.CommandName == "Delete")
            {
                DeleteInfo(dataId);
            }
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteSysDataHistory))
            {
                Alert.Show("权限不足");
                return;
            }
            int result = BllSysDataHistory.DeleteSysDataHistory(long.Parse(infoId), out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }
    }
}