using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.Models
{
    internal class WeatherData
    {
        [JsonPropertyName("wind_speed")]
        public float Wind_Speed { get; set; }

        [JsonPropertyName("wind_degrees")]
        public int Wind_Degrees { get; set; }

        [JsonPropertyName("temp")]
        public int Temp { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("sunset")]
        public int Sunset { get; set; }

        [JsonPropertyName("min_temp")]
        public int Min_Temp { get; set; }

        [JsonPropertyName("cloud_pct")]
        public int Cloud_Pct { get; set; }

        [JsonPropertyName("feels_like")]
        public int Feels_Like { get; set; }

        [JsonPropertyName("sunrise")]
        public int Sunrise { get; set; }

        [JsonPropertyName("max_temp")]
        public int Max_Temp { get; set; }
        public string CurrentWeather { get; set; }
    }
}
