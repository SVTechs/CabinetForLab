
namespace CabinetMgr
{
    partial class FormUserManage
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
            this.uiButtonAddUser = new Sunny.UI.UIButton();
            this.uiButtonRoleAdd = new Sunny.UI.UIButton();
            this.uiButtonDel = new Sunny.UI.UIButton();
            this.uiDataGridView = new Sunny.UI.UIDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // uiButtonAddUser
            // 
            this.uiButtonAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonAddUser.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAddUser.Location = new System.Drawing.Point(30, 12);
            this.uiButtonAddUser.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonAddUser.Name = "uiButtonAddUser";
            this.uiButtonAddUser.Size = new System.Drawing.Size(403, 91);
            this.uiButtonAddUser.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonAddUser.TabIndex = 0;
            this.uiButtonAddUser.Text = "人员添加";
            this.uiButtonAddUser.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAddUser.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonAddUser.Click += new System.EventHandler(this.uiButtonAddUser_Click);
            // 
            // uiButtonRoleAdd
            // 
            this.uiButtonRoleAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRoleAdd.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleAdd.Location = new System.Drawing.Point(458, 12);
            this.uiButtonRoleAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRoleAdd.Name = "uiButtonRoleAdd";
            this.uiButtonRoleAdd.Size = new System.Drawing.Size(403, 91);
            this.uiButtonRoleAdd.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonRoleAdd.TabIndex = 1;
            this.uiButtonRoleAdd.Text = "权限添加";
            this.uiButtonRoleAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonRoleAdd.Click += new System.EventHandler(this.uiButtonRoleAdd_Click);
            // 
            // uiButtonDel
            // 
            this.uiButtonDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonDel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonDel.Location = new System.Drawing.Point(895, 12);
            this.uiButtonDel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonDel.Name = "uiButtonDel";
            this.uiButtonDel.Size = new System.Drawing.Size(163, 91);
            this.uiButtonDel.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonDel.TabIndex = 2;
            this.uiButtonDel.Text = "删除";
            this.uiButtonDel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonDel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonDel.Click += new System.EventHandler(this.uiButtonDel_Click);
            // 
            // uiDataGridView
            // 
            this.uiDataGridView.AllowUserToAddRows = false;
            this.uiDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.uiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.uiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.uiDataGridView.EnableHeadersVisualStyles = false;
            this.uiDataGridView.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView.Location = new System.Drawing.Point(51, 158);
            this.uiDataGridView.MultiSelect = false;
            this.uiDataGridView.Name = "uiDataGridView";
            this.uiDataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.uiDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("HarmonyOS Sans SC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.uiDataGridView.RowTemplate.Height = 45;
            this.uiDataGridView.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView.SelectedIndex = -1;
            this.uiDataGridView.Size = new System.Drawing.Size(978, 1455);
            this.uiDataGridView.Style = Sunny.UI.UIStyle.Custom;
            this.uiDataGridView.TabIndex = 3;
            this.uiDataGridView.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiDataGridView_CellContentClick);
            // 
            // FormUserManage
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.ClientSize = new System.Drawing.Size(1080, 1725);
            this.Controls.Add(this.uiDataGridView);
            this.Controls.Add(this.uiButtonDel);
            this.Controls.Add(this.uiButtonRoleAdd);
            this.Controls.Add(this.uiButtonAddUser);
            this.Name = "FormUserManage";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FormUserManage_Load);
            this.Shown += new System.EventHandler(this.FormUserManage_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton uiButtonAddUser;
        private Sunny.UI.UIButton uiButtonRoleAdd;
        private Sunny.UI.UIButton uiButtonDel;
        private Sunny.UI.UIDataGridView uiDataGridView;
    }
}