using Newtonsoft.Json;

namespace EncoreTIX.Models
{
    public class Attraction
    {
        [JsonProperty("id")]
        public string? Id { get; set; }


        [JsonProperty("name")]
        public string? Name { get; set; }



        [JsonProperty("images")]
        public string? ImageUrl { get; set; }


        [JsonProperty("externalLinks")]
        public ExternalLinks? ExternalLinks { get; set; }

    }
}
