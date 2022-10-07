using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapRuntimeInfo : ClassMap<RuntimeInfo>
    {
        public MapRuntimeInfo()
        {
            Table("RuntimeInfo");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.KeyName).Column("KeyName");
            Map(x => x.KeyValue1).Column("KeyValue1");
            Map(x => x.KeyValue2).Column("KeyValue2");
            Map(x => x.KeyValue3).Column("KeyValue3");
            Map(x => x.KeyValue4).Column("KeyValue4");
        }
    }
}
