using RainfallAPI.Models;
using RainfallAPI.Services.Interface;

namespace RainfallAPI.Services
{
    public class RainfallService : IRainfallService
    {
        private readonly HttpClient _httpClient;

        public RainfallService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RainfallReadingResponse> GetRainfallReadingsAsync(string stationId, int limit)
        {
            if (string.IsNullOrWhiteSpace(stationId))
            {
                throw new ArgumentException("stationId cannot be null or empty", nameof(stationId));
            }

            string _stationId = Uri.EscapeDataString(stationId);

            var environmentApiUrl = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{_stationId}/readings?_sorted&_limit={limit}";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<RainfallReadingResponse>(environmentApiUrl);

                return response;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest) //404
            {
                throw new Exception(ex.Message);
            }
            catch (HttpRequestException ex) //400
            {
                throw new Exception("Invalid request", ex);
            }
            catch (Exception ex) //500
            {
                throw new Exception("Internal server error", ex);
            }
        }
    }
}
