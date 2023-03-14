using HotelTransylvaniaMaui.Models;
using HotelTransylvaniaMaui.Views;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui
{
    public partial class MainPage : ContentPage
    {
        // Grunden för uppspelning av ljud
        private readonly IAudioManager audioManager;
        
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            this.audioManager = audioManager;
        }
        // Byter sida till hotellayout
        private async void OnClickedChangeToHotelLayout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HotelLayout(AudioManager.Current));
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("door.mp3"));
            player.Volume = 0.6;
            player.Play();
        }
        // Byter sida till adminlayout
        private async void OnClickedChangeToAdminPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminPage(AudioManager.Current));
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("typing.mp3"));
            player.Volume = 0.6;
            player.Play();
        }
        // Startar spooky bakgrundsmusik
        private async void OnClickedWelcome(object sender, EventArgs e)
        {
            var hotelmusic = ThemeMusic.Instance;
            hotelmusic.WelcomeSoundPlay();
            hotelmusic.MusicPlay();
            WelcomeLabel.IsVisible = true;
            WelcomeLabel.FadeTo(1, 3000);
            BokaButton.IsVisible = true;
            BokaButton.FadeTo(1, 3000);
            AdminButton.IsVisible = true;
            AdminButton.FadeTo(1, 3000);
            ActivityButton.IsVisible = true;
            ActivityButton.FadeTo(1, 3000);
            SpookyButton.IsVisible = false;
            // await DisplayAlert("Spooky!", "Du har aktiverat maximum spookyness... Välkommen in!", "Scary!");
        }

        private async void OnClickedChangeToActivityPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActivityPage(AudioManager.Current));
        }
    }
}