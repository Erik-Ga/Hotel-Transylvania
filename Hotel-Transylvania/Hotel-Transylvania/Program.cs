using Hotel_Transylvania.Methods;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // await MethodAPI.GetWeather();
            Task saveGuest = Models.MongoDB.MongoDBSave();
            await saveGuest;
        }
    }
}