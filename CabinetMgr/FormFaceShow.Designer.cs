
namespace CabinetMgr
{
    partial class FormFaceShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFaceShow));
            this.pictureBoxCapImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxCapImg
            // 
            this.pictureBoxCapImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxCapImg.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxCapImg.Name = "pictureBoxCapImg";
            this.pictureBoxCapImg.Size = new System.Drawing.Size(450, 600);
            this.pictureBoxCapImg.TabIndex = 0;
            this.pictureBoxCapImg.TabStop = false;
            // 
            // FormFaceShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.Controls.Add(this.pictureBoxCapImg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFaceShow";
            this.Text = "FormFaceShow";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.FormFaceShow_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCapImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxCapImg;
    }
}