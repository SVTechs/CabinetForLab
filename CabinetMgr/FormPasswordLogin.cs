using CabinetMgr.BLL;
using CabinetMgr.Common;
using Domain.Main.Domain;
using Hardware.DeviceInterface;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormPasswordLogin : Form
    {
        public static FormPasswordLogin formPasswordLogin;

        public static FormPasswordLogin Instance()
        {
            if (formPasswordLogin == null || formPasswordLogin.IsDisposed) formPasswordLogin = new FormPasswordLogin();
            return formPasswordLogin;
        }

        public FormPasswordLogin()
        {
            InitializeComponent();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void uiButtonLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(uiTextBoxUserName.Text.Trim()))
            {
                UIMessageBox.Show("请输入工号", true, true);
                return;
            }
            if (string.IsNullOrEmpty(uiTextBoxPassword.Text.Trim()))
            {
                UIMessageBox.Show("请输入密码", true, true);
                return;
            }
            UserInfo ui = BllUserInfo.Login(uiTextBoxUserName.Text.Trim(), uiTextBoxPassword.Text.Trim(), out _);
            if (ui == null)
            {
                UIMessageBox.ShowError("工号或密码错误", true, true);
                return;
            }
            FpCallBack.OnUserRecognised.Invoke(ui.TemplateId, 4);
            Dispose();
        }

        private void uiTextBoxUserName_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void uiTextBoxPassword_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void FormPasswordLogin_Click(object sender, EventArgs e)
        {
            Osk.HideInputPanel();
        }

        private void FormPasswordLogin_Shown(object sender, EventArgs e)
        {

        }

        private void FormPasswordLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Osk.HideInputPanel();
        }
    }
}
