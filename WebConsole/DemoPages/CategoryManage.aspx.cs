using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.DemoPages
{
    public partial class CategoryManage : PageBase
    {
        private const string PmCodeDemoTreeGroup = "C2238FB7-D392-435D-9FD1-13B71FDB08B2";
        private const string PmCodeAddCategory = "36C00A3C-294F-4D4E-83DC-516337F7FCE3";
        private const string PmCodeModifyCategory = "2F2E4CCD-8108-430F-BEB6-12B7468F6F00";
        private const string PmCodeDeleteCategory = "380E98BB-5D89-4659-AAF2-0AB04967369F";

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
            List<GenericTree> pNode = TreeManager.GetGenericTreeTable(PmCodeDemoTreeGroup);
            MainGrid.DataSource = pNode;
            MainGrid.DataBind();

            EditWindow.Hidden = true;
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            if (e.CommandName == "Edit")
            {
                EditWindow.Title = "编辑分类";
                FillEdtInfo(dataId);
            }
            else if (e.CommandName == "Delete")
            {
                DeleteInfo(dataId);
            }
        }

        private void FillEdtInfo(string infoId)
        {
            GenericTree di = BllGenericTree.GetGenericTree(infoId, out _);
            if (di != null)
            {
                tbNodeId.Text = di.Id;
                tbNodeName.Text = di.NodeName;
                tbNodeOrder.Text = di.NodeOrder.ToString();
                tbNodeDesp.Text = di.NodeDesp;

                EditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (tbNodeId.Text.Length == 0)
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
            if (!SessionManager.CheckPermission(PmCodeAddCategory))
            {
                Alert.Show("权限不足");
                return;
            }
            int nodeLevel = 0;
            string nodeParent = tbSelectedRowId.Text;
            if (!string.IsNullOrEmpty(nodeParent))
            {
                GenericTree di = BllGenericTree.GetGenericTree(nodeParent, out _);
                if (di != null)
                {
                    nodeLevel = di.TreeLevel + 1;
                }
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllGenericTree.AddGenericTree(PmCodeDemoTreeGroup, tbNodeName.Text, nodeLevel, nodeParent,
                int.Parse(tbNodeOrder.Text), tbNodeDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyCategory))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllGenericTree.ModifyGenericTree(tbNodeId.Text, tbNodeName.Text,
                int.Parse(tbNodeOrder.Text), tbNodeDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteCategory))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllGenericTree.DeleteGenericTree(infoId, PmCodeDemoTreeGroup, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }
    }
}