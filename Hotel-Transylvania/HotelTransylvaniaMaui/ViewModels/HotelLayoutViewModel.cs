using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    internal partial class HotelLayoutViewModel : ObservableObject
    {
        // Autogenererande kod
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

        // Skapande av lista för rum
        public HotelLayoutViewModel() 
        {
            Rooms = new ObservableCollection<Models.Room>();
        }
        // Hämtar alla rum i MongoDb metod
        public async Task GetRooms()
        {
            List<Room> roomsFromDb = await GetDbCollection().AsQueryable().ToListAsync();
            roomsFromDb.ForEach(x => Rooms.Add(x));
        }

        // Data för att kommunicera med MongoDb
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
