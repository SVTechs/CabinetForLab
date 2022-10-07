using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapUserInfo : ClassMap<UserInfo>
    {
        public MapUserInfo()
        {
            Table("UserInfo");
            Id(x => x.ID).GeneratedBy.Assigned().Column("ID");
            Map(x => x.UserName).Column("UserName");
            Map(x => x.Password).Column("Password");
            Map(x => x.FullName).Column("FullName");
            Map(x => x.Sex).Column("Sex");
            Map(x => x.Age).Column("Age");
            Map(x => x.Tel).Column("Tel");
            Map(x => x.Adress).Column("Adress");
            Map(x => x.UserState).Column("UserState");
            Map(x => x.Createtime).Column("Createtime");
            Map(x => x.CreateUser).Column("CreateUser");
            Map(x => x.Updatetime).Column("Updatetime");
            Map(x => x.UpdateUser).Column("UpdateUser");
            Map(x => x.CardNum).Column("CardNum");
            Map(x => x.Image).Column("Image");
            Map(x => x.FaceFeature).Column("FaceFeature");
            Map(x => x.FingerFeature).Column("FingerFeature");
        }
    }
}