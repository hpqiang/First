using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class CompanyContext:DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> Contacts { get; set; }

        public /*static*/ CompanyContext()
            : base("Hywin")
        {
            Console.WriteLine("Constructing CompanyContext...");
            //this.Database.Initialize(true);
            //this.Database.Delete();
            //this.Database.Create();
            //SaveChanges();

            //Database.SetInitializer<CompanyContext>(new CompanyInitializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Console.WriteLine("Calling OnModelCreating...");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Company>()
            //    .HasMany(c => c.Contacts);
                //.WithMany(i => i.Courses);
                //.Map(t => t.MapLeftKey("CourseID")
                //    .MapRightKey("InstructorID")
                //    .ToTable("CourseInstructor")
                //    );
            //modelBuilder.Entity<Department>().MapToStoredProcedures();
        }

    }

}