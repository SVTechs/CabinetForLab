using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapBorrowRecord : ClassMap<BorrowRecord>
    {
        public MapBorrowRecord()
        {
            Table("BorrowRecord");
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.ToolId).Column("ToolId");
            Map(x => x.ToolName).Column("ToolName");
            Map(x => x.ToolPosition).Column("ToolPosition");
            Map(x => x.ToolCount).Column("ToolCount");
            Map(x => x.WorkerId).Column("WorkerId");
            Map(x => x.WorkerName).Column("WorkerName");
            Map(x => x.EventTime).Column("EventTime");
            Map(x => x.Status).Column("Status");
            Map(x => x.ReturnTime).Column("ReturnTime");
        }
    }
}
