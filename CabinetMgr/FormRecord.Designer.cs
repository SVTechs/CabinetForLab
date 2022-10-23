
namespace CabinetMgr
{
    partial class FormRecord
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.uiButtonQuery = new Sunny.UI.UIButton();
            this.uiButtonExport = new Sunny.UI.UIButton();
            this.uiLabelEndDate = new Sunny.UI.UILabel();
            this.uiLabelStartDate = new Sunny.UI.UILabel();
            this.uiDatePickerEndDate = new Sunny.UI.UIDatePicker();
            this.uiDatePickerStartDate = new Sunny.UI.UIDatePicker();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.uiDataGridViewBorrowRecord = new Sunny.UI.UIDataGridView();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewBorrowRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.uiButtonQuery);
            this.panelTop.Controls.Add(this.uiButtonExport);
            this.panelTop.Controls.Add(this.uiLabelEndDate);
            this.panelTop.Controls.Add(this.uiLabelStartDate);
            this.panelTop.Controls.Add(this.uiDatePickerEndDate);
            this.panelTop.Controls.Add(this.uiDatePickerStartDate);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1026, 125);
            this.panelTop.TabIndex = 0;
            // 
            // uiButtonQuery
            // 
            this.uiButtonQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonQuery.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonQuery.Location = new System.Drawing.Point(669, 43);
            this.uiButtonQuery.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonQuery.Name = "uiButtonQuery";
            this.uiButtonQuery.Radius = 30;
            this.uiButtonQuery.Size = new System.Drawing.Size(100, 35);
            this.uiButtonQuery.TabIndex = 5;
            this.uiButtonQuery.Text = "查询";
            this.uiButtonQuery.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonQuery.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonQuery.Click += new System.EventHandler(this.uiButtonQuery_Click);
            // 
            // uiButtonExport
            // 
            this.uiButtonExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonExport.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonExport.Location = new System.Drawing.Point(869, 43);
            this.uiButtonExport.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonExport.Name = "uiButtonExport";
            this.uiButtonExport.Radius = 30;
            this.uiButtonExport.Size = new System.Drawing.Size(100, 35);
            this.uiButtonExport.TabIndex = 4;
            this.uiButtonExport.Text = "导出";
            this.uiButtonExport.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonExport.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonExport.Click += new System.EventHandler(this.uiButtonExport_Click);
            // 
            // uiLabelEndDate
            // 
            this.uiLabelEndDate.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelEndDate.Location = new System.Drawing.Point(313, 49);
            this.uiLabelEndDate.Name = "uiLabelEndDate";
            this.uiLabelEndDate.Size = new System.Drawing.Size(100, 23);
            this.uiLabelEndDate.TabIndex = 3;
            this.uiLabelEndDate.Text = "截止日期";
            this.uiLabelEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelEndDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelStartDate
            // 
            this.uiLabelStartDate.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelStartDate.Location = new System.Drawing.Point(37, 49);
            this.uiLabelStartDate.Name = "uiLabelStartDate";
            this.uiLabelStartDate.Size = new System.Drawing.Size(100, 23);
            this.uiLabelStartDate.TabIndex = 2;
            this.uiLabelStartDate.Text = "开始日期";
            this.uiLabelStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelStartDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiDatePickerEndDate
            // 
            this.uiDatePickerEndDate.FillColor = System.Drawing.Color.White;
            this.uiDatePickerEndDate.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDatePickerEndDate.Location = new System.Drawing.Point(426, 46);
            this.uiDatePickerEndDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePickerEndDate.MaxLength = 10;
            this.uiDatePickerEndDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePickerEndDate.Name = "uiDatePickerEndDate";
            this.uiDatePickerEndDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePickerEndDate.Size = new System.Drawing.Size(150, 29);
            this.uiDatePickerEndDate.SymbolDropDown = 61555;
            this.uiDatePickerEndDate.SymbolNormal = 61555;
            this.uiDatePickerEndDate.TabIndex = 1;
            this.uiDatePickerEndDate.Text = "2022-10-18";
            this.uiDatePickerEndDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePickerEndDate.Value = new System.DateTime(2022, 10, 18, 11, 38, 49, 420);
            this.uiDatePickerEndDate.Watermark = "";
            this.uiDatePickerEndDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiDatePickerStartDate
            // 
            this.uiDatePickerStartDate.FillColor = System.Drawing.Color.White;
            this.uiDatePickerStartDate.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDatePickerStartDate.Location = new System.Drawing.Point(150, 46);
            this.uiDatePickerStartDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDatePickerStartDate.MaxLength = 10;
            this.uiDatePickerStartDate.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiDatePickerStartDate.Name = "uiDatePickerStartDate";
            this.uiDatePickerStartDate.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiDatePickerStartDate.Size = new System.Drawing.Size(150, 29);
            this.uiDatePickerStartDate.SymbolDropDown = 61555;
            this.uiDatePickerStartDate.SymbolNormal = 61555;
            this.uiDatePickerStartDate.TabIndex = 0;
            this.uiDatePickerStartDate.Text = "2022-10-18";
            this.uiDatePickerStartDate.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiDatePickerStartDate.Value = new System.DateTime(2022, 10, 18, 0, 0, 0, 0);
            this.uiDatePickerStartDate.Watermark = "";
            this.uiDatePickerStartDate.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.uiDataGridViewBorrowRecord);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 125);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1026, 1429);
            this.panelBottom.TabIndex = 1;
            // 
            // uiDataGridViewBorrowRecord
            // 
            this.uiDataGridViewBorrowRecord.AllowUserToAddRows = false;
            this.uiDataGridViewBorrowRecord.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridViewBorrowRecord.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridViewBorrowRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridViewBorrowRecord.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridViewBorrowRecord.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewBorrowRecord.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridViewBorrowRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridViewBorrowRecord.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridViewBorrowRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridViewBorrowRecord.EnableHeadersVisualStyles = false;
            this.uiDataGridViewBorrowRecord.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridViewBorrowRecord.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridViewBorrowRecord.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridViewBorrowRecord.MultiSelect = false;
            this.uiDataGridViewBorrowRecord.Name = "uiDataGridViewBorrowRecord";
            this.uiDataGridViewBorrowRecord.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewBorrowRecord.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridViewBorrowRecord.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridViewBorrowRecord.RowTemplate.Height = 23;
            this.uiDataGridViewBorrowRecord.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridViewBorrowRecord.SelectedIndex = -1;
            this.uiDataGridViewBorrowRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridViewBorrowRecord.Size = new System.Drawing.Size(1026, 1429);
            this.uiDataGridViewBorrowRecord.TabIndex = 0;
            this.uiDataGridViewBorrowRecord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormRecord
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1026, 1554);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FormRecord";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Tag = "4";
            this.Text = "FormRecord";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1010, 1577);
            this.Load += new System.EventHandler(this.FormRecord_Load);
            this.Shown += new System.EventHandler(this.FormRecord_Shown);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewBorrowRecord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private Sunny.UI.UIDataGridView uiDataGridViewBorrowRecord;
        private Sunny.UI.UIButton uiButtonQuery;
        private Sunny.UI.UIButton uiButtonExport;
        private Sunny.UI.UILabel uiLabelEndDate;
        private Sunny.UI.UILabel uiLabelStartDate;
        private Sunny.UI.UIDatePicker uiDatePickerEndDate;
        private Sunny.UI.UIDatePicker uiDatePickerStartDate;
    }
}