namespace Lab12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTS()
        {
            OrdersProducts = new HashSet<OrdersProducts>();
        }

        [Required]
        [StringLength(15)]
        public string NAME { get; set; }

        public int PRICE { get; set; }

        [Required]
        [StringLength(5)]
        public string CURRENCY { get; set; }

        [Key]
        public int IDPRODUCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersProducts> OrdersProducts { get; set; }
    }
}
