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
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            if(WeatherLabel.Text == null)
            {
                NoWeatherLabel.IsVisible = true;
                ImagePool.Source = "spookypoolhuh.png";
                ImageBowling.Source = "spookybowlinghuh.png";
            }
            else if(WeatherLabel.Text != null)
            {
                WeatherLabel.IsVisible = true;
            }
            pageStarted = true;
            if(WeatherLabel.IsVisible == true) 
            {
                if (WeatherLabel.Text.Contains("pool"))
                {
                    ImagePool.Source = "spookypool.png";
                    ImageBowling.Source = "spookybowlingclosed.png";
                }
                else if(WeatherLabel.Text.Contains("bowling"))
                {
                    ImagePool.Source = "spookypoolclosed.png";
                    ImageBowling.Source = "spookybowling.png";
                }
            }
        }
    }
}