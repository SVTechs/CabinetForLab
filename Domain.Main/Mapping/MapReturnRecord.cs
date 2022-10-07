using Domain.Main.Domain;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Mapping
{
    public class MapReturnRecord : ClassMap<ReturnRecord>
    {
        public MapReturnRecord()
        {
            Table("ReturnRecord");
            Id(x => x.Id).GeneratedBy.Assigned().Column("Id");
            Map(x => x.BorrowRecord).Column("BorrowRecord");
            Map(x => x.WorkerId).Column("WorkerId");
            Map(x => x.WorkerName).Column("WorkerName");
            Map(x => x.EventTime).Column("EventTime");
        }
    }
}
