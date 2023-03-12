using HotelTransylvaniaMaui.ViewModels;
using HotelTransylvaniaMaui.Views;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui;

public partial class HotelLayout : ContentPage
{
    // Grunden för uppspelning av ljud
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

    // För att kunna gå till detaljvy av respektive existerande rum
    private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var room = ((ListView)sender).SelectedItem as Models.Room;
        if (room.IsBooked == false)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(room.SoundSource));
            player.Play();

            if (room != null)
            {
                var page = new RoomDetailsPage(AudioManager.Current);
                page.BindingContext = room;
                await Navigation.PushAsync(page);
            }
        }
        // Ifall rummet redan är bokat blockas användare från att gå vidare
        else if (room.IsBooked == true)
        {
            var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("scream.mp3"));
            player.Volume = 0.5;
            player.Play();
            var player2 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sorry.mp3"));
            player2.Volume = 0.5;
            player2.Play();
            await DisplayAlert("This is a jump scare >:O", "Rummet du valt är tyvärr bokat :(", "Leave...");
        }


    }
}