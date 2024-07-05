using Microsoft.AspNetCore.Mvc;

namespace RainfallAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RainfallController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public RainfallController(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
        }

        [HttpGet("rainfall/id/{stationId}/readings")]
        public async Task<IActionResult> GetRainfallReading(string stationId)
        {

            return null;
        }
    }
}
