using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapToolType : ClassMap<ToolType>
    {
        public MapToolType()
        {
            Table("ToolType");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.TypeName).Column("TypeName");
            Map(x => x.CreateTime).Column("CreateTime");
        }
    }
}
