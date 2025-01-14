using System.ComponentModel.DataAnnotations;

namespace HotelAPI.Models
{
    public class Notification
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Message cannot exceed 250 characters.")]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime SentDate { get; set; }

        public User User { get; set; }
    }
}
