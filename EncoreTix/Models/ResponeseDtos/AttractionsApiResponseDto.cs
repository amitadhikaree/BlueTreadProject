using Newtonsoft.Json;

namespace EncoreTIX.Models.ResponeseDtos
{

    public class AttactionsApiResponseDto
    {
        [JsonProperty("_embedded")]
        public EmbeddedData Embedded { get; set; }
    }

    public class EmbeddedData
    {
        [JsonProperty("attractions")]
        public List<AttractionDto> Attractions { get; set; }
    }

    public class AttractionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        [JsonProperty("externalLinks")]
        public ExternalLinks ExternalLinks { get; set; }
    }
}
