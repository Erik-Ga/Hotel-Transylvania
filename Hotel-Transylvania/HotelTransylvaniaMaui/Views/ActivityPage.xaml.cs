using HotelTransylvaniaMaui.Models;
using HotelTransylvaniaMaui.ViewModels;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui.Views;

public partial class ActivityPage : ContentPage
{
    private readonly IAudioManager audioManager;
    public ActivityPage(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.ActivityPageViewModel().WeatherData;
        this.audioManager = audioManager;
    }
    bool pageStarted = false;
    //Visar olika bilder på aktivitetsförslag beroende på temperaturen som hämtas från API'n 
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("poolball.mp3"));
            player.Volume = 0.5;
            player.Play();
            ImageDisco.Source = "dance.gif";
            if (WeatherLabel.Text == null)
            {
                NoWeatherLabel.IsVisible = true;
                ImagePool.Source = "spookypoolhuh.png";
                ImageBowling.Source = "spookybowlinghuh.png";
            }
            else if (WeatherLabel.Text != null)
            {
                WeatherLabel.IsVisible = true;
        }
        pageStarted = true;
        if (WeatherLabel.IsVisible == true)
        {
            if (WeatherLabel.Text.Contains("Pool"))
            {
                ImagePool.Source = "spookypool.png";
            ImageBowling.Source = "spookybowlingclosed.png";
        }
        else if (WeatherLabel.Text.Contains("bowling"))
        {
            ImagePool.Source = "spookypoolclosed.png";
            ImageBowling.Source = "spookybowling.png";
        }
    }
}
    }
}