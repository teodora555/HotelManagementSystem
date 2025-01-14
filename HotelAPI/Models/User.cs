using System.ComponentModel.DataAnnotations;
using HotelAPI.Models;

namespace HotelAPI
{

    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [RegularExpression("^(Admin|Client)$", ErrorMessage = "Role must be either 'Admin' or 'Client'.")]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Notification> Notifications { get; set; }

    }
}