using Newtonsoft.Json;

namespace EncoreTIX.Models
{
    public class Image
    {
        [JsonProperty("ratio")]
        public string Ratio { get; set; } = String.Empty;


        [JsonProperty("url")]
        public string Url { get; set; } = String.Empty;


        [JsonProperty("width")]
        public int Width { get; set; }


        [JsonProperty("height")]
        public int Height { get; set; }


        [JsonProperty("fallback")]
        public string Fallback { get; set; } = String.Empty;
    }
}
