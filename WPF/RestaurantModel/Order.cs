namespace RestaurantModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int ComandaId { get; set; }

        public int ClientId { get; set; }

        public int ProdusId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
