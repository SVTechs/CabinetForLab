using System;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class SysDict : PageBase
    {
        private const string PmCodeDictGroup = "D8DADFC0-F422-459F-B81B-8EE4B006ABE4";
        private const string PmCodeAddSysDict = "19F66917-3456-4ED0-BDDF-D69D8570E0AD";
        private const string PmCodeModifySysDict = "B451BD47-4C5D-4EC4-9E74-8FA488A6F366";
        private const string PmCodeDeleteSysDict = "6D7916FF-852F-4248-9C9C-FBD15382B713";

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
            MainGrid.RecordCount = BllSysDictInfo.GetSysDictInfoCount(PmCodeDictGroup, out _);
            var data = BllSysDictInfo.SearchSysDictInfo(PmCodeDictGroup, MainGrid.PageIndex * MainGrid.PageSize, MainGrid.PageSize, out _);
            MainGrid.DataSource = data;
            MainGrid.DataBind();

            EditWindow.Hidden = true;
        }

        protected void MainGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            UpdateGrid();
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            if (e.CommandName == "Edit")
            {
                EditWindow.Title = "编辑项目";
                FillEdtInfo(dataId);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteInfo(dataId);
            }
        }

        private void FillEdtInfo(string infoId)
        {
            SysDictInfo di = BllSysDictInfo.GetSysDictInfo(long.Parse(infoId), out _);
            if (di != null)
            {
                tbDataId.Text = di.Id.ToString();
                tbDataKey.Text = di.DataKey;
                tbDataSubKey.Text = di.DataSubKey;
                tbDataOrder.Text = di.DataOrder.ToString();
                tbValue1.Text = di.DataValue1;
                tbValue2.Text = di.DataValue2;
                tbValue3.Text = di.DataValue3;
                tbValue4.Text = di.DataValue4;
                tbValue5.Text = di.DataValue5;
                tbValue6.Text = di.DataValue6;
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
            if (tbDataId.Text.Length == 0)
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
            if (!SessionManager.CheckPermission(PmCodeAddSysDict))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllSysDictInfo.AddSysDictInfo(PmCodeDictGroup, tbDataKey.Text, tbDataSubKey.Text, null, int.Parse(tbDataOrder.Text),
                tbValue1.Text, tbValue2.Text, tbValue3.Text, tbValue4.Text, tbValue5.Text,
                tbValue6.Text, tbComment.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifySysDict))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllSysDictInfo.ModifySysDictInfo(long.Parse(tbDataId.Text), tbDataKey.Text, tbDataSubKey.Text, null,
                int.Parse(tbDataOrder.Text),
                tbValue1.Text, tbValue2.Text, tbValue3.Text, tbValue4.Text, tbValue5.Text,
                tbValue6.Text, tbComment.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteSysDict))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllSysDictInfo.DeleteSysDictInfo(long.Parse(infoId), userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }
    }
}