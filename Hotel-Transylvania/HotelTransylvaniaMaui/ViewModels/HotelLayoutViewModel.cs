using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        [ObservableProperty] // ÄNDRAT!
        ObservableCollection<Models.Room> rooms;
        //public List<Models.Product> Products { get; set; }

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
        public HotelLayoutViewModel() 
        {
            Rooms = new ObservableCollection<Models.Room>();

            Rooms.Add(new Models.Room
            {
                RoomName = "Zombie Room",
                Price = 0,
                ImageSource = "zombiedoor.png",
                RoomDescription = "Zombie Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Skeleton Room",
                Price = 0,
                ImageSource = "skeletondoor.png",
                RoomDescription = "Skeleton Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Ghost Room",
                Price = 0,
                ImageSource = "ghostdoor.png",
                RoomDescription = "Ghost Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Vampire Room",
                Price = 0,
                ImageSource = "vampiredoor.png",
                RoomDescription = "Vampire Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Troll Room",
                Price = 0,
                ImageSource = "trolldoor.png",
                RoomDescription = "Troll Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Mummy Room",
                Price = 0,
                ImageSource = "mummydoor.png",
                RoomDescription = "Mummy Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Witch Room",
                Price = 0,
                ImageSource = "witchdoor.png",
                RoomDescription = "Witch Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Werewolf Room",
                Price = 0,
                ImageSource = "werewolfdoor.png",
                RoomDescription = "Werewolf Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Dragon Room",
                Price = 0,
                ImageSource = "dragondoor.png",
                RoomDescription = "Dragon Placeholder"
            });
            Rooms.Add(new Models.Room
            {
                RoomName = "Devil Room",
                Price = 0,
                ImageSource = "devildoor.png",
                RoomDescription = "Devil Placeholder"
            });
        }

        //[RelayCommand]
        //public async void AddProduct()
        //{
        //    Product product = new Product()
        //    {
        //        Id = Guid.NewGuid(),
        //        ProductName = ProductName,
        //        Price = Price,
        //        ImageSource = ImageSource,
        //        Details = Details
        //    };

        //    await GetDbCollection().InsertOneAsync(product);

        //    Products.Add(product);
        //}

        //[RelayCommand]
        //public async void DeleteProduct(object p)
        //{
        //    var prod = (Product)p;
        //    await GetDbCollection().DeleteOneAsync(x => x.Id == prod.Id);
        //    Products.Remove(prod);
        //}

        //public async Task GetProducts()
        //{
        //    List<Product> productsFromDb = await GetDbCollection().AsQueryable().ToListAsync();
        //    await Task.Delay(3000);
        //    productsFromDb.ForEach(x => Products.Add(x));
        //    Console.WriteLine("Hej");
        //}
    }
}
