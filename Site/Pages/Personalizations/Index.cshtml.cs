using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Models;

namespace Site.Pages.Personalizations
{
    public class IndexModel : PageModel
    {
        private readonly Site.Data.SiteContext _context;

        public IndexModel(Site.Data.SiteContext context)
        {
            _context = context;
        }

        public IList<Personalization> Personalization { get;set; }

        public async Task OnGetAsync()
        {
            Personalization = await _context.Personalization.ToListAsync();
        }
    }
}
