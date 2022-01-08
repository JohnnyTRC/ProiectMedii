using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Site.Models
{
    public class Personalization
    {
        public int ID { get; set; }
        
        [Display(Name = "Personalizare")]
        public string NumePersonalizare { get; set; }
        public ICollection<SiteOrderPerson> SiteOrderPersons { get; set; }
    }
}
