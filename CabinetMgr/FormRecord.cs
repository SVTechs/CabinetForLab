using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormRecord : Form
    {
        public FormRecord()
        {
            InitializeComponent();
        }

        private void FormRecord_Shown(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            DateTime startDate = DateTime.Today.AddDays(-3);
            DateTime endDate = DateTime.Today.AddDays(1);
            string searchName = uiTextBoxSeachToolName.Text;
            int page = uiPagination.ActivePage;
            int pageSize = uiPagination.PageSize;
            IList<BorrowRecord> list = BllBorrowRecord.SearchBorrowRecord(startDate, endDate, searchName
                ,  (page-1)*pageSize, pageSize, null, out Exception ex);
            int recordCount = BllBorrowRecord.GetBorrowRecordCount(startDate, endDate, searchName, out ex);
            uiDataGridView.DataSource = list;
            uiPagination.TotalCount = recordCount;

            uiDataGridView.Columns["Id"].Visible = false;
            uiDataGridView.Columns["ToolId"].Visible = false;
            uiDataGridView.Columns["WorkerId"].Visible = false;
            uiDataGridView.Columns["Status"].Visible = false;
            uiDataGridView.Columns["ReturnTime"].Visible = false;

            uiDataGridView.Columns["ToolName"].HeaderText = "物资名称";
            uiDataGridView.Columns["ToolName"].Width = 120;
            uiDataGridView.Columns["ToolPosition"].HeaderText = "物资位置";
            uiDataGridView.Columns["ToolPosition"].Width = 120;
            uiDataGridView.Columns["WorkerName"].HeaderText = "人员名称";
            uiDataGridView.Columns["WorkerName"].Width = 120;
            uiDataGridView.Columns["StatusResult"].HeaderText = "操作";
            uiDataGridView.Columns["StatusResult"].Width = 120;
            uiDataGridView.Columns["EventTIme"].HeaderText = "操作时间";
            uiDataGridView.Columns["EventTIme"].Width = 180;
            uiDataGridView.Columns["ToolCount"].HeaderText = "数量";
            uiDataGridView.Columns["ToolCount"].Width = 100;
            uiDataGridView.Columns["ReturnTimeValue"].HeaderText = "归还时间";
            uiDataGridView.Columns["ReturnTimeValue"].Width = 180;
        }

        private void uiTextBoxSeachToolName_TextChanged(object sender, EventArgs e)
        {
            uiPagination.ActivePage = 1;
            LoadData();
        }

        private void uiTextBoxSeachToolName_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void uiPagination_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            LoadData();
        }

        private void FormRecord_VisibleChanged(object sender, EventArgs e)
        {
            uiTextBoxSeachToolName.Text = "";
            //LoadData();
            uiPagination.ActivePage = 1;
        }
    }
}
