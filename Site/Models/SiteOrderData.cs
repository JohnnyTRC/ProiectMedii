using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class SiteOrderData
    {
        public IEnumerable<SiteOrder> SiteOrders { get; set; }
        public IEnumerable<Personalization> Personalizations { get; set; }
        public IEnumerable<SiteOrderPerson> SiteOrderPersons { get; set; }
    }
}
