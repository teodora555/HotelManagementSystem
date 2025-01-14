using HotelMauiApp.Models;
using Microsoft.Maui.Controls;
using System;

namespace HotelMauiApp
{
    public partial class BookingsPage : ContentPage
    {
        public BookingsPage()
        {
            InitializeComponent();
        }

        private async void OnBookRoomClicked(object sender, EventArgs e)
        {
            // Validare
            if (RoomTypePicker.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Please select a room type.", "OK");
                return;
            }

            if (StartDatePicker.Date > EndDatePicker.Date)
            {
                await DisplayAlert("Error", "Check-out date must be after check-in date.", "OK");
                return;
            }

            // Crearea rezervării
            var booking = new Booking
            {
                Id = 0, // Generat automat în baza de date
                Name = "Default User", // Înlocuiește cu un nume din contextul aplicației
                Type = RoomTypePicker.SelectedItem.ToString(),
                CheckInDate = StartDatePicker.Date,
                CheckOutDate = EndDatePicker.Date
            };

            // Salvarea rezervării
            await App.Database.SaveBookingAsync(booking);
            await DisplayAlert("Success", "Booking made successfully!", "OK");
        }
    }
}