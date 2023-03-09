using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui.Views;

public partial class AdminRoomDetailsPage : ContentPage
{
    private readonly IAudioManager audioManager;
    public AdminRoomDetailsPage(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.AdminRoomDetailsPageViewModel();
        this.audioManager = audioManager;
    }
    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    private void OnClickedUpdateRoom(object sender, EventArgs e)
    {
        Guid id = Guid.Parse(LabelId.Text);
        var roomName = EntryRumnamn.Text;
        int price = int.Parse(EntryPris.Text);
        var image = EntryBild.Text;
        var roomImage = EntryRumBild.Text;
        var roomDescriptionImage = EntryRumBeskrivningsbild.Text;
        var titelImage = EntryTitelBild.Text;
        var sound = EntryLjud.Text;
        var details = EntryDetaljer.Text;
        bool booked = bool.Parse(EntryBokad.Text);
        var guest = EntryGäst.Text;
        ViewModels.AdminRoomDetailsPageViewModel.UpdateRoom(id, roomName, price, image, roomImage, roomDescriptionImage, titelImage, sound, details, booked, guest);
    }
    private async void OnClickedCancelRoom(object sender, EventArgs e)
    {
        Guid id = Guid.Parse(LabelId.Text);
        string roomDoorImage = DoorImage.Text;
        string guest = null;
        ViewModels.AdminRoomDetailsPageViewModel.CancelRoom(id, roomDoorImage, guest);
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sweeping.mp3"));
        player.Play();
        await DisplayAlert("Avbokning lyckad!", "Rummet är städat och rensat på guck och redo för nästa gäst!", "Woop Woop!");

    }
}