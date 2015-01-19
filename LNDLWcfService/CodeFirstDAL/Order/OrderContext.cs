using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using LNDLWcfService.CodeFirstEntities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LNDLWcfService.CodeFirstDAL
{
    public class OrderContext:DbContext
    {
        public DbSet<OrderFromCustomer> OrderFromCustomer { get; set; }
        public DbSet<OrderToSupplier> OrderToSupplier { get; set; }
        //public DbSet<OrderToOrder> OrderToOrder { get; set; }

        public /*static*/ OrderContext()
            : base("Hywin")
        {
            Console.WriteLine("Constructing OrderContext...");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("Calling OnModelCreating for OrderContext...");
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}