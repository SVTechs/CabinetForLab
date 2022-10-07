using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class DepartManage : PageBase
    {
        private const string PmCodeAddDepart = "36C00A3C-294F-4D4E-83DC-516337F7FCE3";
        private const string PmCodeModifyDepart = "2F2E4CCD-8108-430F-BEB6-12B7468F6F00";
        private const string PmCodeDeleteDepart = "380E98BB-5D89-4659-AAF2-0AB04967369F";

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
            List<DepartInfo> pNode = TreeManager.GetDepartTable(true);
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
            DepartInfo di = BllDepartInfo.GetDepartInfo(infoId, out _);
            if (di != null)
            {
                tbDepartId.Text = di.Id;
                tbDepartName.Text = di.DepartName;
                tbDepartOrder.Text = di.DepartOrder.ToString();
                cbIsEnabled.SelectedValue = di.IsEnabled.ToString();
                tbDepartDesp.Text = di.DepartDesp;

                EditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (tbDepartId.Text.Length == 0)
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
            if (!SessionManager.CheckPermission(PmCodeAddDepart))
            {
                Alert.Show("权限不足");
                return;
            }
            int departLevel = 0;
            string departParent = tbSelectedRowId.Text;
            if (departParent == "root") departParent = "";
            if (!string.IsNullOrEmpty(departParent))
            {
                DepartInfo di = BllDepartInfo.GetDepartInfo(departParent, out _);
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
            int result = BllDepartInfo.AddDepartInfo(tbDepartName.Text, departLevel, departParent,
                int.Parse(tbDepartOrder.Text), isEnabled, tbDepartDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyDepart))
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
            int result = BllDepartInfo.ModifyDepartInfo(tbDepartId.Text, tbDepartName.Text,
                int.Parse(tbDepartOrder.Text), isEnabled, tbDepartDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteDepart))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllDepartInfo.DeleteDepartInfo(infoId, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }
    }
}