using CabinetMgr.Common;
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
    public partial class FormManage : Form
    {
        public FormManage()
        {
            InitializeComponent();
        }

        private void uiImageButtonViewLog_Click(object sender, EventArgs e)
        {
            AppRt.FormMain.ShowWindow(AppRt.FormMain._recordForm);
        }

        private void uiImageButtonMaintain_Click(object sender, EventArgs e)
        {
            if(AppRt.CurUser == null)
            {
                UIMessageBox.ShowError("请登录后进行维护");
                return;
            }
            if (AppRt.RoleSettings.FirstOrDefault(x => x.RoleId == PresetRole.Admin) == null)
            {
                UIMessageBox.ShowError("只有管理员可以维护");
                return;
            }
            AppRt.FormMain.ShowWindow(AppRt.FormMain._systemManage);
        }

    }
}
