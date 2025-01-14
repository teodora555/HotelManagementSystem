using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelWebApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }  

        [Required]
        public int Rating { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Message cannot exceed 250 characters.")]
        public string Comment { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }
    }
}
