using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Pages.Menus
{
    public class DeleteModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;

        public DeleteModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Menu Menu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Menu = await _context.Menu.FirstOrDefaultAsync(m => m.ProdusId == id);

            if (Menu == null)
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

            Menu = await _context.Menu.FindAsync(id);

            if (Menu != null)
            {
                _context.Menu.Remove(Menu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
