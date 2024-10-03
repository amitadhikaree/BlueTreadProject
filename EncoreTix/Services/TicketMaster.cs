
using EncoreTIX.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Net.Http;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using EncoreTIX.Models.ResponeseDtos;

namespace EncoreTIX.Services
{
    public class TicketMaster : ITicketMaster 
    {
        private const string V = "_embedded";
        private readonly IHttpService _httpClient;
        private readonly String? _apiKey;
        private readonly String? _resultSize;



        public TicketMaster(IHttpService httpClient, IConfiguration configuration) {
            _httpClient = httpClient;
            _apiKey = configuration["ApiKey"];
            _resultSize = configuration["MaxResultSize"];
        }

        public async Task<Attraction> GetAttractionDetails(string attractionId)
        {
            try
            {
                string endPoint = $"attractions/{attractionId}?apikey={_apiKey}";
                var response = await _httpClient.GetAsync<String>(endPoint);
                var attractionDto = JsonConvert.DeserializeObject<AttractionDto>(response);
                //Getting Url of 16_9 and assigning it to Attraction Model class
                return new Attraction
                {
                    Name = attractionDto?.Name,
                    ExternalLinks = attractionDto?.ExternalLinks,
                    Id = attractionDto?.Id,
                    ImageUrl = attractionDto?.Images?.FirstOrDefault<Image>(o => o.Ratio == "16_9")?.Url
                };
            }

            catch (Exception ex) {
                //log the message
                return new Attraction();
            }
        }



        public async Task<List<Attraction>> GetAttractionsByKeyword(string keyword)
        {
            try
            {
                string endPoint = $"attractions?apikey={_apiKey}&keyword={keyword}&bands&size={_resultSize}";
                var response = await _httpClient.GetAsync<String>(endPoint);

                //String imageUrl = images.FirstOrDefault<Image>(o => o.Ratio == "16_9").Url;
                var apiResponse = JsonConvert.DeserializeObject<AttactionsApiResponseDto>(response)!;
                var attractions =  apiResponse.Embedded.Attractions;

                //Getting Url of 16_9 and assigning it to Attraction Model class
                List<Attraction> attractionList = new List<Attraction>();
                foreach (var attraction in attractions)
                {
                    attractionList.Add(new Attraction {
                        Name = attraction?.Name,
                        ExternalLinks = attraction?.ExternalLinks,
                        Id = attraction?.Id,
                        ImageUrl = attraction?.Images.FirstOrDefault<Image>(o => o.Ratio == "16_9")?.Url
                    });
                }
               

                return attractionList;

            }

            catch (Exception ex) {
                return [];
            }
            
        }



        public async Task<List<AttractionEvent>> GetEventsByAttractionId(string id)
        {
            try
            {
                string endPoint = $"events?size={_resultSize}&apikey={_apiKey}&attractionId={id}";
                var response = await _httpClient.GetAsync<String>(endPoint);
                var apiResponse = JsonConvert.DeserializeObject<EventApiResponse>(response);

                List<AttractionEvent> attractionEvents = new();
                foreach (var apiEvent in apiResponse?._embedded?.Events)
                {
                    var date = apiEvent?.Dates?.Start?.LocalDate ?? "";
                    DateTime dateTime = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    string formattedDate = dateTime.ToString("dddd MMM dd yyyy", CultureInfo.InvariantCulture);
                    attractionEvents.Add(
                        new AttractionEvent
                        {
                            Name = apiEvent?.Name,
                            VenueDate = formattedDate,
                            Venue = apiEvent?._embedded?.Venues?[0].Name
                        });
                }
                return attractionEvents;
            }

            catch (Exception ex)
            {
                return [];
            }
        }


    }
}
