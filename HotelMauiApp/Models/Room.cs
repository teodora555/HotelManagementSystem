using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMauiApp.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }

        [Required]
        [RegularExpression("^(Single|Double|Suite)$", ErrorMessage = "Type must be 'Single', 'Double', or 'Suite'.")]
        public string Type { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Price per night must be between 1 and 10,000.")]
        public decimal PricePerNight { get; set; }

        [Required]
        [RegularExpression("^(Available|Occupied)$", ErrorMessage = "Status must be 'Available' or 'Occupied'.")]
        public string Status { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
