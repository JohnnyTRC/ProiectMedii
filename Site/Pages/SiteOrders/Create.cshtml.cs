using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Site.Data;
using Site.Models;

namespace Site.Pages.SiteOrders
{
    public class CreateModel : SiteOrderPersonsPageModel
    {
        private readonly Site.Data.SiteContext _context;

        public CreateModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var customers = _context.Set<Customer>().Select(s => new
            {
                CustomerId = s.ClientId,
                description = string.Format("{0} {1}", s.NumeClient, s.PrenumeClient)
            }).ToList() ;

            ViewData["CustomerClientId"] = new SelectList(customers, "CustomerId", "description");


            var meniu = _context.Set<Menu>().Select(s => new
            {
                ProdusId = s.ProdusId,
                description = string.Format("{0} - {1} lei", s.NumeProdus, s.Pret)
            }).ToList();

            ViewData["MenuProdusId"] = new SelectList(meniu, "ProdusId", "description");

            var siteOrder = new SiteOrder();
            siteOrder.SiteOrderPersons = new List<SiteOrderPerson>();
            PopulateAssignedPersonalizationData(_context, siteOrder);


            return Page();
        }

        [BindProperty]
        public SiteOrder SiteOrder { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedPersonalizations)
        {
            var newSiteOrder = new SiteOrder();
            if (selectedPersonalizations != null)
            {
                newSiteOrder.SiteOrderPersons = new List<SiteOrderPerson>();
                foreach (var per in selectedPersonalizations)
                {
                    var perToAdd = new SiteOrderPerson
                    {
                        PersonalizationID = int.Parse(per)
                    };
                    newSiteOrder.SiteOrderPersons.Add(perToAdd);
                }
            }
            if (await TryUpdateModelAsync<SiteOrder>(
            newSiteOrder,
            "SiteOrder",
            i => i.Cantitate, i => i.DataComanda, i => i.CustomerClientId, i => i.MenuProdusId))
            {
                _context.SiteOrder.Add(newSiteOrder);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedPersonalizationData(_context, newSiteOrder);
            return Page();
        }
    }
}
