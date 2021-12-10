using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonAddresses.Models;

namespace Final_Project_CIDM_3312.Pages.Person
{
    public class DeleteModel : PageModel
    {
        private readonly PersonAddresses.Models.Context _context;

        public DeleteModel(PersonAddresses.Models.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Addresses.FirstOrDefaultAsync(m => m.AddressID == id);

            if (Address == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Addresses.FindAsync(id);

            if (Address != null)
            {
                _context.Addresses.Remove(Address);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
