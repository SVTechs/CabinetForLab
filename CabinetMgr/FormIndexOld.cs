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
        private static string currentPage;// = "A";
        private static readonly Color notFullColor = Color.FromArgb(0, 188, 212);

        private IList<DoorInfo> doorList;
        private static IList<LatticeInfo> latticeList;
        private static IList<ToolInfo> toolInfoList;

        private readonly float[,,] btnPositions =
{
                //1
                { { 0.5f, 0.5f }, { 0f, 0f }, { 0f, 0f }, { 0f, 0f },
                { 0f, 0f }, { 0f, 0f }, { 0f, 0f }, { 0f, 0f }  },
                //2
                { { 0.3f, 0.5f }, { 0.6f, 0.5f } , { 0f, 0f }, { 0f, 0f },
                { 0f, 0f }, { 0f, 0f }, { 0f, 0f }, { 0f, 0f } },
                //3
                { { 0.25f, 0.5f }, { 0.5f, 0.5f }, { 0.75f, 0.5f }, { 0f, 0f },
                { 0f, 0f }, { 0f, 0f }, { 0f, 0f }, { 0f, 0f } },
                //4
                { { 0.2f, 0.5f }, { 0.4f, 0.5f }, { 0.6f, 0.5f }, { 0.8f, 0.5f },
                { 0f, 0f }, { 0f, 0f }, { 0f, 0f }, { 0f, 0f } },
                //5   
                { { 0.16f, 0.5f }, { 0.32f, 0.5f }, { 0.48f, 0.5f }, { 0.64f, 0.5f },
                { 0.8f, 0.5f }, { 0f, 0f }, { 0f, 0f }, { 0f, 0f } },
                //6
                { { 0.14f, 0.5f }, { 0.28f, 0.5f }, { 0.42f, 0.5f }, { 0.56f, 0.5f },
                { 0.7f, 0.5f }, { 0.84f, 0.5f }, { 0f, 0f }, { 0f, 0f } },
                //7       
                { { 0.125f, 0.5f }, { 0.25f, 0.5f }, { 0.375f, 0.5f }, { 0.5f, 0.5f },
                { 0.625f, 0.5f }, { 0.75f, 0.5f }, { 0.875f, 0.5f }, { 0f, 0f } },
                //8
                { { 0.11f, 0.5f }, { 0.22f, 0.5f }, { 0.33f, 0.5f }, { 0.44f, 0.5f },
                { 0.55f, 0.5f }, { 0.66f, 0.5f }, { 0.77f, 0.5f }, { 0.88f, 0.5f } },
        };

        private readonly UILabel[] lblList = new UILabel[20];
        private readonly Panel[] pnlList = new Panel[20];
        private readonly UILabel[] tbList = new UILabel[20];
        private readonly UILabel[] currentAmountlList = new UILabel[20];
        private readonly PictureBox[] pblList = new PictureBox[20];
        private readonly UILabel[] setAmountlList = new UILabel[20];

        public FormIndexOld()
        {
            InitializeComponent();
            CabinetServerCallback.DoorStatusChange += DoorStatusChange;

            for (int i = 1; i <= 20; i++)
            {
                Panel panel = Controls.Find("panel" + i.ToString("D2"), false)[0] as Panel;
                panel.Click += Panel_Click;
            }

            InitPageButton();
            InitControlAry();
        }

        private int[,] GetButtonPosition(int itemCount, int panelWidth, int panelHeight,
    int iconWidth, int iconHeight)
        {
            int[,] position = new int[8, 2];
            for (int i = 0; i < itemCount; i++)
            {
                position[i, 0] = (int)(btnPositions[itemCount - 1, i, 0] * panelWidth - iconWidth / 2.0);
                position[i, 1] = (int)(btnPositions[itemCount - 1, i, 1] * panelHeight - iconHeight / 2.0);
            }
            return position;
        }

        private void InitPageButton()
        {
            IList<string> pageList = BllLatticeInfo.GetPageList(out _);
            if (pageList == null) pageList = new List<string>();
            currentPage = pageList.Count == 0 ? "" : pageList[0];
            int[,] position = GetButtonPosition(pageList.Count, panelPage.Width, panelPage.Height, 88, 88);
            for (int i = 0; i < 8; i++)
            {
                UIImageButton button = panelPage.Controls[i] as UIImageButton;
                button.Click += PageButton_Click;
                button.Location = new Point(position[i, 0], position[i, 1]);
                if (i < pageList.Count)
                {
                    button.Visible = true;
                    button.Tag = pageList[i];
                    button.Text = pageList[i];
                }
                else
                {
                    button.Visible = false;
                    button.Tag = "";
                    button.Text = "";
                }
            }
        }

        private void InitControlAry()
        {
            for (int i = 1; i <= 20; i++)
            {
                UILabel lbl = Controls.Find("uiLabel" + i.ToString("D2"), false)[0] as UILabel;
                Panel pnl = Controls.Find("panel" + i.ToString("D2"), false)[0] as Panel;
                UILabel toolName = pnl.Controls.Find("uiTextBox" + i.ToString("D2"), false)[0] as UILabel;
                UILabel currentAmount = pnl.Controls.Find($"uiTextBox{i.ToString("D2")}CurrentAmount", false)[0] as UILabel;
                UILabel setAmount = pnl.Controls.Find($"uiTextBox{i.ToString("D2")}SetAmount", false)[0] as UILabel;
                PictureBox pictureBox = pnl.Controls.Find($"pictureBox{i.ToString("D2")}", false)[0] as PictureBox;

                lblList[i - 1] = lbl;
                pnlList[i - 1] = pnl;
                tbList[i - 1] = toolName;
                currentAmountlList[i - 1] = currentAmount;
                setAmountlList[i - 1] = setAmount;
                pblList[i - 1] = pictureBox;

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
            string toolId = (panel.Tag as string).Split('|')[1];
            ToolInfo ti = AppRt.ToolList.FirstOrDefault(x => x.Id == toolId);
            if (ti == null)
            {
                UIMessageBox.Show("您没有借取该工具的权限");
                return;
            }
            long latticeId = long.Parse((panel.Tag as string).Split('|')[2]);
            LatticeInfo lattice = latticeList.FirstOrDefault(x => x.Id == latticeId);
            CabinetServer.OpenDoors(int.Parse(lattice.Channel), int.Parse(lattice.BoardId));
            FormOperateTool formOperateTool = FormOperateTool.Instance(panel.Tag as string);
            formOperateTool.ShowDialog();
            ReloadData();
            LoadPage(currentPage);
        }

        public void LoadPage(string cabinetNum = "")
        {
            if (string.IsNullOrEmpty(cabinetNum)) cabinetNum = currentPage;
            IList<LatticeInfo> currentPageLatticeList = latticeList.Where(x => x.CabinetNum == cabinetNum)?.ToList();
            for (int i = 1; i <= 20; i++)
            {
                Color c = Color.White;
                LatticeInfo lattice = currentPageLatticeList.FirstOrDefault(x => x.CabinetLatticeNum == i.ToString("D2"));
                DoorInfo door = doorList.FirstOrDefault(x => x.Id.ToString() == lattice?.Channel && x.Nch.ToString() == lattice?.BoardId);
                ToolInfo tool = toolInfoList.FirstOrDefault(x => x.LatticeId == lattice?.Id);

                UILabel lbl = lblList[i - 1];
                Panel pnl = pnlList[i - 1];

                if (lattice == null)
                {
                    SetLabel(lbl, false, "", Color.White);
                    SetPanel(pnl, false, null);
                    continue;
                }

                if (door == null)
                {
                    SetLabel(lbl, false, "", Color.White);
                    SetPanel(pnl, false, null);
                    continue;
                }
                SetLabel(lbl, true, currentPage + i.ToString("D2"), Color.White);

                UILabel toolName = tbList[i - 1];
                UILabel currentAmount = currentAmountlList[i - 1];
                UILabel setAmount = setAmountlList[i - 1];
                PictureBox pictureBox = pblList[i - 1];

                if (tool == null)
                {
                    SetLabel(toolName, false, "", Color.White);
                    SetLabel(currentAmount, false, "", Color.White);
                    SetLabel(setAmount, false, "", Color.White);
                    SetPicture(pictureBox, false);
                    SetPanel(pnl, true, null);
                    continue;
                }
                SetLabel(toolName, true, tool.ToolName, Color.White);
                if (tool.CurrentCount != tool.ToolCount) c = notFullColor;
                SetLabel(currentAmount, true, tool.CurrentCount.ToString(), c);
                SetLabel(setAmount, true, tool.ToolCount.ToString(), Color.White);
                SetPicture(pictureBox, true);
                SetPanel(pnl, true, currentPage + i.ToString("D2") + "|" + tool.Id + "|" + lattice.Id);
            }

        }

        #region ControlDelegate

        private delegate void SetLableDelegate(UILabel label, bool visible, string labelText, Color foreColor);
        private void SetLabel(UILabel label, bool visible, string labelText, Color foreColor)
        {
            if (label.InvokeRequired)
            {
                SetLableDelegate d = SetLabel;
                label.Invoke(d, label, visible, labelText, foreColor);
            }
            else
            {
                label.Visible = visible;
                label.Text = labelText;
                label.ForeColor = foreColor;
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
            toolInfoList = BllToolInfo.SearchToolInfo("", 0, -1, null, out _);
            LoadPage(currentPage);
        }

        private void uiLabelUserName_Click(object sender, EventArgs e)
        {
            AppRt.BackToLoginForm(true);
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            AppRt.BackToLoginForm(false);
        }
    }
}
