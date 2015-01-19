using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LNDLWcfService.CodeFirstEntities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace LNDLWcfService.CodeFirstDAL
{
    public class ShipContext:DbContext
    {
        public DbSet<Shipping> Shipping { get; set; }

        public /*static*/ ShipContext()
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