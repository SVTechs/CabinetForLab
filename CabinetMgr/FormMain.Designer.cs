namespace CabinetMgr
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tmUhfInit = new System.Windows.Forms.Timer(this.components);
            this.panelTop = new System.Windows.Forms.Panel();
            this.uiLabelUser = new Sunny.UI.UILabel();
            this.uiButtonRecord = new Sunny.UI.UIButton();
            this.uiButtonToolManage = new Sunny.UI.UIButton();
            this.uiButtonUserManage = new Sunny.UI.UIButton();
            this.uiButtonToolQuery = new Sunny.UI.UIButton();
            this.uiButtonIndex = new Sunny.UI.UIButton();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureBoxQuit = new System.Windows.Forms.PictureBox();
            this.pictureBoxKeyBoard = new System.Windows.Forms.PictureBox();
            this.panelWindow = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // tmUhfInit
            // 
            this.tmUhfInit.Interval = 1000;
            this.tmUhfInit.Tick += new System.EventHandler(this.tmUhfInit_Tick);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.uiLabelUser);
            this.panelTop.Controls.Add(this.uiButtonRecord);
            this.panelTop.Controls.Add(this.uiButtonToolManage);
            this.panelTop.Controls.Add(this.uiButtonUserManage);
            this.panelTop.Controls.Add(this.uiButtonToolQuery);
            this.panelTop.Controls.Add(this.uiButtonIndex);
            this.panelTop.Controls.Add(this.panelTitle);
            this.panelTop.Controls.Add(this.panelWindow);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 1920);
            this.panelTop.TabIndex = 2;
            // 
            // uiLabelUser
            // 
            this.uiLabelUser.AutoSize = true;
            this.uiLabelUser.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelUser.ForeColor = System.Drawing.Color.White;
            this.uiLabelUser.Location = new System.Drawing.Point(831, 258);
            this.uiLabelUser.Name = "uiLabelUser";
            this.uiLabelUser.Size = new System.Drawing.Size(112, 27);
            this.uiLabelUser.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelUser.TabIndex = 16;
            this.uiLabelUser.Text = "当前用户：";
            this.uiLabelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelUser.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiLabelUser.Click += new System.EventHandler(this.uiLabelUser_Click);
            // 
            // uiButtonRecord
            // 
            this.uiButtonRecord.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonRecord.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRecord.Location = new System.Drawing.Point(901, 184);
            this.uiButtonRecord.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonRecord.Name = "uiButtonRecord";
            this.uiButtonRecord.Radius = 59;
            this.uiButtonRecord.Size = new System.Drawing.Size(152, 59);
            this.uiButtonRecord.TabIndex = 15;
            this.uiButtonRecord.Tag = "4";
            this.uiButtonRecord.Text = "取用日志";
            this.uiButtonRecord.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonRecord.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonRecord.Click += new System.EventHandler(this.uiButtonRecord_Click);
            // 
            // uiButtonToolManage
            // 
            this.uiButtonToolManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonToolManage.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolManage.Location = new System.Drawing.Point(683, 184);
            this.uiButtonToolManage.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonToolManage.Name = "uiButtonToolManage";
            this.uiButtonToolManage.Radius = 59;
            this.uiButtonToolManage.Size = new System.Drawing.Size(152, 59);
            this.uiButtonToolManage.TabIndex = 14;
            this.uiButtonToolManage.Tag = "3";
            this.uiButtonToolManage.Text = "物品管理";
            this.uiButtonToolManage.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolManage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonToolManage.Click += new System.EventHandler(this.uiButtonToolManage_Click);
            // 
            // uiButtonUserManage
            // 
            this.uiButtonUserManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonUserManage.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonUserManage.Location = new System.Drawing.Point(465, 184);
            this.uiButtonUserManage.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonUserManage.Name = "uiButtonUserManage";
            this.uiButtonUserManage.Radius = 59;
            this.uiButtonUserManage.Size = new System.Drawing.Size(152, 59);
            this.uiButtonUserManage.TabIndex = 13;
            this.uiButtonUserManage.Tag = "2";
            this.uiButtonUserManage.Text = "人员管理";
            this.uiButtonUserManage.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonUserManage.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonUserManage.Click += new System.EventHandler(this.uiButtonUserManage_Click);
            // 
            // uiButtonToolQuery
            // 
            this.uiButtonToolQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonToolQuery.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolQuery.Location = new System.Drawing.Point(247, 184);
            this.uiButtonToolQuery.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonToolQuery.Name = "uiButtonToolQuery";
            this.uiButtonToolQuery.Radius = 59;
            this.uiButtonToolQuery.Size = new System.Drawing.Size(152, 59);
            this.uiButtonToolQuery.TabIndex = 12;
            this.uiButtonToolQuery.Tag = "1";
            this.uiButtonToolQuery.Text = "分类查询";
            this.uiButtonToolQuery.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonToolQuery.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonToolQuery.Click += new System.EventHandler(this.uiButtonToolQuery_Click);
            // 
            // uiButtonIndex
            // 
            this.uiButtonIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonIndex.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonIndex.Location = new System.Drawing.Point(29, 184);
            this.uiButtonIndex.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonIndex.Name = "uiButtonIndex";
            this.uiButtonIndex.Radius = 59;
            this.uiButtonIndex.Size = new System.Drawing.Size(152, 59);
            this.uiButtonIndex.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonIndex.TabIndex = 11;
            this.uiButtonIndex.Tag = "0";
            this.uiButtonIndex.Text = "首页";
            this.uiButtonIndex.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonIndex.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonIndex.Click += new System.EventHandler(this.uiButtonIndex_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTitle.BackgroundImage")));
            this.panelTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTitle.Controls.Add(this.pictureBoxQuit);
            this.panelTitle.Controls.Add(this.pictureBoxKeyBoard);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1080, 160);
            this.panelTitle.TabIndex = 10;
            // 
            // pictureBoxQuit
            // 
            this.pictureBoxQuit.BackgroundImage = global::CabinetMgr.Properties.Resources.close;
            this.pictureBoxQuit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxQuit.Location = new System.Drawing.Point(1020, 12);
            this.pictureBoxQuit.Name = "pictureBoxQuit";
            this.pictureBoxQuit.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxQuit.TabIndex = 1;
            this.pictureBoxQuit.TabStop = false;
            this.pictureBoxQuit.Click += new System.EventHandler(this.pictureBoxQuit_Click);
            // 
            // pictureBoxKeyBoard
            // 
            this.pictureBoxKeyBoard.BackgroundImage = global::CabinetMgr.Properties.Resources.keyboard;
            this.pictureBoxKeyBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxKeyBoard.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxKeyBoard.Name = "pictureBoxKeyBoard";
            this.pictureBoxKeyBoard.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxKeyBoard.TabIndex = 0;
            this.pictureBoxKeyBoard.TabStop = false;
            this.pictureBoxKeyBoard.Click += new System.EventHandler(this.pbKeyboard_Click);
            // 
            // panelWindow
            // 
            this.panelWindow.BackColor = System.Drawing.Color.Transparent;
            this.panelWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWindow.Location = new System.Drawing.Point(29, 309);
            this.panelWindow.Name = "panelWindow";
            this.panelWindow.Size = new System.Drawing.Size(1026, 1554);
            this.panelWindow.TabIndex = 4;
            this.panelWindow.SizeChanged += new System.EventHandler(this.panelWindow_SizeChanged);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(1080, 1920);
            this.Controls.Add(this.panelTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FormMain";
            this.Text = "智能微库";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxKeyBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelWindow;
        private System.Windows.Forms.Timer tmUhfInit;
        private System.Windows.Forms.Panel panelTitle;
        private Sunny.UI.UIButton uiButtonToolQuery;
        private Sunny.UI.UIButton uiButtonIndex;
        private Sunny.UI.UIButton uiButtonRecord;
        private Sunny.UI.UIButton uiButtonToolManage;
        private Sunny.UI.UIButton uiButtonUserManage;
        private System.Windows.Forms.PictureBox pictureBoxKeyBoard;
        private Sunny.UI.UILabel uiLabelUser;
        private System.Windows.Forms.PictureBox pictureBoxQuit;
    }
}

