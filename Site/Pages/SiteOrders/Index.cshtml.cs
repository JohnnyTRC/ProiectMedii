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
    public class IndexModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;

        public IndexModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        public IList<SiteOrder> SiteOrder { get;set; }

        public SiteOrderData SiteOrderD { get; set; }
        public int SiteOrderComandaSiteId { get; set; }
        public int PersonalizationID { get; set; }
        public async Task OnGetAsync(int? id, int? personalizationID)
        {
            SiteOrderD = new SiteOrderData();

            SiteOrderD.SiteOrders = await _context.SiteOrder
            .Include(b=>b.Menu)
             .Include(b => b.Customer)
            .Include(b => b.SiteOrderPersons)
            .ThenInclude(b => b.Personalization)
            .AsNoTracking()
            .OrderBy(b=>b.DataComanda)
            .ToListAsync();
            if (id != null)
            {
                SiteOrderComandaSiteId = id.Value;
                SiteOrder siteOrder = SiteOrderD.SiteOrders
                .Where(i => i.ComandaSiteId == id.Value).Single();
                SiteOrderD.Personalizations = siteOrder.SiteOrderPersons.Select(s => s.Personalization);
            }
        }
    }

}

