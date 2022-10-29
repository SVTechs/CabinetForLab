﻿using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapToolSettings : ClassMap<ToolSettings>
    {
        public MapToolSettings()
        {
            Table("ToolSettings");
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.OwnerType).Column("OwnerType");
            Map(x => x.OwnerId).Column("OwnerId");
            Map(x => x.ToolId).Column("ToolId");
            Map(x => x.AddTime).Column("AddTime");
        }
    }
}
