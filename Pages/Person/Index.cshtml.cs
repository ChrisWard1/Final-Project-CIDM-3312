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
    public class IndexModel : PageModel
    {
        private readonly PersonAddresses.Models.Context _context;

        public IndexModel(PersonAddresses.Models.Context context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public async Task OnGetAsync()
        {
            Address = await _context.Addresses.Include(s => s.PersonAddress).ThenInclude(sc => sc.Person).ToListAsync();
        }
    }
}
