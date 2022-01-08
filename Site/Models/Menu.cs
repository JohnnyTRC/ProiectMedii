using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Models
{
    public class Menu
    {
        [Key]
        public int ProdusId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nume Produs")]
        public string NumeProdus { get; set; }
        [Display(Name = "Preț")]
        public double Pret { get; set; }

        [Column(TypeName = "text")]
        public string Descriere { get; set; }

        [Column(TypeName = "image")]
        public byte[] PozaProdus { get; set; }

        public  ICollection<SiteOrder> SiteOrders { get; set; }
    }
}
