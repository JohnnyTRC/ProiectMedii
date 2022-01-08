using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Site.Models
{
    public class Customer
    {
        [Key]
        public int ClientId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nume Client")]
        public string NumeClient { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Prenume Client")]
        public string PrenumeClient { get; set; }

        [Required]
        [Display(Name = "Nr. Telefon"), StringLength(10, MinimumLength = 10, ErrorMessage = "Număr de telefon invalid!")]
        public string NrTelefon { get; set; }

        public ICollection<SiteOrder> SiteOrders { get; set; }
    }
}
