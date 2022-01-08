using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;

        public DetailsModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer.FirstOrDefaultAsync(m => m.ClientId == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
