using HotelMauiApp.Models;
using Microsoft.Maui.Controls;
using System;

namespace HotelMauiApp;

public partial class ReviewsPage : ContentPage
{
	public ReviewsPage()
	{
		InitializeComponent();
	}
    private async void OnSubmitReviewClicked(object sender, EventArgs e)
    {
        // Validare
        if (RatingPicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a rating.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(CommentEditor.Text))
        {
            await DisplayAlert("Error", "Please enter a comment.", "OK");
            return;
        }

        // Crearea recenziei
        var review = new Review
        {
            Id = 0, // ID-ul va fi generat automat
            Rating = RatingPicker.SelectedIndex + 1, // Ratingul selectat
            Comment = CommentEditor.Text,
            DateCreated = DateTime.Now
        };

        // Salvarea recenziei
        await App.Database.SaveReviewAsync(review);

        // Mesaj de succes
        await DisplayAlert("Success", "Your review has been submitted!", "OK");

        // Goleste campurile
        RatingPicker.SelectedIndex = -1;
        CommentEditor.Text = string.Empty;
    }
}