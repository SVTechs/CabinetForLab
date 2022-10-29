
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.uiDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.uiDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView.EnableHeadersVisualStyles = false;
            this.uiDataGridView.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView.Location = new System.Drawing.Point(51, 158);
            this.uiDataGridView.MultiSelect = false;
            this.uiDataGridView.Name = "uiDataGridView";
            this.uiDataGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.uiDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("HarmonyOS Sans SC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView.RowTemplate.Height = 45;
            this.uiDataGridView.ScrollBarRectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiDataGridView.SelectedIndex = -1;
            this.uiDataGridView.Size = new System.Drawing.Size(978, 1455);
            this.uiDataGridView.TabIndex = 3;
            this.uiDataGridView.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiDataGridView_CellContentClick);
            // 
            // FormUserManage
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.ClientSize = new System.Drawing.Size(1080, 1770);
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