namespace Lab12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDERS()
        {
            OrdersProducts = new HashSet<OrdersProducts>();
        }

        public int? IDCUSTOMER { get; set; }

        [Key]
        public int IDORDER { get; set; }

        [Column(TypeName = "date")]
        public DateTime CREATEDAT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SHIPPEDAT { get; set; }

        [Required]
        [StringLength(10)]
        public string STATUS { get; set; }

        [Required]
        [StringLength(5)]
        public string CURRENCY { get; set; }

        public virtual CUSTOMERS CUSTOMERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersProducts> OrdersProducts { get; set; }
    }
}
