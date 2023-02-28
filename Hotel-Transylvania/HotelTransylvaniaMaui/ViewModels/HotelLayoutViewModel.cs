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
        string roomDescription;

        // Skapande av lista för rum
        public HotelLayoutViewModel() 
        {
            Rooms = new ObservableCollection<Models.Room>();

            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Zombie Room",
            //    Price = 0,
            //    ImageSource = "zombiedoor.png",
            //    RoomDescription = "Zombie Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Skeleton Room",
            //    Price = 0,
            //    ImageSource = "skeletondoor.png",
            //    RoomDescription = "Skeleton Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Ghost Room",
            //    Price = 0,
            //    ImageSource = "ghostdoor.png",
            //    RoomDescription = "Ghost Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Vampire Room",
            //    Price = 0,
            //    ImageSource = "vampiredoor.png",
            //    RoomDescription = "Vampire Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Troll Room",
            //    Price = 0,
            //    ImageSource = "trolldoor.png",
            //    RoomDescription = "Troll Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Mummy Room",
            //    Price = 0,
            //    ImageSource = "mummydoor.png",
            //    RoomDescription = "Mummy Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Witch Room",
            //    Price = 0,
            //    ImageSource = "witchdoor.png",
            //    RoomDescription = "Witch Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Werewolf Room",
            //    Price = 0,
            //    ImageSource = "werewolfdoor.png",
            //    RoomDescription = "Werewolf Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Dragon Room",
            //    Price = 0,
            //    ImageSource = "dragondoor.png",
            //    RoomDescription = "Dragon Placeholder"
            //});
            //Rooms.Add(new Models.Room
            //{
            //    RoomName = "Devil Room",
            //    Price = 0,
            //    ImageSource = "devildoor.png",
            //    RoomDescription = "Devil Placeholder"
            //});

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
