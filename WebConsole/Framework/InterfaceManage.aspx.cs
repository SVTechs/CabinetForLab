using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Domain.Server.Domain;
using Domain.Server.Types;
using FineUIPro;
using Utilities.DbHelper;
using WebConsole.BLL;
using WebConsole.Framework.Logic;
using CheckBoxField = FineUIPro.CheckBoxField;

namespace WebConsole.Framework
{
    public partial class InterfaceManage : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateRoleGrid();

                UpdateGrid();
            }
        }

        protected void MainPanel_PreDataBound(object sender, EventArgs e)
        {

        }

        private void UpdateGrid()
        {
            IList<GridItem> domainList = BllInterfaceOutput.SearchOutputItem("Domain.Main");
            MainGrid.DataSource = domainList;
            MainGrid.DataBind();

            EditWindow.Hidden = true;
        }

        private void UpdateRoleGrid()
        {
            List<RoleInfo> pNode = TreeManager.GetRoleTable();
            GridRole.DataSource = pNode;
            GridRole.DataBind();
        }

        private void UpdateColumnGrid(string roleId, string domainName)
        {
            if (string.IsNullOrEmpty(roleId) || string.IsNullOrEmpty(domainName))
            {
                GridColumn.DataSource = new List<GridItem>();
                GridColumn.DataBind();
                return;
            }

            IList<InterfaceOutput> outputs = BllInterfaceOutput.SearchInterfaceOutput(roleId, domainName, out var ex);
            if (ex != null) return;
            Hashtable filterTable = new Hashtable();
            for (int i = 0; i < outputs.Count; i++)
            {
                filterTable[outputs[i].EntityName] = 1;
            }

            Assembly entityAssembly = Assembly.Load("Domain.Main");
            Type domainType = entityAssembly.GetType("Domain.Main.Domain." + domainName);
            IList<GridItem> itemList = BllGridOutput.SearchGridItem(domainType);
            if (!SqlDataHelper.IsDataValid(itemList))
            {
                return;
            }
            for (int i = 0; i < itemList.Count; i++)
            {
                if (filterTable[itemList[i].ItemName] != null) itemList[i].Checked = true;
            }

            GridColumn.DataSource = itemList;
            GridColumn.DataBind();
        }

        protected void LeftGrid_RowClick(object sender, GridRowClickEventArgs e)
        {
            string roleId = tbRoleId.Text = e.RowID;
            string domainName = tbDomainName.Text;

            UpdateColumnGrid(roleId, domainName);
        }

        protected void btnSaveColumn_Click(object sender, EventArgs e)
        {
            List<string> opColumns = new List<string>();
            CheckBoxField column = (CheckBoxField)GridColumn.FindColumn("ColumnStatus");
            for (int i = 0; i < GridColumn.Rows.Count; i++)
            {
                if (column.GetCheckedState(i))
                {
                    opColumns.Add(GridColumn.Rows[i].RowID);
                }
            }
            int result = BllInterfaceOutput.SetInterfaceOutput(tbRoleId.Text, tbDomainName.Text, opColumns, out _);
            if (result <= 0)
            {
                Alert.Show("操作失败,错误代码: " + result);
                return;
            }
            EditWindow.Hidden = true;
        }

        protected void MainGrid_OnRowClick(object sender, GridRowClickEventArgs e)
        {
            tbDomainName.Text = e.RowID;

            GridRole.ClearSelection();
            UpdateColumnGrid(null, null);

            EditWindow.Hidden = false;
        }
    }
}