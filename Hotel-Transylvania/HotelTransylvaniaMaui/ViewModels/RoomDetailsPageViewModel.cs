using CommunityToolkit.Mvvm.ComponentModel;
using HotelTransylvaniaMaui.Models;
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
        public async void UpdateRoom()
        {
            
            Room room = new Room()
            {
                Id = Guid.NewGuid(),
                RoomName = RoomName,
                Price = Price,
                ImageSource = ImageSource,
                ImageRoomSource = ImageRoomSource,
                ImageRoomDescription = ImageRoomDescription,
                LabelSource = LabelSource,
                SoundSource = SoundSource,
                RoomDescription = RoomDescription,
                IsBooked = IsBooked,
                Guest = Guest

            };

            await GetDbCollection().FindOneAndUpdate(room.Id, Guest);
        }
        public IMongoCollection<Models.Room> GetDbCollection()
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
