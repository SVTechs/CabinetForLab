using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Domain
{
    public class LatticeInfo
    {
        public virtual long Id { get; set; }

        public virtual string CabinetNum { get; set; }

        public virtual string CabinetLatticeNum { get; set; }

        public virtual int Location { get; set; }

        public virtual string LabName { get; set; }

        public virtual string Channel { get; set; }

        public virtual string BoardId { get; set; }

        public virtual string LatticePosition { get => $"{CabinetNum}-{CabinetLatticeNum}"; }
    }
}
