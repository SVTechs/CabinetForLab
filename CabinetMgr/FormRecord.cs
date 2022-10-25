using CabinetMgr.BLL;
using CabinetMgr.Common;
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

        private void FormRecord_Shown(object sender, EventArgs e)
        {
            uiTextBoxSeachToolName.Text = "";
            LoadData();
        }

        private void LoadData()
        {
            DateTime startDate = DateTime.Today.AddDays(-3);
            DateTime endDate = DateTime.Today.AddDays(1);
            string searchName = uiTextBoxSeachToolName.Text;
            IList<BorrowRecord> list = BllBorrowRecord.SearchBorrowRecord(startDate, endDate, searchName, 0, 15, null, out Exception ex);
            uiDataGridView.DataSource = list;

            uiDataGridView.Columns["Id"].Visible = false;
            uiDataGridView.Columns["ToolId"].Visible = false;
            uiDataGridView.Columns["WorkerId"].Visible = false;
            uiDataGridView.Columns["Status"].Visible = false;
            uiDataGridView.Columns["ReturnTime"].Visible = false;

            uiDataGridView.Columns["ToolName"].HeaderText = "物资名称";
            uiDataGridView.Columns["ToolPosition"].HeaderText = "物资位置";
            uiDataGridView.Columns["WorkerName"].HeaderText = "人员名称";
            uiDataGridView.Columns["StatusResult"].HeaderText = "操作";
            uiDataGridView.Columns["EventTIme"].HeaderText = "操作时间";
            uiDataGridView.Columns["ToolCount"].HeaderText = "数量";
            uiDataGridView.Columns["ReturnTimeValue"].HeaderText = "归还时间";
        }

        private void uiTextBoxSeachToolName_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void uiTextBoxSeachToolName_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }
    }
}
