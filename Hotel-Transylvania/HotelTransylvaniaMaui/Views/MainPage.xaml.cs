namespace HotelTransylvaniaMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel().WeatherData;
        }

        // Byter sida till hotellayout
        private async void OnClickedChangeToHotelLayout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HotelLayout());
        }
    }
}