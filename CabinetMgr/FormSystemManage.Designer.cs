
namespace CabinetMgr
{
    partial class FormSystemManage
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("库存维护");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("人员维护");
            this.panel = new System.Windows.Forms.Panel();
            this.uiNavBar = new Sunny.UI.UINavBar();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.panel.Location = new System.Drawing.Point(0, 130);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1080, 1655);
            this.panel.TabIndex = 1;
            // 
            // uiNavBar
            // 
            this.uiNavBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.uiNavBar.DropMenuFont = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar.ForeColor = System.Drawing.Color.White;
            this.uiNavBar.Location = new System.Drawing.Point(0, -4);
            this.uiNavBar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.uiNavBar.MenuHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiNavBar.MenuSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiNavBar.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.uiNavBar.Name = "uiNavBar";
            treeNode1.Name = "ToolManage";
            treeNode1.Text = "库存维护";
            treeNode2.Name = "UserManage";
            treeNode2.Text = "人员维护";
            this.uiNavBar.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.uiNavBar.SelectedForeColor = System.Drawing.Color.White;
            this.uiNavBar.SelectedHighColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.uiNavBar.SelectedHighColorSize = 6;
            this.uiNavBar.SelectedIndex = 0;
            this.uiNavBar.Size = new System.Drawing.Size(1080, 133);
            this.uiNavBar.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavBar.TabIndex = 0;
            this.uiNavBar.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiNavBar.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.uiNavBar_MenuItemClick);
            // 
            // FormSystemManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.ClientSize = new System.Drawing.Size(1080, 1785);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.uiNavBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSystemManage";
            this.Text = "FormUserMange";
            this.Load += new System.EventHandler(this.FormSystemManage_Load);
            this.Shown += new System.EventHandler(this.FormSystemManage_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel;
        private Sunny.UI.UINavBar uiNavBar;
    }
}