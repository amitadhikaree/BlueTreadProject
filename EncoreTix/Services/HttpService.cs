using Newtonsoft.Json;

namespace EncoreTIX.Services
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _baseUrl = "https://app.ticketmaster.com/discovery/v2/";
        public HttpService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _baseUrl = configuration["TicketMasterBaseUri"]!;
        }

        public async Task<string> GetAsync<T>(string endpoint)
        {
            try
            {
                // Create a new HttpClient instance using the factory
                var client = _httpClientFactory.CreateClient();

                // Combine base URL with the endpoint
                client.BaseAddress = new Uri(_baseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                // Make the GET request
                var response = await client.GetAsync(endpoint);

                // Ensure success or throw an exception
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                var responseData = await response.Content.ReadAsStringAsync();
                // Deserialize the response content into the specified type
                return responseData;
                //return JsonConvert.DeserializeObject<T>(responseData);
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP-specific errors (e.g., network issues, 404, etc.)
                throw new ApplicationException($"Error fetching data from API: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                throw new ApplicationException("An unexpected error occurred", ex);
            }
        }
    }
}
