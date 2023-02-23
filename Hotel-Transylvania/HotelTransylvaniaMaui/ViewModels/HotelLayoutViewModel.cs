using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.ViewModels
{
    internal class HotelLayoutViewModel
    {
        public List<Models.Room> Rooms { get; set; }
        public HotelLayoutViewModel() 
        {
            Rooms = new List<Models.Room>();

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
    }
}
