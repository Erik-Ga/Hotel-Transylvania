using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelTransylvaniaMaui.Models;
using HotelTransylvaniaMaui.Views;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.ViewModels
{
    internal partial class RoomDetailsPageViewModel : ObservableObject
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

        public static async void UpdateRoom(object r, object g, object i)
        {
            var filter = Builders<Room>.Filter.Eq(i => i.RoomName, r);
            var update = Builders<Room>.Update.Set(g => g.Guest, g);
            var update2 = Builders<Room>.Update.Set(g => g.IsBooked, true);
            var update3 = Builders<Room>.Update.Set(g => g.ImageSource, i);
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
