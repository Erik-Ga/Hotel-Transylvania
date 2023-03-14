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
}