using CabinetMgr.BLL;
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
    public partial class FormIndex : UIForm
    {
        private static string currentPage = "A";
        private static readonly Color notFullColor = Color.FromArgb(0, 188, 212);

        private IList<DoorInfo> doorList;
        private static IList<LatticeInfo> latticeList;
        private static IList<ToolInfo> toolInfoList;

        public FormIndex()
        {
            InitializeComponent();
            CabinetServerCallback.DoorStatusChange += DoorStatusChange;
            foreach (Control ctl in panelPage.Controls)
            {
                UIImageButton button = ctl as UIImageButton;
                button.Click += PageButton_Click;
            }
            for (int i = 1; i <= 20; i++)
            {
                Panel panel = Controls.Find("panel" + i.ToString("D2"), false)[0] as Panel;
                panel.Click += Panel_Click;
            }
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {

        }

        private void FormIndex_Shown(object sender, EventArgs e)
        {
            ReloadData();
            LoadPage(currentPage);
        }

        private void PageButton_Click(object sender, EventArgs e)
        {
            UIImageButton btn = sender as UIImageButton;
            string tagValue = btn.Tag as string;
            currentPage = tagValue;
            LoadPage(currentPage);
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (string.IsNullOrEmpty(panel.Tag as string)) return;
            FormOperateTool formOperateTool = FormOperateTool.Instance(panel.Tag as string);
            formOperateTool.ShowDialog();
        }

        public void LoadPage(string cabinetNum)
        {
            IList<LatticeInfo> currentPageLatticeList = latticeList.Where(x => x.CabinetNum == cabinetNum)?.ToList();
            for(int i = 1; i <= 20; i++)
            {
                UILabel lbl = Controls.Find("uiLabel" + i.ToString("D2"), false)[0] as UILabel;
                Panel pnl = Controls.Find("panel" + i.ToString("D2"), false)[0] as Panel;

                LatticeInfo lattice = currentPageLatticeList.FirstOrDefault(x => x.CabinetLatticeNum == i.ToString("D2"));
                if (lattice == null)
                {
                    SetLabel(lbl, false, currentPage + i.ToString("D2"), Color.White);
                    SetPanel(pnl, false, null);
                    continue;
                }
                DoorInfo door = doorList.FirstOrDefault(x => x.Id.ToString() == lattice.Channel && x.Nch.ToString() == lattice.BoardId);
                if (door == null)
                {
                    SetLabel(lbl, false, currentPage + i.ToString("D2"), Color.Orange);
                    SetPanel(pnl, false, null);
                    continue;
                }
                SetLabel(lbl, true, currentPage + i.ToString("D2"), Color.White);
                SetPanel(pnl, true, null);
                UILabel toolName = pnl.Controls.Find("uiTextBox" + i.ToString("D2"), false)[0] as UILabel;
                UILabel currentAmount = pnl.Controls.Find($"uiTextBox{i.ToString("D2")}CurrentAmount", false)[0] as UILabel;
                UILabel setAmount = pnl.Controls.Find($"uiTextBox{i.ToString("D2")}SetAmount", false)[0] as UILabel;
                PictureBox pictureBox = pnl.Controls.Find($"pictureBox{i.ToString("D2")}", false)[0] as PictureBox;
                ToolInfo tool = toolInfoList.FirstOrDefault(x => x.LatticeId == lattice.Id);
                if(tool == null)
                {
                    SetLabel(toolName, false, "", Color.White);
                    SetLabel(currentAmount, false, "", Color.White);
                    SetLabel(setAmount, false, "", Color.White);
                    SetPicture(pictureBox, false);
                    continue;
                }
                SetLabel(toolName, true, tool.ToolName, Color.White);
                SetLabel(currentAmount, true, tool.CurrentCount.ToString(), Color.White);
                SetLabel(setAmount, true, tool.ToolCount.ToString(), Color.White);
                SetPicture(pictureBox, true);
                SetPanel(pnl, true, currentPage + i.ToString("D2") + "|" + tool.Id);
            }
            
        }

        #region ControlDelegate

        private delegate void SetLableDelegate(UILabel label, bool visible, string labelText, Color foreColor);
        private void SetLabel(UILabel label, bool visible, string labelText, Color foreColor)
        {
            if (label.InvokeRequired)
            {
                SetLableDelegate d = SetLabel;
                label.Invoke(d, label, visible, labelText);
            }
            else
            {
                label.Visible = visible;
                label.Text = labelText;
            }
        }

        private delegate void SetPanelDelegate(Panel panel, bool visible, string toolId);
        private void SetPanel(Panel panel, bool visible, string toolId)
        {
            if (panel.InvokeRequired)
            {
                SetPanelDelegate d = SetPanel;
                panel.Invoke(d, panel, visible, toolId);
            }
            else
            {
                panel.Visible = visible;
                panel.Tag = toolId;
            }
        }
        private delegate void SetPictureDelegate(PictureBox pictureBox, bool visible);
        private void SetPicture(PictureBox pictureBox, bool visible)
        {
            if (pictureBox.InvokeRequired)
            {
                SetPictureDelegate d = SetPicture;
                pictureBox.Invoke(d, pictureBox, visible);
            }
            else
            {
                pictureBox.Visible = visible;
            }
        }


        private delegate void DisplayUserDelegate(string userText);
        public void DisplayUser(string userText)
        {
            if (uiLabelUserName.InvokeRequired)
            {
                DisplayUserDelegate d = DisplayUser;
                uiLabelUserName.Invoke(d, userText);
            }
            uiLabelUserName.Text = userText;
        }

        #endregion

        public void ReloadData()
        {
            doorList = CabinetServer.GetDoorList();
            latticeList = BllLatticeInfo.SearchLatticeInfo(0, -1, null, out _);
            toolInfoList = BllToolInfo.SearchToolInfo("", 0, -1, null, out _);
        }
        private void DoorStatusChange(int id, int nch)
        {
            DoorInfo di = doorList.First(x => x.Id == id && x.Nch == nch);
            di.IsClosed = !di.IsClosed;
            LoadPage(currentPage);
        }

        private void uiLabelUserName_Click(object sender, EventArgs e)
        {
            AppRt.FormMain.PerformManualLogin();
        }
    }
}
