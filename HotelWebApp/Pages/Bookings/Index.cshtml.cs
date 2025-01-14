using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelWebApp.Data;
using HotelWebApp.Models;

namespace HotelWebApp.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly HotelWebAppContext _context;

        public IndexModel(HotelWebAppContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = new List<Booking>();

        public async Task OnGetAsync()
        {
            if (_context.Booking != null)
            {
                Booking = await _context.Booking
                 .Include(b => b.Room)
                 .Include(b => b.User)
                 .ToListAsync();

            }
        }
    }
}
