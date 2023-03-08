using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelTransylvaniaMaui.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;

namespace HotelTransylvaniaMaui.ViewModels
{
    internal partial class AdminPageViewModel : ObservableObject
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
        public AdminPageViewModel()
        {
            Rooms = new ObservableCollection<Models.Room>();
        }

        // Lägger till rum i MongoDb metod
        [RelayCommand]
        public async void AddRoom()
        {
            Room room = new Room()
            {
                Id = Guid.NewGuid(),
                RoomName = RoomName,
                Price = Price,
                ImageSource = ImageSource,
                ImageSourceBooked = ImageSourceBooked,
                ImageSourceNotBooked = ImageSourceNotBooked,
                ImageRoomSource = ImageRoomSource,
                ImageRoomDescription = ImageRoomDescription,
                LabelSource = LabelSource,
                SoundSource = SoundSource,
                RoomDescription = RoomDescription,
                IsBooked = IsBooked,
                Guest = Guest

            };

            await GetDbCollection().InsertOneAsync(room);

            Rooms.Add(room);
        }
        public static async void CancelRoom(object r, object d, object g)
        {
            var filter = Builders<Room>.Filter.Eq(i => i.RoomName, r);
            var update = Builders<Room>.Update.Set(g => g.ImageSource, d);
            var update2 = Builders<Room>.Update.Set(g => g.Guest, g);
            var update3 = Builders<Room>.Update.Set(g => g.IsBooked, false);
            await GetDbCollection().UpdateOneAsync(filter, update);
            await GetDbCollection().UpdateOneAsync(filter, update2);
            await GetDbCollection().UpdateOneAsync(filter, update3);
        }

        // Tar bort rum i MongoDb metod
        [RelayCommand]
        public async void DeleteRoom(object r)
        {
            var room = (Room)r;
            await GetDbCollection().DeleteOneAsync(x => x.Id == room.Id);
            Rooms.Remove(room);
        }
        public static async void UpdateRoom(object r, object g)
        {
            var filter = Builders<Room>.Filter.Eq(i => i.RoomName, r);
            var update = Builders<Room>.Update.Set(g => g.Guest, g);
            var update2 = Builders<Room>.Update.Set(g => g.IsBooked, true);
            await GetDbCollection().UpdateOneAsync(filter, update);
            await GetDbCollection().UpdateOneAsync(filter, update2);
        }

        // Hämtar alla rum i MongoDb metod
        public async Task GetRooms()
        {
            List<Room> roomsFromDb = await GetDbCollection().AsQueryable().ToListAsync();
            roomsFromDb.ForEach(x => Rooms.Add(x));
        }

        // Data för att kommunicera med MongoDb
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
