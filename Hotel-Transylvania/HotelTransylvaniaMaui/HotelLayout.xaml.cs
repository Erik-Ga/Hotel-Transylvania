namespace HotelTransylvaniaMaui;

public partial class HotelLayout : ContentPage
{
	public HotelLayout()
	{
		InitializeComponent();
	}
    private async void OnZombieDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ZombieDoorPage());
    }
    private async void OnSkeletonDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SkeletonDoorPage());
    }
    private async void OnGhostDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GhostDoorPage());
    }
    private async void OnVampireDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VampireDoorPage());
    }
    private async void OnTrollDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new TrollDoorPage());
    }
    private async void OnMummyDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MummyDoorPage());
    }
    private async void OnWitchDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WitchDoorPage());
    }
    private async void OnWerewolfDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WerewolfDoorPage());
    }
    private async void OnDragonDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DragonDoorPage());
    }
    private async void OnDevilDoorClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DevilDoorPage());
    }
}