using System.Text.Json.Serialization;
using static RainfallAPI.Models.RainfallModel;

namespace RainfallAPI.Models
{
    public class RainfallReadingsResponse
    {
        public List<RainfallReading> Items { get; set; }
    }
}
