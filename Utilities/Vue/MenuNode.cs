using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace Utilities.Vue
{
    public class MenuNode : VueMenu
    {
        [JsonProperty("submenu")]
        public List<MenuNode> Submenu = new List<MenuNode>();
    }
}
