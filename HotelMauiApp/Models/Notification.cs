using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelMauiApp.Models
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
    }
}
