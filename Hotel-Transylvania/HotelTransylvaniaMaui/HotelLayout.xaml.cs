using HotelTransylvaniaMaui.ViewModels;
using HotelTransylvaniaMaui.Views;

namespace HotelTransylvaniaMaui;

public partial class HotelLayout : ContentPage
{
	public HotelLayout()
	{
		InitializeComponent();
        BindingContext = new ViewModels.HotelLayoutViewModel();
    }

    // Printar ut alla rum ifr�n MongoDb
    bool pageStarted = false;
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            Task t = (BindingContext as HotelLayoutViewModel).GetRooms(); // Metod i ViewModel
            pageStarted = true;
        }
    }

    // G�r s� att man kan klicka p� rum
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