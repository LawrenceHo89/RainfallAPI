﻿using System.Text.Json.Serialization;

namespace RainfallAPI.Models
{
    public class RainfallReading
    {
        public string DateTime { get; set; }
        public decimal Value { get; set; }
    }
}
