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
    public class HywinContext : DbContext
    {
        public HywinContext()
            : base("Hywin")
        {
            //Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            //Configuration.ValidateOnSaveEnabled = true;
            Console.WriteLine("Constructing HywinContext...");
        }

        protected override void Dispose(bool disposing)
        {
            Console.WriteLine("Disposing HywinContext? " + disposing);
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Address> Addresses { get; set; }

        //public DbSet<CompanyProduct> CompanyProducts { get; set; }

        //public DbSet<Contact> Contacts { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<OrderFromCustomer> CustomerOrders { get; set; }
        public DbSet<OrderToSupplier> OrdersToSupplier { get; set; }
        //public DbSet<OrderToOrder> OrderToOrder { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<Shipping> Shippings { get; set; }
        //public DbSet<ShippingList> ShippingLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("Calling OnModelCreating for HywinContext...");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure office's ID as PK for Address
            //modelBuilder.Entity<Office>()
            //    .HasKey(e => e.Id);

            //// Configure office's as FK for Address
            //modelBuilder.Entity<Address>()
            //            .HasOptional(s => s.Office) // Mark Office is optional for Address
            //            .WithRequired(ad => ad.Address); // Create inverse relationship

            //modelBuilder.Entity<Office>()
            //.Property(s => s.buildingName)
            //.IsRequired();

            //modelBuilder.Entity<Office>()
            //    .HasRequired(p => p.Company)
            //    .WithMany(b => b.Offices)
            //    .HasForeignKey(p => p.FKCompanyID)
            //    .WillCascadeOnDelete(true);

            //modelBuilder.Entity<Person>()
            //.Property(s => s.FirstName)
            //.IsRequired();

            //modelBuilder.Entity<Person>()
            //    .HasRequired(p => p.Office)
            //    .WithMany(b => b.People)
            //    .HasForeignKey(p => p.FKOfficeID)
            //    .WillCascadeOnDelete(true); ;
        }
    }
}