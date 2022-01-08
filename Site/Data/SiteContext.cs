using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Site.Models;

namespace Site.Data
{
    public class SiteContext : DbContext
    {
        public SiteContext (DbContextOptions<SiteContext> options)
            : base(options)
        {
        }
        public DbSet<Site.Models.SiteOrder> SiteOrder { get; set; }
        public DbSet<Site.Models.Customer> Customer { get; set; }
        public DbSet<Site.Models.Personalization> Personalization { get; set; }
        public DbSet<Site.Models.Menu> Menu { get; set; }
      
       
    }
}
