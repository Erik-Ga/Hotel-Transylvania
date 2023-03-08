using Hotel_Transylvania.Methods;
using Hotel_Transylvania.Models;

namespace Hotel_Transylvania
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // await MethodAPI.GetWeather();
            //Task saveguesttest = Models.MongoDBTest.AddGuest();
            //await saveguesttest;
            Task updateroom = Models.MongoDBTest.UpdateRoom();
            await updateroom;
            //Task saveGuest = Models.MongoDB.MongoDBSave();
            //await saveGuest;
        }
    }
}