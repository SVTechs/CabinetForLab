using CabinetMgr.BLL;
using Domain.Main.Domain;
using Domain.Main.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Utilities.DbHelper;
using Utilities.Ext;

namespace CabinetMgr.Common
{
    public class TreeManager
    {

        public static List<RoleInfo> GetRoleTable(bool showTop = false)
        {
            IList<RoleInfo> menuList = BllRoleInfo.SearchRoleInfo(0, -1, null, out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                RoleInfo menuData = ExtHelper.GetTree<RoleInfo>((IList)menuList);

                List<RoleInfo> roleList = ExtractItemList(ToBaseTree(menuData.TreeChildren));
                if (showTop)
                {
                    for (int i = 0; i < roleList.Count; i++)
                    {
                        roleList[i].TreeLevel += 1;
                    }
                    RoleInfo di = new RoleInfo
                    {
                        Id = "root",
                        RoleName = "所有角色",
                        IsEnabled = -1
                    };
                    roleList.Insert(0, di);
                }
                return roleList;
            }
            return null;
        }

        public static RoleInfo GetRoleNode()
        {
            IList<RoleInfo> menuList = BllRoleInfo.SearchRoleInfo(0, -1, null, out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                RoleInfo menuData = ExtHelper.GetTree<RoleInfo>((IList)menuList);
                return menuData;
            }
            return null;
        }


        private static List<ITreeDef<T>> ToBaseTree<T>(List<T> tList)
        {
            List<ITreeDef<T>> iList = new List<ITreeDef<T>>();
            for (int i = 0; i < tList.Count; i++)
            {
                iList.Add((ITreeDef<T>)tList[i]);
            }
            return iList;
        }

        private static List<T> ExtractItemList<T>(List<ITreeDef<T>> childList)
        {
            if (childList == null || childList.Count == 0) return null;
            List<T> infoList = new List<T>();
            for (int i = 0; i < childList.Count; i++)
            {
                infoList.Add((T)childList[i]);
                if (childList[i].TreeChildren != null && childList[i].TreeChildren.Count > 0)
                {
                    infoList.AddRange(ExtractItemList(ToBaseTree(childList[i].TreeChildren)));
                }
            }
            return infoList;
        }

    }
}