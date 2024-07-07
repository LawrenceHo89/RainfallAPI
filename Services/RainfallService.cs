﻿using RainfallAPI.Models;
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

        public async Task<RainfallReadingsResponse> GetRainfallReadingsAsync(string stationId)
        {
            //var environmentApiUrl = $"https://environment.data.gov.uk/flood-monitoring/id/stations/{stationId}/readings?_sorted&_limit=100";
            var environmentApiUrl = "https://environment.data.gov.uk/flood-monitoring/id/stations/3680/readings?_sorted&_limit=5";

            try
            {
                var response = await _httpClient.GetFromJsonAsync<RainfallReadingsResponse>(environmentApiUrl);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
