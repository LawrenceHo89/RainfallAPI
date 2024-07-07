using System.Text.Json.Serialization;

namespace RainfallAPI.Models
{
    public class RainfallReading
    {
        [JsonPropertyName("dateTime")]
        public string dateMeasured { get; set; }
        [JsonPropertyName("value")]
        public decimal amountMeasured { get; set; }
    }
}
