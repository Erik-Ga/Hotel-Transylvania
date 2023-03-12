using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTransylvaniaMaui.Models
{
    // Singleton implementation
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
        // Startar huvudmusiken
        public async void MusicPlay()
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("hotel.mp3"));
            player.Play();
            player.Loop = true;
        }
    }
}
