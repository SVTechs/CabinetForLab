using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using NHibernate.Criterion;
using NLog;
using WebConsole.DAL.NhUtils;

namespace WebConsole.DAL
{
    public class DalAnnouncement : FlexNhBase<Announcement>
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static IList<Announcement> SearchAnnouncement(int dataStart, int dataCount, out Exception exception)
        {
            List<Order> orderList = new List<Order>
            {
                Order.Desc("Id")
            };
            return SearchItem<Announcement>(null, orderList, dataStart, dataCount, out exception);
        }

        public static int GetAnnouncementCount(out Exception exception)
        {
            return GetItemCount<Announcement>(null, out exception);
        }

        public static Announcement GetAnnouncement(long id, out Exception exception)
        {
            return GetItemInfo<Announcement>("Id", id, out exception);
        }

        public static int AddAnnouncement(string infoTitle, string infoContent, string infoAuthor,
            string infoAuthorName, DateTime createTime, out Exception exception)
        {
            Announcement itemRecord = new Announcement
            {
                InfoTitle = infoTitle,
                InfoContent = infoContent,
                InfoAuthor = infoAuthor,
                InfoAuthorName = infoAuthorName,
                CreateTime = createTime,
            };
            return SaveItem(itemRecord, out exception);
        }

        public static int ModifyAnnouncement(long id, string infoTitle, string infoContent, string infoAuthor,
            string infoAuthorName, DateTime createTime, out Exception exception)
        {
            Announcement itemRecord = GetAnnouncement(id, out exception);
            if (itemRecord == null) return 0;
            itemRecord.InfoTitle = infoTitle;
            itemRecord.InfoContent = infoContent;
            itemRecord.InfoAuthor = infoAuthor;
            itemRecord.InfoAuthorName = infoAuthorName;
            itemRecord.CreateTime = createTime;
            return UpdateItem(itemRecord, out exception);
        }

        public static int UpdateAnnouncement(Announcement announcement, out Exception exception)
        {
            return UpdateItem(announcement, out exception);
        }

        public static int DeleteAnnouncement(long id, out Exception exception)
        {
            return DeleteItem<Announcement>("Id", id, out exception);
        }
    }
}
