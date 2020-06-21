namespace Lab12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CUSTOMERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMERS()
        {
            ORDERS = new HashSet<ORDERS>();
        }

        [Key]
        public int IDCUSTOMER { get; set; }

        [Required]
        [StringLength(15)]
        public string FIRSTNAME { get; set; }

        [Required]
        [StringLength(15)]
        public string LASTNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string ADDRESS { get; set; }

        [Required]
        [StringLength(20)]
        public string PHONE { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        public int ZIP { get; set; }

        [Required]
        [StringLength(20)]
        public string REGION { get; set; }

        [Required]
        [StringLength(20)]
        public string COUNTRY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERS> ORDERS { get; set; }
    }
}
