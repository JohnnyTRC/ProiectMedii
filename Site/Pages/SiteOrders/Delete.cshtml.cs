using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Pages.SiteOrders
{
    public class DeleteModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;

        public DeleteModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SiteOrder SiteOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteOrder = await _context.SiteOrder.FirstOrDefaultAsync(m => m.ComandaSiteId == id);

            if (SiteOrder == null)
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

            SiteOrder = await _context.SiteOrder.FindAsync(id);

            if (SiteOrder != null)
            {
                _context.SiteOrder.Remove(SiteOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
