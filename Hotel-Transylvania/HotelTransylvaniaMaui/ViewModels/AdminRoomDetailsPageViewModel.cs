using CommunityToolkit.Mvvm.ComponentModel;
using HotelTransylvaniaMaui.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.ViewModels
{
    internal partial class AdminRoomDetailsPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Models.Room> rooms;
        [ObservableProperty]
        Guid id;
        [ObservableProperty]
        string roomName;
        [ObservableProperty]
        int price;
        [ObservableProperty]
        string imageSource;
        [ObservableProperty]
        string imageSourceBooked;
        [ObservableProperty]
        string imageSourceNotBooked;
        [ObservableProperty]
        string imageRoomSource;
        [ObservableProperty]
        string imageRoomDescription;
        [ObservableProperty]
        string labelSource;
        [ObservableProperty]
        string soundSource;
        [ObservableProperty]
        string roomDescription;
        [ObservableProperty]
        bool isBooked;
        [ObservableProperty]
        string guest;

        public static async void UpdateRoom(Guid id, string r, int p, string i, string ri, string rdi, string ti, string s, string d, bool b, string g)
        {
            var filter = Builders<Room>.Filter.Eq(x => x.Id, id);
            var update = Builders<Room>.Update.Set(x => x.RoomName, r);
            var update2 = Builders<Room>.Update.Set(x => x.Price, p);
            var update3 = Builders<Room>.Update.Set(x => x.ImageSource, i);
            var update4 = Builders<Room>.Update.Set(x => x.ImageRoomSource, ri);
            var update5 = Builders<Room>.Update.Set(x => x.ImageRoomDescription, rdi);
            var update6 = Builders<Room>.Update.Set(x => x.LabelSource, ti);
            var update7 = Builders<Room>.Update.Set(x => x.SoundSource, s);
            var update8 = Builders<Room>.Update.Set(x => x.RoomDescription, d);
            var update9 = Builders<Room>.Update.Set(x => x.IsBooked, b);
            var update10 = Builders<Room>.Update.Set(x => x.Guest, g);
            await GetDbCollection().UpdateOneAsync(filter, update);
            await GetDbCollection().UpdateOneAsync(filter, update2);
            await GetDbCollection().UpdateOneAsync(filter, update3);
            await GetDbCollection().UpdateOneAsync(filter, update4);
            await GetDbCollection().UpdateOneAsync(filter, update5);
            await GetDbCollection().UpdateOneAsync(filter, update6);
            await GetDbCollection().UpdateOneAsync(filter, update7);
            await GetDbCollection().UpdateOneAsync(filter, update8);
            await GetDbCollection().UpdateOneAsync(filter, update9);
            await GetDbCollection().UpdateOneAsync(filter, update10);
        }
        public static async void CancelRoom(Guid id, string d, string g)
        {
            var filter = Builders<Room>.Filter.Eq(x => x.Id, id);
            var update = Builders<Room>.Update.Set(x => x.ImageSource, d);
            var update2 = Builders<Room>.Update.Set(x => x.Guest, g);
            var update3 = Builders<Room>.Update.Set(x => x.IsBooked, false);
            await GetDbCollection().UpdateOneAsync(filter, update);
            await GetDbCollection().UpdateOneAsync(filter, update2);
            await GetDbCollection().UpdateOneAsync(filter, update3);
        }

        public static IMongoCollection<Models.Room> GetDbCollection()
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
