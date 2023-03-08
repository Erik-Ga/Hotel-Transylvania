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
        public string ImageSourceBooked { get; set; }
        public string ImageSourceNotBooked { get; set; }
        public string ImageRoomSource { get; set; }
        public string ImageRoomDescription { get; set; }
        public string LabelSource { get; set; }
        public string SoundSource { get; set; }
        public string RoomDescription { get; set; }
        public bool IsBooked { get; set; }
        public string Guest { get; set; }
    }
}
