using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapRoleSettings : ClassMap<RoleSettings>
    {
        public MapRoleSettings()
        {
            Table("RoleSettings");
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.UserId).Column("UserId");
            Map(x => x.RoleId).Column("RoleId");
            Map(x => x.AddTime).Column("AddTime");
        }
    }
}
