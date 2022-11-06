
namespace CabinetMgr
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            this.panelButtonContainer = new System.Windows.Forms.Panel();
            this.uiImageButtonPassword = new Sunny.UI.UIImageButton();
            this.uiImageButtonCard = new Sunny.UI.UIImageButton();
            this.uiImageButtonFingerPrint = new Sunny.UI.UIImageButton();
            this.uiImageButtonFace = new Sunny.UI.UIImageButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.timerStopCrit = new System.Windows.Forms.Timer(this.components);
            this.textBoxCardNum = new System.Windows.Forms.TextBox();
            this.panelButtonContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonCard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonFingerPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonFace)).BeginInit();
            this.SuspendLayout();
            // 
            // panelButtonContainer
            // 
            this.panelButtonContainer.BackColor = System.Drawing.Color.Transparent;
            this.panelButtonContainer.Controls.Add(this.uiImageButtonPassword);
            this.panelButtonContainer.Controls.Add(this.uiImageButtonCard);
            this.panelButtonContainer.Controls.Add(this.uiImageButtonFingerPrint);
            this.panelButtonContainer.Controls.Add(this.uiImageButtonFace);
            this.panelButtonContainer.Location = new System.Drawing.Point(42, 757);
            this.panelButtonContainer.Name = "panelButtonContainer";
            this.panelButtonContainer.Size = new System.Drawing.Size(1004, 237);
            this.panelButtonContainer.TabIndex = 4;
            // 
            // uiImageButtonPassword
            // 
            this.uiImageButtonPassword.BackgroundImage = global::CabinetMgr.Properties.Resources.Password;
            this.uiImageButtonPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonPassword.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButtonPassword.Location = new System.Drawing.Point(774, -6);
            this.uiImageButtonPassword.Name = "uiImageButtonPassword";
            this.uiImageButtonPassword.Size = new System.Drawing.Size(225, 235);
            this.uiImageButtonPassword.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButtonPassword.TabIndex = 3;
            this.uiImageButtonPassword.TabStop = false;
            this.uiImageButtonPassword.Text = null;
            this.uiImageButtonPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiImageButtonPassword.Click += new System.EventHandler(this.uiImageButtonPassword_Click);
            // 
            // uiImageButtonCard
            // 
            this.uiImageButtonCard.BackgroundImage = global::CabinetMgr.Properties.Resources.Card;
            this.uiImageButtonCard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonCard.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButtonCard.Location = new System.Drawing.Point(522, 9);
            this.uiImageButtonCard.Name = "uiImageButtonCard";
            this.uiImageButtonCard.Size = new System.Drawing.Size(220, 220);
            this.uiImageButtonCard.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButtonCard.TabIndex = 2;
            this.uiImageButtonCard.TabStop = false;
            this.uiImageButtonCard.Text = null;
            this.uiImageButtonCard.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiImageButtonCard.Click += new System.EventHandler(this.uiImageButtonCard_Click);
            // 
            // uiImageButtonFingerPrint
            // 
            this.uiImageButtonFingerPrint.BackgroundImage = global::CabinetMgr.Properties.Resources.FingerPrint;
            this.uiImageButtonFingerPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonFingerPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonFingerPrint.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButtonFingerPrint.Location = new System.Drawing.Point(258, 9);
            this.uiImageButtonFingerPrint.Name = "uiImageButtonFingerPrint";
            this.uiImageButtonFingerPrint.Size = new System.Drawing.Size(225, 237);
            this.uiImageButtonFingerPrint.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButtonFingerPrint.TabIndex = 1;
            this.uiImageButtonFingerPrint.TabStop = false;
            this.uiImageButtonFingerPrint.Text = null;
            this.uiImageButtonFingerPrint.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiImageButtonFingerPrint.Click += new System.EventHandler(this.uiImageButtonFingerPrint_Click);
            // 
            // uiImageButtonFace
            // 
            this.uiImageButtonFace.BackgroundImage = global::CabinetMgr.Properties.Resources.Face;
            this.uiImageButtonFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uiImageButtonFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiImageButtonFace.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiImageButtonFace.Location = new System.Drawing.Point(4, 9);
            this.uiImageButtonFace.Name = "uiImageButtonFace";
            this.uiImageButtonFace.Size = new System.Drawing.Size(220, 220);
            this.uiImageButtonFace.Style = Sunny.UI.UIStyle.Custom;
            this.uiImageButtonFace.TabIndex = 0;
            this.uiImageButtonFace.TabStop = false;
            this.uiImageButtonFace.Text = null;
            this.uiImageButtonFace.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiImageButtonFace.Click += new System.EventHandler(this.uiImageButtonFace_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(131, 157);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(855, 387);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // timerStopCrit
            // 
            this.timerStopCrit.Interval = 30000;
            this.timerStopCrit.Tick += new System.EventHandler(this.timerStopCrit_Tick);
            // 
            // textBoxCardNum
            // 
            this.textBoxCardNum.Location = new System.Drawing.Point(564, 1095);
            this.textBoxCardNum.Name = "textBoxCardNum";
            this.textBoxCardNum.Size = new System.Drawing.Size(228, 21);
            this.textBoxCardNum.TabIndex = 8;
            this.textBoxCardNum.Visible = false;
            // 
            // FormLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.NewBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 1785);
            this.Controls.Add(this.textBoxCardNum);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panelButtonContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.Text = "FormLogin";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.Shown += new System.EventHandler(this.FormLogin_Shown);
            this.VisibleChanged += new System.EventHandler(this.FormLogin_VisibleChanged);
            this.Click += new System.EventHandler(this.FormLogin_Click);
            this.panelButtonContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonCard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonFingerPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiImageButtonFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelButtonContainer;
        private Sunny.UI.UIImageButton uiImageButtonPassword;
        private Sunny.UI.UIImageButton uiImageButtonCard;
        private Sunny.UI.UIImageButton uiImageButtonFingerPrint;
        private Sunny.UI.UIImageButton uiImageButtonFace;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Timer timerStopCrit;
        private System.Windows.Forms.TextBox textBoxCardNum;
    }
}