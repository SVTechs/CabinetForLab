
namespace CabinetMgr
{
    partial class FormManage
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
            this.panelButtonContainer = new System.Windows.Forms.Panel();
            this.uiImageButtonMaintain = new Sunny.UI.UIImageButton();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.uiLabelViewLog = new Sunny.UI.UILabel();
            this.uiImageButtonViewLog = new Sunny.UI.UIImageButton();
            this.pictureBoxBgPic = new System.Windows.Forms.PictureBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBoxTitleE = new System.Windows.Forms.PictureBox();
            this.pictureBoxTitleC = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonMaintain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonViewLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBgPic)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButtonContainer
            // 
            this.panelButtonContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonContainer.BackgroundImage = global::CabinetMgr.Properties.Resources.PanelButtonBg;
            this.panelButtonContainer.Controls.Add(this.uiImageButtonMaintain);
            this.panelButtonContainer.Controls.Add(this.uiLabel2);
            this.panelButtonContainer.Controls.Add(this.uiLabelViewLog);
            this.panelButtonContainer.Controls.Add(this.uiImageButtonViewLog);
            this.panelButtonContainer.Location = new System.Drawing.Point(42, 757);
            this.panelButtonContainer.Name = "panelButtonContainer";
            this.panelButtonContainer.Size = new System.Drawing.Size(985, 305);
            this.panelButtonContainer.TabIndex = 5;
            // 
            // uiImageButtonMaintain
            // 
            this.uiImageButtonMaintain.BackgroundImage = global::CabinetMgr.Properties.Resources.Maintain;
            this.uiImageButtonMaintain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonMaintain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonMaintain.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButtonMaintain.Location = new System.Drawing.Point(656, 46);
            this.uiImageButtonMaintain.Name = "uiImageButtonMaintain";
            this.uiImageButtonMaintain.Size = new System.Drawing.Size(128, 128);
            this.uiImageButtonMaintain.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButtonMaintain.TabIndex = 3;
            this.uiImageButtonMaintain.TabStop = false;
            this.uiImageButtonMaintain.Text = null;
            this.uiImageButtonMaintain.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiImageButtonMaintain.Click += new System.EventHandler(this.uiImageButtonMaintain_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabel2.Location = new System.Drawing.Point(656, 199);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(128, 35);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "维护管理";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabel2.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelViewLog
            // 
            this.uiLabelViewLog.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelViewLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelViewLog.Location = new System.Drawing.Point(231, 204);
            this.uiLabelViewLog.Name = "uiLabelViewLog";
            this.uiLabelViewLog.Size = new System.Drawing.Size(128, 35);
            this.uiLabelViewLog.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelViewLog.TabIndex = 1;
            this.uiLabelViewLog.Text = "日志查看";
            this.uiLabelViewLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabelViewLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiImageButtonViewLog
            // 
            this.uiImageButtonViewLog.BackgroundImage = global::CabinetMgr.Properties.Resources.ViewLog;
            this.uiImageButtonViewLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonViewLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonViewLog.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButtonViewLog.Location = new System.Drawing.Point(231, 46);
            this.uiImageButtonViewLog.Name = "uiImageButtonViewLog";
            this.uiImageButtonViewLog.Size = new System.Drawing.Size(128, 128);
            this.uiImageButtonViewLog.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButtonViewLog.TabIndex = 0;
            this.uiImageButtonViewLog.TabStop = false;
            this.uiImageButtonViewLog.Text = null;
            this.uiImageButtonViewLog.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiImageButtonViewLog.Click += new System.EventHandler(this.uiImageButtonViewLog_Click);
            // 
            // pictureBoxBgPic
            // 
            this.pictureBoxBgPic.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBgPic.BackgroundImage = global::CabinetMgr.Properties.Resources.BgPic;
            this.pictureBoxBgPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBgPic.Location = new System.Drawing.Point(68, 856);
            this.pictureBoxBgPic.Name = "pictureBoxBgPic";
            this.pictureBoxBgPic.Size = new System.Drawing.Size(940, 800);
            this.pictureBoxBgPic.TabIndex = 4;
            this.pictureBoxBgPic.TabStop = false;
            // 
            // panelTop
            // 
            this.panelTop.BackgroundImage = global::CabinetMgr.Properties.Resources.TitleBg;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.pictureBoxTitleE);
            this.panelTop.Controls.Add(this.pictureBoxTitleC);
            this.panelTop.Controls.Add(this.pictureBoxIcon);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 135);
            this.panelTop.TabIndex = 7;
            // 
            // pictureBoxTitleE
            // 
            this.pictureBoxTitleE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTitleE.BackgroundImage = global::CabinetMgr.Properties.Resources.TitleE;
            this.pictureBoxTitleE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTitleE.Location = new System.Drawing.Point(653, 79);
            this.pictureBoxTitleE.Name = "pictureBoxTitleE";
            this.pictureBoxTitleE.Size = new System.Drawing.Size(260, 23);
            this.pictureBoxTitleE.TabIndex = 2;
            this.pictureBoxTitleE.TabStop = false;
            // 
            // pictureBoxTitleC
            // 
            this.pictureBoxTitleC.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTitleC.BackgroundImage = global::CabinetMgr.Properties.Resources.TitleC;
            this.pictureBoxTitleC.Location = new System.Drawing.Point(653, 31);
            this.pictureBoxTitleC.Name = "pictureBoxTitleC";
            this.pictureBoxTitleC.Size = new System.Drawing.Size(290, 42);
            this.pictureBoxTitleC.TabIndex = 1;
            this.pictureBoxTitleC.TabStop = false;
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.BackgroundImage = global::CabinetMgr.Properties.Resources.LOGO;
            this.pictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxIcon.Location = new System.Drawing.Point(52, 31);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(300, 75);
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.pictureBoxIcon_Click);
            // 
            // FormManage
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.ClientSize = new System.Drawing.Size(1080, 1745);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelButtonContainer);
            this.Controls.Add(this.pictureBoxBgPic);
            this.Name = "FormManage";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "FormManage";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.panelButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonMaintain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonViewLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBgPic)).EndInit();
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBgPic;
        private System.Windows.Forms.Panel panelButtonContainer;
        private Sunny.UI.UIImageButton uiImageButtonViewLog;
        private Sunny.UI.UIImageButton uiImageButtonMaintain;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabelViewLog;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pictureBoxTitleE;
        private System.Windows.Forms.PictureBox pictureBoxTitleC;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}