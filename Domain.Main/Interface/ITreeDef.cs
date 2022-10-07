using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main.Interface
{
    public interface ITreeDef<T>
    {
        List<T> TreeChildren { get; set; }
    }
}