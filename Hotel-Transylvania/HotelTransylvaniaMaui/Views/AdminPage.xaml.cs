using HotelTransylvaniaMaui.ViewModels;
using HotelTransylvaniaMaui.Views;
namespace HotelTransylvaniaMaui.Views;

public partial class AdminPage : ContentPage
{
	public AdminPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.HotelLayoutViewModel();
    
    }
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