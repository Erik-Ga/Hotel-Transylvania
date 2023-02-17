using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Methods
{
    internal class MethodAPI
    {
        public static async Task GetWeather()
        {
            Task<WeatherAPI> weather = WeatherAPI.GetWeather("v1/weather?city=Transylvania");
            Console.WriteLine("Vädret i Transylvania är idag följande: ");

            Console.WriteLine("Vindhastighet: " + (await weather).Wind_Speed);
            Console.WriteLine("Vindgrader: " + (await weather).Wind_Degrees);
            Console.WriteLine("Temperatur: " + (await weather).Temp);
            Console.WriteLine("Luftfuktighet: " + (await weather).Humidity);
            if((await weather).Temp > 8)
            {
                Console.WriteLine("Poolen är öppen, kör på!");
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}
