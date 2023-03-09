using HotelTransylvaniaMaui.Models;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui.Views;

public partial class RoomDetailsPage : ContentPage
{
    private readonly IAudioManager audioManager;
    public RoomDetailsPage(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.RoomDetailsPageViewModel();
        this.audioManager = audioManager;
    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();  
    }
    private async void OnClickedBookRoomAsync(object sender, EventArgs e)
    {
        var guest = GuestEntry.Text;
        var roomName = LabelRoomName.Text;
        var roomDoorImage = DoorImage.Text;
        ViewModels.RoomDetailsPageViewModel.UpdateRoom(roomName, guest, roomDoorImage);
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("yay.mp3"));
        player.Play();
        await DisplayAlert("V�lkommen!", "Bokningen lyckades! :)", "Yay!");
    }
}