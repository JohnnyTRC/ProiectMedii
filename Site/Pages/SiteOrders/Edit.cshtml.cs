using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Pages.SiteOrders
{
    public class EditModel : SiteOrderPersonsPageModel
    {
        private readonly Site.Data.SiteContext _context;

        public EditModel(Site.Data.SiteContext context)
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

            SiteOrder = await _context.SiteOrder
            .Include(b => b.Customer)
            .Include(b => b.SiteOrderPersons).ThenInclude(b => b.Personalization)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ComandaSiteId == id);

            if (SiteOrder == null)
            {
                return NotFound();
            }
            PopulateAssignedPersonalizationData(_context, SiteOrder);

            var customers = _context.Set<Customer>().Select(s => new
            {
                CustomerId = s.ClientId,
                description = string.Format("{0} {1}", s.NumeClient, s.PrenumeClient)
            }).ToList();

            ViewData["CustomerClientId"] = new SelectList(customers, "CustomerId", "description");


            var meniu = _context.Set<Menu>().Select(s => new
            {
                ProdusId = s.ProdusId,
                description = string.Format("{0} - {1} lei", s.NumeProdus, s.Pret)
            }).ToList();

            ViewData["MenuProdusId"] = new SelectList(meniu, "ProdusId", "description");


            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult>  OnPostAsync(int? id, string[]
selectedPersonalizations)
        {
            if (id == null)
            {
                return NotFound();
            }
            var siteOrderToUpdate = await _context.SiteOrder
            .Include(i => i.Customer)
            .Include(i => i.SiteOrderPersons)
            .ThenInclude(i => i.Personalization)
            .FirstOrDefaultAsync(s => s.ComandaSiteId == id);
            if (siteOrderToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<SiteOrder>(
            siteOrderToUpdate,
            "SiteOrder",
            i => i.Cantitate,  i => i.DataComanda, i=>i.Customer, i=>i.Menu))
            {
                UpdateSiteOrderPersons(_context, selectedPersonalizations, siteOrderToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateSiteOrderPersons(_context, selectedPersonalizations, siteOrderToUpdate);
            PopulateAssignedPersonalizationData(_context, siteOrderToUpdate);
            return Page();
        }
    }
}
