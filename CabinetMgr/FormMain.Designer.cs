
namespace CabinetMgr
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelWindow = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.uiLabelUserName = new System.Windows.Forms.Label();
            this.pictureBoxTitleE = new System.Windows.Forms.PictureBox();
            this.pictureBoxTitleC = new System.Windows.Forms.PictureBox();
            this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelWindow
            // 
            this.panelWindow.BackColor = System.Drawing.Color.Transparent;
            this.panelWindow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelWindow.Location = new System.Drawing.Point(0, 135);
            this.panelWindow.Name = "panelWindow";
            this.panelWindow.Size = new System.Drawing.Size(1080, 1785);
            this.panelWindow.TabIndex = 3;
            this.panelWindow.SizeChanged += new System.EventHandler(this.panelWindow_SizeChanged);
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.panelTop.BackgroundImage = global::CabinetMgr.Properties.Resources.TitleBg;
            this.panelTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelTop.Controls.Add(this.uiLabelUserName);
            this.panelTop.Controls.Add(this.pictureBoxTitleE);
            this.panelTop.Controls.Add(this.pictureBoxTitleC);
            this.panelTop.Controls.Add(this.pictureBoxIcon);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1080, 135);
            this.panelTop.TabIndex = 9;
            // 
            // uiLabelUserName
            // 
            this.uiLabelUserName.BackColor = System.Drawing.Color.Transparent;
            this.uiLabelUserName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelUserName.ForeColor = System.Drawing.Color.White;
            this.uiLabelUserName.Location = new System.Drawing.Point(766, 30);
            this.uiLabelUserName.Name = "uiLabelUserName";
            this.uiLabelUserName.Size = new System.Drawing.Size(286, 48);
            this.uiLabelUserName.TabIndex = 3;
            this.uiLabelUserName.Text = "uiLabel1";
            this.uiLabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelUserName.Visible = false;
            this.uiLabelUserName.Click += new System.EventHandler(this.uiLabelUserName_Click);
            // 
            // pictureBoxTitleE
            // 
            this.pictureBoxTitleE.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTitleE.BackgroundImage = global::CabinetMgr.Properties.Resources.TitleE;
            this.pictureBoxTitleE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxTitleE.Location = new System.Drawing.Point(762, 78);
            this.pictureBoxTitleE.Name = "pictureBoxTitleE";
            this.pictureBoxTitleE.Size = new System.Drawing.Size(260, 23);
            this.pictureBoxTitleE.TabIndex = 2;
            this.pictureBoxTitleE.TabStop = false;
            // 
            // pictureBoxTitleC
            // 
            this.pictureBoxTitleC.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxTitleC.BackgroundImage = global::CabinetMgr.Properties.Resources.TitleC;
            this.pictureBoxTitleC.Location = new System.Drawing.Point(762, 30);
            this.pictureBoxTitleC.Name = "pictureBoxTitleC";
            this.pictureBoxTitleC.Size = new System.Drawing.Size(290, 42);
            this.pictureBoxTitleC.TabIndex = 1;
            this.pictureBoxTitleC.TabStop = false;
            this.pictureBoxTitleC.Click += new System.EventHandler(this.pictureBoxTitleC_Click);
            // 
            // pictureBoxIcon
            // 
            this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxIcon.BackgroundImage = global::CabinetMgr.Properties.Resources.NewLogo;
            this.pictureBoxIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxIcon.Location = new System.Drawing.Point(30, 30);
            this.pictureBoxIcon.Name = "pictureBoxIcon";
            this.pictureBoxIcon.Size = new System.Drawing.Size(693, 72);
            this.pictureBoxIcon.TabIndex = 0;
            this.pictureBoxIcon.TabStop = false;
            this.pictureBoxIcon.Click += new System.EventHandler(this.pictureBoxIcon_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.BackgroundImage = global::CabinetMgr.Properties.Resources.MainBg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1080, 1920);
            this.ControlBox = false;
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelWindow);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "智能储物柜";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTitleC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelWindow;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label uiLabelUserName;
        private System.Windows.Forms.PictureBox pictureBoxTitleE;
        private System.Windows.Forms.PictureBox pictureBoxTitleC;
        private System.Windows.Forms.PictureBox pictureBoxIcon;
    }
}