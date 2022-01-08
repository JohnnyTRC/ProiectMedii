using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Site.Models
{
    public class SiteOrder
    {
        [Key]
       
        public int ComandaSiteId { get; set; }
        [Range(1, 30, ErrorMessage = "Trebuie să conțină minim o comandă!")]
        public int Cantitate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Dată Comandă")]
        public DateTime DataComanda { get; set; }

        [Display(Name = "Nume Prenume Client")]
        public int CustomerClientId { get; set; }
      
        public Customer Customer { get; set; }
     
        public int MenuProdusId { get; set; }
        public Menu Menu { get; set; }
        [Display(Name = "Personalizări")]
        public ICollection<SiteOrderPerson> SiteOrderPersons { get; set; }

        
    }
}
