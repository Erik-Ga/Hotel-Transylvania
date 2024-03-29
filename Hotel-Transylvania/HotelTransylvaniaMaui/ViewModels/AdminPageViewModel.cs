﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelTransylvaniaMaui.Models;
using MongoDB.Driver;
using Plugin.Maui.Audio;
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

        private readonly IAudioManager audioManager;
        // Skapande av lista för rum
        public AdminPageViewModel(IAudioManager audioManager)
        {
            Rooms = new ObservableCollection<Models.Room>();
            this.audioManager = audioManager;
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
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("wrench.mp3"));
            player.Play();
            await Application.Current.MainPage.DisplayAlert("Vackert!", "Rummet har skapats :)", "Toppen!");

        }

        // Tar bort rum i MongoDb metod
        [RelayCommand]
        public async void DeleteRoom(object r)
        {
            var room = (Room)r;
            await GetDbCollection().DeleteOneAsync(x => x.Id == room.Id);
            Rooms.Remove(room);
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("crash.mp3"));
            player.Play();
            await Application.Current.MainPage.DisplayAlert("Boom!", "Rummet har rivits! >:)", "Moahahaha!");

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
