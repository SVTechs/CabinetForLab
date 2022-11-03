
namespace CabinetMgr
{
    partial class FormPasswordLogin
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
            this.uiLabelUserName = new Sunny.UI.UILabel();
            this.uiTextBoxUserName = new Sunny.UI.UITextBox();
            this.uiTextBoxPassword = new Sunny.UI.UITextBox();
            this.uiLabelPassword = new Sunny.UI.UILabel();
            this.uiButtonLogin = new Sunny.UI.UIButton();
            this.uiButtonCancel = new Sunny.UI.UIButton();
            this.uiButton1 = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabelUserName
            // 
            this.uiLabelUserName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelUserName.Location = new System.Drawing.Point(234, 163);
            this.uiLabelUserName.Name = "uiLabelUserName";
            this.uiLabelUserName.Size = new System.Drawing.Size(177, 59);
            this.uiLabelUserName.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelUserName.TabIndex = 6;
            this.uiLabelUserName.Text = "工号：";
            this.uiLabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxUserName
            // 
            this.uiTextBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxUserName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxUserName.Location = new System.Drawing.Point(418, 163);
            this.uiTextBoxUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxUserName.Name = "uiTextBoxUserName";
            this.uiTextBoxUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxUserName.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxUserName.RectSize = 2;
            this.uiTextBoxUserName.ShowText = false;
            this.uiTextBoxUserName.Size = new System.Drawing.Size(251, 60);
            this.uiTextBoxUserName.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxUserName.TabIndex = 1;
            this.uiTextBoxUserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxUserName.Watermark = "";
            this.uiTextBoxUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTextBoxUserName.Enter += new System.EventHandler(this.uiTextBoxUserName_Enter);
            // 
            // uiTextBoxPassword
            // 
            this.uiTextBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxPassword.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiTextBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxPassword.Location = new System.Drawing.Point(418, 263);
            this.uiTextBoxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxPassword.Name = "uiTextBoxPassword";
            this.uiTextBoxPassword.PasswordChar = '*';
            this.uiTextBoxPassword.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxPassword.RectDisableColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxPassword.RectSize = 2;
            this.uiTextBoxPassword.ShowText = false;
            this.uiTextBoxPassword.Size = new System.Drawing.Size(251, 60);
            this.uiTextBoxPassword.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxPassword.TabIndex = 4;
            this.uiTextBoxPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxPassword.Watermark = "";
            this.uiTextBoxPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTextBoxPassword.Enter += new System.EventHandler(this.uiTextBoxPassword_Enter);
            // 
            // uiLabelPassword
            // 
            this.uiLabelPassword.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiLabelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelPassword.Location = new System.Drawing.Point(234, 263);
            this.uiLabelPassword.Name = "uiLabelPassword";
            this.uiLabelPassword.Size = new System.Drawing.Size(177, 59);
            this.uiLabelPassword.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelPassword.TabIndex = 3;
            this.uiLabelPassword.Text = "密码：";
            this.uiLabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonLogin
            // 
            this.uiButtonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonLogin.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonLogin.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonLogin.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonLogin.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonLogin.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButtonLogin.Location = new System.Drawing.Point(166, 488);
            this.uiButtonLogin.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonLogin.Name = "uiButtonLogin";
            this.uiButtonLogin.Size = new System.Drawing.Size(201, 71);
            this.uiButtonLogin.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonLogin.TabIndex = 5;
            this.uiButtonLogin.Text = "登录";
            this.uiButtonLogin.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonLogin.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonLogin.Click += new System.EventHandler(this.uiButtonLogin_Click);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonCancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonCancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonCancel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uiButtonCancel.Location = new System.Drawing.Point(558, 488);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(201, 71);
            this.uiButtonCancel.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonCancel.TabIndex = 1;
            this.uiButtonCancel.Text = "取消";
            this.uiButtonCancel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(58, 49);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(100, 35);
            this.uiButton1.Style = Sunny.UI.UIStyle.Custom;
            this.uiButton1.TabIndex = 0;
            this.uiButton1.Text = "uiButton1";
            this.uiButton1.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Visible = false;
            this.uiButton1.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormPasswordLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(937, 709);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiButtonLogin);
            this.Controls.Add(this.uiTextBoxPassword);
            this.Controls.Add(this.uiLabelPassword);
            this.Controls.Add(this.uiTextBoxUserName);
            this.Controls.Add(this.uiLabelUserName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPasswordLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPasswordLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPasswordLogin_FormClosed);
            this.Shown += new System.EventHandler(this.FormPasswordLogin_Shown);
            this.Click += new System.EventHandler(this.FormPasswordLogin_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabelUserName;
        private Sunny.UI.UITextBox uiTextBoxUserName;
        private Sunny.UI.UITextBox uiTextBoxPassword;
        private Sunny.UI.UILabel uiLabelPassword;
        private Sunny.UI.UIButton uiButtonLogin;
        private Sunny.UI.UIButton uiButtonCancel;
        private Sunny.UI.UIButton uiButton1;
    }
}