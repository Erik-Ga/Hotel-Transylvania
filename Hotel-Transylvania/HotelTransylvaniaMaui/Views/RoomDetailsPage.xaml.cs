using HotelTransylvaniaMaui.Models;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui.Views;

public partial class RoomDetailsPage : ContentPage
{
    // Grunden för uppspelning av ljud
    private readonly IAudioManager audioManager;
    public RoomDetailsPage(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.RoomDetailsPageViewModel();
        this.audioManager = audioManager;
    }
    // Går tillbaka ett steg i applikationen
    private void OnBackClicked(object sender, EventArgs e) 
    {
        Navigation.PopAsync();  
    }
    // Kallar på metod för att boka valt rum
    private async void OnClickedBookRoomAsync(object sender, EventArgs e)
    {
        var guest = GuestEntry.Text;
        var roomName = LabelRoomName.Text;
        var roomDoorImage = DoorImage.Text;
        ViewModels.RoomDetailsPageViewModel.UpdateRoom(roomName, guest, roomDoorImage);
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("yay.mp3"));
        player.Volume = 0.4;
        player.Play();
        var player2 = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("thankyou.mp3"));
        player2.Volume = 0.4;
        player2.Play();
        await DisplayAlert("Välkommen!", "Bokningen lyckades! :)", "Yay!");
    }
}