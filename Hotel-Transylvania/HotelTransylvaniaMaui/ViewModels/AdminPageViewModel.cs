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
        string soundSource;
        [ObservableProperty]
        string roomDescription;

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
                SoundSource = SoundSource,
                RoomDescription = RoomDescription
            };

            await GetDbCollection().InsertOneAsync(room);

            Rooms.Add(room);
        }

        // Tar bort rum i MongoDb metod
        [RelayCommand]
        public async void DeleteRoom(object r)
        {
            var room = (Room)r;
            await GetDbCollection().DeleteOneAsync(x => x.Id == room.Id);
            Rooms.Remove(room);
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
