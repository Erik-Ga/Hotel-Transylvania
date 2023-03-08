namespace HotelTransylvaniaMaui.Views;

public partial class AdminRoomDetailsPage : ContentPage
{
	public AdminRoomDetailsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.AdminRoomDetailsPageViewModel();
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
}