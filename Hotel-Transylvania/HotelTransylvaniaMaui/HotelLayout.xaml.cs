using HotelTransylvaniaMaui.Views;

namespace HotelTransylvaniaMaui;

public partial class HotelLayout : ContentPage
{
	public HotelLayout()
	{
		InitializeComponent();
        BindingContext = new ViewModels.HotelLayoutViewModel();
    }
    private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var product = ((ListView)sender).SelectedItem as Models.Room;
        if (product != null)
        {
            var page = new RoomDetailsPage();
            page.BindingContext = product;
            await Navigation.PushAsync(page);
        }
    }
}