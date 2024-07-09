using RainfallAPI.Models;

namespace RainfallAPI.Services.Interface
{
    public interface IRainfallService
    {
        Task<RainfallReadingResponse> GetRainfallReadingsAsync(string stationId, int limit);
    }
}