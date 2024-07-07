using RainfallAPI.Models;
using RainfallAPI.Services.Interface;
using static System.Net.WebRequestMethods;

namespace RainfallAPI.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly HttpClient _httpClient;

        public RainfallService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RainfallReadingResponse> GetRainfallReadingsAsync(string stationId)
        {
            //var environmentApiUrl = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit=100";
            var environmentApiUrl = "https://environment.data.gov.uk/flood-monitoring/id/stations/3680/readings?_sorted&_limit=5";

            //TODO: Add limit as a param

            try
            {
                var response = await _httpClient.GetFromJsonAsync<RainfallReadingResponse>(environmentApiUrl);

                if (response?.Items == null || response.Items.Count == 0)
                {
                    throw new HttpRequestException("No data found for the specified stationId");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
