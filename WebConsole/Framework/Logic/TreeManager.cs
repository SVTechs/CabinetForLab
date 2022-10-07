using System.Collections;
using System.Collections.Generic;
using Domain.Server.Domain;
using Domain.Server.Interface;
using FineUIPro;
using Utilities.DbHelper;
using Utilities.Ext;
using WebConsole.BLL;

namespace WebConsole.Framework.Logic
{
    public class TreeManager
    {
        public static TreeNode GetMenuTree()
        {
            TreeNode pTreeNode = new TreeNode { Expanded = true };
            IList<PageMenus> menuList = BllPageMenus.GetWebMenus(out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                PageMenus menuData = ExtHelper.GetTree<PageMenus>((IList)menuList);
                GenerateMenu(ref pTreeNode, menuData);
            }

            return pTreeNode;
        }

        private static void GenerateMenu(ref TreeNode rootTreeNode, PageMenus menuData)
        {
            if (menuData.MenuName != null)
            {
                rootTreeNode.NodeID = menuData.Id;
                rootTreeNode.Text = menuData.MenuName;
                rootTreeNode.Attributes["title"] = menuData.MenuName; 
                rootTreeNode.IconFontClass = string.IsNullOrEmpty(menuData.MenuIcon) ? "fa fa-angle-right" : menuData.MenuIcon;
                string menuUrl = menuData.MenuUrl ?? "";
                if (menuData.MenuType == 1)
                {
                    if (menuUrl.StartsWith("javascript:"))
                    {
                        rootTreeNode.Attributes["type"] = 10;
                        rootTreeNode.Attributes["target"] = ReplaceUrlHolder(menuUrl);
                        rootTreeNode.Leaf = true;
                    }
                    else
                    {
                        rootTreeNode.Attributes["type"] = 0;
                        rootTreeNode.Attributes["target"] = ReplaceUrlHolder(menuUrl);
                        rootTreeNode.Leaf = true;
                    }
                }
                else if (menuData.MenuType == 2)
                {
                    rootTreeNode.Attributes["type"] = 1;
                    rootTreeNode.Attributes["target"] = ReplaceUrlHolder(menuUrl);
                    rootTreeNode.Leaf = true;
                }
            }

            Hashtable ht = SessionManager.GetPermission();
            if (ht != null)
            {
                for (int i = 0; i < menuData.TreeChildren.Count; i++)
                {
                    if (menuData.TreeChildren[i].IsVisible == 1)
                    {
                        string childId = menuData.TreeChildren[i].Id;
                        if ((int)(ht[childId] ?? 0) == 1)
                        {
                            TreeNode pTreeNode = new TreeNode();
                            GenerateMenu(ref pTreeNode, menuData.TreeChildren[i]);
                            rootTreeNode.Nodes.Add(pTreeNode);
                        }
                    }
                }
            }
        }

        private static string ReplaceUrlHolder(string url)
        {
            url = url ?? "";
            UserInfo ui = SessionManager.GetUserInfo();
            url = url.Replace("{UserName}", ui.UserName);
            return url;
        }

        public static List<PageMenus> GetMenuAndFuncTable(bool showTop = false)
        {
            Hashtable funcTable = BllPageFunctions.GetFunctionTable(out _);
            IList<PageMenus> menuList = BllPageMenus.GetAllMenus(out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                PageMenus menuData = ExtHelper.GetTree<PageMenus>((IList)menuList);
                FillFuncTable(menuData, funcTable);

                List<PageMenus> retList = ExtractItemList(ToBaseTree(menuData.TreeChildren));
                for (int i = 0; i < retList.Count; i++)
                {
                    if (retList[i].MenuType == 0) retList[i].MenuUrl = "<分类>";
                }
                if (showTop)
                {
                    for (int i = 0; i < retList.Count; i++)
                    {
                        retList[i].TreeLevel += 1;
                    }
                    PageMenus di = new PageMenus
                    {
                        Id = "root",
                        MenuName = "所有菜单",
                        MenuUrl = "",
                        IsVisible = 1
                    };
                    retList.Insert(0, di);
                }
                return retList;
            }
            return null;
        }

