
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
            this.uiNavBar = new Sunny.UI.UINavBar();
            this.uiSymbolButtonBack = new Sunny.UI.UISymbolButton();
            this.panel = new System.Windows.Forms.Panel();
            this.uiNavBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiNavBar
            // 
            this.uiNavBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.uiNavBar.Controls.Add(this.uiSymbolButtonBack);
            this.uiNavBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiNavBar.DropMenuFont = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNavBar.ForeColor = System.Drawing.Color.White;
            this.uiNavBar.Location = new System.Drawing.Point(0, 0);
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
            this.uiNavBar.Size = new System.Drawing.Size(1080, 110);
            this.uiNavBar.Style = Sunny.UI.UIStyle.Custom;
            this.uiNavBar.TabIndex = 0;
            this.uiNavBar.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiNavBar.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.uiNavBar_MenuItemClick);
            // 
            // uiSymbolButtonBack
            // 
            this.uiSymbolButtonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButtonBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.uiSymbolButtonBack.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.uiSymbolButtonBack.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButtonBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiSymbolButtonBack.Location = new System.Drawing.Point(45, 36);
            this.uiSymbolButtonBack.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButtonBack.Name = "uiSymbolButtonBack";
            this.uiSymbolButtonBack.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.uiSymbolButtonBack.Size = new System.Drawing.Size(163, 35);
            this.uiSymbolButtonBack.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButtonBack.Symbol = 61608;
            this.uiSymbolButtonBack.SymbolSize = 36;
            this.uiSymbolButtonBack.TabIndex = 0;
            this.uiSymbolButtonBack.Text = "BACK";
            this.uiSymbolButtonBack.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButtonBack.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiSymbolButtonBack.Click += new System.EventHandler(this.uiSymbolButtonBack_Click);
            // 
            // panel
            // 
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 110);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(1080, 1770);
            this.panel.TabIndex = 1;
            // 
            // FormSystemManage
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.ClientSize = new System.Drawing.Size(1080, 1880);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.uiNavBar);
            this.Name = "FormSystemManage";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "FormUserMange";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FormSystemManage_Load);
            this.Shown += new System.EventHandler(this.FormSystemManage_Shown);
            this.uiNavBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UINavBar uiNavBar;
        private Sunny.UI.UISymbolButton uiSymbolButtonBack;
        private System.Windows.Forms.Panel panel;
    }
}