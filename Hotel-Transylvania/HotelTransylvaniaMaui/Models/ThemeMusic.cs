using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.Models
{
    public class ThemeMusic
    {
        private readonly IAudioManager audioManager;
        private static ThemeMusic instance = null;

        private ThemeMusic(IAudioManager audioManager)
        {
            this.audioManager = audioManager;
        }

        public static ThemeMusic Instance
        { 
            get  
            { 
                if(instance == null)
                {
                    instance = new ThemeMusic(AudioManager.Current);
                }
                return instance;
            } 
        }
        public async void MusicPlay()
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("hotel.mp3"));
            player.Play();
        }
    }
}
