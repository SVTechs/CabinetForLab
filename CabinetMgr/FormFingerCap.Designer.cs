
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
            this.uiButtonStartCap = new System.Windows.Forms.Button();
            this.uiLabelPressRemind = new System.Windows.Forms.Label();
            this.uiLabelCapTimesCount = new System.Windows.Forms.Label();
            this.uiButtonCancel = new System.Windows.Forms.Button();
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
            this.uiButtonStartCap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonStartCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonStartCap.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonStartCap.ForeColor = System.Drawing.Color.White;
            this.uiButtonStartCap.Location = new System.Drawing.Point(48, 362);
            this.uiButtonStartCap.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonStartCap.Name = "uiButtonStartCap";
            this.uiButtonStartCap.Size = new System.Drawing.Size(189, 35);
            this.uiButtonStartCap.TabIndex = 2;
            this.uiButtonStartCap.Text = "重新采集";
            this.uiButtonStartCap.UseVisualStyleBackColor = false;
            this.uiButtonStartCap.Click += new System.EventHandler(this.uiButtonStartCap_Click);
            // 
            // uiLabelPressRemind
            // 
            this.uiLabelPressRemind.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelPressRemind.Location = new System.Drawing.Point(48, 278);
            this.uiLabelPressRemind.Name = "uiLabelPressRemind";
            this.uiLabelPressRemind.Size = new System.Drawing.Size(189, 29);
            this.uiLabelPressRemind.TabIndex = 5;
            this.uiLabelPressRemind.Text = "11";
            this.uiLabelPressRemind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabelCapTimesCount
            // 
            this.uiLabelCapTimesCount.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelCapTimesCount.Location = new System.Drawing.Point(48, 318);
            this.uiLabelCapTimesCount.Name = "uiLabelCapTimesCount";
            this.uiLabelCapTimesCount.Size = new System.Drawing.Size(189, 29);
            this.uiLabelCapTimesCount.TabIndex = 6;
            this.uiLabelCapTimesCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.ForeColor = System.Drawing.Color.White;
            this.uiButtonCancel.Location = new System.Drawing.Point(48, 403);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(189, 35);
            this.uiButtonCancel.TabIndex = 7;
            this.uiButtonCancel.Text = "取消采集";
            this.uiButtonCancel.UseVisualStyleBackColor = false;
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // FormFingerCap
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 466);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiLabelCapTimesCount);
            this.Controls.Add(this.uiLabelPressRemind);
            this.Controls.Add(this.uiButtonStartCap);
            this.Controls.Add(this.pictureBoxFingerBmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFingerCap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFingerCap";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.FormFingerCap_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerBmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFingerBmp;
        private System.Windows.Forms.Button uiButtonStartCap;
        private System.Windows.Forms.Label uiLabelPressRemind;
        private System.Windows.Forms.Label uiLabelCapTimesCount;
        private System.Windows.Forms.Button uiButtonCancel;
    }
}