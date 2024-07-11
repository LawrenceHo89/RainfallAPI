using Microsoft.AspNetCore.Mvc;
using RainfallAPI.Services.Interface;

namespace RainfallAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        [HttpGet("rainfall/id/{stationId}/readings")]
        public async Task<IActionResult> GetRainfallReadings(string stationId, [FromQuery] int limit = 10)
        {
            try
            {
                if (limit < 1 || limit > 100)
                {
                    return BadRequest(new { message = "Limit must be between 1 and 100" });
                }

                var response = await _rainfallService.GetRainfallReadingsAsync(stationId, limit);

                if (response == null || response.readings.Count == 0)
                {
                    return BadRequest(new { message = "No data found for the specified stationId" });
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
