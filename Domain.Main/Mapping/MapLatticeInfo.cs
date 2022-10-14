using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapLatticeInfo : ClassMap<LatticeInfo>
    {
        public MapLatticeInfo()
        {
            Table("LatticeInfo");
            Id(x => x.Id).GeneratedBy.Identity().Column("Id");
            Map(x => x.CabinetNum).Column("CabinetNum");
            Map(x => x.CabinetLatticeNum).Column("CabinetLatticeNum");
            Map(x => x.Location).Column("Location");
            Map(x => x.LabName).Column("LabName");
            Map(x => x.Channel).Column("Channel");
            Map(x => x.BoardId).Column("BoardId");
        }
    }
}
