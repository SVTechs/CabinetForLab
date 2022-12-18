using CabinetMgr.RtVars;
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
    public partial class FormSystemManage : Form
    {
        private Form _curForm;
        public Form _toolManageForm;
        public Form _userManageForm;

        public FormSystemManage()
        {
            InitializeComponent();
        }

        private void uiNavBar_MenuItemClick(string itemText, int menuIndex, int pageIndex)
        {
            switch (menuIndex)
            {
                case 0:
                    ShowWindow(_toolManageForm);
                    break;
                case 1:
                    ShowWindow(_userManageForm);
                    break;
            }
        }

        private void FormSystemManage_Load(object sender, EventArgs e)
        {
            //_toolManageForm = new FormToolManage();
            //AddToPanel(_toolManageForm);

            //_userManageForm = new FormUserManage();
            //AddToPanel(_userManageForm);

            ShowWindow(_toolManageForm);
        }

        public void AddToPanel(Form targetForm)
        {
            targetForm.TopLevel = false;
            targetForm.Width = panel.Width;
            targetForm.Height = panel.Height;
            panel.Controls.Add(targetForm);
        }

        public void ShowWindow(Form targetForm)
        {
            if (_curForm == targetForm)
            {
                return;
            }
            foreach (var form in panel.Controls)
            {
                var curForm = form as Form;
                if (curForm != null)
                {
                    FormVisible(false, curForm);
                }
            }
            _curForm = targetForm;
            FormVisible(true, targetForm);
        }

        private delegate void FormVisibleDelegate(bool visible, Form form);
        public void FormVisible(bool visible, Form form)
        {
            try
            {
                if (form.InvokeRequired)
                {
                    FormVisibleDelegate d = FormVisible;
                    form.Invoke(d, visible, form);
                }
                else
                {
                    if (visible)
                    {
                        form.Show();
                    }
                    else
                    {
                        form.Hide();
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void FormSystemManage_Shown(object sender, EventArgs e)
        {
            AppRt.FaceEnable = false;
            AppRt.FpEnable = false;
            AppRt.CardEnable = false;
        }

    }
}
