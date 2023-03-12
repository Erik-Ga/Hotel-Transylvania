using HotelTransylvaniaMaui.Models;
using HotelTransylvaniaMaui.Views;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager audioManager;
        
        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel().WeatherData;
            this.audioManager = audioManager;
        }
        // Byter sida till hotellayout
        private async void OnClickedChangeToHotelLayout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HotelLayout(AudioManager.Current));
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("door.mp3"));
            player.Play();
        }
        // Byter sida till adminlayout
        private async void OnClickedChangeToAdminPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminPage(AudioManager.Current));
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("typing.mp3"));
            player.Play();
        }
        // Startar spooky bakgrundsmusik
        private async void OnClickedWelcome(object sender, EventArgs e)
        {
            var hotelmusic = ThemeMusic.Instance;
            hotelmusic.MusicPlay();
            SpookyButton.IsVisible = false;
            await DisplayAlert("Spooky!", "Du har aktiverat maximum spookyness...", "Scary!");
        }
    }
}