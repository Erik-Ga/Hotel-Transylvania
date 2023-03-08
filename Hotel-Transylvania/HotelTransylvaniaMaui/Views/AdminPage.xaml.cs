using HotelTransylvaniaMaui.Models;
using HotelTransylvaniaMaui.ViewModels;
using HotelTransylvaniaMaui.Views;
using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui.Views;

public partial class AdminPage : ContentPage
{
    private readonly IAudioManager audioManager;

    public AdminPage(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.AdminPageViewModel();
        this.audioManager = audioManager;
    }
    bool pageStarted = false;
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!pageStarted)
        {
            Task t = (BindingContext as AdminPageViewModel).GetRooms(); // Metod i ViewModel
            pageStarted = true;
        }
    }
    private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var room = ((ListView)sender).SelectedItem as Models.Room;

        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync(room.SoundSource));
        player.Play();

        if (room != null)
        {
            var page = new AdminRoomDetailsPage();
            page.BindingContext = room;
            await Navigation.PushAsync(page);
        }
    }
    private void OnClickedCancelRoom(object sender, EventArgs e)
    {
        var roomName = LabelRoomName.Text;
        var roomDoorImage = DoorImage.Source;
        string guest = null;
        ViewModels.AdminPageViewModel.CancelRoom(roomName, roomDoorImage, guest);

    }
}