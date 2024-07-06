using RainfallAPI.Models;

namespace RainfallAPI.Services.Interface
{
    public interface IRainfallService
    {
        Task<RainfallReadingsResponse> GetRainfallReadingsAsync(string stationId);
    }
}