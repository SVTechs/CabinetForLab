
namespace CabinetMgr
{
    partial class FormRoleEdit
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
            this.uiLabelRoleManage = new System.Windows.Forms.Label();
            this.uiTreeViewRole = new Sunny.UI.UITreeView();
            this.uiTreeViewLattice = new Sunny.UI.UITreeView();
            this.uiButtonAddRole = new System.Windows.Forms.Button();
            this.uiButtonRoleDelete = new System.Windows.Forms.Button();
            this.uiButtonSave = new System.Windows.Forms.Button();
            this.uiButtonCancel = new System.Windows.Forms.Button();
            this.uiLabelRoleName = new System.Windows.Forms.Label();
            this.uiTextBoxRoleName = new Sunny.UI.UITextBox();
            this.uiButtonRoleSave = new System.Windows.Forms.Button();
            this.uiTextBoxRoleOrder = new Sunny.UI.UITextBox();
            this.uiLabelRoleOrder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uiLabelRoleManage
            // 
            this.uiLabelRoleManage.Font = new System.Drawing.Font("HarmonyOS Sans SC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelRoleManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelRoleManage.Location = new System.Drawing.Point(398, 19);
            this.uiLabelRoleManage.Name = "uiLabelRoleManage";
            this.uiLabelRoleManage.Size = new System.Drawing.Size(249, 60);
            this.uiLabelRoleManage.TabIndex = 0;
            this.uiLabelRoleManage.Text = "权限添加";
            this.uiLabelRoleManage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTreeViewRole
            // 
            this.uiTreeViewRole.FillColor = System.Drawing.Color.White;
            this.uiTreeViewRole.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTreeViewRole.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiTreeViewRole.Location = new System.Drawing.Point(71, 277);
            this.uiTreeViewRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeViewRole.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTreeViewRole.Name = "uiTreeViewRole";
            this.uiTreeViewRole.ShowText = false;
            this.uiTreeViewRole.Size = new System.Drawing.Size(406, 565);
            this.uiTreeViewRole.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeViewRole.TabIndex = 3;
            this.uiTreeViewRole.Text = null;
            this.uiTreeViewRole.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTreeViewRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTreeViewRole.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.uiTreeViewRole_NodeMouseClick);
            // 
            // uiTreeViewLattice
            // 
            this.uiTreeViewLattice.CheckBoxes = true;
            this.uiTreeViewLattice.FillColor = System.Drawing.Color.White;
            this.uiTreeViewLattice.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTreeViewLattice.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiTreeViewLattice.Location = new System.Drawing.Point(528, 277);
            this.uiTreeViewLattice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTreeViewLattice.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTreeViewLattice.Name = "uiTreeViewLattice";
            this.uiTreeViewLattice.ShowText = false;
            this.uiTreeViewLattice.Size = new System.Drawing.Size(406, 565);
            this.uiTreeViewLattice.Style = Sunny.UI.UIStyle.Custom;
            this.uiTreeViewLattice.TabIndex = 4;
            this.uiTreeViewLattice.Text = null;
            this.uiTreeViewLattice.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTreeViewLattice.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonAddRole
            // 
            this.uiButtonAddRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonAddRole.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonAddRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButtonAddRole.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonAddRole.ForeColor = System.Drawing.Color.White;
            this.uiButtonAddRole.Location = new System.Drawing.Point(71, 197);
            this.uiButtonAddRole.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonAddRole.Name = "uiButtonAddRole";
            this.uiButtonAddRole.Size = new System.Drawing.Size(157, 48);
            this.uiButtonAddRole.TabIndex = 5;
            this.uiButtonAddRole.Text = "新建权限";
            this.uiButtonAddRole.UseVisualStyleBackColor = false;
            this.uiButtonAddRole.Click += new System.EventHandler(this.uiButtonAddRole_Click);
            // 
            // uiButtonRoleDelete
            // 
            this.uiButtonRoleDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonRoleDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRoleDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButtonRoleDelete.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleDelete.ForeColor = System.Drawing.Color.White;
            this.uiButtonRoleDelete.Location = new System.Drawing.Point(307, 197);
            this.uiButtonRoleDelete.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRoleDelete.Name = "uiButtonRoleDelete";
            this.uiButtonRoleDelete.Size = new System.Drawing.Size(157, 48);
            this.uiButtonRoleDelete.TabIndex = 6;
            this.uiButtonRoleDelete.Text = "删除权限";
            this.uiButtonRoleDelete.UseVisualStyleBackColor = false;
            this.uiButtonRoleDelete.Click += new System.EventHandler(this.uiButtonRoleDelete_Click);
            // 
            // uiButtonSave
            // 
            this.uiButtonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButtonSave.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.ForeColor = System.Drawing.Color.White;
            this.uiButtonSave.Location = new System.Drawing.Point(528, 197);
            this.uiButtonSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonSave.Name = "uiButtonSave";
            this.uiButtonSave.Size = new System.Drawing.Size(157, 48);
            this.uiButtonSave.TabIndex = 7;
            this.uiButtonSave.Text = "保存";
            this.uiButtonSave.UseVisualStyleBackColor = false;
            this.uiButtonSave.Click += new System.EventHandler(this.uiButtonSave_Click);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButtonCancel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.ForeColor = System.Drawing.Color.White;
            this.uiButtonCancel.Location = new System.Drawing.Point(777, 197);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(157, 48);
            this.uiButtonCancel.TabIndex = 8;
            this.uiButtonCancel.Text = "取消";
            this.uiButtonCancel.UseVisualStyleBackColor = false;
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // uiLabelRoleName
            // 
            this.uiLabelRoleName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelRoleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelRoleName.Location = new System.Drawing.Point(76, 115);
            this.uiLabelRoleName.Name = "uiLabelRoleName";
            this.uiLabelRoleName.Size = new System.Drawing.Size(127, 41);
            this.uiLabelRoleName.TabIndex = 9;
            this.uiLabelRoleName.Text = "权限名称：";
            this.uiLabelRoleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelRoleName.Visible = false;
            // 
            // uiTextBoxRoleName
            // 
            this.uiTextBoxRoleName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxRoleName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxRoleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxRoleName.Location = new System.Drawing.Point(210, 115);
            this.uiTextBoxRoleName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxRoleName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxRoleName.Name = "uiTextBoxRoleName";
            this.uiTextBoxRoleName.RectSize = 2;
            this.uiTextBoxRoleName.ShowText = false;
            this.uiTextBoxRoleName.Size = new System.Drawing.Size(197, 41);
            this.uiTextBoxRoleName.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxRoleName.StyleCustomMode = true;
            this.uiTextBoxRoleName.TabIndex = 10;
            this.uiTextBoxRoleName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxRoleName.Visible = false;
            this.uiTextBoxRoleName.Watermark = "";
            this.uiTextBoxRoleName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTextBoxRoleName.Enter += new System.EventHandler(this.uiTextBoxRoleName_Enter);
            // 
            // uiButtonRoleSave
            // 
            this.uiButtonRoleSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonRoleSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRoleSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiButtonRoleSave.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRoleSave.ForeColor = System.Drawing.Color.White;
            this.uiButtonRoleSave.Location = new System.Drawing.Point(777, 108);
            this.uiButtonRoleSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRoleSave.Name = "uiButtonRoleSave";
            this.uiButtonRoleSave.Size = new System.Drawing.Size(157, 48);
            this.uiButtonRoleSave.TabIndex = 11;
            this.uiButtonRoleSave.Text = "保存权限";
            this.uiButtonRoleSave.UseVisualStyleBackColor = false;
            this.uiButtonRoleSave.Visible = false;
            this.uiButtonRoleSave.Click += new System.EventHandler(this.uiButtonRoleSave_Click);
            // 
            // uiTextBoxRoleOrder
            // 
            this.uiTextBoxRoleOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxRoleOrder.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxRoleOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxRoleOrder.Location = new System.Drawing.Point(573, 115);
            this.uiTextBoxRoleOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxRoleOrder.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxRoleOrder.Name = "uiTextBoxRoleOrder";
            this.uiTextBoxRoleOrder.RectSize = 2;
            this.uiTextBoxRoleOrder.ShowText = false;
            this.uiTextBoxRoleOrder.Size = new System.Drawing.Size(164, 41);
            this.uiTextBoxRoleOrder.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxRoleOrder.StyleCustomMode = true;
            this.uiTextBoxRoleOrder.TabIndex = 13;
            this.uiTextBoxRoleOrder.Text = "0";
            this.uiTextBoxRoleOrder.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxRoleOrder.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBoxRoleOrder.Visible = false;
            this.uiTextBoxRoleOrder.Watermark = "";
            this.uiTextBoxRoleOrder.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelRoleOrder
            // 
            this.uiLabelRoleOrder.Font = new System.Drawing.Font("HarmonyOS Sans SC", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelRoleOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelRoleOrder.Location = new System.Drawing.Point(439, 115);
            this.uiLabelRoleOrder.Name = "uiLabelRoleOrder";
            this.uiLabelRoleOrder.Size = new System.Drawing.Size(127, 41);
            this.uiLabelRoleOrder.TabIndex = 12;
            this.uiLabelRoleOrder.Text = "权限排序：";
            this.uiLabelRoleOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelRoleOrder.Visible = false;
            // 
            // FormRoleEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(1007, 895);
            this.Controls.Add(this.uiTextBoxRoleOrder);
            this.Controls.Add(this.uiLabelRoleOrder);
            this.Controls.Add(this.uiButtonRoleSave);
            this.Controls.Add(this.uiTextBoxRoleName);
            this.Controls.Add(this.uiLabelRoleName);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiButtonSave);
            this.Controls.Add(this.uiButtonRoleDelete);
            this.Controls.Add(this.uiTreeViewLattice);
            this.Controls.Add(this.uiButtonAddRole);
            this.Controls.Add(this.uiTreeViewRole);
            this.Controls.Add(this.uiLabelRoleManage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRoleEdit";
            this.ShowInTaskbar = false;
            this.Text = "FormRoleEdit";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FormRoleEdit_Shown);
            this.Click += new System.EventHandler(this.FormRoleEdit_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label uiLabelRoleManage;
        private Sunny.UI.UITreeView uiTreeViewRole;
        private Sunny.UI.UITreeView uiTreeViewLattice;
        private System.Windows.Forms.Button uiButtonAddRole;
        private System.Windows.Forms.Button uiButtonRoleDelete;
        private System.Windows.Forms.Button uiButtonSave;
        private System.Windows.Forms.Button uiButtonCancel;
        private System.Windows.Forms.Label uiLabelRoleName;
        private Sunny.UI.UITextBox uiTextBoxRoleName;
        private System.Windows.Forms.Button uiButtonRoleSave;
        private Sunny.UI.UITextBox uiTextBoxRoleOrder;
        private System.Windows.Forms.Label uiLabelRoleOrder;
    }
}