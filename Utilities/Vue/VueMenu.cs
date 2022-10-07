using Newtonsoft.Json;

namespace Utilities.Vue
{
    public abstract class VueMenu
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("onclick")]
        public string OnClick { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("tagColor")]
        public string TagColor { get; set; }

        [JsonProperty("i18n")]
        public string I18N { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }

        [JsonProperty("isDisabled")]
        public bool IsDisabled { get; set; }
    }
}
