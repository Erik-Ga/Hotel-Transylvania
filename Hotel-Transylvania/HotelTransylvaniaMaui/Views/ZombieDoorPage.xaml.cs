namespace HotelTransylvaniaMaui;

public partial class ZombieDoorPage : ContentPage
{
	public ZombieDoorPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.HotelLayoutViewModel();
    }
    private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var product = ((ListView)sender).SelectedItem as Models.Room;
        if (product != null)
        {
            var page = new ZombieDoorPage();
            page.BindingContext = product;
            await Navigation.PushAsync(page);
        }
    }
}