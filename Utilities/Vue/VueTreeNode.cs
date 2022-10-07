using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utilities.Vue
{
    public class VueTreeNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("expanded")]
        public bool Expanded { get; set; }

        [JsonProperty("checked")]
        public bool Checked { get; set; }

        [JsonProperty("nodeType")]
        public int NodeType { get; set; }

        [JsonProperty("children")]
        public IList<VueTreeNode> Children { get; set; } = new List<VueTreeNode>();
    }
}