        private static void FillFuncTable(PageMenus menuData, Hashtable funcTable)
        {
            //页面节点
            if (!string.IsNullOrEmpty(menuData.Id) && funcTable[menuData.Id] != null)
            {
                ArrayList al = (ArrayList)funcTable[menuData.Id];
                for (int j = 0; j < al.Count; j++)
                {
                    PageFunctions pf = (PageFunctions)al[j];
                    PageMenus pTreeNode = new PageMenus
                    {
                        Id = pf.Id,
                        MenuName = pf.FunctionName,
                        TreeLevel = menuData.TreeLevel + 1,
                        MenuOrder = pf.FunctionOrder,
                        MenuUrl = "<功能>",
                        MenuType = 50000,
                        IsProtected = pf.IsProtected,
                        IsVisible = 1
                    };
                    for (int k = 0; k < pf.ChildFunction?.Count; k++)
                    {
                        PageFunctions cf = pf.ChildFunction[k];
                        PageMenus cTreeNode = new PageMenus
                        {
                            Id = cf.Id,
                            MenuName = cf.FunctionName,
                            TreeLevel = pTreeNode.TreeLevel + 1,
                            MenuOrder = cf.FunctionOrder,
                            MenuUrl = "<二级功能>",
                            MenuType = 50001,
                            IsProtected = pf.IsProtected,
                            IsVisible = 1
                        };
                        pTreeNode.TreeChildren.Add(cTreeNode);
                    }
                    menuData.TreeChildren.Add(pTreeNode);
                }
            }
            if (SqlDataHelper.IsDataValid<PageMenus>(menuData.TreeChildren))
            {
                for (int i = 0; i < menuData.TreeChildren.Count; i++)
                {
                    FillFuncTable(menuData.TreeChildren[i], funcTable);
                }
            }
        }

        public static List<DepartInfo> GetDepartTable(bool showTop = false)
        {
            IList<DepartInfo> menuList = BllDepartInfo.SearchDepartInfo(out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                DepartInfo menuData = ExtHelper.GetTree<DepartInfo>((IList)menuList);

                List<DepartInfo> departList = ExtractItemList(ToBaseTree(menuData.TreeChildren));
                if (showTop)
                {
                    for (int i = 0; i < departList.Count; i++)
                    {
                        departList[i].TreeLevel += 1;
                    }
                    DepartInfo di = new DepartInfo
                    {
                        Id = "root",
                        DepartName = "所有部门",
                        IsEnabled = -1
                    };
                    departList.Insert(0, di);
                }
                return departList;
            }
            return null;
        }

