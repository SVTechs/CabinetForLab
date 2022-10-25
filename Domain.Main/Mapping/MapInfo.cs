using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapInfo : ClassMap<Info>
    {
        public MapInfo()
        {
            Table("Info");
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.InfoContent).Column("InfoContent");
            Map(x => x.InfoType).Column("InfoType");
            Map(x => x.IsTop).Column("IsTop");
            Map(x => x.CreateTime).Column("CreateTime");
        }
    }
}
