
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.uiTextBoxSeachToolName = new Sunny.UI.UITextBox();
            this.panelDataGridView = new System.Windows.Forms.Panel();
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
            this.panelDataGridView.Controls.Add(this.uiDataGridView);
            this.panelDataGridView.Controls.Add(this.flowLayoutPanelSearch);
            this.panelDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDataGridView.Location = new System.Drawing.Point(0, 0);
            this.panelDataGridView.Name = "panelDataGridView";
            this.panelDataGridView.Size = new System.Drawing.Size(1080, 1785);
            this.panelDataGridView.TabIndex = 9;
            // 
            // uiDataGridView
            // 
            this.uiDataGridView.AllowUserToAddRows = false;
            this.uiDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.uiDataGridView.EnableHeadersVisualStyles = false;
            this.uiDataGridView.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiDataGridView.Location = new System.Drawing.Point(53, 174);
            this.uiDataGridView.MultiSelect = false;
            this.uiDataGridView.Name = "uiDataGridView";
            this.uiDataGridView.ReadOnly = true;
            this.uiDataGridView.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.uiDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("HarmonyOS Sans SC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.uiDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
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
    }
}