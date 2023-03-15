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
                ImagePool.Source = "poolhuh.jpg";
            }
            else if(WeatherLabel.Text != null)
            {
                WeatherLabel.IsVisible = true;
            }
            pageStarted = true;
            if(WeatherLabel.IsVisible == true) 
            {
                if (WeatherLabel.Text.Contains("öppen"))
                {
                    ImagePool.Source = "pool.jpg";
                }
                else if(WeatherLabel.Text.Contains("stängd"))
                {
                    ImagePool.Source = "poolclosed.jpg";
                }
            }
        }
    }
}