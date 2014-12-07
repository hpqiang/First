using LNDLWcfService.CodeFirstDAL;
using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstRepository
{
    public class CompanyRepository
    {
        public List<Person> getCompanyContacts()
        {
            CompanyContext cc = new CompanyContext();
            return cc.Contacts.Include("Contacts").ToList();
        }
    }
}