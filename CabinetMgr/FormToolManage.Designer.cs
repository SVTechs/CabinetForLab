
namespace CabinetMgr
{
    partial class FormToolManage
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
            this.uiButtonDel = new Sunny.UI.UIButton();
            this.uiButtonEdit = new Sunny.UI.UIButton();
            this.uiButtonAdd = new Sunny.UI.UIButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.uiDataGridViewToolInfo = new Sunny.UI.UIDataGridView();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewToolInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.uiButtonDel);
            this.panelTop.Controls.Add(this.uiButtonEdit);
            this.panelTop.Controls.Add(this.uiButtonAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1026, 115);
            this.panelTop.TabIndex = 0;
            // 
            // uiButtonDel
            // 
            this.uiButtonDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonDel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonDel.Location = new System.Drawing.Point(751, 28);
            this.uiButtonDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonDel.Name = "uiButtonDel";
            this.uiButtonDel.Radius = 30;
            this.uiButtonDel.Size = new System.Drawing.Size(120, 50);
            this.uiButtonDel.TabIndex = 2;
            this.uiButtonDel.Text = "删除工具";
            this.uiButtonDel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonDel.Click += new System.EventHandler(this.uiButtonDel_Click);
            // 
            // uiButtonEdit
            // 
            this.uiButtonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonEdit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonEdit.Location = new System.Drawing.Point(453, 28);
            this.uiButtonEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonEdit.Name = "uiButtonEdit";
            this.uiButtonEdit.Radius = 30;
            this.uiButtonEdit.Size = new System.Drawing.Size(120, 50);
            this.uiButtonEdit.TabIndex = 1;
            this.uiButtonEdit.Text = "编辑工具";
            this.uiButtonEdit.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonEdit.Click += new System.EventHandler(this.uiButtonEdit_Click);
            // 
            // uiButtonAdd
            // 
            this.uiButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAdd.Location = new System.Drawing.Point(155, 28);
            this.uiButtonAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonAdd.Name = "uiButtonAdd";
            this.uiButtonAdd.Radius = 30;
            this.uiButtonAdd.Size = new System.Drawing.Size(120, 50);
            this.uiButtonAdd.TabIndex = 0;
            this.uiButtonAdd.Text = "新增工具";
            this.uiButtonAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonAdd.Click += new System.EventHandler(this.uiButtonAdd_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.uiDataGridViewToolInfo);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 115);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1026, 1439);
            this.panelBottom.TabIndex = 1;
            // 
            // uiDataGridViewToolInfo
            // 
            this.uiDataGridViewToolInfo.AllowUserToAddRows = false;
            this.uiDataGridViewToolInfo.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridViewToolInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridViewToolInfo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewToolInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridViewToolInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridViewToolInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridViewToolInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridViewToolInfo.EnableHeadersVisualStyles = false;
            this.uiDataGridViewToolInfo.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridViewToolInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolInfo.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridViewToolInfo.MultiSelect = false;
            this.uiDataGridViewToolInfo.Name = "uiDataGridViewToolInfo";
            this.uiDataGridViewToolInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewToolInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridViewToolInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridViewToolInfo.RowTemplate.Height = 23;
            this.uiDataGridViewToolInfo.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolInfo.SelectedIndex = -1;
            this.uiDataGridViewToolInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridViewToolInfo.Size = new System.Drawing.Size(1026, 1439);
            this.uiDataGridViewToolInfo.TabIndex = 0;
            this.uiDataGridViewToolInfo.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormToolManage
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1026, 1554);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "FormToolManage";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Tag = "3";
            this.Text = "FormToolManage";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormToolManage_FormClosed);
            this.Load += new System.EventHandler(this.FormToolManage_Load);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewToolInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private Sunny.UI.UIDataGridView uiDataGridViewToolInfo;
        private Sunny.UI.UIButton uiButtonAdd;
        private Sunny.UI.UIButton uiButtonDel;
        private Sunny.UI.UIButton uiButtonEdit;
    }
}