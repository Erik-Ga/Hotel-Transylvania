namespace HotelTransylvaniaMaui
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            MyLabelInfo.Text = await GetWeather();

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async Task<string> GetWeather()
        {
            Task<WeatherAPI> weather = WeatherAPI.GetWeatherData("v1/weather?city=Transylvania");
            string weatherCurrent = "Vädret i Transylvania är idag följande: " + (await weather).Temp;

            if ((await weather).Temp > 8)
            {
                weatherCurrent = "Temperaturen är: " + (await weather).Temp + ", poolen är öppen, kör på!";
            }
            return weatherCurrent;
        }
        private async void OnClickedChangeToHotelLayout(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HotelLayout());
        }
    }
}