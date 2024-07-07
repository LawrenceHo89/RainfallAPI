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
            if (string.IsNullOrWhiteSpace(stationId))
            {
                throw new ArgumentException("stationId cannot be null or empty", nameof(stationId));
            }

            //var environmentApiUrl = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit=100";
            var environmentApiUrl = "https://environment.data.gov.uk/flood-monitoringaaaa/id/stations/3680/readings?_sorted&_limit=5";

            //TODO: Add limit as a param

            try
            {
                var response = await _httpClient.GetFromJsonAsync<RainfallReadingResponse>(environmentApiUrl);

                if (response?.readings == null || response.readings.Count == 0)
                {
                    throw new HttpRequestException("No data found for the specified stationId");
                }

                return response;
            }
            catch (HttpRequestException ex) //400
            {
                var errorResponse = new ErrorResponse
                {
                    Message = "Invalid request",
                    Detail = new List<ErrorDetail>
                    {
                        new ErrorDetail { PropertyName = "HttpRequest", Message = ex.Message }
                    }
                };

                throw new Exception("Invalid request", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal server error", ex);
            }
        }
    }
}
