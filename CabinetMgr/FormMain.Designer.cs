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
            this.pbKeyboard = new System.Windows.Forms.PictureBox();
            this.pbAbout = new System.Windows.Forms.PictureBox();
            this.pbMin = new System.Windows.Forms.PictureBox();
            this.pbAuthority = new System.Windows.Forms.PictureBox();
            this.pbSetting = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbInitTime = new System.Windows.Forms.Label();
            this.panelWindow = new System.Windows.Forms.Panel();
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbKeyboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // tmUhfInit
            // 
            this.tmUhfInit.Interval = 1000;
            this.tmUhfInit.Tick += new System.EventHandler(this.tmUhfInit_Tick);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.SystemColors.Control;
            this.panelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelTop.BackgroundImage")));
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.pbKeyboard);
            this.panelTop.Controls.Add(this.pbAbout);
            this.panelTop.Controls.Add(this.pbMin);
            this.panelTop.Controls.Add(this.pbAuthority);
            this.panelTop.Controls.Add(this.pbSetting);
            this.panelTop.Controls.Add(this.pbClose);
            this.panelTop.Controls.Add(this.pnlSearch);
            this.panelTop.Controls.Add(this.lbInitTime);
            this.panelTop.Controls.Add(this.panelWindow);
            this.panelTop.Controls.Add(this.pbAvatar);
            this.panelTop.Controls.Add(this.lbUserName);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 1920);
            this.panelTop.TabIndex = 2;
            // 
            // pbKeyboard
            // 
            this.pbKeyboard.BackColor = System.Drawing.Color.Transparent;
            //this.pbKeyboard.BackgroundImage = global::CabinetMgr.Properties.Resources.keyboard;
            this.pbKeyboard.Location = new System.Drawing.Point(29, 21);
            this.pbKeyboard.Name = "pbKeyboard";
            this.pbKeyboard.Size = new System.Drawing.Size(48, 48);
            this.pbKeyboard.TabIndex = 252;
            this.pbKeyboard.TabStop = false;
            this.pbKeyboard.Click += new System.EventHandler(this.pbKeyboard_Click);
            // 
            // pbAbout
            // 
            this.pbAbout.BackColor = System.Drawing.Color.Transparent;
            //this.pbAbout.BackgroundImage = global::CabinetMgr.Properties.Resources.question;
            this.pbAbout.Location = new System.Drawing.Point(924, 3);
            this.pbAbout.Name = "pbAbout";
            this.pbAbout.Size = new System.Drawing.Size(48, 48);
            this.pbAbout.TabIndex = 251;
            this.pbAbout.TabStop = false;
            this.pbAbout.Click += new System.EventHandler(this.pbAbout_Click);
            // 
            // pbMin
            // 
            this.pbMin.BackColor = System.Drawing.Color.Transparent;
            //this.pbMin.BackgroundImage = global::CabinetMgr.Properties.Resources.minus;
            this.pbMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMin.Location = new System.Drawing.Point(979, 3);
            this.pbMin.Name = "pbMin";
            this.pbMin.Size = new System.Drawing.Size(48, 48);
            this.pbMin.TabIndex = 250;
            this.pbMin.TabStop = false;
            this.pbMin.Click += new System.EventHandler(this.pbMin_Click);
            // 
            // pbAuthority
            // 
            this.pbAuthority.BackColor = System.Drawing.Color.Transparent;
            //this.pbAuthority.BackgroundImage = global::CabinetMgr.Properties.Resources.authority;
            this.pbAuthority.Location = new System.Drawing.Point(29, 87);
            this.pbAuthority.Name = "pbAuthority";
            this.pbAuthority.Size = new System.Drawing.Size(48, 48);
            this.pbAuthority.TabIndex = 249;
            this.pbAuthority.TabStop = false;
            this.pbAuthority.Visible = false;
            this.pbAuthority.Click += new System.EventHandler(this.pbAuthority_Click);
            // 
            // pbSetting
            // 
            this.pbSetting.BackColor = System.Drawing.Color.Transparent;
            //this.pbSetting.BackgroundImage = global::CabinetMgr.Properties.Resources.setting;
            this.pbSetting.Location = new System.Drawing.Point(29, 156);
            this.pbSetting.Name = "pbSetting";
            this.pbSetting.Size = new System.Drawing.Size(48, 48);
            this.pbSetting.TabIndex = 248;
            this.pbSetting.TabStop = false;
            this.pbSetting.Visible = false;
            this.pbSetting.Click += new System.EventHandler(this.pbSetting_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            //this.pbClose.BackgroundImage = global::CabinetMgr.Properties.Resources.cancel;
            this.pbClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbClose.Location = new System.Drawing.Point(1032, 7);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(40, 40);
            this.pbClose.TabIndex = 247;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSearch.BackgroundImage")));
            this.pnlSearch.Controls.Add(this.tbSearch);
            this.pnlSearch.Controls.Add(this.btnSearch);
            this.pnlSearch.Location = new System.Drawing.Point(264, 159);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(457, 56);
            this.pnlSearch.TabIndex = 246;
            // 
            // tbSearch
            // 
            this.tbSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(28)))), ((int)(((byte)(72)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F);
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.tbSearch.Location = new System.Drawing.Point(4, 8);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(350, 32);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            this.tbSearch.Enter += new System.EventHandler(this.tbSearch_Enter);
            this.tbSearch.Leave += new System.EventHandler(this.tbSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(359, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 50);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbInitTime
            // 
            this.lbInitTime.AutoSize = true;
            this.lbInitTime.BackColor = System.Drawing.Color.Transparent;
            this.lbInitTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lbInitTime.ForeColor = System.Drawing.SystemColors.Window;
            this.lbInitTime.Location = new System.Drawing.Point(798, 210);
            this.lbInitTime.Name = "lbInitTime";
            this.lbInitTime.Size = new System.Drawing.Size(110, 22);
            this.lbInitTime.TabIndex = 245;
            this.lbInitTime.Text = "启动中,剩余:";
            // 
            // panelWindow
            // 
            this.panelWindow.BackColor = System.Drawing.Color.Transparent;
            this.panelWindow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelWindow.Location = new System.Drawing.Point(29, 247);
            this.panelWindow.Name = "panelWindow";
            this.panelWindow.Size = new System.Drawing.Size(1026, 1616);
            this.panelWindow.TabIndex = 4;
            this.panelWindow.SizeChanged += new System.EventHandler(this.panelWindow_SizeChanged);
            // 
            // pbAvatar
            // 
            this.pbAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pbAvatar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbAvatar.BackgroundImage")));
            this.pbAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAvatar.Location = new System.Drawing.Point(752, 101);
            this.pbAvatar.Name = "pbAvatar";
            this.pbAvatar.Size = new System.Drawing.Size(58, 61);
            this.pbAvatar.TabIndex = 3;
            this.pbAvatar.TabStop = false;
            this.pbAvatar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbAvatar_MouseClick);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.BackColor = System.Drawing.Color.Transparent;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(205)))), ((int)(((byte)(222)))));
            this.lbUserName.Location = new System.Drawing.Point(825, 101);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(133, 29);
            this.lbUserName.TabIndex = 2;
            this.lbUserName.Text = "当前用户：";
            this.lbUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbUserName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbUserName_MouseClick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
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
            ((System.ComponentModel.ISupportInitialize)(this.pbKeyboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAbout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAuthority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Panel panelWindow;
        private System.Windows.Forms.Timer tmUhfInit;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbInitTime;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.PictureBox pbAuthority;
        private System.Windows.Forms.PictureBox pbSetting;
        private System.Windows.Forms.PictureBox pbAbout;
        private System.Windows.Forms.PictureBox pbMin;
        private System.Windows.Forms.PictureBox pbKeyboard;
    }
}

