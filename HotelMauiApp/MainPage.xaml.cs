namespace HotelMauiApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnBookingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingsPage());
        }

        private async void OnReviewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewsPage());
        }
    }
}
