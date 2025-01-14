using HotelMauiApp.Services;
using HotelMauiApp.Models;

namespace HotelMauiApp;

public partial class RoomsPage : ContentPage
{
	public RoomsPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtine camerele disponibile din baza de date
        var rooms = await App.Database.GetAvailableRoomsAsync();
        RoomsListView.ItemsSource = rooms;
    }

    private void RoomsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Room selectedRoom)
        {
            DisplayAlert("Room Selected", $"You selected room {selectedRoom.RoomNumber}", "OK");
        }
    }

    private async void OnMakeBookingClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new BookingsPage());
    }

    private async void OnRoomBookingClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var roomId = button?.CommandParameter;

        if (roomId != null)
        {
            var bookingPage = new BookingsPage();
            await Navigation.PushAsync(bookingPage);
        }
    }
}