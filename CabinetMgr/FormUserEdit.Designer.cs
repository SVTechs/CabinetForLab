
namespace CabinetMgr
{
    partial class FormUserEdit
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
            this.uiLabelTitle = new Sunny.UI.UILabel();
            this.uiLabelFullName = new Sunny.UI.UILabel();
            this.uiLabelPassword = new Sunny.UI.UILabel();
            this.uiTextBoxFullName = new Sunny.UI.UITextBox();
            this.uiTextBoxPassword = new Sunny.UI.UITextBox();
            this.uiLabelRole = new Sunny.UI.UILabel();
            this.uiLabelSetFeature = new Sunny.UI.UILabel();
            this.uiButtonCancel = new Sunny.UI.UIButton();
            this.uiButtonSave = new Sunny.UI.UIButton();
            this.uiButtonCard = new Sunny.UI.UIButton();
            this.uiButtonFace = new Sunny.UI.UIButton();
            this.uiButtonFinger = new Sunny.UI.UIButton();
            this.uiLabelUserName = new Sunny.UI.UILabel();
            this.uiTextBoxUserName = new Sunny.UI.UITextBox();
            this.uiButtonFaceCap = new Sunny.UI.UIButton();
            this.uiComboTreeViewRole = new Sunny.UI.UIComboTreeView();
            this.uiTextBoxCardNum = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // uiLabelTitle
            // 
            this.uiLabelTitle.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelTitle.Location = new System.Drawing.Point(406, 38);
            this.uiLabelTitle.Name = "uiLabelTitle";
            this.uiLabelTitle.Size = new System.Drawing.Size(228, 67);
            this.uiLabelTitle.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelTitle.TabIndex = 0;
            this.uiLabelTitle.Text = "人员添加";
            this.uiLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabelTitle.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelFullName
            // 
            this.uiLabelFullName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelFullName.Location = new System.Drawing.Point(49, 249);
            this.uiLabelFullName.Name = "uiLabelFullName";
            this.uiLabelFullName.Size = new System.Drawing.Size(150, 63);
            this.uiLabelFullName.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelFullName.TabIndex = 1;
            this.uiLabelFullName.Text = "人员姓名：";
            this.uiLabelFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelFullName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelPassword
            // 
            this.uiLabelPassword.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelPassword.Location = new System.Drawing.Point(49, 350);
            this.uiLabelPassword.Name = "uiLabelPassword";
            this.uiLabelPassword.Size = new System.Drawing.Size(150, 63);
            this.uiLabelPassword.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelPassword.TabIndex = 2;
            this.uiLabelPassword.Text = "数字密码：";
            this.uiLabelPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxFullName
            // 
            this.uiTextBoxFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxFullName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxFullName.Location = new System.Drawing.Point(217, 249);
            this.uiTextBoxFullName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxFullName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxFullName.Name = "uiTextBoxFullName";
            this.uiTextBoxFullName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxFullName.RectSize = 2;
            this.uiTextBoxFullName.ShowText = false;
            this.uiTextBoxFullName.Size = new System.Drawing.Size(648, 60);
            this.uiTextBoxFullName.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxFullName.TabIndex = 3;
            this.uiTextBoxFullName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxFullName.Watermark = "";
            this.uiTextBoxFullName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxPassword
            // 
            this.uiTextBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxPassword.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxPassword.Location = new System.Drawing.Point(217, 353);
            this.uiTextBoxPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxPassword.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxPassword.Name = "uiTextBoxPassword";
            this.uiTextBoxPassword.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxPassword.RectSize = 2;
            this.uiTextBoxPassword.ShowText = false;
            this.uiTextBoxPassword.Size = new System.Drawing.Size(648, 60);
            this.uiTextBoxPassword.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxPassword.TabIndex = 4;
            this.uiTextBoxPassword.Text = "0";
            this.uiTextBoxPassword.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxPassword.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBoxPassword.Watermark = "";
            this.uiTextBoxPassword.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelRole
            // 
            this.uiLabelRole.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelRole.Location = new System.Drawing.Point(49, 451);
            this.uiLabelRole.Name = "uiLabelRole";
            this.uiLabelRole.Size = new System.Drawing.Size(150, 63);
            this.uiLabelRole.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelRole.TabIndex = 5;
            this.uiLabelRole.Text = "领用权限：";
            this.uiLabelRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelSetFeature
            // 
            this.uiLabelSetFeature.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelSetFeature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelSetFeature.Location = new System.Drawing.Point(49, 552);
            this.uiLabelSetFeature.Name = "uiLabelSetFeature";
            this.uiLabelSetFeature.Size = new System.Drawing.Size(150, 63);
            this.uiLabelSetFeature.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelSetFeature.TabIndex = 7;
            this.uiLabelSetFeature.Text = "录入身份：";
            this.uiLabelSetFeature.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelSetFeature.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.Location = new System.Drawing.Point(83, 719);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(403, 91);
            this.uiButtonCancel.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonCancel.TabIndex = 8;
            this.uiButtonCancel.Text = "取消";
            this.uiButtonCancel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // uiButtonSave
            // 
            this.uiButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonSave.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.Location = new System.Drawing.Point(540, 719);
            this.uiButtonSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonSave.Name = "uiButtonSave";
            this.uiButtonSave.Size = new System.Drawing.Size(403, 91);
            this.uiButtonSave.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonSave.TabIndex = 9;
            this.uiButtonSave.Text = "确认";
            this.uiButtonSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonSave.Click += new System.EventHandler(this.uiButtonSave_Click);
            // 
            // uiButtonCard
            // 
            this.uiButtonCard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCard.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonCard.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCard.Location = new System.Drawing.Point(217, 552);
            this.uiButtonCard.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCard.Name = "uiButtonCard";
            this.uiButtonCard.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonCard.Size = new System.Drawing.Size(202, 63);
            this.uiButtonCard.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonCard.TabIndex = 10;
            this.uiButtonCard.Text = "工卡录入";
            this.uiButtonCard.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCard.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonCard.Click += new System.EventHandler(this.uiButtonCard_Click);
            // 
            // uiButtonFace
            // 
            this.uiButtonFace.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonFace.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonFace.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonFace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonFace.Location = new System.Drawing.Point(440, 552);
            this.uiButtonFace.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonFace.Name = "uiButtonFace";
            this.uiButtonFace.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonFace.Size = new System.Drawing.Size(202, 63);
            this.uiButtonFace.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonFace.TabIndex = 11;
            this.uiButtonFace.Text = "人脸录入";
            this.uiButtonFace.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonFace.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonFace.Click += new System.EventHandler(this.uiButtonFace_Click);
            // 
            // uiButtonFinger
            // 
            this.uiButtonFinger.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonFinger.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonFinger.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonFinger.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonFinger.Location = new System.Drawing.Point(663, 552);
            this.uiButtonFinger.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonFinger.Name = "uiButtonFinger";
            this.uiButtonFinger.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonFinger.Size = new System.Drawing.Size(202, 63);
            this.uiButtonFinger.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonFinger.TabIndex = 12;
            this.uiButtonFinger.Text = "指纹录入";
            this.uiButtonFinger.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonFinger.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonFinger.Click += new System.EventHandler(this.uiButtonFinger_Click);
            // 
            // uiLabelUserName
            // 
            this.uiLabelUserName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelUserName.Location = new System.Drawing.Point(49, 148);
            this.uiLabelUserName.Name = "uiLabelUserName";
            this.uiLabelUserName.Size = new System.Drawing.Size(150, 63);
            this.uiLabelUserName.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelUserName.TabIndex = 13;
            this.uiLabelUserName.Text = "工号：";
            this.uiLabelUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxUserName
            // 
            this.uiTextBoxUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxUserName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxUserName.Location = new System.Drawing.Point(217, 148);
            this.uiTextBoxUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxUserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxUserName.Name = "uiTextBoxUserName";
            this.uiTextBoxUserName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxUserName.RectSize = 2;
            this.uiTextBoxUserName.ShowText = false;
            this.uiTextBoxUserName.Size = new System.Drawing.Size(648, 60);
            this.uiTextBoxUserName.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxUserName.TabIndex = 4;
            this.uiTextBoxUserName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxUserName.Watermark = "";
            this.uiTextBoxUserName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonFaceCap
            // 
            this.uiButtonFaceCap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonFaceCap.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonFaceCap.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonFaceCap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonFaceCap.Location = new System.Drawing.Point(440, 634);
            this.uiButtonFaceCap.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonFaceCap.Name = "uiButtonFaceCap";
            this.uiButtonFaceCap.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.uiButtonFaceCap.Size = new System.Drawing.Size(202, 63);
            this.uiButtonFaceCap.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonFaceCap.TabIndex = 14;
            this.uiButtonFaceCap.Text = "人脸捕捉";
            this.uiButtonFaceCap.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonFaceCap.Visible = false;
            this.uiButtonFaceCap.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonFaceCap.Click += new System.EventHandler(this.uiButtonFaceCap_Click);
            // 
            // uiComboTreeViewRole
            // 
            this.uiComboTreeViewRole.CheckBoxes = true;
            this.uiComboTreeViewRole.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboTreeViewRole.FillColor = System.Drawing.Color.White;
            this.uiComboTreeViewRole.Font = new System.Drawing.Font("HarmonyOS Sans SC", 14F);
            this.uiComboTreeViewRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiComboTreeViewRole.Location = new System.Drawing.Point(217, 460);
            this.uiComboTreeViewRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboTreeViewRole.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboTreeViewRole.Name = "uiComboTreeViewRole";
            this.uiComboTreeViewRole.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboTreeViewRole.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiComboTreeViewRole.RectSize = 2;
            this.uiComboTreeViewRole.Size = new System.Drawing.Size(648, 60);
            this.uiComboTreeViewRole.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboTreeViewRole.TabIndex = 15;
            this.uiComboTreeViewRole.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboTreeViewRole.Watermark = "";
            this.uiComboTreeViewRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxCardNum
            // 
            this.uiTextBoxCardNum.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxCardNum.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxCardNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxCardNum.Location = new System.Drawing.Point(83, 637);
            this.uiTextBoxCardNum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxCardNum.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxCardNum.Name = "uiTextBoxCardNum";
            this.uiTextBoxCardNum.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxCardNum.RectSize = 2;
            this.uiTextBoxCardNum.ShowText = false;
            this.uiTextBoxCardNum.Size = new System.Drawing.Size(334, 60);
            this.uiTextBoxCardNum.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxCardNum.TabIndex = 5;
            this.uiTextBoxCardNum.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxCardNum.Visible = false;
            this.uiTextBoxCardNum.Watermark = "";
            this.uiTextBoxCardNum.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormUserEdit
            // 
            this.AllowShowTitle = false;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 895);
            this.Controls.Add(this.uiTextBoxCardNum);
            this.Controls.Add(this.uiComboTreeViewRole);
            this.Controls.Add(this.uiButtonFaceCap);
            this.Controls.Add(this.uiTextBoxUserName);
            this.Controls.Add(this.uiLabelUserName);
            this.Controls.Add(this.uiButtonFinger);
            this.Controls.Add(this.uiButtonFace);
            this.Controls.Add(this.uiButtonCard);
            this.Controls.Add(this.uiButtonSave);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiLabelSetFeature);
            this.Controls.Add(this.uiLabelRole);
            this.Controls.Add(this.uiTextBoxPassword);
            this.Controls.Add(this.uiTextBoxFullName);
            this.Controls.Add(this.uiLabelPassword);
            this.Controls.Add(this.uiLabelFullName);
            this.Controls.Add(this.uiLabelTitle);
            this.Name = "FormUserEdit";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowTitle = false;
            this.Style = Sunny.UI.UIStyle.Custom;
            this.Text = "FormUserEdit";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Shown += new System.EventHandler(this.FormUserEdit_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabelTitle;
        private Sunny.UI.UILabel uiLabelFullName;
        private Sunny.UI.UILabel uiLabelPassword;
        private Sunny.UI.UITextBox uiTextBoxFullName;
        private Sunny.UI.UITextBox uiTextBoxPassword;
        private Sunny.UI.UILabel uiLabelRole;
        private Sunny.UI.UILabel uiLabelSetFeature;
        private Sunny.UI.UIButton uiButtonCancel;
        private Sunny.UI.UIButton uiButtonSave;
        private Sunny.UI.UIButton uiButtonCard;
        private Sunny.UI.UIButton uiButtonFace;
        private Sunny.UI.UIButton uiButtonFinger;
        private Sunny.UI.UILabel uiLabelUserName;
        private Sunny.UI.UITextBox uiTextBoxUserName;
        private Sunny.UI.UIButton uiButtonFaceCap;
        private Sunny.UI.UIComboTreeView uiComboTreeViewRole;
        private Sunny.UI.UITextBox uiTextBoxCardNum;
    }
}