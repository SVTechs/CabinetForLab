
using System.Windows.Forms;

namespace CabinetMgr
{
    partial class FormRoleManage
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.uiButtonEditLatticePermission = new Sunny.UI.UIButton();
            this.uiButtonDelete = new Sunny.UI.UIButton();
            this.uiButtonEdit = new Sunny.UI.UIButton();
            this.uiButtonAdd = new Sunny.UI.UIButton();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.uiTreeViewRole = new Sunny.UI.UITreeView();
            this.panelTop.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.uiButtonEditLatticePermission);
            this.panelTop.Controls.Add(this.uiButtonDelete);
            this.panelTop.Controls.Add(this.uiButtonEdit);
            this.panelTop.Controls.Add(this.uiButtonAdd);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1018, 107);
            this.panelTop.TabIndex = 1;
            // 
            // uiButtonEditLatticePermission
            // 
            this.uiButtonEditLatticePermission.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonEditLatticePermission.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonEditLatticePermission.Location = new System.Drawing.Point(614, 21);
            this.uiButtonEditLatticePermission.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonEditLatticePermission.Name = "uiButtonEditLatticePermission";
            this.uiButtonEditLatticePermission.Radius = 30;
            this.uiButtonEditLatticePermission.Size = new System.Drawing.Size(100, 35);
            this.uiButtonEditLatticePermission.TabIndex = 6;
            this.uiButtonEditLatticePermission.Text = "储物权限";
            this.uiButtonEditLatticePermission.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonEditLatticePermission.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonEditLatticePermission.Click += new System.EventHandler(this.uiButtonEditLatticePermission_Click);
            // 
            // uiButtonDelete
            // 
            this.uiButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonDelete.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonDelete.Location = new System.Drawing.Point(476, 21);
            this.uiButtonDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonDelete.Name = "uiButtonDelete";
            this.uiButtonDelete.Radius = 30;
            this.uiButtonDelete.Size = new System.Drawing.Size(100, 35);
            this.uiButtonDelete.TabIndex = 5;
            this.uiButtonDelete.Text = "删除";
            this.uiButtonDelete.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonDelete.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonDelete.Click += new System.EventHandler(this.uiButtonDelete_Click);
            // 
            // uiButtonEdit
            // 
            this.uiButtonEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonEdit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonEdit.Location = new System.Drawing.Point(313, 21);
            this.uiButtonEdit.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonEdit.Name = "uiButtonEdit";
            this.uiButtonEdit.Radius = 30;
            this.uiButtonEdit.Size = new System.Drawing.Size(100, 35);
            this.uiButtonEdit.TabIndex = 4;
            this.uiButtonEdit.Text = "编辑";
            this.uiButtonEdit.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonEdit.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonEdit.Click += new System.EventHandler(this.uiButtonEdit_Click);
            // 
            // uiButtonAdd
            // 
            this.uiButtonAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonAdd.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAdd.Location = new System.Drawing.Point(107, 21);
            this.uiButtonAdd.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonAdd.Name = "uiButtonAdd";
            this.uiButtonAdd.Radius = 30;
            this.uiButtonAdd.Size = new System.Drawing.Size(100, 35);
            this.uiButtonAdd.TabIndex = 3;
            this.uiButtonAdd.Text = "添加";
            this.uiButtonAdd.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAdd.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonAdd.Click += new System.EventHandler(this.uiButtonAdd_Click);
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.uiTreeViewRole);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, -372);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1018, 1472);
            this.panelBottom.TabIndex = 2;
            // 
            // uiTreeViewRole
            // 
            this.uiTreeViewRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTreeViewRole.FillColor = System.Drawing.Color.White;
            this.uiTreeViewRole.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTreeViewRole.Location = new System.Drawing.Point(0, 0);
            this.uiTreeViewRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeViewRole.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTreeViewRole.Name = "uiTreeViewRole";
            this.uiTreeViewRole.ShowLines = true;
            this.uiTreeViewRole.ShowText = false;
            this.uiTreeViewRole.Size = new System.Drawing.Size(1018, 1472);
            this.uiTreeViewRole.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeViewRole.TabIndex = 0;
            this.uiTreeViewRole.Text = "uiTreeViewRole";
            this.uiTreeViewRole.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTreeViewRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormRoleManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1018, 1100);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRoleManage";
            this.Text = "FormRoleManage";
            this.Load += new System.EventHandler(this.FormRoleManage_Load);
            this.panelTop.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelBottom;
        private Sunny.UI.UIButton uiButtonAdd;
        private Sunny.UI.UIButton uiButtonEdit;
        private Sunny.UI.UIButton uiButtonDelete;
        private Sunny.UI.UIButton uiButtonEditLatticePermission;
        private Sunny.UI.UITreeView uiTreeViewRole;
    }
}