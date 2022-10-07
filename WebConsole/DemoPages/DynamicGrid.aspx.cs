using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using Domain.Server.Types;
using FineUIPro;
using Utilities.DbHelper;
using Utilities.Json;
using WebConsole.BLL;
using WebConsole.Framework.Logic;

namespace WebConsole.DemoPages
{
    public partial class DynamicGrid : PageBase
    {
        private static readonly string PmCodeGridCustomization = "5B48241A-13B9-4353-B31C-53AD63C0D171";

        public string FormId = "43E27390-F57E-448C-BDE1-15D8A3F99A2F";
        public string MainGridColumn = "", CustomGridFull = "";
        public string CustomizationEnabled = "0";

        protected void Page_Init()
        {
            AdjustGrid();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = "值乘司机";

                if (SessionManager.CheckPermission(PmCodeGridCustomization))
                {
                    CustomizationEnabled = "1";
                    IList<GridItem> itemList = BllGridOutput.SearchGridItem(typeof(DutyDriverInfo));
                    CustomGridFull = ConvertJson.ListToJson(itemList);
                }

                UpdateGrid();
            }
        }

        private void UpdateGrid()
        {
            MainGrid.RecordCount = BllDutyDriverInfo.GetDutyDriverInfoCount(out _);
            var data = BllDutyDriverInfo.SearchDutyDriverInfo(MainGrid.PageIndex * MainGrid.PageSize,
                MainGrid.PageSize, DbOrder.GetOrderList(MainGrid.SortDirection, MainGrid.SortField), out _);
            MainGrid.DataSource = data;
            MainGrid.DataBind();
        }

        private void AdjustGrid()
        {
            IList<GridOutput> outputList = BllGridOutput.SearchGridOutput(FormId, out _);
            if (SqlDataHelper.IsDataValid(outputList))
            {
                MainGridColumn = ConvertJson.ListToJson(outputList);

                for (int i = 0; i < outputList?.Count; i++)
                {
                    BoundField bf = new BoundField();
                    bf.HeaderText = outputList[i].EntityDisplayName;
                    bf.DataField = outputList[i].EntityName;
                    bf.SortField = outputList[i].EntityName;
                    bf.BoxFlex = outputList[i].Flex;
                    MainGrid.Columns.Add(bf);
                }
            }
        }

        protected void MainGrid_RowCommand(object sender, GridCommandEventArgs e)
        {
            string dataId = MainGrid.DataKeys[e.RowIndex][0].ToString();
        }

        protected void MainGrid_PageIndexChange(object sender, GridPageEventArgs e)
        {
            UpdateGrid();
        }

        protected void MainGrid_OnSort(object sender, GridSortEventArgs e)
        {
            UpdateGrid();
        }

        protected void MainPanel_PreDataBound(object sender, EventArgs e)
        {

        }
    }
}