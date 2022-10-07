using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapToolInfo : ClassMap<ToolInfo>
    {
        public MapToolInfo()
        {
            Table("ToolInfo");
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.LatticeId).Column("LatticeId");
            Map(x => x.ToolName).Column("ToolName");
            Map(x => x.ToolCode).Column("ToolCode");
            Map(x => x.ToolSpec).Column("ToolSpec");
            Map(x => x.ToolTypeId).Column("ToolTypeId");
            Map(x => x.ToolTypeName).Column("ToolTypeName");
            Map(x => x.ToolCount).Column("ToolCount");
            Map(x => x.HardwareId).Column("HardwareId");
            Map(x => x.CardId).Column("CardId");
            Map(x => x.ToolManager).Column("ToolManager");
            Map(x => x.Comment).Column("Comment");
            Map(x => x.Operator).Column("Operator");
            Map(x => x.OperateTime).Column("OperateTime");
            Map(x => x.ToolStatus).Column("ToolStatus");
        }
    }
}
