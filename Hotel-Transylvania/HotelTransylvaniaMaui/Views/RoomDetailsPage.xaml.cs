namespace HotelTransylvaniaMaui.Views;

public partial class RoomDetailsPage : ContentPage
{
	public RoomDetailsPage()
	{
		InitializeComponent();
	}
    private void OnBackClicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();  
    }
    private void OnClickedBookRoom(object sender, EventArgs e)
    {
        
    }
}