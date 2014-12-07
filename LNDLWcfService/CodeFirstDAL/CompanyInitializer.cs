using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class CompanyInitializer: /*DropCreateDatabaseAlways<CompanyContext> */DropCreateDatabaseIfModelChanges<CompanyContext>/**/
    {
        protected override void Seed(CompanyContext context)
        {
            Console.WriteLine("Calling Seed...");

            var addresses = new List<Address>
            {
                new Address{Number="41",Street="Aileen Road",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
                new Address{Number="42",Street="Aileen Road",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
                new Address{Number="43",Street="Aileen Road",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            };

            addresses.ForEach(s => context.Addresses.Add(s));
            context.SaveChanges();

            var companies = new List<Company>
            {
                new Company{BriefName="HW",FullName="Hywin HiTech Ltd.",Type="Owner",Phone="416-888-6666",Email="hpqiang@gmail.com", WebSite="localhost",DateSince=DateTime.Parse("2014-10-11"),IsActive=true,AddressId=1},
                new Company{BriefName="YH",FullName="YongHe Textile Ltd.",Type="Supplier",Phone="86057233338888",Email="info@yh.com", WebSite="localhost",DateSince=DateTime.Parse("2012-10-11"),IsActive=true,AddressId=2},
                new Company{BriefName="QC",FullName="QuiltCraft Curtain & Bedding Ltd.",Type="Customer",Phone="503-917-3333",Email="admin@quiltcraft.com", WebSite="localhost",DateSince=DateTime.Parse("2013-10-11"),IsActive=true,AddressId=3}
            };

            companies.ForEach(s => context.Companies.Add(s));
            context.SaveChanges(); var persons = new List<Person>
            {
                new Person{FirstName="Mike",LastName="Qiang",Role="Sales",ManagerId=0,CompanyPhone="647-931-1907",MobilePhone="416-845-1823",Email="hpqiang@hotmail.com",photo="MQ",companyId=1},
                new Person{FirstName="Wenli",LastName="Wang",Role="Employee",ManagerId=1,CompanyPhone="648-931-1907",MobilePhone="418-845-1823",Email="wlwang18@hotmail.com",photo="WL",companyId=1},
                new Person{FirstName="Hua",LastName="Zhang",Role="Manager",ManagerId=0,CompanyPhone="860572-33338888",MobilePhone="138197190453",Email="hz@163.com",photo=null,companyId=2},
                new Person{FirstName="JingSheng",LastName="Wang",Role="Manufacturere",ManagerId=3,CompanyPhone="860572-66668888",MobilePhone="1391971333353",Email="jswang@163.com",photo=null,companyId=2},
                new Person{FirstName="John",LastName="Smith",Role="Buyer",ManagerId=0,CompanyPhone="095-333-5555",MobilePhone="978-222-3234",Email="jsmith@quiltcraft.com",photo=null,companyId=3}
            };

            persons.ForEach(s => context.Contacts.Add(s));
            context.SaveChanges();

           }
    }
}