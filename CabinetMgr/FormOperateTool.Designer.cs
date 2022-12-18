
namespace CabinetMgr
{
    partial class FormOperateTool
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
            this.uiLabelCurrentSelect = new Sunny.UI.UILabel();
            this.uiLabelAmount = new Sunny.UI.UILabel();
            this.uiTextBoxAmount = new Sunny.UI.UITextBox();
            this.uiLabelOperateType = new Sunny.UI.UILabel();
            this.uiRadioButtonBorrrow = new Sunny.UI.UIRadioButton();
            this.uiRadioButtonReturn = new Sunny.UI.UIRadioButton();
            this.uiRadioButtonRepair = new Sunny.UI.UIRadioButton();
            this.uiRadioButtonLack = new Sunny.UI.UIRadioButton();
            this.uiButtonCancel = new Sunny.UI.UIButton();
            this.uiButtonConfirm = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiLabelCurrentSelect
            // 
            this.uiLabelCurrentSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiLabelCurrentSelect.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelCurrentSelect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelCurrentSelect.Location = new System.Drawing.Point(0, 0);
            this.uiLabelCurrentSelect.Name = "uiLabelCurrentSelect";
            this.uiLabelCurrentSelect.Size = new System.Drawing.Size(1007, 62);
            this.uiLabelCurrentSelect.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelCurrentSelect.TabIndex = 0;
            this.uiLabelCurrentSelect.Text = "当前选择";
            this.uiLabelCurrentSelect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiLabelCurrentSelect.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelAmount
            // 
            this.uiLabelAmount.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelAmount.Location = new System.Drawing.Point(64, 318);
            this.uiLabelAmount.Name = "uiLabelAmount";
            this.uiLabelAmount.Size = new System.Drawing.Size(225, 64);
            this.uiLabelAmount.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelAmount.TabIndex = 18;
            this.uiLabelAmount.Text = "数量：";
            this.uiLabelAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabelAmount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxAmount
            // 
            this.uiTextBoxAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxAmount.DoubleValue = 1D;
            this.uiTextBoxAmount.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxAmount.IntValue = 1;
            this.uiTextBoxAmount.Location = new System.Drawing.Point(305, 318);
            this.uiTextBoxAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxAmount.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxAmount.Name = "uiTextBoxAmount";
            this.uiTextBoxAmount.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiTextBoxAmount.RectSize = 2;
            this.uiTextBoxAmount.ShowText = false;
            this.uiTextBoxAmount.Size = new System.Drawing.Size(338, 60);
            this.uiTextBoxAmount.Style = Sunny.UI.UIStyle.Custom;
            this.uiTextBoxAmount.TabIndex = 5;
            this.uiTextBoxAmount.Text = "1";
            this.uiTextBoxAmount.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxAmount.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBoxAmount.Watermark = "";
            this.uiTextBoxAmount.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiTextBoxAmount.Enter += new System.EventHandler(this.uiTextBoxAmount_Enter);
            // 
            // uiLabelOperateType
            // 
            this.uiLabelOperateType.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelOperateType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiLabelOperateType.Location = new System.Drawing.Point(64, 180);
            this.uiLabelOperateType.Name = "uiLabelOperateType";
            this.uiLabelOperateType.Size = new System.Drawing.Size(225, 64);
            this.uiLabelOperateType.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabelOperateType.TabIndex = 17;
            this.uiLabelOperateType.Text = "操作类型：";
            this.uiLabelOperateType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uiLabelOperateType.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiRadioButtonBorrrow
            // 
            this.uiRadioButtonBorrrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButtonBorrrow.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButtonBorrrow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiRadioButtonBorrrow.ImageInterval = 6;
            this.uiRadioButtonBorrrow.ImageSize = 30;
            this.uiRadioButtonBorrrow.Location = new System.Drawing.Point(305, 189);
            this.uiRadioButtonBorrrow.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonBorrrow.Name = "uiRadioButtonBorrrow";
            this.uiRadioButtonBorrrow.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.uiRadioButtonBorrrow.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.uiRadioButtonBorrrow.Size = new System.Drawing.Size(155, 46);
            this.uiRadioButtonBorrrow.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButtonBorrrow.TabIndex = 1;
            this.uiRadioButtonBorrrow.Tag = "Borrow";
            this.uiRadioButtonBorrrow.Text = "领用";
            this.uiRadioButtonBorrrow.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiRadioButtonReturn
            // 
            this.uiRadioButtonReturn.Checked = true;
            this.uiRadioButtonReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButtonReturn.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButtonReturn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiRadioButtonReturn.ImageInterval = 6;
            this.uiRadioButtonReturn.ImageSize = 30;
            this.uiRadioButtonReturn.Location = new System.Drawing.Point(466, 189);
            this.uiRadioButtonReturn.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonReturn.Name = "uiRadioButtonReturn";
            this.uiRadioButtonReturn.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.uiRadioButtonReturn.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.uiRadioButtonReturn.Size = new System.Drawing.Size(155, 46);
            this.uiRadioButtonReturn.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButtonReturn.TabIndex = 2;
            this.uiRadioButtonReturn.Tag = "Return";
            this.uiRadioButtonReturn.Text = "归还";
            this.uiRadioButtonReturn.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiRadioButtonRepair
            // 
            this.uiRadioButtonRepair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButtonRepair.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButtonRepair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiRadioButtonRepair.ImageInterval = 6;
            this.uiRadioButtonRepair.ImageSize = 30;
            this.uiRadioButtonRepair.Location = new System.Drawing.Point(627, 189);
            this.uiRadioButtonRepair.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonRepair.Name = "uiRadioButtonRepair";
            this.uiRadioButtonRepair.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.uiRadioButtonRepair.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.uiRadioButtonRepair.Size = new System.Drawing.Size(155, 46);
            this.uiRadioButtonRepair.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButtonRepair.TabIndex = 3;
            this.uiRadioButtonRepair.Tag = "Repair";
            this.uiRadioButtonRepair.Text = "报修";
            this.uiRadioButtonRepair.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiRadioButtonLack
            // 
            this.uiRadioButtonLack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButtonLack.Font = new System.Drawing.Font("HarmonyOS Sans SC", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButtonLack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiRadioButtonLack.ImageInterval = 6;
            this.uiRadioButtonLack.ImageSize = 30;
            this.uiRadioButtonLack.Location = new System.Drawing.Point(788, 189);
            this.uiRadioButtonLack.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonLack.Name = "uiRadioButtonLack";
            this.uiRadioButtonLack.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
            this.uiRadioButtonLack.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.uiRadioButtonLack.Size = new System.Drawing.Size(155, 46);
            this.uiRadioButtonLack.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButtonLack.TabIndex = 4;
            this.uiRadioButtonLack.Tag = "Lack";
            this.uiRadioButtonLack.Text = "缺料";
            this.uiRadioButtonLack.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonCancel.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.Location = new System.Drawing.Point(240, 425);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Size = new System.Drawing.Size(403, 91);
            this.uiButtonCancel.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonCancel.TabIndex = 19;
            this.uiButtonCancel.Text = "取消";
            this.uiButtonCancel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.Visible = false;
            this.uiButtonCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // uiButtonConfirm
            // 
            this.uiButtonConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonConfirm.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonConfirm.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.uiButtonConfirm.Font = new System.Drawing.Font("HarmonyOS Sans SC", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonConfirm.Location = new System.Drawing.Point(305, 595);
            this.uiButtonConfirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonConfirm.Name = "uiButtonConfirm";
            this.uiButtonConfirm.Size = new System.Drawing.Size(403, 91);
            this.uiButtonConfirm.Style = Sunny.UI.UIStyle.Custom;
            this.uiButtonConfirm.TabIndex = 20;
            this.uiButtonConfirm.Text = "确认";
            this.uiButtonConfirm.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonConfirm.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonConfirm.Click += new System.EventHandler(this.uiButtonConfirm_Click);
            // 
            // FormOperateTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1007, 800);
            this.Controls.Add(this.uiButtonConfirm);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiRadioButtonLack);
            this.Controls.Add(this.uiRadioButtonRepair);
            this.Controls.Add(this.uiRadioButtonReturn);
            this.Controls.Add(this.uiRadioButtonBorrrow);
            this.Controls.Add(this.uiLabelOperateType);
            this.Controls.Add(this.uiTextBoxAmount);
            this.Controls.Add(this.uiLabelAmount);
            this.Controls.Add(this.uiLabelCurrentSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormOperateTool";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOperateTool";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOperateTool_FormClosed);
            this.Shown += new System.EventHandler(this.FormOperateTool_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILabel uiLabelCurrentSelect;
        private Sunny.UI.UILabel uiLabelAmount;
        private Sunny.UI.UITextBox uiTextBoxAmount;
        private Sunny.UI.UILabel uiLabelOperateType;
        private Sunny.UI.UIRadioButton uiRadioButtonBorrrow;
        private Sunny.UI.UIRadioButton uiRadioButtonReturn;
        private Sunny.UI.UIRadioButton uiRadioButtonRepair;
        private Sunny.UI.UIRadioButton uiRadioButtonLack;
        private Sunny.UI.UIButton uiButtonCancel;
        private Sunny.UI.UIButton uiButtonConfirm;
    }
}