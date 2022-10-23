using CabinetMgr.BLL;
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
    public partial class FormRecord : UIForm
    {
        public FormRecord()
        {
            InitializeComponent();
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.Today;
            uiDatePickerStartDate.Value = new DateTime(currentDate.Year, currentDate.Month, 1);
            uiDatePickerStartDate.Text = uiDatePickerStartDate.Value.ToString("yyyy-MM-dd");
            uiDatePickerEndDate.Value = currentDate.AddDays(1);
            uiDatePickerEndDate.Text = uiDatePickerEndDate.Value.ToString("yyyy-MM-dd");

        }

        private void uiButtonQuery_Click(object sender, EventArgs e)
        {
            LoadBorrowRecord();
        }

        private void uiButtonExport_Click(object sender, EventArgs e)
        {

        }

        private void LoadBorrowRecord()
        {
            DateTime startDate = uiDatePickerStartDate.Value;
            DateTime endDate = uiDatePickerEndDate.Value;
            IList<BorrowRecord> recordList = BllBorrowRecord.SearchBorrowRecord(startDate, endDate, 0, -1, null, out Exception ex);
            uiDataGridViewBorrowRecord.DataSource = recordList;


            uiDataGridViewBorrowRecord.Columns["Id"].Visible = false;
            uiDataGridViewBorrowRecord.Columns["ToolId"].Visible = false;
            uiDataGridViewBorrowRecord.Columns["WorkerId"].Visible = false;
            uiDataGridViewBorrowRecord.Columns["Status"].Visible = false;
            

            uiDataGridViewBorrowRecord.Columns["ToolName"].HeaderText = "工具名称";
            uiDataGridViewBorrowRecord.Columns["ToolPosition"].HeaderText = "工具位置";
            uiDataGridViewBorrowRecord.Columns["WorkerName"].HeaderText = "借取人";
            uiDataGridViewBorrowRecord.Columns["EventTime"].HeaderText = "借取时间";
            uiDataGridViewBorrowRecord.Columns["ReturnTime"].HeaderText = "归还时间";
        }

        private void FormRecord_Shown(object sender, EventArgs e)
        {
            LoadBorrowRecord();
        }
    }
}
