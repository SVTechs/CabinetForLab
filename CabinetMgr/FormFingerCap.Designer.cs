
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
            this.uiButtonStartCap = new Sunny.UI.UIButton();
            this.pictureBoxFingerBmp = new System.Windows.Forms.PictureBox();
            this.uiButtonStopCap = new Sunny.UI.UIButton();
            this.uiLabelCapTimesCount = new Sunny.UI.UILabel();
            this.uiLabelPressRemind = new Sunny.UI.UILabel();
            this.richTextBoxErrMsg = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerBmp)).BeginInit();
            this.SuspendLayout();
            // 
            // uiButtonStartCap
            // 
            this.uiButtonStartCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonStartCap.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStartCap.Location = new System.Drawing.Point(210, 326);
            this.uiButtonStartCap.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonStartCap.Name = "uiButtonStartCap";
            this.uiButtonStartCap.Size = new System.Drawing.Size(100, 35);
            this.uiButtonStartCap.TabIndex = 1;
            this.uiButtonStartCap.Text = "开始采集";
            this.uiButtonStartCap.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStartCap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonStartCap.Click += new System.EventHandler(this.uiButtonStartCap_Click);
            // 
            // pictureBoxFingerBmp
            // 
            this.pictureBoxFingerBmp.Location = new System.Drawing.Point(7, 38);
            this.pictureBoxFingerBmp.Name = "pictureBoxFingerBmp";
            this.pictureBoxFingerBmp.Size = new System.Drawing.Size(189, 231);
            this.pictureBoxFingerBmp.TabIndex = 0;
            this.pictureBoxFingerBmp.TabStop = false;
            // 
            // uiButtonStopCap
            // 
            this.uiButtonStopCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonStopCap.Enabled = false;
            this.uiButtonStopCap.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStopCap.Location = new System.Drawing.Point(333, 326);
            this.uiButtonStopCap.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonStopCap.Name = "uiButtonStopCap";
            this.uiButtonStopCap.Size = new System.Drawing.Size(100, 35);
            this.uiButtonStopCap.TabIndex = 2;
            this.uiButtonStopCap.Text = "结束采集";
            this.uiButtonStopCap.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStopCap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonStopCap.Click += new System.EventHandler(this.uiButtonStopCap_Click);
            // 
            // uiLabelCapTimesCount
            // 
            this.uiLabelCapTimesCount.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelCapTimesCount.Location = new System.Drawing.Point(7, 326);
            this.uiLabelCapTimesCount.Name = "uiLabelCapTimesCount";
            this.uiLabelCapTimesCount.Size = new System.Drawing.Size(189, 23);
            this.uiLabelCapTimesCount.TabIndex = 3;
            this.uiLabelCapTimesCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelCapTimesCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelPressRemind
            // 
            this.uiLabelPressRemind.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelPressRemind.Location = new System.Drawing.Point(7, 292);
            this.uiLabelPressRemind.Name = "uiLabelPressRemind";
            this.uiLabelPressRemind.Size = new System.Drawing.Size(189, 23);
            this.uiLabelPressRemind.TabIndex = 4;
            this.uiLabelPressRemind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelPressRemind.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // richTextBoxErrMsg
            // 
            this.richTextBoxErrMsg.Location = new System.Drawing.Point(210, 39);
            this.richTextBoxErrMsg.Name = "richTextBoxErrMsg";
            this.richTextBoxErrMsg.Size = new System.Drawing.Size(233, 230);
            this.richTextBoxErrMsg.TabIndex = 5;
            this.richTextBoxErrMsg.Text = "";
            // 
            // FormFingerCap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(459, 402);
            this.Controls.Add(this.richTextBoxErrMsg);
            this.Controls.Add(this.uiLabelPressRemind);
            this.Controls.Add(this.uiLabelCapTimesCount);
            this.Controls.Add(this.uiButtonStopCap);
            this.Controls.Add(this.uiButtonStartCap);
            this.Controls.Add(this.pictureBoxFingerBmp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormFingerCap";
            this.Text = "指纹采集";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFingerCap_FormClosed);
            this.Shown += new System.EventHandler(this.FormFingerCap_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerBmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFingerBmp;
        private Sunny.UI.UIButton uiButtonStartCap;
        private Sunny.UI.UIButton uiButtonStopCap;
        private Sunny.UI.UILabel uiLabelCapTimesCount;
        private Sunny.UI.UILabel uiLabelPressRemind;
        private System.Windows.Forms.RichTextBox richTextBoxErrMsg;
    }
}