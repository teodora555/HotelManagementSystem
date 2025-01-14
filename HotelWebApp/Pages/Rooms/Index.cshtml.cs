using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelWebApp.Data;
using HotelWebApp.Models;

namespace HotelWebApp.Pages.Rooms
{
    public class IndexModel : PageModel
    {
        private readonly HotelWebAppContext _context;

        public IndexModel(HotelWebAppContext context)
        {
            _context = context;
        }

      
        public IList<Room> Rooms { get; set; } = new List<Room>();

        public async Task OnGetAsync()
        {
            Rooms = await _context.Room
                .Include(r => r.Bookings)
                .ThenInclude(b => b.User)
                .ToListAsync();

            Console.WriteLine($"Number of rooms retrieved: {Rooms.Count}");
        }

    }
}
