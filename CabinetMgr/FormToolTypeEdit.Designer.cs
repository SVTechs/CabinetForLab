
namespace CabinetMgr
{
    partial class FormToolTypeEdit
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
            this.uiTextBoxToolTypeId = new Sunny.UI.UITextBox();
            this.uiTextBoxToolTypeName = new Sunny.UI.UITextBox();
            this.uiLabelToolTypeName = new Sunny.UI.UILabel();
            this.uiButtonSave = new Sunny.UI.UIButton();
            this.uiButtonCancel = new Sunny.UI.UIButton();
            this.uiLabelToolTypeSortOrder = new Sunny.UI.UILabel();
            this.uiTextBoxToolTypeSortOrder = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // uiTextBoxToolTypeId
            // 
            this.uiTextBoxToolTypeId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxToolTypeId.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxToolTypeId.Location = new System.Drawing.Point(199, 303);
            this.uiTextBoxToolTypeId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxToolTypeId.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxToolTypeId.Name = "uiTextBoxToolTypeId";
            this.uiTextBoxToolTypeId.ShowText = false;
            this.uiTextBoxToolTypeId.Size = new System.Drawing.Size(150, 29);
            this.uiTextBoxToolTypeId.TabIndex = 0;
            this.uiTextBoxToolTypeId.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxToolTypeId.Visible = false;
            this.uiTextBoxToolTypeId.Watermark = "";
            this.uiTextBoxToolTypeId.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxToolTypeName
            // 
            this.uiTextBoxToolTypeName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxToolTypeName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxToolTypeName.Location = new System.Drawing.Point(249, 82);
            this.uiTextBoxToolTypeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxToolTypeName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxToolTypeName.Name = "uiTextBoxToolTypeName";
            this.uiTextBoxToolTypeName.ShowText = false;
            this.uiTextBoxToolTypeName.Size = new System.Drawing.Size(150, 29);
            this.uiTextBoxToolTypeName.TabIndex = 3;
            this.uiTextBoxToolTypeName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxToolTypeName.Watermark = "";
            this.uiTextBoxToolTypeName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiLabelToolTypeName
            // 
            this.uiLabelToolTypeName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelToolTypeName.Location = new System.Drawing.Point(92, 82);
            this.uiLabelToolTypeName.Name = "uiLabelToolTypeName";
            this.uiLabelToolTypeName.Size = new System.Drawing.Size(100, 23);
            this.uiLabelToolTypeName.TabIndex = 4;
            this.uiLabelToolTypeName.Text = "类型名称";
            this.uiLabelToolTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelToolTypeName.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiButtonSave
            // 
            this.uiButtonSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonSave.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.Location = new System.Drawing.Point(116, 236);
            this.uiButtonSave.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonSave.Name = "uiButtonSave";
            this.uiButtonSave.Radius = 30;
            this.uiButtonSave.Size = new System.Drawing.Size(100, 35);
            this.uiButtonSave.TabIndex = 5;
            this.uiButtonSave.Text = "保存";
            this.uiButtonSave.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonSave.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonSave.Click += new System.EventHandler(this.uiButtonSave_Click);
            // 
            // uiButtonCancel
            // 
            this.uiButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButtonCancel.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.Location = new System.Drawing.Point(299, 236);
            this.uiButtonCancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButtonCancel.Name = "uiButtonCancel";
            this.uiButtonCancel.Radius = 30;
            this.uiButtonCancel.Size = new System.Drawing.Size(100, 35);
            this.uiButtonCancel.TabIndex = 6;
            this.uiButtonCancel.Text = "取消";
            this.uiButtonCancel.TipsFont = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButtonCancel.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.uiButtonCancel.Click += new System.EventHandler(this.uiButtonCancel_Click);
            // 
            // uiLabelToolTypeSortOrder
            // 
            this.uiLabelToolTypeSortOrder.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabelToolTypeSortOrder.Location = new System.Drawing.Point(92, 143);
            this.uiLabelToolTypeSortOrder.Name = "uiLabelToolTypeSortOrder";
            this.uiLabelToolTypeSortOrder.Size = new System.Drawing.Size(100, 23);
            this.uiLabelToolTypeSortOrder.TabIndex = 7;
            this.uiLabelToolTypeSortOrder.Text = "类型排序";
            this.uiLabelToolTypeSortOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiLabelToolTypeSortOrder.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // uiTextBoxToolTypeSortOrder
            // 
            this.uiTextBoxToolTypeSortOrder.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBoxToolTypeSortOrder.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBoxToolTypeSortOrder.Location = new System.Drawing.Point(249, 143);
            this.uiTextBoxToolTypeSortOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBoxToolTypeSortOrder.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBoxToolTypeSortOrder.Name = "uiTextBoxToolTypeSortOrder";
            this.uiTextBoxToolTypeSortOrder.ShowText = false;
            this.uiTextBoxToolTypeSortOrder.Size = new System.Drawing.Size(150, 29);
            this.uiTextBoxToolTypeSortOrder.TabIndex = 4;
            this.uiTextBoxToolTypeSortOrder.Text = "0";
            this.uiTextBoxToolTypeSortOrder.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBoxToolTypeSortOrder.Type = Sunny.UI.UITextBox.UIEditType.Integer;
            this.uiTextBoxToolTypeSortOrder.Watermark = "";
            this.uiTextBoxToolTypeSortOrder.ZoomScaleRect = new System.Drawing.Rectangle(0, 0, 0, 0);
            // 
            // FormToolTypeEdit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(513, 363);
            this.Controls.Add(this.uiTextBoxToolTypeSortOrder);
            this.Controls.Add(this.uiLabelToolTypeSortOrder);
            this.Controls.Add(this.uiButtonCancel);
            this.Controls.Add(this.uiButtonSave);
            this.Controls.Add(this.uiLabelToolTypeName);
            this.Controls.Add(this.uiTextBoxToolTypeName);
            this.Controls.Add(this.uiTextBoxToolTypeId);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormToolTypeEdit";
            this.Text = "FormToolTypeEdit";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormToolTypeEdit_FormClosed);
            this.Load += new System.EventHandler(this.FormToolTypeEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITextBox uiTextBoxToolTypeId;
        private Sunny.UI.UITextBox uiTextBoxToolTypeName;
        private Sunny.UI.UILabel uiLabelToolTypeName;
        private Sunny.UI.UIButton uiButtonSave;
        private Sunny.UI.UIButton uiButtonCancel;
        private Sunny.UI.UILabel uiLabelToolTypeSortOrder;
        private Sunny.UI.UITextBox uiTextBoxToolTypeSortOrder;
    }
}