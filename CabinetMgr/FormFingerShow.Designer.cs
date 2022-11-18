
namespace CabinetMgr
{
    partial class FormFingerShow
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
            this.uiLabelPressResult = new System.Windows.Forms.Label();
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
            // uiLabelPressResult
            // 
            this.uiLabelPressResult.Font = new System.Drawing.Font("HarmonyOS Sans SC", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelPressResult.Location = new System.Drawing.Point(48, 278);
            this.uiLabelPressResult.Name = "uiLabelPressResult";
            this.uiLabelPressResult.Size = new System.Drawing.Size(189, 29);
            this.uiLabelPressResult.TabIndex = 5;
            this.uiLabelPressResult.Text = "请按压指纹";
            this.uiLabelPressResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormFingerShow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(284, 329);
            this.Controls.Add(this.uiLabelPressResult);
            this.Controls.Add(this.pictureBoxFingerBmp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormFingerShow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormFingerCap";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.FormFingerShow_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFingerBmp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxFingerBmp;
        private System.Windows.Forms.Label uiLabelPressResult;
    }
}