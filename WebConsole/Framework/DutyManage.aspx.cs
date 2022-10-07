using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class DutyManage : PageBase
    {
        private const string PmCodeAddDuty = "516DA66B-0E8A-492F-B0C9-2DB0608B5001";
        private const string PmCodeModifyDuty = "6EED2E06-0BB8-429B-BC62-735505B0A29D";
        private const string PmCodeDeleteDuty = "BD2264B4-56BC-45E2-8C19-6C63B3299747";

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
            List<DutyInfo> pNode = TreeManager.GetDutyTable(true);
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
                EditWindow.Title = "编辑部门";
                FillEdtInfo(dataId);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteInfo(dataId);
            }
        }

        private void FillEdtInfo(string infoId)
        {
            DutyInfo di = BllDutyInfo.GetDutyInfo(infoId, out _);
            if (di != null)
            {
                tbDutyId.Text = di.Id;
                tbDutyName.Text = di.DutyName;
                tbDutyOrder.Text = di.DutyOrder.ToString();
                tbDutyDesp.Text = di.DutyDesp;
                cbIsEnabled.SelectedValue = di.IsEnabled.ToString();
                tbDutyDesp.Text = di.DutyDesp;

                EditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (tbDutyId.Text.Length == 0)
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
            if (!SessionManager.CheckPermission(PmCodeAddDuty))
            {
                Alert.Show("权限不足");
                return;
            }
            int departLevel = 0;
            string departParent = tbSelectedRowId.Text;
            if (!string.IsNullOrEmpty(departParent))
            {
                DutyInfo di = BllDutyInfo.GetDutyInfo(departParent, out _);
                if (di != null)
                {
                    departLevel = di.TreeLevel + 1;
                }
            }
            if (!int.TryParse(cbIsEnabled.SelectedValue, out var isEnabled))
            {
                Alert.Show("请选择是否启用");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllDutyInfo.AddDutyInfo(tbDutyName.Text, departLevel, departParent,
                int.Parse(tbDutyOrder.Text), tbDutyDesp.Text, isEnabled, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyDuty))
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
            int result = BllDutyInfo.ModifyDutyInfo(tbDutyId.Text, tbDutyName.Text,
                int.Parse(tbDutyOrder.Text), tbDutyDesp.Text, isEnabled, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteDuty))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllDutyInfo.DeleteDutyInfo(infoId, userInfo.Id, userInfo.RealName, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }
    }
}