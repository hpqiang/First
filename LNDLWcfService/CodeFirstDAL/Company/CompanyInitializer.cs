using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class CompanyInitializer: /*DropCreateDatabaseAlways<CompanyContext>*/DropCreateDatabaseIfModelChanges<CompanyContext>/**/
    {
        protected override void Seed(CompanyContext context)
        {
            //Console.WriteLine("Calling Seed...");

            //var addresses = new List<Address>
            //{
            //    new Address{Number="41",Street="Aileen Road1",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            //    new Address{Number="42",Street="Aileen Road2",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            //    new Address{Number="43",Street="Aileen Road3",City="Thornhill",State="ON",Country="Canada",ZipCode="L3T 5P7"},
            //};

            ////addresses.ForEach(s => context.Addresses.Add(s));
            ////context.SaveChanges();

            //var companies = new List<Company>
            //{
            //    new Company{BriefName="HW",FullName="Hywin HiTech Ltd.",companyType=(CompanyType)0,Phone="416-888-6666",Email="hpqiang@gmail.com", WebSite="localhost",DateSince=DateTime.Parse("2014-10-11"),IsActive=true},
            //    new Company{BriefName="YH",FullName="YongHe Textile Ltd.",companyType=(CompanyType)1,Phone="86057233338888",Email="info@yh.com", WebSite="localhost",DateSince=DateTime.Parse("2013-10-11"),IsActive=true},
            //    new Company{BriefName="QC",FullName="QuiltCraft Curtain & Bedding Ltd.",companyType=(CompanyType)2,Phone="503-917-3333",Email="admin@quiltcraft.com", WebSite="localhost",DateSince=DateTime.Parse("2014-10-11"),IsActive=true}
            //};
            ////DateSince=DateTime.Parse("2014-10-11"),
            ////DateSince=DateTime.Parse("2012-10-11"),
            ////DateSince=DateTime.Parse("2013-10-11"),
            //companies.ForEach(s => context.Companies.Add(s));
            //context.SaveChanges(); var persons = new List<Person>
            //{
            //    new Person{FirstName="Mike",LastName="Qiang",ManagerId=0,MobilePhone="416-845-1823",Email="hpqiang@hotmail.com",photo="MQ"},
            //    new Person{FirstName="Wenli",LastName="Wang",ManagerId=1,MobilePhone="418-845-1823",Email="wlwang18@hotmail.com",photo="WL"},
            //    new Person{FirstName="Hua",LastName="Zhang",ManagerId=0,MobilePhone="138197190453",Email="hz@163.com",photo=null},
            //    new Person{FirstName="JingSheng",LastName="Wang",ManagerId=3,MobilePhone="1391971333353",Email="jswang@163.com",photo=null},
            //    new Person{FirstName="John",LastName="Smith",ManagerId=0,MobilePhone="978-222-3234",Email="jsmith@quiltcraft.com",photo=null}
            //};

            //persons.ForEach(s => context.Contacts.Add(s));
            //context.SaveChanges();

           }
    }
}