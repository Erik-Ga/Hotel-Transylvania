using HotelTransylvaniaMaui.Models;

namespace HotelTransylvaniaMaui.Views;

public partial class RoomDetailsPage : ContentPage
{
	public RoomDetailsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.RoomDetailsPageViewModel();
	}
    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();  
    }
    private void OnClickedBookRoom(object sender, EventArgs e)
    {
        var guest = GuestEntry.Text;
        var roomName = LabelRoomName.Text;
        var roomDoorImage = DoorImage.Text;
        ViewModels.RoomDetailsPageViewModel.UpdateRoom(roomName, guest, roomDoorImage);
    }
}