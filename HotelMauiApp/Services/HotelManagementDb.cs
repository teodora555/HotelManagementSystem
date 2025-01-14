using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelMauiApp.Models;
using HotelMauiApp.Services;

namespace HotelMauiApp.Services
{
    public class HotelManagementDb
    {
        private readonly IRestService<Room> _roomService;
        private readonly IRestService<Booking> _bookingService;
        private readonly IRestService<Notification> _notificationService;
        private readonly IRestService<Review> _reviewService;

        public HotelManagementDb(
            IRestService<Room> roomService,
            IRestService<Booking> bookingService,
            IRestService<Notification> notificationService,
            IRestService<Review> reviewService)
        {
            _roomService = roomService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _reviewService = reviewService;
        }

        // Camere libere
        public Task<List<Room>> GetAvailableRoomsAsync()
        {
            return _roomService.GetAllAsync();
        }

        // Rezervari
        public Task SaveBookingAsync(Booking booking)
        {
            return _bookingService.CreateAsync(booking);
        }

        // Notificari
        public Task<List<Notification>> GetNotificationsAsync()
        {
            return _notificationService.GetAllAsync();
        }

        // Recenzii - Salvare
        public Task SaveReviewAsync(Review review)
        {
            return _reviewService.CreateAsync(review);
        }

        // Recenzii - Obtinere
        public Task<List<Review>> GetReviewsAsync()
        {
            return _reviewService.GetAllAsync();
        }

        // Recenzii - Stergere
        public Task DeleteReviewAsync(int reviewId)
        {
            return _reviewService.DeleteAsync(reviewId);
        }

    }
}
