using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllPageMenus
    {
        public static PageMenus GetPageMenu(string menuId, out Exception exception)
        {
            if (string.IsNullOrEmpty(menuId))
            {
                exception = null;
                return null;
            }
            return DalPageMenus.GetPageMenu(menuId, out exception);
        }

        public static PageMenus GetPageMenuByUrl(string menuUrl, out Exception exception)
        {
            return DalPageMenus.GetPageMenuByUrl(menuUrl, out exception);
        }

        public static IList<PageMenus> GetWebMenus(out Exception exception)
        {
            return DalPageMenus.GetWebMenus(out exception);
        }

        public static IList<PageMenus> GetAllMenus(out Exception exception)
        {
            return DalPageMenus.GetAllMenus(out exception);
        }

        public static int SavePageMenus(PageMenus pageMenu, out Exception exception)
        {
            return DalPageMenus.SavePageMenus(pageMenu, out exception);
        }

        public static int AddPageMenu(string menuName, int menuLevel, string menuParent, int menuOrder,
            int menuType, string menuUrl, string menuIcon, int isVisible, string menuDesp, UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(menuName) || menuLevel < 0 || menuType < 0)
            {
                exception = null;
                return -100;
            }
            return DalPageMenus.AddPageMenu(menuName, menuLevel, menuParent, menuOrder, menuType,
                menuUrl, menuIcon, isVisible, menuDesp, userInfo, out exception);
        }

        public static int ModifyPageMenu(string menuId, string menuName, int menuOrder,
            int menuType, string menuUrl, string menuIcon, int isVisible, string menuDesp, UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(menuId) || string.IsNullOrEmpty(menuName) || menuType < 0)
            {
                exception = null;
                return -100;
            }
            return DalPageMenus.ModifyPageMenu(menuId, menuName, menuOrder, menuType,
                menuUrl, menuIcon, isVisible, menuDesp, userInfo, out exception);
        }

        public static int UpdatePageMenu(PageMenus menuInfo, out Exception exception)
        {
            return DalPageMenus.UpdatePageMenu(menuInfo, out exception);
        }

        public static int DeletePageMenu(string menuId, UserInfo userInfo, out Exception exception)
        {
            if (string.IsNullOrEmpty(menuId))
            {
                exception = null;
                return -100;
            }
            return DalPageMenus.DeletePageMenu(menuId, userInfo, out exception);
        }
    }
}
