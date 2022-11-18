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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetMgr
{
    public partial class FormToolManage1 : Form
    {
        private static string currentPage;// = "A";

        private static IList<LatticeInfo> latticeList;
        private static IList<ToolInfo> toolInfoList;
        private static IList<LatticeInfo> currentPageLatticeList;// = latticeList.Where(x => x.CabinetNum == cabinetNum)?.ToList();
        private static Color backColor = Color.FromArgb(187, 222, 10);


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


        public FormToolManage1()
        {
            InitializeComponent();
            FormCallback.FormToolManageRefresh += FormRefresh;

            ReloadData();
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
                TabPage tb = tabControl.TabPages[i];
                button.Click += PageButton_Click;
                button.Location = new Point(position[i, 0], position[i, 1]);
                if (i < pageList.Count)
                {
                    button.Visible = true;
                    button.Tag = pageList[i];
                    button.Text = pageList[i];
                    tb.Tag = pageList[i];
                }
                else
                {
                    button.Visible = false;
                    button.Tag = "";
                    button.Text = "";
                    tb.Tag = "";
                }
            }
        }

        private void InitControlAry()
        {
            foreach (TabPage tp in tabControl.TabPages)
            {
                string page = tp.Tag as string;
                int idx = int.Parse(tp.Text);
                if (string.IsNullOrEmpty(page)) continue;
                IList<LatticeInfo> currentPageLatticeList = latticeList.Where(x => x.CabinetNum == page)?.ToList();
                for (int i = 1; i <= 20; i++)
                {
                    LatticeInfo lattice = currentPageLatticeList.FirstOrDefault(x => x.CabinetLatticeNum == i.ToString("D2"));
                    ToolInfo tool = toolInfoList.FirstOrDefault(x => x.LatticeId == lattice?.Id);

                    Label lbl = tp.Controls.Find($"label{idx * 20 + i}", false)[0] as Label;
                    Panel pnl = tp.Controls.Find($"panel{idx * 20 + i}", false)[0] as Panel;
                    pnl.Paint += PanelOnPaint;
                    pnl.Click += Panel_Click;

                    if (lattice == null)
                    {
                        SetLabel(lbl, false, "", Color.White);
                        SetPanel(pnl, false, null, backColor);
                        continue;
                    }

                    SetLabel(lbl, true, currentPage + i.ToString("D2"), Color.White);

                    if (tool == null)
                    {
                        SetPanel(pnl, true, currentPage + i.ToString("D2") + "||" + lattice.Id, backColor);
                    }
                    else
                    {
                        SetPanel(pnl, true, currentPage + i.ToString("D2") + "|" + tool.Id + "|" + lattice.Id, backColor);
                    }
                    PanelRefresh(pnl);
                }
            }

        }

        private void FormToolManage_Shown(object sender, EventArgs e)
        {
            //ReloadData();
            //LoadPage(currentPage);
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
            (AppRt.FormLog as FormLog).AddLine(panel.Tag as string);
            FormToolEdit formToolEdit = FormToolEdit.Instance(panel.Tag as string);
            formToolEdit.ShowDialog();
            //ReloadData();
            //LoadPage(currentPage);
        }


        public void LoadPage(string cabinetNum = "")
        {
            if (string.IsNullOrEmpty(cabinetNum)) cabinetNum = currentPage;

            Thread t = new Thread(new ParameterizedThreadStart(RefreshControl));
            t.Start(cabinetNum);

        }

        private void RefreshControl(object cabinetPage)
        {
            string cabinetNum = cabinetPage as string;
            IList<LatticeInfo> currentPageLatticeList = latticeList.Where(x => x.CabinetNum == cabinetNum)?.ToList();
            TabPage page = new TabPage();
            int idx = 0;
            foreach (TabPage tp in tabControl.TabPages)
            {
                if (string.IsNullOrEmpty(tp.Tag as string)) continue;
                if (tp.Tag as string == cabinetNum)
                {
                    page = tp;
                    idx = int.Parse(tp.Text);
                    break;
                }
            }
            for (int i = 1; i <= 20; i++)
            {
                Color c = Color.White;
                LatticeInfo lattice = currentPageLatticeList.FirstOrDefault(x => x.CabinetLatticeNum == i.ToString("D2"));
                if (lattice == null) continue;
                ToolInfo tool = toolInfoList.FirstOrDefault(x => x.LatticeId == lattice?.Id);

                Label lbl = page.Controls.Find($"label{idx * 20 + i}", false)[0] as Label;
                Panel pnl = page.Controls.Find($"panel{idx * 20 + i}", false)[0] as Panel;


                SetLabel(lbl, true, currentPage + i.ToString("D2"), Color.White);

                if (tool == null)
                {
                    SetPanel(pnl, true, currentPage + i.ToString("D2") + "||" + lattice.Id, backColor);
                }
                else
                {
                    SetPanel(pnl, true, currentPage + i.ToString("D2") + "|" + tool.Id + "|" + lattice.Id, backColor);
                }
                PanelRefresh(pnl);
            }
            TabPageSelect(page);
        }

        private void PanelOnPaint(object sender, PaintEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (string.IsNullOrEmpty(pnl.Tag as string)) return;
            string toolId = (pnl.Tag as string).Split('|')[1];
            if (string.IsNullOrEmpty(toolId)) return;
            ToolInfo toolInfo = toolInfoList.FirstOrDefault(x => x.Id == toolId);
            if (toolInfo == null) return;
            Color defaultColor = Color.White;
            Color notFullColor = Color.FromArgb(0, 188, 212);
            string toolName = toolInfo.ToolName;
            int currentCount = toolInfo.CurrentCount;
            int count = toolInfo.ToolCount;
            Font drawFont = new Font("HarmonyOS Sans SC", 20, FontStyle.Regular);
            SolidBrush defaultBrush = new SolidBrush(defaultColor);
            SolidBrush notFullBrush = new SolidBrush(notFullColor);
            StringFormat drawFormat = new StringFormat();
            SizeF textSize = e.Graphics.MeasureString(toolName, drawFont);//文本的矩形区域大小   
            int fHeight = drawFont.Height;
            float nameh = (pnl.Size.Height - fHeight) / 2;
            float currentCounth = 20f;
            float currentCountw = pnl.Size.Width - 60;

            e.Graphics.DrawString(toolName, drawFont, defaultBrush, 0, nameh);
            e.Graphics.DrawString(currentCount.ToString(), drawFont, currentCount < count ? notFullBrush : defaultBrush,
                Convert.ToInt16(currentCountw), Convert.ToInt16(currentCounth), drawFormat);
            e.Graphics.DrawString("___", drawFont, defaultBrush, Convert.ToInt16(currentCountw - 3), Convert.ToInt16(currentCounth + 5), drawFormat);
            e.Graphics.DrawString(count.ToString(), drawFont, defaultBrush, Convert.ToInt16(currentCountw), Convert.ToInt16(currentCounth + FontHeight + 20), drawFormat);
        }

        #region ControlDelegate

        private delegate void SetLableDelegate(Label label, bool visible, string labelText, Color foreColor);
        private void SetLabel(Label label, bool visible, string labelText, Color foreColor)
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

        private delegate void SetPanelDelegate(Panel panel, bool visible, string toolId, Color backColor);
        private void SetPanel(Panel panel, bool visible, string toolId, Color backColor)
        {
            if (panel.InvokeRequired)
            {
                SetPanelDelegate d = SetPanel;
                panel.Invoke(d, panel, visible, toolId, backColor);
            }
            else
            {
                panel.Visible = visible;
                panel.Tag = toolId;
                panel.BackColor = backColor;
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

        private delegate void PanelRefreshDelegate(Panel pnl);
        private void PanelRefresh(Panel pnl)
        {
            if (pnl.InvokeRequired)
            {
                PanelRefreshDelegate d = PanelRefresh;
                pnl.Invoke(d, pnl);
            }
            else
            {
                pnl.Refresh();
            }
        }

        private delegate void TabPageSelectDelegate(TabPage page);
        private void TabPageSelect(TabPage page)
        {
            if (tabControl.InvokeRequired)
            {
                TabPageSelectDelegate d = TabPageSelect;
                tabControl.Invoke(d, page);
            }
            else
            {
                tabControl.SelectedTab = page;
            }
        }

        #endregion

        private void FormRefresh()
        {
            ReloadData();
            LoadPage(currentPage);
        }

        public void ReloadData()
        {
            latticeList = BllLatticeInfo.SearchLatticeInfo(0, -1, null, out _);
            toolInfoList = BllToolInfo.SearchToolInfo("", 0, -1, null, out _);
        }

        private void FormToolManage0_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) FormRefresh();
        }
    }
}
