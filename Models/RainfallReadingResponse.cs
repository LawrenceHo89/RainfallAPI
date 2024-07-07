using System.Text.Json.Serialization;

namespace RainfallAPI.Models
{
    public class RainfallReadingResponse
    {
        [JsonPropertyName("Items")]
        public List<RainfallReading> readings { get; set; }
    }
}
