using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class CompanyRepository
    {
        public List<Company> GetCompanies()
        {
            CompanyContext companyContext = new CompanyContext();

            List<Company> c = companyContext.Companies
                .Include("Addresses")
                .Include("Contacts")
                .ToList();

            foreach(var d in c)
            {
                Console.WriteLine(" ID = " + c.FirstOrDefault(x => x.Id == d.Id).Id 
                    + " Name = " + c.FirstOrDefault(x => x.BriefName == d.BriefName).BriefName
                    + " Full Name = " + c.FirstOrDefault(x=>x.FullName == d.FullName).FullName
                    + " \n Address = " + c.FirstOrDefault(x=>x.Addresses.Street == d.Addresses.Street).Addresses.Street
                    );
                foreach (var x in d.Contacts)
                {
                    Console.WriteLine(" Contact Person = " + d.Contacts.FirstOrDefault(a => a.FirstName == x.FirstName).FirstName
                        + " " + d.Contacts.FirstOrDefault(a => a.LastName == x.LastName).LastName
                        );
                }
            }
            Console.WriteLine("About to return from CompanyRepsitory class...");
            return c;
        }

        public void insertCompany(Company c)
        {
            CompanyContext companyContext = new CompanyContext();

            companyContext.Companies.Add(c);
            companyContext.SaveChanges();
        }

        public void updateCompany(Company c)
        {
            CompanyContext companyContext = new CompanyContext();

            //db.Entry(course).State = EntityState.Modified;
            //db.SaveChanges();
            companyContext.Entry(c).State = System.Data.Entity.EntityState.Modified;
            companyContext.SaveChanges();
        }

    }
}