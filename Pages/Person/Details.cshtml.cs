using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PersonAddresses.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project_CIDM_3312.Pages.Person
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly PersonAddresses.Models.Context _context;

        public DetailsModel(PersonAddresses.Models.Context context, ILogger<DetailsModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public Address Address{ get; set; }

        [BindProperty]
        public int AddressIdToDelete {get; set;}

        [BindProperty]
        [Display(Name = "Address")]
        public int AddressIdToAdd {get; set;}
        public List<Address> AllAddress {get; set;}
        public SelectList AddressDropDown {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data with .Include and .ThenInclude
            Address = await _context.Addresses.Include(s => s.PersonAddress).ThenInclude(sc => sc.Address).FirstOrDefaultAsync(m => m.AddressID == id);
            AllAddress = await _context.Addresses.ToListAsync();
            AddressDropDown = new SelectList(AllAddress, "AddressID", "Description");

            if (Address == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteCourseAsync(int? id)
        {
            _logger.LogWarning($"OnPost: PersonId {id}, DROP address {AddressIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Addresses.Include(s => s.PersonAddress).ThenInclude(sc => sc.Address).FirstOrDefaultAsync(m => m.AddressID == id);

            
            if (Address == null)
            {
                return NotFound();
            }

           PersonAddress courseToDrop = _context.PersonAddress.Find(AddressIdToDelete, id.Value);

            if (courseToDrop != null)
            {
                _context.Remove(courseToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Person NOT Dropped from Addressbook");
            }

            return RedirectToPage(new {id = id});
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: PersonId {id}, ADD address {AddressIdToAdd}");
            if (AddressIdToAdd == 0)
            {
                ModelState.AddModelError("CourseIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            Address = await _context.Addresses.Include(s => s.PersonAddress).ThenInclude(sc => sc.Address).FirstOrDefaultAsync(m => m.AddressID == id);            
            AllAddress = await _context.Addresses.ToListAsync();
            AddressDropDown = new SelectList(AllAddress, "AddressID", "Description");

            if (Address == null)
            {
                return NotFound();
            }

            if (!_context.PersonAddress.Any(sc => sc.AddressID == AddressIdToAdd && sc.PersonID == id.Value))
            {
                PersonAddress AddressToAdd = new PersonAddress { PersonID = id.Value, AddressID = AddressIdToAdd};
                _context.Add(AddressToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Person already entered in the address book");
            }

            // Best practice is that OnPost should redirect. This clears the form data.
            // FIXME: Can we just populate the routeValues from what is already there?
            return RedirectToPage(new {id = id});
        }
    }
}