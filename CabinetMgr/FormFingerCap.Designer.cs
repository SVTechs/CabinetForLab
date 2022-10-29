
namespace CabinetMgr
{
    partial class FormFingerCap
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
            this.pictureBoxFingerBmp = new System.Windows.Forms.PictureBox();
            this.uiButtonStartCap = new Sunny.UI.UIButton();
            this.uiLabelPressRemind = new Sunny.UI.UILabel();
            this.uiLabelCapTimesCount = new Sunny.UI.UILabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerBmp)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxFingerBmp
            // 
            this.pictureBoxFingerBmp.Location = new System.Drawing.Point(48, 23);
            this.pictureBoxFingerBmp.Name = "pictureBoxFingerBmp";
            this.pictureBoxFingerBmp.Size = new System.Drawing.Size(189, 231);
            this.pictureBoxFingerBmp.TabIndex = 1;
            this.pictureBoxFingerBmp.TabStop = false;
            // 
            // uiButtonStartCap
            // 
            this.uiButtonStartCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonStartCap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonStartCap.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonStartCap.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStartCap.Location = new System.Drawing.Point(48, 362);
            this.uiButtonStartCap.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonStartCap.Name = "uiButtonStartCap";
            this.uiButtonStartCap.Size = new System.Drawing.Size(189, 35);
            this.uiButtonStartCap.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonStartCap.StyleCustomMode = true;
            this.uiButtonStartCap.TabIndex = 2;
            this.uiButtonStartCap.Text = "重新采集";
            this.uiButtonStartCap.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStartCap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonStartCap.Click += new System.EventHandler(this.uiButtonStartCap_Click);
            // 
            // uiLabelPressRemind
            // 
            this.uiLabelPressRemind.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelPressRemind.Location = new System.Drawing.Point(48, 278);
            this.uiLabelPressRemind.Name = "uiLabelPressRemind";
            this.uiLabelPressRemind.Size = new System.Drawing.Size(189, 29);
            this.uiLabelPressRemind.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelPressRemind.TabIndex = 5;
            this.uiLabelPressRemind.Text = "11";
            this.uiLabelPressRemind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabelPressRemind.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelCapTimesCount
            // 
            this.uiLabelCapTimesCount.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelCapTimesCount.Location = new System.Drawing.Point(48, 318);
            this.uiLabelCapTimesCount.Name = "uiLabelCapTimesCount";
            this.uiLabelCapTimesCount.Size = new System.Drawing.Size(189, 29);
            this.uiLabelCapTimesCount.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelCapTimesCount.TabIndex = 6;
            this.uiLabelCapTimesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabelCapTimesCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormFingerCap
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 426);
            this.Controls.Add(this.uiLabelCapTimesCount);
            this.Controls.Add(this.uiLabelPressRemind);
            this.Controls.Add(this.uiButtonStartCap);
            this.Controls.Add(this.pictureBoxFingerBmp);
            this.Name = "FormFingerCap";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "FormFingerCap";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Shown += new System.EventHandler(this.FormFingerCap_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerBmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFingerBmp;
        private Sunny.UI.UIButton uiButtonStartCap;
        private Sunny.UI.UILabel uiLabelPressRemind;
        private Sunny.UI.UILabel uiLabelCapTimesCount;
    }
}