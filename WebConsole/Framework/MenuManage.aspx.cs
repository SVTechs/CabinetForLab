using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using FineUIPro;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.Framework
{
    public partial class MenuManage : PageBase
    {
        private const string PmCodeAddMenu = "11C56D90-8D24-4D8F-99BC-CC7B20F01A24";
        private const string PmCodeModifyMenu = "761C3B6E-B57D-4CBB-88CA-5C643FA0C5E2";
        private const string PmCodeDeleteMenu = "D17DCCC8-1C7B-4090-BC41-88BB15C09D82";
        private const string PmCodeAddFunc = "807FA4DD-39A6-47A7-BE33-28CD143E6679";
        private const string PmCodeModifyFunc = "DBE16603-E816-4395-A6C6-FFD5B7F13AA8";
        private const string PmCodeDeleteFunc = "C4D58A7B-8275-4DDD-BDF5-818C6CC6CFE9";

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
            List<PageMenus> pNode = TreeManager.GetMenuAndFuncTable(true);
            MainGrid.DataSource = pNode;
            MainGrid.DataBind();

            MenuEditWindow.Hidden = true;
            FuncEditWindow.Hidden = true;
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
            string dataType = MainGrid.DataKeys[e.RowIndex][1].ToString();
            if (dataId == "root")
            {
                Alert.Show("根节点不能进行操作");
                return;
            }
            if (e.CommandName == "Edit")
            {
                if (!dataType.Contains("功能>"))
                {
                    MenuEditWindow.Title = "编辑部门";
                    FillMenuEdtInfo(dataId);
                }
                else
                {
                    FuncEditWindow.Title = "编辑功能";
                    FillFuncEdtInfo(dataId);
                }
            }
            else if (e.CommandName == "Delete")
            {
                if (!dataType.Contains("功能>"))
                {
                    DeleteMenuInfo(dataId);
                }
                else
                {
                    DeleteFuncInfo(dataId);
                }
            }
        }

        private void FillMenuEdtInfo(string infoId)
        {
            var di = BllPageMenus.GetPageMenu(infoId, out _);
            if (di != null)
            {
                tbMenuId.Text = di.Id;
                tbMenuName.Text = di.MenuName;
                tbMenuIcon.Text = di.MenuIcon;
                tbMenuOrder.Text = di.MenuOrder.ToString();
                cbMenuType.SelectedValue = di.MenuType.ToString();
                tbMenuUrl.Text = di.MenuUrl;
                cbMenuVisible.SelectedValue = di.IsVisible.ToString();
                tbMenuDesp.Text = di.MenuDesp;

                MenuEditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        private void FillFuncEdtInfo(string infoId)
        {
            var di = BllPageFunctions.GetPageFunctions(infoId, out _);
            if (di != null)
            {
                tbFuncId.Text = di.Id;
                tbFuncName.Text = di.FunctionName;
                tbFuncOrder.Text = di.FunctionOrder.ToString();
                tbFuncDesp.Text = di.FunctionDesp;

                FuncEditWindow.Hidden = false;
            }
            else
            {
                Alert.Show("未找到相关信息");
            }
        }

        protected void btnMenuSaveClose_Click(object sender, EventArgs e)
        {
            if (tbMenuId.Text.Length == 0)
            {
                InsertMenuInfo();
            }
            else
            {
                UpdateMenuInfo();
            }
        }

        private void InsertMenuInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeAddMenu))
            {
                Alert.Show("权限不足");
                return;
            }
            int menuLevel = 0;
            string itemParent = tbSelectedRowId.Text;
            if (!string.IsNullOrEmpty(itemParent))
            {
                var di = BllPageMenus.GetPageMenu(itemParent, out _);
                if (di != null)
                {
                    menuLevel = di.TreeLevel + 1;
                }
            }
            if (!int.TryParse(cbMenuType.SelectedValue, out var menuType))
            {
                Alert.Show("请选择菜单类型");
                return;
            }
            if (!int.TryParse(tbMenuOrder.Text, out var menuOrder))
            {
                Alert.Show("请输入菜单排序");
                return;
            }
            if (!int.TryParse(cbMenuVisible.SelectedValue, out var isVisible))
            {
                Alert.Show("请选择是否启用");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllPageMenus.AddPageMenu(tbMenuName.Text, menuLevel, itemParent,
                menuOrder, menuType, tbMenuUrl.Text, tbMenuIcon.Text, isVisible, tbMenuDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateMenuInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyMenu))
            {
                Alert.Show("权限不足");
                return;
            }
            if (!int.TryParse(cbMenuType.SelectedValue, out var menuType))
            {
                Alert.Show("请选择菜单类型");
                return;
            }
            if (!int.TryParse(tbMenuOrder.Text, out var menuOrder))
            {
                Alert.Show("请输入菜单排序");
                return;
            }
            if (!int.TryParse(cbMenuVisible.SelectedValue, out var isVisible))
            {
                Alert.Show("请选择是否启用");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllPageMenus.ModifyPageMenu(tbMenuId.Text, tbMenuName.Text, menuOrder,
                menuType, tbMenuUrl.Text, tbMenuIcon.Text, isVisible, tbMenuDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteMenuInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteMenu))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllPageMenus.DeletePageMenu(infoId, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }

        protected void btnFuncSaveClose_Click(object sender, EventArgs e)
        {
            if (tbFuncId.Text.Length == 0)
            {
                InsertFuncInfo(tbFuncType.Text);
            }
            else
            {
                UpdateFuncInfo();
            }
        }

        private void InsertFuncInfo(string funcType)
        {
            if (!SessionManager.CheckPermission(PmCodeAddFunc))
            {
                Alert.Show("权限不足");
                return;
            }
            if (!int.TryParse(tbFuncOrder.Text, out var funcOrder))
            {
                Alert.Show("请输入功能排序");
                return;
            }
            string itemParent = tbSelectedRowId.Text;
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = 0;
            if (tbFuncType.Text != "50000")
            {
                result = BllPageFunctions.AddPageFunction(tbFuncName.Text, funcOrder, itemParent,
                    tbFuncDesp.Text, userInfo, out _);
            }
            else
            {
                result = BllPageFunctions.AddSubFunction(tbFuncName.Text, funcOrder, itemParent,
                    tbFuncDesp.Text, userInfo, out _);
            }
            if (result <= 0)
            {
                Alert.Show("添加失败");
                return;
            }
            UpdateGrid();
        }

        private void UpdateFuncInfo()
        {
            if (!SessionManager.CheckPermission(PmCodeModifyFunc))
            {
                Alert.Show("权限不足");
                return;
            }
            if (!int.TryParse(tbFuncOrder.Text, out var funcOrder))
            {
                Alert.Show("请输入功能排序");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllPageFunctions.ModifyPageFunction(tbFuncId.Text, tbFuncName.Text,
                funcOrder, tbFuncDesp.Text, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("修改失败");
                return;
            }
            UpdateGrid();
        }

        private void DeleteFuncInfo(string infoId)
        {
            if (!SessionManager.CheckPermission(PmCodeDeleteFunc))
            {
                Alert.Show("权限不足");
                return;
            }
            UserInfo userInfo = SessionManager.GetUserInfo();
            int result = BllPageFunctions.DeletePageFunctions(infoId, userInfo, out _);
            if (result <= 0)
            {
                Alert.Show("删除失败");
                return;
            }
            UpdateGrid();
        }
    }
}