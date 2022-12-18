
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
            this.uiImageButtonMaintain = new System.Windows.Forms.Button();
            this.uiLabel2 = new System.Windows.Forms.Label();
            this.uiLabelViewLog = new System.Windows.Forms.Label();
            this.uiImageButtonViewLog = new System.Windows.Forms.Button();
            this.panelButtonContainer.SuspendLayout();
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
            this.uiImageButtonMaintain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiImageButtonMaintain.BackgroundImage = global::CabinetMgr.Properties.Resources.Maintain;
            this.uiImageButtonMaintain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonMaintain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonMaintain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiImageButtonMaintain.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F);
            this.uiImageButtonMaintain.Location = new System.Drawing.Point(656, 46);
            this.uiImageButtonMaintain.Name = "uiImageButtonMaintain";
            this.uiImageButtonMaintain.Size = new System.Drawing.Size(128, 128);
            this.uiImageButtonMaintain.TabIndex = 3;
            this.uiImageButtonMaintain.TabStop = false;
            this.uiImageButtonMaintain.UseVisualStyleBackColor = false;
            this.uiImageButtonMaintain.Click += new System.EventHandler(this.uiImageButtonMaintain_Click);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabel2.Location = new System.Drawing.Point(656, 199);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(128, 35);
            this.uiLabel2.TabIndex = 2;
            this.uiLabel2.Text = "维护管理";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabelViewLog
            // 
            this.uiLabelViewLog.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelViewLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelViewLog.Location = new System.Drawing.Point(231, 204);
            this.uiLabelViewLog.Name = "uiLabelViewLog";
            this.uiLabelViewLog.Size = new System.Drawing.Size(128, 35);
            this.uiLabelViewLog.TabIndex = 1;
            this.uiLabelViewLog.Text = "日志查看";
            this.uiLabelViewLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiImageButtonViewLog
            // 
            this.uiImageButtonViewLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiImageButtonViewLog.BackgroundImage = global::CabinetMgr.Properties.Resources.ViewLog;
            this.uiImageButtonViewLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonViewLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonViewLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uiImageButtonViewLog.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F);
            this.uiImageButtonViewLog.Location = new System.Drawing.Point(231, 46);
            this.uiImageButtonViewLog.Name = "uiImageButtonViewLog";
            this.uiImageButtonViewLog.Size = new System.Drawing.Size(128, 128);
            this.uiImageButtonViewLog.TabIndex = 0;
            this.uiImageButtonViewLog.TabStop = false;
            this.uiImageButtonViewLog.UseVisualStyleBackColor = false;
            this.uiImageButtonViewLog.Click += new System.EventHandler(this.uiImageButtonViewLog_Click);
            // 
            // FormManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.NewBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 1785);
            this.Controls.Add(this.panelButtonContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormManage";
            this.Text = "FormManage";
            this.panelButtonContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelButtonContainer;
        private System.Windows.Forms.Button uiImageButtonViewLog;
        private System.Windows.Forms.Button uiImageButtonMaintain;
        private System.Windows.Forms.Label uiLabel2;
        private System.Windows.Forms.Label uiLabelViewLog;
    }
}