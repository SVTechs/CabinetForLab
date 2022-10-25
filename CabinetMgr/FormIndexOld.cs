using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.RtVars;
using Domain.Main.Domain;
using Hardware.DeviceInterface;
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
    public partial class FormIndexOld : UIForm
    {
        private static int pageCount;
        private static int pageIdx = 0;
        private IList<DoorInfo> doorList;
        private IList<LatticeInfo> searchedLattice;
        private static readonly Color defaultColor = Color.FromArgb(80, 160, 255);
        private static readonly Color openedColor = Color.Orange;
        private static readonly Color searchedColor = Color.Green;
        private static readonly Color hoverColor = Color.Green;
        private static readonly Color normalColor = Color.FromArgb(80, 160, 255);
        private static IList<LatticeInfo> latticeList;
        private static IList<ToolInfo> toolInfoList;
        public FormIndexOld()
        {
            InitializeComponent();
            InitPageButton();
            CabinetServerCallback.DoorStatusChange += DoorStatusChange;
        }

        private void InitPageButton()
        {
            doorList = CabinetServer.GetDoorList();
            pageCount = (int)Math.Ceiling((double)doorList.Count / 12);
            int buttonInterval = (int)Math.Floor((double)(panelPage.Width - 220) / (pageCount + 1));
            int buttonHeight = (int)Math.Floor((double)panelPage.Height / 2);
            for (int i = 0; i < pageCount; i++)
            {
                UIButton button = new UIButton();
                button.Font = new Font("Microsoft YaHei", 25);
                button.Location = new Point(110 + (i + 1) * buttonInterval - 30, buttonHeight - 30);
                button.Text = (i + 1).ToString();
                button.Tag = i;
                button.Size = new Size(60, 60);
                button.Radius = 60;
                button.Click += PageButton_Click;
                
                panelPage.Controls.Add(button);
            }
        }

        private void PageButton_Click(object sender, EventArgs e)
        {
            UIButton btn = sender as UIButton;
            pageIdx = (int)btn.Tag;
            LoadCurrentPage();
        }

        public void LoadCurrentPage()
        {
            ResetPageButton();
            ResetDoorButton();
            List<DoorInfo> currentPageList = doorList.Skip(pageIdx * 12).Take(12).ToList();
            for (int i = 0; i < currentPageList.Count; i++) 
            {
                DoorInfo info = currentPageList[i];
                UIButton button = panelDoorContainer.Controls.Find($"UIButton{i + 1}", false)[0] as UIButton;
                DoorButtonSet(button, info);
            }
        }

        private void ResetPageButton()
        {
            foreach (Control ctl in panelPage.Controls)
            {
                UIButton button = ctl as UIButton;
                PageButtonSet(button, pageIdx);
            }
        }

        private void ResetDoorButton()
        {
            foreach(Control ctl in panelDoorContainer.Controls)
            {
                UIButton button = ctl as UIButton;
                DoorButtonReset(button);
            }
        }

        public void ReloadData()
        {
            latticeList = BllLatticeInfo.SearchLatticeInfo(0, -1, null, out _);
            toolInfoList = BllToolInfo.SearchToolInfo("", 0, -1, null, out _);
        }

        
        private void DoorStatusChange(int id, int nch)
        {
            DoorInfo di = doorList.First(x => x.Id == id && x.Nch == nch);
            di.IsClosed = !di.IsClosed;
            LoadCurrentPage();
        }

        private delegate void DoorButtonSetDelegate(UIButton button, DoorInfo info);
        public void DoorButtonSet(UIButton button, DoorInfo info)
        {
            try
            {
                if (button.InvokeRequired)
                {
                    DoorButtonSetDelegate d = DoorButtonSet;
                    button.Invoke(d, button, info);
                }
                else
                {
                    ToolInfo toolInfo = null;
                    LatticeInfo lattice = latticeList.FirstOrDefault(x => x.Channel == info.Id.ToString() && x.BoardId == info.Nch.ToString());
                    if(lattice != null) toolInfo = toolInfoList.FirstOrDefault(x => x.LatticeId == lattice.Id);
                    button.Text = info.Id + "-" + info.Nch + (toolInfo != null ?"   " + toolInfo.CurrentCount + "/" + toolInfo.ToolCount + "\n" + toolInfo.ToolName : "");
                    button.FillColor = info.IsClosed ? defaultColor : openedColor;
                    button.Visible = true;
                    button.Tag = info.Id + "|" + info.Nch;
                    if(searchedLattice.FirstOrDefault(x => int.Parse(x.Channel) == info.Id && int.Parse(x.BoardId)== info.Nch) != null)
                    {
                        button.FillColor = searchedColor;
                    }
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private delegate void DoorButtonResetDelegate(UIButton button);

        public void PageButtonSet(UIButton button, int currentPage)
        {
            try
            {
                if (button.InvokeRequired)
                {
                    PageButtonSetDelegate d = PageButtonSet;
                    button.Invoke(d, button, currentPage);
                }
                else
                {
                    if ((int)button.Tag == currentPage) button.Selected = true;
                    else button.Selected = false;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }
        private delegate void PageButtonSetDelegate(UIButton button, int currentPage);

        public void DoorButtonReset(UIButton button)
        {
            try
            {
                if (button.InvokeRequired)
                {
                    DoorButtonResetDelegate d = DoorButtonReset;
                    button.Invoke(d, button);
                }
                else
                {
                    button.Tag = null;
                    button.Visible = false;
                    button.FillColor = defaultColor;
                }
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in panelDoorContainer.Controls)
            {
                UIButton button = ctl as UIButton;
                button.Click += DoorButton_Click;
            }
        }

        private void DoorButton_Click(object sender, EventArgs e)
        {
            if(AppRt.CurUser == null)
            {
                UIMessageBox.Show("请先登录");
                return;
            }
            UIButton btn = sender as UIButton;
            string tagValue = btn.Tag as string;
            int id = int.Parse(tagValue.Split('|')[0]);
            int nch = int.Parse(tagValue.Split('|')[1]);
            if(AppRt.LatticeList.FirstOrDefault(x => x.Channel == id.ToString() && x.BoardId == nch.ToString()) == null)
            {
                UIMessageBox.Show("您没有该储物格权限");
                return;
            }
            CabinetServer.OpenDoors(id, nch);
        }

        private void uiTextBoxToolName_Enter(object sender, EventArgs e)
        {
            Osk.ShowInputPanel();
        }

        private void uiTextBoxToolName_Leave(object sender, EventArgs e)
        {
            Osk.HideInputPanel();
        }

        private void uiSymbolButtonSearch_Click(object sender, EventArgs e)
        {
            string searchToolName = string.IsNullOrEmpty(uiTextBoxToolName.Text.Trim())? "¿": uiTextBoxToolName.Text.Trim();
            IList<ToolInfo> toolList = BllToolInfo.SearchToolInfo(searchToolName, 0,-1, null, out Exception ex);
            long[] idAry = toolList.Select(x => x.LatticeId).ToArray();
            IList<LatticeInfo> latticeList = BllLatticeInfo.SearchLatticeInfo(idAry, out ex);
            searchedLattice = latticeList;
            LoadCurrentPage();
        }

        private void FormIndex_Shown(object sender, EventArgs e)
        {
            ReloadData();
            LoadCurrentPage();
        }
    }
}
