using CabinetMgr.BLL;
using CabinetMgr.Common;
using CabinetMgr.RtVars;
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
    public partial class FormToolEdit : Form
    {
        private static FormToolEdit formToolEdit;
        private static string _toolId;
        private static string _position;
        private static long _latticeId;
        private static IList<ListItem> warnTypeList = new List<ListItem>() { 
            new ListItem() { Text = "领用超时", Value = 0 }, new ListItem() { Text = "领用超量", Value = 1 } };

        public static FormToolEdit Instance(string inputValue)
        {
            if (formToolEdit == null || formToolEdit.IsDisposed) formToolEdit = new FormToolEdit();
            if (!string.IsNullOrEmpty(inputValue))
            {
                _toolId = inputValue?.Split('|')[1];
                _position = inputValue?.Split('|')[0];
                _latticeId = long.Parse(inputValue?.Split('|')[2]);
            }
            return formToolEdit;
        }

        public FormToolEdit()
        {
            InitializeComponent();
            LoadRoleData();
            uiComboBoxWarnType.DataSource = warnTypeList;
            uiComboBoxWarnType.ValueMember = "Value";
            uiComboBoxWarnType.DisplayMember = "Text";
        }

        private void LoadRoleData()
        {
            uiComboTreeViewRole.Nodes.Clear();
            var node = TreeManager.GetRoleNode();
            IList<ToolSettings> toolSettings = BllToolSettings.SearchToolSettings(_toolId, 0, -1, null, out _);
            foreach (RoleInfo ri in node.TreeChildren)
            {
                ToolSettings ts = toolSettings.FirstOrDefault(x => x.OwnerId == ri.Id);
                TreeNode tn = new TreeNode()
                {
                    Text = ri.RoleName,
                    Tag = ri.Id,
                    Checked = ts != null
                };
                uiComboTreeViewRole.Nodes.Add(tn);
            }
        }

        private void FormToolEdit_Shown(object sender, EventArgs e)
        {
            uiLabelTitle.Text = $"当前选择  {_position}";
            if (string.IsNullOrEmpty(_toolId)) return;
            ToolInfo toolInfo = BllToolInfo.GetToolInfo(_toolId, out _);
            IList<ToolSettings> toolSettings = BllToolSettings.SearchToolSettings(toolInfo.Id, 0, -1, null, out _);
            foreach(TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                ToolSettings ts = toolSettings.FirstOrDefault(x => x.OwnerId == tn.Tag as string);
                if (ts != null)
                {
                    tn.Checked = true;
                    uiComboTreeViewRole.Text += tn.Text + ";";
                }
            }
            uiComboTreeViewRole.Refresh();
            uiTextBoxToolName.Text = toolInfo.ToolName;
            uiTextBoxToolCount.Text = toolInfo.ToolCount.ToString();
            uiComboBoxWarnType.SelectedValue = toolInfo.WarnType;
            uiTextBoxWarnValue.Text = toolInfo.WarnValue.ToString();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            //ClearInputData();
            Hide();
        }

        private void ClearInputData()
        {
            uiTextBoxToolName.Text = "";
            uiTextBoxToolCount.Text = "0";
            foreach (TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                tn.Checked = false;
            }
            uiComboTreeViewRole.Text = "";
            uiComboBoxWarnType.SelectedIndex = -1;
            uiTextBoxWarnValue.Text = "0";
            _toolId = "";
            _position = "";
            _latticeId = -1;
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uiTextBoxToolName.Text))
            {
                UIMessageBox.ShowError("请填写工具规格");
                return;
            }
            if (uiComboBoxWarnType.SelectedItem == null)
            {
                UIMessageBox.ShowError("请选择告警阈值");
                return;
            }
            //if (string.IsNullOrEmpty(_toolId)) result = InsertToolInfo();
            //else result = UpdateToolInfo();
            //if (result < 0) return;
            ToolInfo ti = new ToolInfo()
            {
                Id = Guid.NewGuid().ToString(),
                ToolName = uiTextBoxToolName.Text.Trim(),
                ToolCount = int.Parse(uiTextBoxToolCount.Text),
                CurrentCount = int.Parse(uiTextBoxToolCount.Text),
                WarnType = (int)uiComboBoxWarnType.SelectedValue,
                WarnValue = int.Parse(uiTextBoxWarnValue.Text),
                OperateTime = DateTime.Now,
                Operator = AppRt.CurUser.ID,
                OperatorName = AppRt.CurUser.FullName,
            };

            IList<ToolSettings> toolSettings = new List<ToolSettings>();
            foreach (TreeNode tn in uiComboTreeViewRole.Nodes)
            {
                if (!tn.Checked) continue;
                ToolSettings ts = new ToolSettings()
                {
                    Id = Guid.NewGuid().ToString().ToUpper(),
                    OwnerId = tn.Tag as string,
                    OwnerType = "Role",
                    ToolId = ti.Id,
                    AddTime = DateTime.Now
                };
                toolSettings.Add(ts);
            }

            AppRt.Tasks.Add(DbExecute(_toolId, _latticeId, ti, toolSettings));
            Hide();
        }

        private Task DbExecute(string toolId, long latticeId, ToolInfo ti, IList<ToolSettings> toolSettings)
        {
            var task = Task.Factory.StartNew(() => {

                LatticeInfo lattice = BllLatticeInfo.GetLatticeInfo(latticeId, out _);
                ti.LatticeId = lattice.Id;
                ti.LatticePosition = lattice.LatticePosition;

                int result = -1;
                if (string.IsNullOrEmpty(toolId)) result = InsertToolInfo(ti, toolSettings);
                else result = UpdateToolInfo(toolId, ti, toolSettings);
                if (result < 0)
                {
                    //UIMessageBox.ShowError($"保存失败");
                }
                //result = BllToolSettings.BatchSaveToolSettings(ti.Id, toolSettings, out _);
                //if (result < 0)
                //{
                //    UIMessageBox.ShowError($"保存失败，原因：\n{ex.Message}");
                //    return -1;
                //}
                //return result;

                FormCallback.FormToolManageRefresh.Invoke();

            }, TaskCreationOptions.LongRunning);
            return task;
        }

        private int InsertToolInfo(ToolInfo ti, IList<ToolSettings> toolSettings)
        {
            //LatticeInfo lattice = BllLatticeInfo.GetLatticeInfo(latticeId, out _);
            //ti.LatticeId = lattice.Id;
            //ti.LatticePosition = lattice.LatticePosition;
            int result = BllToolInfo.SaveToolInfo(ti, out Exception ex);

            result = BllToolSettings.BatchSaveToolSettings(ti.Id, toolSettings, out _);
            if (result < 0)
            {
                UIMessageBox.ShowError($"保存失败，原因：\n{ex.Message}");
                return -1;
            }
            return result;
        }

        private int UpdateToolInfo(string toolId, ToolInfo ti, IList<ToolSettings> toolSettings)
        {
            ToolInfo toolinfo = BllToolInfo.GetToolInfo(toolId, out _);
            toolinfo.LatticeId = ti.LatticeId;
            toolinfo.LatticePosition = ti.LatticePosition;
            toolinfo.ToolName = ti.ToolName;
            toolinfo.ToolCount = ti.ToolCount;
            toolinfo.CurrentCount = ti.CurrentCount;
            toolinfo.WarnType = ti.WarnType;
            toolinfo.WarnValue = ti.WarnValue;
            toolinfo.OperateTime = ti.OperateTime;
            toolinfo.Operator = ti.Operator;
            toolinfo.OperatorName = ti.OperatorName;
            int result = BllToolInfo.UpdateToolInfo(toolinfo, out Exception ex);
            //IList<ToolSettings> toolSettings = new List<ToolSettings>();
            foreach (ToolSettings ts in toolSettings)
            {
                ts.ToolId = toolId;
            }
            result = BllToolSettings.BatchSaveToolSettings(toolId, toolSettings, out _);
            if (result < 0)
            {
                UIMessageBox.ShowError($"保存失败，原因：\n{ex.Message}");
                return -1;
            }
            return result;
        }

        private void FormToolEdit_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) ClearInputData();
        }
    }

    public class ListItem
    {
        public string Text { get; set; }

        public int Value { get; set; }
    }
}
