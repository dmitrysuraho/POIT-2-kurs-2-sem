namespace Lab12
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFirst : DbContext
    {
        public CodeFirst()
            : base("name=DbConnection")
        {
        }

        public virtual DbSet<CUSTOMERS> CUSTOMERS { get; set; }
        public virtual DbSet<ORDERS> ORDERS { get; set; }
        public virtual DbSet<OrdersProducts> OrdersProducts { get; set; }
        public virtual DbSet<PRODUCTS> PRODUCTS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.FIRSTNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.LASTNAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.ADDRESS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.PHONE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.EMAIL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.REGION)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.COUNTRY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ORDERS>()
                .Property(e => e.CURRENCY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTS>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTS>()
                .Property(e => e.CURRENCY)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
