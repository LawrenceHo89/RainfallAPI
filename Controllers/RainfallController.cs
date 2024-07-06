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
        public async Task<IActionResult> GetRainfallReadings(string stationId)
        {
            try
            {
                var response = await _rainfallService.GetRainfallReadingsAsync(stationId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
