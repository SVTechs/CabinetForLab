using CabinetMgr.BLL;
using CabinetMgr.Common;
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
    public partial class FormLatticePermissionManage : UIForm
    {
        private static FormLatticePermissionManage formLatticePermissionManage;
        private static string ownerId, ownerType;

        public FormLatticePermissionManage()
        {
            InitializeComponent();
        }

        public static FormLatticePermissionManage Instance(string id, string idType)
        {
            if (formLatticePermissionManage == null || formLatticePermissionManage.IsDisposed) formLatticePermissionManage = new FormLatticePermissionManage();
            ownerId = id;
            ownerType = idType;
            return formLatticePermissionManage;
        }

        private void FormLatticePermissionManage_Load(object sender, EventArgs e)
        {
            LoadLatticeInfo();
        }

        private void LoadLatticeInfo()
        {
            IList<LatticePermissionSettings> permissionSettings = BllLatticePermissionSettings.SearchLatticePermissionSettings(ownerId, ownerType, 0, -1, null, out _);
            uiTreeViewLatticeInfo.Nodes.Clear();
            TreeNode root = new TreeNode() { Text = "储物格", Tag = "-"};
            var list = BllLatticeInfo.SearchLatticeInfo(0, -1, null, out _);
            foreach(LatticeInfo li in list)
            {
                TreeNode tn = new TreeNode() {
                    Text = li.LabName+"-"+li.Location+"-"+li.CabinetNum+"-"+li.CabinetLatticeNum,
                    Tag = li.Id,
                    Checked = permissionSettings.FirstOrDefault(x => x.LatticeId == li.Id) != null
                };
                root.Nodes.Add(tn);
            }
            uiTreeViewLatticeInfo.Nodes.Add(root);
            uiTreeViewLatticeInfo.ExpandAll();
        }

        private void uiButtonSave_Click(object sender, EventArgs e)
        {
            var root = uiTreeViewLatticeInfo.Nodes;
            if (root[0].Nodes.Count == 0) return;
            List<LatticePermissionSettings> list = new List<LatticePermissionSettings>();
            foreach(TreeNode tn in root[0].Nodes)
            {
                if (!tn.Checked) continue;
                LatticePermissionSettings info = new LatticePermissionSettings()
                {
                    Id = Guid.NewGuid().ToString(),
                    LatticeId = (long)tn.Tag,
                    OwnerId = ownerId,
                    OwnerType = ownerType,
                    AddTime = DateTime.Now
                };
                list.Add(info);
            }
            if (list.Count == 0)
            {
                UIMessageBox.Show("请选择需要保存的储物格权限"); return;
            }
            int result = BllLatticePermissionSettings.BatchSaveLatticePermissionSettings(ownerId, ownerType, list, out Exception exception);
            if(result <= 0)
            {
                UIMessageBox.ShowError($"保存失败，原因:{exception.Message}", true, true);
            }
            Hide();
        }

        private void uiButtonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
