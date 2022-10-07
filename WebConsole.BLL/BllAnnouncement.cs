using System;
using System.Collections.Generic;
using Domain.Server.Domain;
using WebConsole.DAL;

namespace WebConsole.BLL
{
    public class BllAnnouncement
    {
        public static IList<Announcement> SearchAnnouncement(int dataStart, int dataCount, out Exception exception) {
            return DalAnnouncement.SearchAnnouncement(dataStart, dataCount, out exception);
        }

        public static int GetAnnouncementCount(out Exception exception) {
            return DalAnnouncement.GetAnnouncementCount(out exception);
        }

        public static Announcement GetAnnouncement(long id, out Exception exception) {
            return DalAnnouncement.GetAnnouncement(id, out exception);
        }

        public static int AddAnnouncement(string infoTitle, string infoContent, string infoAuthor, string infoAuthorName, DateTime createTime, out Exception exception) {
            return DalAnnouncement.AddAnnouncement(infoTitle, infoContent, infoAuthor, infoAuthorName, createTime, out exception);
        }

        public static int ModifyAnnouncement(long id, string infoTitle, string infoContent, string infoAuthor, string infoAuthorName, DateTime createTime, out Exception exception) {
            return DalAnnouncement.ModifyAnnouncement(id, infoTitle, infoContent, infoAuthor, infoAuthorName, createTime, out exception);
        }

        public static int UpdateAnnouncement(Announcement announcement, out Exception exception) {
            return DalAnnouncement.UpdateAnnouncement(announcement, out exception);
        }

        public static int DeleteAnnouncement(long id, out Exception exception) {
            return DalAnnouncement.DeleteAnnouncement(id, out exception);
        }
    }
}
