using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Models
{
    public class SiteOrderPerson
    {
        public int ID { get; set; }
        public int SiteOrderComandaSiteId { get; set; }
        public SiteOrder SiteOrder { get; set; }
        public int PersonalizationID { get; set; }
        public Personalization Personalization { get; set; }
    }
}
