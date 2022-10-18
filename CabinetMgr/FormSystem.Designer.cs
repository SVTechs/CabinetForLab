
namespace CabinetMgr
{
    partial class FormSystem
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
            this.uiGroupBoxRole = new Sunny.UI.UIGroupBox();
            this.panelRoleBottom = new System.Windows.Forms.Panel();
            this.uiTreeViewRole = new Sunny.UI.UITreeView();
            this.panelRoleTop = new System.Windows.Forms.Panel();
            this.uiButtonRoleDel = new Sunny.UI.UIButton();
            this.uiButtonRoleEdit = new Sunny.UI.UIButton();
            this.uiButtonRoleAdd = new Sunny.UI.UIButton();
            this.uiGroupBoxToolType = new Sunny.UI.UIGroupBox();
            this.panelToolTypeBottom = new System.Windows.Forms.Panel();
            this.uiDataGridViewToolType = new Sunny.UI.UIDataGridView();
            this.panelToolTypeTop = new System.Windows.Forms.Panel();
            this.uiButtonToolTypeDel = new Sunny.UI.UIButton();
            this.uiButtonToolTypeEdit = new Sunny.UI.UIButton();
            this.uiButtonToolTypeAdd = new Sunny.UI.UIButton();
            this.uiGroupBoxRole.SuspendLayout();
            this.panelRoleBottom.SuspendLayout();
            this.panelRoleTop.SuspendLayout();
            this.uiGroupBoxToolType.SuspendLayout();
            this.panelToolTypeBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewToolType)).BeginInit();
            this.panelToolTypeTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiGroupBoxRole
            // 
            this.uiGroupBoxRole.Controls.Add(this.panelRoleBottom);
            this.uiGroupBoxRole.Controls.Add(this.panelRoleTop);
            this.uiGroupBoxRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBoxRole.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBoxRole.Location = new System.Drawing.Point(0, 35);
            this.uiGroupBoxRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBoxRole.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBoxRole.Name = "uiGroupBoxRole";
            this.uiGroupBoxRole.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBoxRole.Size = new System.Drawing.Size(810, 551);
            this.uiGroupBoxRole.TabIndex = 0;
            this.uiGroupBoxRole.Text = "角色编辑";
            this.uiGroupBoxRole.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBoxRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panelRoleBottom
            // 
            this.panelRoleBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelRoleBottom.Controls.Add(this.uiTreeViewRole);
            this.panelRoleBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRoleBottom.Location = new System.Drawing.Point(0, 132);
            this.panelRoleBottom.Name = "panelRoleBottom";
            this.panelRoleBottom.Size = new System.Drawing.Size(810, 419);
            this.panelRoleBottom.TabIndex = 1;
            // 
            // uiTreeViewRole
            // 
            this.uiTreeViewRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTreeViewRole.FillColor = System.Drawing.Color.White;
            this.uiTreeViewRole.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTreeViewRole.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiTreeViewRole.Location = new System.Drawing.Point(0, 0);
            this.uiTreeViewRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeViewRole.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTreeViewRole.Name = "uiTreeViewRole";
            this.uiTreeViewRole.ShowLines = true;
            this.uiTreeViewRole.ShowText = false;
            this.uiTreeViewRole.Size = new System.Drawing.Size(810, 419);
            this.uiTreeViewRole.TabIndex = 0;
            this.uiTreeViewRole.Text = "uiTreeView1";
            this.uiTreeViewRole.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTreeViewRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panelRoleTop
            // 
            this.panelRoleTop.BackColor = System.Drawing.Color.Transparent;
            this.panelRoleTop.Controls.Add(this.uiButtonRoleDel);
            this.panelRoleTop.Controls.Add(this.uiButtonRoleEdit);
            this.panelRoleTop.Controls.Add(this.uiButtonRoleAdd);
            this.panelRoleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRoleTop.Location = new System.Drawing.Point(0, 32);
            this.panelRoleTop.Name = "panelRoleTop";
            this.panelRoleTop.Size = new System.Drawing.Size(810, 100);
            this.panelRoleTop.TabIndex = 0;
            // 
            // uiButtonRoleDel
            // 
            this.uiButtonRoleDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRoleDel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleDel.Location = new System.Drawing.Point(559, 22);
            this.uiButtonRoleDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRoleDel.Name = "uiButtonRoleDel";
            this.uiButtonRoleDel.Radius = 30;
            this.uiButtonRoleDel.Size = new System.Drawing.Size(120, 50);
            this.uiButtonRoleDel.TabIndex = 2;
            this.uiButtonRoleDel.Text = "删除角色";
            this.uiButtonRoleDel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonRoleDel.Click += new System.EventHandler(this.uiButtonRoleDel_Click);
            // 
            // uiButtonRoleEdit
            // 
            this.uiButtonRoleEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRoleEdit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleEdit.Location = new System.Drawing.Point(353, 22);
            this.uiButtonRoleEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRoleEdit.Name = "uiButtonRoleEdit";
            this.uiButtonRoleEdit.Radius = 30;
            this.uiButtonRoleEdit.Size = new System.Drawing.Size(120, 50);
            this.uiButtonRoleEdit.TabIndex = 1;
            this.uiButtonRoleEdit.Text = "编辑角色";
            this.uiButtonRoleEdit.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonRoleEdit.Click += new System.EventHandler(this.uiButtonRoleEdit_Click);
            // 
            // uiButtonRoleAdd
            // 
            this.uiButtonRoleAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRoleAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleAdd.Location = new System.Drawing.Point(147, 22);
            this.uiButtonRoleAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRoleAdd.Name = "uiButtonRoleAdd";
            this.uiButtonRoleAdd.Radius = 30;
            this.uiButtonRoleAdd.Size = new System.Drawing.Size(120, 50);
            this.uiButtonRoleAdd.TabIndex = 0;
            this.uiButtonRoleAdd.Text = "新建角色";
            this.uiButtonRoleAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonRoleAdd.Click += new System.EventHandler(this.uiButtonRoleAdd_Click);
            // 
            // uiGroupBoxToolType
            // 
            this.uiGroupBoxToolType.Controls.Add(this.panelToolTypeBottom);
            this.uiGroupBoxToolType.Controls.Add(this.panelToolTypeTop);
            this.uiGroupBoxToolType.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBoxToolType.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBoxToolType.Location = new System.Drawing.Point(0, 586);
            this.uiGroupBoxToolType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBoxToolType.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBoxToolType.Name = "uiGroupBoxToolType";
            this.uiGroupBoxToolType.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBoxToolType.Size = new System.Drawing.Size(810, 355);
            this.uiGroupBoxToolType.TabIndex = 1;
            this.uiGroupBoxToolType.Text = "工具类型";
            this.uiGroupBoxToolType.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiGroupBoxToolType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panelToolTypeBottom
            // 
            this.panelToolTypeBottom.Controls.Add(this.uiDataGridViewToolType);
            this.panelToolTypeBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelToolTypeBottom.Location = new System.Drawing.Point(0, 132);
            this.panelToolTypeBottom.Name = "panelToolTypeBottom";
            this.panelToolTypeBottom.Size = new System.Drawing.Size(810, 223);
            this.panelToolTypeBottom.TabIndex = 1;
            // 
            // uiDataGridViewToolType
            // 
            this.uiDataGridViewToolType.AllowUserToAddRows = false;
            this.uiDataGridViewToolType.AllowUserToDeleteRows = false;
            this.uiDataGridViewToolType.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolType.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridViewToolType.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridViewToolType.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolType.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewToolType.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridViewToolType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridViewToolType.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridViewToolType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiDataGridViewToolType.EnableHeadersVisualStyles = false;
            this.uiDataGridViewToolType.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridViewToolType.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolType.Location = new System.Drawing.Point(0, 0);
            this.uiDataGridViewToolType.MultiSelect = false;
            this.uiDataGridViewToolType.Name = "uiDataGridViewToolType";
            this.uiDataGridViewToolType.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridViewToolType.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridViewToolType.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridViewToolType.RowTemplate.Height = 23;
            this.uiDataGridViewToolType.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridViewToolType.SelectedIndex = -1;
            this.uiDataGridViewToolType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.uiDataGridViewToolType.Size = new System.Drawing.Size(810, 223);
            this.uiDataGridViewToolType.TabIndex = 0;
            this.uiDataGridViewToolType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // panelToolTypeTop
            // 
            this.panelToolTypeTop.Controls.Add(this.uiButtonToolTypeDel);
            this.panelToolTypeTop.Controls.Add(this.uiButtonToolTypeEdit);
            this.panelToolTypeTop.Controls.Add(this.uiButtonToolTypeAdd);
            this.panelToolTypeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolTypeTop.Location = new System.Drawing.Point(0, 32);
            this.panelToolTypeTop.Name = "panelToolTypeTop";
            this.panelToolTypeTop.Size = new System.Drawing.Size(810, 100);
            this.panelToolTypeTop.TabIndex = 0;
            // 
            // uiButtonToolTypeDel
            // 
            this.uiButtonToolTypeDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonToolTypeDel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolTypeDel.Location = new System.Drawing.Point(559, 29);
            this.uiButtonToolTypeDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonToolTypeDel.Name = "uiButtonToolTypeDel";
            this.uiButtonToolTypeDel.Radius = 30;
            this.uiButtonToolTypeDel.Size = new System.Drawing.Size(120, 50);
            this.uiButtonToolTypeDel.TabIndex = 3;
            this.uiButtonToolTypeDel.Text = "删除类型";
            this.uiButtonToolTypeDel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolTypeDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonToolTypeDel.Click += new System.EventHandler(this.uiButtonToolTypeDel_Click);
            // 
            // uiButtonToolTypeEdit
            // 
            this.uiButtonToolTypeEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonToolTypeEdit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolTypeEdit.Location = new System.Drawing.Point(353, 29);
            this.uiButtonToolTypeEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonToolTypeEdit.Name = "uiButtonToolTypeEdit";
            this.uiButtonToolTypeEdit.Radius = 30;
            this.uiButtonToolTypeEdit.Size = new System.Drawing.Size(120, 50);
            this.uiButtonToolTypeEdit.TabIndex = 2;
            this.uiButtonToolTypeEdit.Text = "编辑类型";
            this.uiButtonToolTypeEdit.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolTypeEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonToolTypeEdit.Click += new System.EventHandler(this.uiButtonToolTypeEdit_Click);
            // 
            // uiButtonToolTypeAdd
            // 
            this.uiButtonToolTypeAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonToolTypeAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolTypeAdd.Location = new System.Drawing.Point(147, 29);
            this.uiButtonToolTypeAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonToolTypeAdd.Name = "uiButtonToolTypeAdd";
            this.uiButtonToolTypeAdd.Radius = 30;
            this.uiButtonToolTypeAdd.Size = new System.Drawing.Size(120, 50);
            this.uiButtonToolTypeAdd.TabIndex = 1;
            this.uiButtonToolTypeAdd.Text = "新建类型";
            this.uiButtonToolTypeAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolTypeAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonToolTypeAdd.Click += new System.EventHandler(this.uiButtonToolTypeAdd_Click);
            // 
            // FormSystem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(810, 1440);
            this.Controls.Add(this.uiGroupBoxToolType);
            this.Controls.Add(this.uiGroupBoxRole);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSystem";
            this.Text = "FormSystem";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSystem_FormClosed);
            this.Load += new System.EventHandler(this.FormSystem_Load);
            this.uiGroupBoxRole.ResumeLayout(false);
            this.panelRoleBottom.ResumeLayout(false);
            this.panelRoleTop.ResumeLayout(false);
            this.uiGroupBoxToolType.ResumeLayout(false);
            this.panelToolTypeBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridViewToolType)).EndInit();
            this.panelToolTypeTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIGroupBox uiGroupBoxRole;
        private Sunny.UI.UIGroupBox uiGroupBoxToolType;
        private System.Windows.Forms.Panel panelRoleTop;
        private Sunny.UI.UIButton uiButtonRoleAdd;
        private Sunny.UI.UIButton uiButtonRoleDel;
        private Sunny.UI.UIButton uiButtonRoleEdit;
        private System.Windows.Forms.Panel panelRoleBottom;
        private Sunny.UI.UITreeView uiTreeViewRole;
        private System.Windows.Forms.Panel panelToolTypeTop;
        private System.Windows.Forms.Panel panelToolTypeBottom;
        private Sunny.UI.UIButton uiButtonToolTypeDel;
        private Sunny.UI.UIButton uiButtonToolTypeEdit;
        private Sunny.UI.UIButton uiButtonToolTypeAdd;
        private Sunny.UI.UIDataGridView uiDataGridViewToolType;
    }
}