using Newtonsoft.Json;

namespace EncoreTIX.Models
{
    public class ExternalLinks
    {
        [JsonProperty("youtube")]
        public List<UrlItem>? YouTube { get; set; }


        [JsonProperty("twitter")]
        public List<UrlItem>? Twitter { get; set; }


        [JsonProperty("facebook")]
        public List<UrlItem>? Facebook { get; set; }


        [JsonProperty("instagram")]
        public List<UrlItem>? Instagram { get; set; }


        [JsonProperty("home")]
        public List<UrlItem>? Homepage { get; set; }

    }

    public class UrlItem
    {
        [JsonProperty("url")]
        public string? Url { get; set; }
    }
}
