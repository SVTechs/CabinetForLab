using CabinetMgr.BLL;
using Domain.Main.Domain;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormToolTypeEditOld : UIForm
    {
        public static FormToolTypeEditOld formToolTypeEdit;
        public static long toolTypeId;

        public static FormToolTypeEditOld Instance(string formTitle = "新建类型")
        {
            if (formToolTypeEdit == null || formToolTypeEdit.IsDisposed) formToolTypeEdit = new FormToolTypeEditOld();
            formToolTypeEdit.Text = formTitle;
            return formToolTypeEdit;
        }

        public FormToolTypeEditOld()
        {
            InitializeComponent();
        }

        private void FormToolTypeEdit_Load(object sender, EventArgs e)
        {

        }

        private void FormToolTypeEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hide();
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(uiTextBoxToolTypeName.Text.Trim()))
            {
                UIMessageBox.Show("工具类型名称不能为空");
                return;
            }
            int result = -1;
            if (string.IsNullOrEmpty(uiTextBoxToolTypeId.Text)) result = AddToolType();
            else result = UpdateToolType();
            if (result > 0)
            {
                FormReset();
                Hide();
            }
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            FormReset();
            Hide();
        }

        private int AddToolType()
        {
            ToolType toolType = new ToolType()
            {
                TypeName = uiTextBoxToolTypeName.Text.Trim(),
                SortOrder = int.Parse(uiTextBoxToolTypeSortOrder.Text),
                CreateTime = DateTime.Now
            };
            int result = BllToolType.SaveToolType(toolType, out Exception ex);
            if(result <= 0)
            {
                UIMessageBox.Show($"保存失败，原因为{ex.Message}");
                return- 1;
            }
            return result;
        }

        private int UpdateToolType()
        {
            ToolType toolType = BllToolType.GetToolType(long.Parse(uiTextBoxToolTypeId.Text), out Exception ex);
            toolType.TypeName = uiTextBoxToolTypeName.Text.Trim();
            toolType.SortOrder = int.Parse(uiTextBoxToolTypeSortOrder.Text);
            int result = BllToolType.UpdateToolType(toolType, out ex);
            if (result <= 0)
            {
                UIMessageBox.Show($"保存失败，原因为{ex.Message}");
                return -1;
            }
            return result;
        }

        public void LoadData(long id)
        {
            ToolType toolType = BllToolType.GetToolType(id, out _);
            uiTextBoxToolTypeId.Text = id.ToString();
            uiTextBoxToolTypeName.Text = toolType.TypeName;
            uiTextBoxToolTypeSortOrder.Text = toolType.SortOrder.ToString();

        }

        private void FormReset()
        {
            uiTextBoxToolTypeId.Text = "";
            uiTextBoxToolTypeName.Text = "";
            uiTextBoxToolTypeSortOrder.Text = "0";
        }
    }
}