        public static List<RoleInfo> GetRoleTable(bool showTop = false)
        {
            IList<RoleInfo> menuList = BllRoleInfo.SearchRoleInfo(null, 0, -1, out _);
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

        public static List<DutyInfo> GetDutyTable(bool showTop = false)
        {
            IList<DutyInfo> menuList = BllDutyInfo.SearchDutyInfo(out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                DutyInfo menuData = ExtHelper.GetTree<DutyInfo>((IList)menuList);

                List<DutyInfo> dutyList = ExtractItemList(ToBaseTree(menuData.TreeChildren));
                if (showTop)
                {
                    for (int i = 0; i < dutyList.Count; i++)
                    {
                        dutyList[i].TreeLevel += 1;
                    }
                    DutyInfo di = new DutyInfo
                    {
                        Id = "root",
                        DutyName = "所有职务",
                        IsEnabled = -1
                    };
                    dutyList.Insert(0, di);
                }
                return dutyList;
            }
            return null;
        }

        public static List<GenericTree> GetGenericTreeTable(string treeGroup)
        {
            IList<GenericTree> menuList = BllGenericTree.SearchGenericTree(treeGroup, 1, out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                GenericTree menuData = ExtHelper.GetTree<GenericTree>((IList)menuList);

                List<GenericTree> treeList = ExtractItemList(ToBaseTree(menuData.TreeChildren));
                return treeList;
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

        public static TreeNode GetPermTreeNode(Hashtable extTable, bool enableCheck)
        {
            Hashtable funcTable = BllPageFunctions.GetFunctionTable(out _);
            IList<PageMenus> menuList = BllPageMenus.GetAllMenus(out _);
            if (SqlDataHelper.IsDataValid(menuList))
            {
                PageMenus menuData = ExtHelper.GetTree<PageMenus>((IList)menuList);

                TreeNode pTreeNode = new TreeNode();
                pTreeNode.Attributes["menuName"] = "系统菜单";
                pTreeNode.Text = "系统菜单";
                pTreeNode.Expanded = true;
                AddToFuncMenu(pTreeNode, menuData, funcTable, extTable, enableCheck);
                return pTreeNode;
            }
            return null;
        }

        private static void AddToFuncMenu(TreeNode rootTreeNode, PageMenus menuData, Hashtable funcTable, Hashtable extTable, bool enableCheck)
        {
            if (menuData.MenuName != null)
            {
                rootTreeNode.Text = menuData.MenuName;
                rootTreeNode.IconFontClass = menuData.MenuIcon;
                if (enableCheck)
                {
                    rootTreeNode.EnableCheckBox = true;
                    rootTreeNode.Checked = extTable != null && extTable[menuData.Id] != null;
                }
                if (menuData.MenuType == 1 || menuData.MenuType == 2 || menuData.MenuType == 3)
                {
                    rootTreeNode.NodeID = "P" + menuData.Id;
                    //页面节点
                    if (funcTable[menuData.Id] != null)
                    {
                        ArrayList al = (ArrayList)funcTable[menuData.Id];
                        for (int i = 0; i < al.Count; i++)
                        {
                            PageFunctions pf = (PageFunctions)al[i];
                            TreeNode pTreeNode = new TreeNode { NodeID = "F" + pf.Id, Text = pf.FunctionName };
                            if (enableCheck)
                            {
                                pTreeNode.EnableCheckBox = true;
                                pTreeNode.Checked = extTable != null && extTable[pf.Id] != null;
                            }
                            if (pf.ChildFunction == null)
                            {
                                pTreeNode.Leaf = true;
                            }
                            else
                            {
                                for (int j = 0; j < pf.ChildFunction.Count; j++)
                                {
                                    PageFunctions cf = pf.ChildFunction[j];
                                    TreeNode cTreeNode = new TreeNode { NodeID = "S" + cf.Id, Text = cf.FunctionName };
                                    if (enableCheck)
                                    {
                                        cTreeNode.EnableCheckBox = true;
                                        cTreeNode.Checked = extTable != null && extTable[cf.Id] != null;
                                    }
                                    cTreeNode.Leaf = true;
                                    pTreeNode.Nodes.Add(cTreeNode);
                                }
                            }
                            rootTreeNode.Nodes.Add(pTreeNode);
                        }
                    }
                    else
                    {
                        rootTreeNode.Leaf = true;
                    }
                }
                else
                {
                    rootTreeNode.NodeID = "W" + menuData.Id;
                    if (menuData.TreeChildren.Count > 0)
                    {
                        rootTreeNode.Expanded = true;
                    }
                }
            }
            for (int i = 0; i < menuData.TreeChildren.Count; i++)
            {
                TreeNode pTreeNode = new TreeNode();
                rootTreeNode.Nodes.Add(pTreeNode);

                AddToFuncMenu(rootTreeNode.Nodes[rootTreeNode.Nodes.Count - 1], menuData.TreeChildren[i], funcTable, extTable, enableCheck);
            }
        }
    }
}