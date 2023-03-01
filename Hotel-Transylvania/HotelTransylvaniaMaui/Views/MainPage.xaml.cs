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
            //var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("CantinaBand3.wav"));
            //player.Play();
            //await Task.Delay(3000);
            //player.Dispose();
            await Navigation.PushAsync(new HotelLayout(AudioManager.Current));
        }
        private async void OnClickedChangeToAdminPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminPage());
        }
    }
}