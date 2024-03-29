using Plugin.Maui.Audio;

namespace HotelTransylvaniaMaui.Views;

public partial class AdminRoomDetailsPage : ContentPage
{
    // Grunden f�r uppspelning av ljud
    private readonly IAudioManager audioManager;
    public AdminRoomDetailsPage(IAudioManager audioManager)
	{
		InitializeComponent();
        BindingContext = new ViewModels.AdminRoomDetailsPageViewModel();
        this.audioManager = audioManager;
    }
    // G�r tillbaka ett steg i applikationen
    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
    // Kallar p� metod f�r att uppdatera befintlig data i valt rum
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
        var guest = EntryG�st.Text;
        ViewModels.AdminRoomDetailsPageViewModel.UpdateRoom(id, roomName, price, image, roomImage, roomDescriptionImage, titelImage, sound, details, booked, guest);
    }
    // Kallar p� metod f�r att avboka g�st i valt rum
    private async void OnClickedCancelRoom(object sender, EventArgs e)
    {
        Guid id = Guid.Parse(LabelId.Text);
        string roomDoorImage = DoorImage.Text;
        string guest = null;
        ViewModels.AdminRoomDetailsPageViewModel.CancelRoom(id, roomDoorImage, guest);
        var player = audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("sweeping.mp3"));
        player.Play();
        await DisplayAlert("Avbokning lyckad!", "Rummet �r st�dat och rensat p� guck och redo f�r n�sta g�st!", "Woop Woop!");

    }
}