using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelWebApp.Data;
using HotelWebApp.Models;

namespace HotelWebApp.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly HotelWebAppContext _context;

        public CreateModel(HotelWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Room Room { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Adaugă camera în contextul bazei de date
            _context.Room.Add(Room);
            // Salvează schimbările
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        

    }
}


