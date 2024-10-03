using Newtonsoft.Json;

namespace EncoreTIX.Models
{
    public class AttractionEvent
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("venue")]
        public string? Venue { get; set; }

        [JsonProperty("dates")]
        public string? VenueDate { get; set; }

    }
}
