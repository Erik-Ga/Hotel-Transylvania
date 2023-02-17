using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hotel_Transylvania
{
    internal class WeatherAPI
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

        public static async Task<WeatherAPI> GetWeather(string uri)
        {
            Console.WriteLine("Getting weather!");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "3N/wr+dj1T8aSx0c9HE34g==GP4plkr1RNlHDyFI");

            WeatherAPI weather = null;

            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<WeatherAPI>(responseString);
                Console.WriteLine("Weather ready!");
            }

            return weather;
        }
    }
}
