using HotelTransylvaniaMaui.Models;
using System.Text.Json;

namespace HotelTransylvaniaMaui.ViewModels
{
    internal class ActivityPageViewModel
    {
        // Skapar en instans av API för att man ska kunna hämta och hänvisa till API-data
        public Models.WeatherData WeatherData { get; set; }

        // Printar ut nuvarande temperatur i Transylvania och ifall "pool är öppen" baserat på resultat
        public ActivityPageViewModel()
        {
            var task = Task.Run(() => GetWeatherAsync());
            task.Wait();

            try
            {
                WeatherData = task.Result;
                if (WeatherData != null)
                {
                    if (WeatherData.Temp >= 20)
                    {
                        WeatherData.CurrentWeather = "Temperaturen är: " + WeatherData.Temp + ", poolen är öppen, kör på!";
                    }
                    else
                    {
                        WeatherData.CurrentWeather = "Temperaturen är: " + WeatherData.Temp + ", poolen är stängd, kom tillbaka en annan dag!";
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
            finally
            {

            }
        }
        // Data för att kommunicera med API
        public static async Task<Models.WeatherData> GetWeatherAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "3N/wr+dj1T8aSx0c9HE34g==GP4plkr1RNlHDyFI");

            Models.WeatherData weather = null;

            HttpResponseMessage response = await client.GetAsync("v1/weather?city=Transylvania");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                weather = JsonSerializer.Deserialize<Models.WeatherData>(responseString);
            }

            return weather;
        }
    }
}
