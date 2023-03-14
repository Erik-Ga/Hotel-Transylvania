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
            player.Volume = 0.5;
            player.Play();
            player.Loop = true;
        }
        public async void WelcomeSoundPlay()
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("thunder.mp3"));
            player.Volume = 0.3;
            player.Play();
            var player2 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("welcome.mp3"));
            player2.Volume = 0.2;
            player2.Play();
        }
    }
}
