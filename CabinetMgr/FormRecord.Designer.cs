
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
            this.flowLayoutPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.uiTextBoxSeachToolName = new Sunny.UI.UITextBox();
            this.panelDataGridView = new System.Windows.Forms.Panel();
            this.uiPagination = new Sunny.UI.UIPagination();
            this.uiDataGridView = new Sunny.UI.UIDataGridView();
            this.flowLayoutPanelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.panelDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanelSearch
            // 
            this.flowLayoutPanelSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.flowLayoutPanelSearch.Controls.Add(this.pictureBoxSearch);
            this.flowLayoutPanelSearch.Controls.Add(this.uiTextBoxSeachToolName);
            this.flowLayoutPanelSearch.Location = new System.Drawing.Point(3, 77);
            this.flowLayoutPanelSearch.Name = "flowLayoutPanelSearch";
            this.flowLayoutPanelSearch.Size = new System.Drawing.Size(1080, 80);
            this.flowLayoutPanelSearch.TabIndex = 8;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.pictureBoxSearch.BackgroundImage = global::CabinetMgr.Properties.Resources.TextBoxSearch;
            this.pictureBoxSearch.Location = new System.Drawing.Point(50, 5);
            this.pictureBoxSearch.Margin = new System.Windows.Forms.Padding(50, 5, 1, 5);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(58, 58);
            this.pictureBoxSearch.TabIndex = 0;
            this.pictureBoxSearch.TabStop = false;
            // 
            // uiTextBoxSeachToolName
            // 
            this.uiTextBoxSeachToolName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxSeachToolName.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiTextBoxSeachToolName.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiTextBoxSeachToolName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxSeachToolName.Location = new System.Drawing.Point(110, 5);
            this.uiTextBoxSeachToolName.Margin = new System.Windows.Forms.Padding(1, 5, 5, 5);
            this.uiTextBoxSeachToolName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxSeachToolName.Name = "uiTextBoxSeachToolName";
            this.uiTextBoxSeachToolName.ShowText = false;
            this.uiTextBoxSeachToolName.Size = new System.Drawing.Size(918, 58);
            this.uiTextBoxSeachToolName.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxSeachToolName.TabIndex = 1;
            this.uiTextBoxSeachToolName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxSeachToolName.Watermark = "请输入物资名称";
            this.uiTextBoxSeachToolName.WatermarkActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxSeachToolName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTextBoxSeachToolName.TextChanged += new System.EventHandler(this.uiTextBoxSeachToolName_TextChanged);
            this.uiTextBoxSeachToolName.Enter += new System.EventHandler(this.uiTextBoxSeachToolName_Enter);
            // 
            // panelDataGridView
            // 
            this.panelDataGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.panelDataGridView.Controls.Add(this.uiPagination);
            this.panelDataGridView.Controls.Add(this.uiDataGridView);
            this.panelDataGridView.Controls.Add(this.flowLayoutPanelSearch);
            this.panelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGridView.Location = new System.Drawing.Point(0, 0);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(1080, 1785);
            this.panelDataGridView.TabIndex = 9;
            // 
            // uiPagination
            // 
            this.uiPagination.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiPagination.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPagination.Location = new System.Drawing.Point(182, 1653);
            this.uiPagination.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination.Name = "uiPagination";
            this.uiPagination.PageSize = 25;
            this.uiPagination.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination.ShowText = false;
            this.uiPagination.Size = new System.Drawing.Size(713, 35);
            this.uiPagination.Style = Sunny.UI.UIStyle.Custom;
            this.uiPagination.TabIndex = 9;
            this.uiPagination.Text = "uiPagination1";
            this.uiPagination.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiPagination.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination_PageChanged);
            // 
            // uiDataGridView
            // 
            this.uiDataGridView.AllowUserToAddRows = false;
            this.uiDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView.EnableHeadersVisualStyles = false;
            this.uiDataGridView.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiDataGridView.Location = new System.Drawing.Point(53, 174);
            this.uiDataGridView.MultiSelect = false;
            this.uiDataGridView.Name = "uiDataGridView";
            this.uiDataGridView.ReadOnly = true;
            this.uiDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("HarmonyOS Sans SC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.uiDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView.RowTemplate.Height = 45;
            this.uiDataGridView.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView.SelectedIndex = -1;
            this.uiDataGridView.Size = new System.Drawing.Size(978, 1455);
            this.uiDataGridView.StripeEvenColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiDataGridView.StripeOddColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView.TabIndex = 0;
            this.uiDataGridView.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormRecord
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.ClientSize = new System.Drawing.Size(1080, 1785);
            this.Controls.Add(this.panelDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRecord";
            this.Text = "FormRecord";
            this.Shown += new System.EventHandler(this.FormRecord_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormRecord_VisibleChanged);
            this.flowLayoutPanelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.panelDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelSearch;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private Sunny.UI.UITextBox uiTextBoxSeachToolName;
        private System.Windows.Forms.Panel panelDataGridView;
        private Sunny.UI.UIDataGridView uiDataGridView;
        private Sunny.UI.UIPagination uiPagination;
    }
}