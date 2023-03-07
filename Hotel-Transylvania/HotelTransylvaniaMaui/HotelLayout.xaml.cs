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

    // Printar ut alla rum ifrån MongoDb
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

    // Gör så att man kan klicka på rum
    private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
    {

        var room = ((ListView)sender).SelectedItem as Models.Room;
        if (room.IsBooked == false)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(room.SoundSource));
            player.Play();

            if (room != null)
            {
                var page = new RoomDetailsPage();
                page.BindingContext = room;
                await Navigation.PushAsync(page);
            }
        }
        else if (room.IsBooked == true)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("scream.mp3"));
            player.Play();
            await DisplayAlert("This is a jump scare >:O", "Rummet du valt är tyvärr bokat :(", "Leave...");
        }


    }
}