namespace HotelMauiApp;

public partial class NotificationsPage : ContentPage
{
	public NotificationsPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtine notificarile din baza de date
        var notifications = await App.Database.GetNotificationsAsync();
        NotificationsListView.ItemsSource = notifications;
    }
}