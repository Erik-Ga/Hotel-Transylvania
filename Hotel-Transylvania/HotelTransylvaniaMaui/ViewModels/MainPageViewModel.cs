using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
//using HomeKit;
//using GameController;

namespace HotelTransylvaniaMaui
{
    internal class MainPageViewModel
    {

        // Skapar en instans av API för att man ska kunna hämta och hänvisa till API-data
        public Models.WeatherData WeatherData { get; set; }
        public MainPageViewModel()
        {
            try
            {
                var task = Task.Run(() => GetWeatherAsync());
                task.Wait();
                WeatherData = task.Result;
                if (WeatherData.Temp >= 20)
                {
                    WeatherData.CurrentWeather = "Temperaturen är: " + WeatherData.Temp + ", poolen är öppen, kör på!";
                }
                else
                {
                    WeatherData.CurrentWeather = "Temperaturen är: " + WeatherData.Temp + ", poolen är stängd, kom tillbaka en annan dag!";
                }
            }
            catch (NullReferenceException)
            {

            }
            finally
            {
                if (WeatherData == null)
                {
                    WeatherData.CurrentWeather = "Vädret i Transylvania går tyvärr inte att hämta...";
                }
            }

        }

        // Data för att kommunicera med API
        public static async Task<Models.WeatherData> GetWeatherAsync()
        {
            Console.WriteLine("Getting weather!");
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "3N/wr+dj1T8aSx0c9HE34g==GP4plkr1RNlHDyFI");

            Models.WeatherData weather = null;

            HttpResponseMessage response = await client.GetAsync("v1/weather?city=Transylvania");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<Models.WeatherData>(responseString);
                Console.WriteLine("Weather ready!");
            }

            return weather;
        }
    }
}
