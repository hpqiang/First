//using LNDLWcfService.CodeFirstEntities;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Linq;
//using System.Web;

//namespace LNDLWcfService.CodeFirstDAL
//{
//    public class ProductContext:DbContext
//    {
//        public DbSet<Product> Products { get; set; }
//        public DbSet<ProductDetail> ProductDetails { get; set; }

//        public /*static*/ ProductContext()
//            : base("Hywin")
//        {
//            Console.WriteLine("Constructing ProductContext...");
//        }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            Console.WriteLine("Calling OnModelCreating for ProductContext...");
//            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LNDLWcfService.CodeFirstEntities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using LNDLWcfService.CodeFirstEntities.Common;
using LNDLWcfService.CodeFirstEntities.Ship;

namespace LNDLWcfService.CodeFirstDAL
{
    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("Hywin")
        {
            //Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            //Configuration.ValidateOnSaveEnabled = true;
            Console.WriteLine("Constructing CompanyContext...");
        }

        protected override void Dispose(bool disposing)
        {
            Console.WriteLine("Disposing ProductContext? " + disposing);
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        //public DbSet<Company> Companies { get; set; }
        //public DbSet<Office> Offices { get; set; }
        //public DbSet<Address> Addresses { get; set; }

        //public DbSet<Person> People { get; set; }

        //public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public DbSet<OrderFromCustomer> CustomerOrders { get; set; }
        public DbSet<OrderToSupplier> OrdersToSupplier { get; set; }
        //public DbSet<OrderToOrder> OrderToOrder { get; set; }

        //public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Shipping> Shippings { get; set; }
        //public DbSet<ShippingList> ShippingLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("Calling OnModelCreating for ProductContext...");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure office's ID as PK for Address
            //modelBuilder.Entity<Office>()
            //    .HasKey(e => e.Id);

            //// Configure office's as FK for Address
            //modelBuilder.Entity<Address>()
            //            .HasOptional(s => s.Office) // Mark Office is optional for Address
            //            .WithRequired(ad => ad.Address); // Create inverse relationship

            //modelBuilder.Entity<Photo>()
            //.Property(s => s.photoPath)
            //.IsRequired();

            //modelBuilder.Entity<Photo>()
            //    .HasRequired(p => p.Product)
            //    .WithMany(b => b.Photos)
            //    .HasForeignKey(p => p.FKProductID)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<OrderFromCustomer>()
            //.Property(s => s.purchaseOrderNumber)
            //.IsRequired();

            //modelBuilder.Entity<OrderFromCustomer>()
            //    .HasRequired(p => p.Product)
            //    .WithMany(b => b.customerOrders)
            //    .HasForeignKey(p => p.FKProductID)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<OrderToSupplier>()
            //    .Property(s => s.purchaseOrderNumber)
            //    .IsRequired();

            //modelBuilder.Entity<OrderToSupplier>()
            //    .HasRequired(p => p.Product)
            //    .WithMany(b => b.supplierOrders)
            //    .HasForeignKey(p => p.FKProductID)
            //    .WillCascadeOnDelete(true); ;

        }
    }
}