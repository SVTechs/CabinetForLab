
namespace CabinetMgr
{
    partial class FormToolEdit
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
            this.uiLabelRole = new System.Windows.Forms.Label();
            this.uiLabelTitle = new System.Windows.Forms.Label();
            this.uiTextBoxToolName = new Sunny.UI.UITextBox();
            this.uiLabelToolName = new System.Windows.Forms.Label();
            this.uiTextBoxToolCount = new Sunny.UI.UITextBox();
            this.uiLabelToolCount = new System.Windows.Forms.Label();
            this.uiButtonSave = new Sunny.UI.UIButton();
            this.uiButtonCancel = new Sunny.UI.UIButton();
            this.uiComboBoxWarnType = new Sunny.UI.UIComboBox();
            this.uiLabelWarn = new System.Windows.Forms.Label();
            this.uiTextBoxWarnValue = new Sunny.UI.UITextBox();
            this.uiComboTreeViewRole = new Sunny.UI.UIComboTreeView();
            this.SuspendLayout();
            // 
            // uiLabelRole
            // 
            this.uiLabelRole.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelRole.Location = new System.Drawing.Point(81, 400);
            this.uiLabelRole.Name = "uiLabelRole";
            this.uiLabelRole.Size = new System.Drawing.Size(150, 63);
            this.uiLabelRole.TabIndex = 7;
            this.uiLabelRole.Text = "领用权限：";
            this.uiLabelRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabelTitle
            // 
            this.uiLabelTitle.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelTitle.Location = new System.Drawing.Point(360, 39);
            this.uiLabelTitle.Name = "uiLabelTitle";
            this.uiLabelTitle.Size = new System.Drawing.Size(339, 67);
            this.uiLabelTitle.TabIndex = 9;
            this.uiLabelTitle.Text = "当前选择";
            this.uiLabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiTextBoxToolName
            // 
            this.uiTextBoxToolName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxToolName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxToolName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxToolName.Location = new System.Drawing.Point(249, 160);
            this.uiTextBoxToolName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxToolName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxToolName.Name = "uiTextBoxToolName";
            this.uiTextBoxToolName.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxToolName.RectSize = 2;
            this.uiTextBoxToolName.ShowText = false;
            this.uiTextBoxToolName.Size = new System.Drawing.Size(648, 60);
            this.uiTextBoxToolName.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxToolName.TabIndex = 14;
            this.uiTextBoxToolName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxToolName.Watermark = "";
            this.uiTextBoxToolName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelToolName
            // 
            this.uiLabelToolName.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelToolName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelToolName.Location = new System.Drawing.Point(81, 160);
            this.uiLabelToolName.Name = "uiLabelToolName";
            this.uiLabelToolName.Size = new System.Drawing.Size(150, 63);
            this.uiLabelToolName.TabIndex = 15;
            this.uiLabelToolName.Text = "物资规格：";
            this.uiLabelToolName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBoxToolCount
            // 
            this.uiTextBoxToolCount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxToolCount.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxToolCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxToolCount.Location = new System.Drawing.Point(249, 275);
            this.uiTextBoxToolCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxToolCount.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxToolCount.Name = "uiTextBoxToolCount";
            this.uiTextBoxToolCount.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxToolCount.RectSize = 2;
            this.uiTextBoxToolCount.ShowText = false;
            this.uiTextBoxToolCount.Size = new System.Drawing.Size(648, 60);
            this.uiTextBoxToolCount.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxToolCount.TabIndex = 6;
            this.uiTextBoxToolCount.Text = "0";
            this.uiTextBoxToolCount.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxToolCount.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBoxToolCount.Watermark = "";
            this.uiTextBoxToolCount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelToolCount
            // 
            this.uiLabelToolCount.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelToolCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelToolCount.Location = new System.Drawing.Point(81, 272);
            this.uiLabelToolCount.Name = "uiLabelToolCount";
            this.uiLabelToolCount.Size = new System.Drawing.Size(150, 63);
            this.uiLabelToolCount.TabIndex = 5;
            this.uiLabelToolCount.Text = "库存数量：";
            this.uiLabelToolCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButtonSave
            // 
            this.uiButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonSave.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.Location = new System.Drawing.Point(541, 677);
            this.uiButtonSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonSave.Name = "uiButtonSave";
            this.uiButtonSave.Size = new System.Drawing.Size(403, 91);
            this.uiButtonSave.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonSave.TabIndex = 17;
            this.uiButtonSave.Text = "确认";
            this.uiButtonSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonSave.Click += new System.EventHandler(this.uiButtonSave_Click);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.Location = new System.Drawing.Point(84, 677);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(403, 91);
            this.uiButtonCancel.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonCancel.TabIndex = 16;
            this.uiButtonCancel.Text = "取消";
            this.uiButtonCancel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // uiComboBoxWarnType
            // 
            this.uiComboBoxWarnType.DataSource = null;
            this.uiComboBoxWarnType.FillColor = System.Drawing.Color.White;
            this.uiComboBoxWarnType.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBoxWarnType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiComboBoxWarnType.Location = new System.Drawing.Point(249, 553);
            this.uiComboBoxWarnType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBoxWarnType.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBoxWarnType.Name = "uiComboBoxWarnType";
            this.uiComboBoxWarnType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBoxWarnType.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiComboBoxWarnType.RectSize = 2;
            this.uiComboBoxWarnType.Size = new System.Drawing.Size(283, 63);
            this.uiComboBoxWarnType.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboBoxWarnType.TabIndex = 10;
            this.uiComboBoxWarnType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBoxWarnType.Watermark = "";
            this.uiComboBoxWarnType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelWarn
            // 
            this.uiLabelWarn.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelWarn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelWarn.Location = new System.Drawing.Point(81, 553);
            this.uiLabelWarn.Name = "uiLabelWarn";
            this.uiLabelWarn.Size = new System.Drawing.Size(150, 63);
            this.uiLabelWarn.TabIndex = 9;
            this.uiLabelWarn.Text = "告警阈值：";
            this.uiLabelWarn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiTextBoxWarnValue
            // 
            this.uiTextBoxWarnValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxWarnValue.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxWarnValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxWarnValue.Location = new System.Drawing.Point(570, 553);
            this.uiTextBoxWarnValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxWarnValue.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxWarnValue.Name = "uiTextBoxWarnValue";
            this.uiTextBoxWarnValue.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxWarnValue.RectSize = 2;
            this.uiTextBoxWarnValue.ShowText = false;
            this.uiTextBoxWarnValue.Size = new System.Drawing.Size(327, 60);
            this.uiTextBoxWarnValue.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxWarnValue.TabIndex = 15;
            this.uiTextBoxWarnValue.Text = "0";
            this.uiTextBoxWarnValue.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTextBoxWarnValue.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBoxWarnValue.Watermark = "";
            this.uiTextBoxWarnValue.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiComboTreeViewRole
            // 
            this.uiComboTreeViewRole.CheckBoxes = true;
            this.uiComboTreeViewRole.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboTreeViewRole.FillColor = System.Drawing.Color.White;
            this.uiComboTreeViewRole.Font = new System.Drawing.Font("HarmonyOS Sans SC", 18F);
            this.uiComboTreeViewRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiComboTreeViewRole.Location = new System.Drawing.Point(249, 403);
            this.uiComboTreeViewRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboTreeViewRole.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboTreeViewRole.Name = "uiComboTreeViewRole";
            this.uiComboTreeViewRole.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboTreeViewRole.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiComboTreeViewRole.RectSize = 2;
            this.uiComboTreeViewRole.Size = new System.Drawing.Size(648, 60);
            this.uiComboTreeViewRole.Style = Sunny.UI.UIStyle.Custom;
            this.uiComboTreeViewRole.TabIndex = 16;
            this.uiComboTreeViewRole.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboTreeViewRole.Watermark = "";
            this.uiComboTreeViewRole.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormToolEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 895);
            this.Controls.Add(this.uiComboTreeViewRole);
            this.Controls.Add(this.uiTextBoxWarnValue);
            this.Controls.Add(this.uiComboBoxWarnType);
            this.Controls.Add(this.uiLabelWarn);
            this.Controls.Add(this.uiButtonSave);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiTextBoxToolCount);
            this.Controls.Add(this.uiTextBoxToolName);
            this.Controls.Add(this.uiLabelToolCount);
            this.Controls.Add(this.uiLabelToolName);
            this.Controls.Add(this.uiLabelTitle);
            this.Controls.Add(this.uiLabelRole);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormToolEdit";
            this.Text = "FormToolEdit";
            this.Shown += new System.EventHandler(this.FormToolEdit_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label uiLabelRole;
        private System.Windows.Forms.Label uiLabelTitle;
        private Sunny.UI.UITextBox uiTextBoxToolName;
        private System.Windows.Forms.Label uiLabelToolName;
        private Sunny.UI.UITextBox uiTextBoxToolCount;
        private System.Windows.Forms.Label uiLabelToolCount;
        private Sunny.UI.UIButton uiButtonSave;
        private Sunny.UI.UIButton uiButtonCancel;
        private Sunny.UI.UIComboBox uiComboBoxWarnType;
        private System.Windows.Forms.Label uiLabelWarn;
        private Sunny.UI.UITextBox uiTextBoxWarnValue;
        private Sunny.UI.UIComboTreeView uiComboTreeViewRole;
    }
}