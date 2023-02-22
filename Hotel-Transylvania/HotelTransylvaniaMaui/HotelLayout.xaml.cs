namespace HotelTransylvaniaMaui;

public partial class HotelLayout : ContentPage
{
	public HotelLayout()
	{
		InitializeComponent();
	}
    private async void OnZombieDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ZombieDoorPage());
    }
}