using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.Models
{
    internal class Room
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public int Price { get; set; }
        public string ImageSource { get; set; }
        public string SoundSource { get; set; }
        public string RoomDescription { get; set; }
    }
}
