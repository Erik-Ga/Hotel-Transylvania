using HotelTransylvaniaMaui.ViewModels;
using HotelTransylvaniaMaui.Views;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui;

public partial class HotelLayout : ContentPage
{
    private readonly IAudioManager audioManager;
    public HotelLayout(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.HotelLayoutViewModel();
        this.audioManager = audioManager;
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
        var room = ((ListView)sender).SelectedItem as Models.Room;

        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(room.SoundSource));
        player.Play();
        await Task.Delay(1000);
        player.Dispose();

        if (room != null)
        {
            var page = new RoomDetailsPage();
            page.BindingContext = room;
            await Navigation.PushAsync(page);
        }
    }
}