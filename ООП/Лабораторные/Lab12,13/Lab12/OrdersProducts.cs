namespace Lab12
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrdersProducts
    {
        public int ID { get; set; }

        public int? IDORDER { get; set; }

        public int? IDPRODUCT { get; set; }

        public int QUANTITY { get; set; }

        public virtual ORDERS ORDERS { get; set; }

        public virtual PRODUCTS PRODUCTS { get; set; }
    }
}
