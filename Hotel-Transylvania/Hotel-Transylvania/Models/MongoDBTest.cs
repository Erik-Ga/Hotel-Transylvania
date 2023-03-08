using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Transylvania.Models
{
    internal class MongoDBTest
    {

        public static async Task AddGuest()
        {
            var database = GetDbCollectionGuest();
            Models.Guest guest1 = new() { Id = new Guid(), Name = "Test Person Emma" };
            await database.InsertOneAsync(guest1);
            Console.WriteLine("Guest Saved!");
        }
        public static async Task UpdateRoom()
        {
            var filter = Builders<Room>.Filter.Eq(i => i.RoomName, "Test");
            var update = Builders<Room>.Update.Set(g => g.Guest, "Emma c:");
            await GetDbCollectionRoom().UpdateOneAsync(filter, update);
            Console.WriteLine("Room Updated!");
        }
        public static IMongoCollection<Models.Guest> GetDbCollectionGuest()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Erik:Pumpa123@cluster0.kh2vogk.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TheHotelDb");
            var myCollection = database.GetCollection<Models.Guest>("MyRoomCollection");
            return myCollection;
        }
        public static IMongoCollection<Models.Room> GetDbCollectionRoom()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://Erik:Pumpa123@cluster0.kh2vogk.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TheHotelDb");
            var myCollection = database.GetCollection<Models.Room>("MyRoomCollection");
            return myCollection;
        }
    }
}
