using HotelTransylvaniaMaui.Views;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager audioManager;
        int count = 0;

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
        private async void OnClickedChangeToAdminPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminPage(AudioManager.Current));
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("typing.mp3"));
            player.Play();
        }
        private async void Welcome(object sender, EventArgs e)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("hotel.mp3"));
            player.Play();
        }
    }
}