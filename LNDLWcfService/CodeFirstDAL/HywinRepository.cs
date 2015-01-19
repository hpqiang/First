//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//using LNDLWcfService.CodeFirstEntities;

//namespace LNDLWcfService.CodeFirstDAL
//{
//    //public class HywinRepository
//    //{
//    //    private HywinContext hywinContext = new HywinContext();

//    //    public List<Company> GetCompanies()
//    //    {
//    //        //CompanyContext companyContext = new CompanyContext();
//    //        //HywinContext hywinContext = new HywinContext();

//    //        List<Company> c = hywinContext.Companies //companyContext.Companies
//    //            //.Include("Offices")
//    //            //.Include("Contacts")
//    //            .ToList();

//    //        foreach (var d in c)
//    //        {
//    //            Console.WriteLine(" ID = " + c.FirstOrDefault(x => x.Id == d.Id).Id
//    //                + " Name = " + c.FirstOrDefault(x => x.BriefName == d.BriefName).BriefName
//    //                + " Full Name = " + c.FirstOrDefault(x => x.FullName == d.FullName).FullName
//    //                //+ " Company Type= " + c.FirstOrDefault(x => x.companyType == d.companyType).companyType
//    //                //+ " \n Address = " + c.FirstOrDefault(x=>x.Addresses.Street == d.Addresses.Street).Addresses.Street
//    //                );
//    //            //foreach (var x in d.Contacts)
//    //            //{
//    //            //    Console.WriteLine(" Contact Person = " + d.Contacts.FirstOrDefault(a => a.FirstName == x.FirstName).FirstName
//    //            //        + " " + d.Contacts.FirstOrDefault(a => a.LastName == x.LastName).LastName
//    //            //        );
//    //            //}
//    //        }

//    //        Console.WriteLine("About to return from HywinRepsitory class...");
//    //        return c;
//    //    }

//    //    public void insertCompany(Company c)
//    //    {
//    //        companyContext.Companies.Add(c);
//    //        companyContext.SaveChanges();
//    //    }

//    //    public void updateCompany(Company c)
//    //    {
//    //        companyContext.Entry(c).State = System.Data.Entity.EntityState.Modified;
//    //        companyContext.SaveChanges();
//    //    }

//    //}
//}

using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class HywinRepository : IDisposable
    {
        private HywinContext hywinContext = new HywinContext();

        public List<T> GetItemAll<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = conditions == null ?
                hywinContext.Set<T>() : hywinContext.Set<T>().Where(conditions); // as IList<T>;
            return list.ToList();
        }

        public List<T> GetItemList<T>(Expression<Func<T, bool>> conditions, string AssociateClass=null) where T : class
        {
            if (!String.IsNullOrEmpty(AssociateClass))
            {
                var list = conditions == null ?
                        hywinContext.Set<T>()
                        .Include(AssociateClass)
                        : hywinContext.Set<T>()
                        .Include(AssociateClass)
                        .Where(conditions);
                return list.ToList();
            }
            else
            {
                var list = conditions == null ?
                        hywinContext.Set<T>()
                        : hywinContext.Set<T>()
                        .Where(conditions);
                return list.ToList();
            }
        }

        public int GetItemCount<T, S>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = conditions == null ? hywinContext.Set<T>() : hywinContext.Set<T>().Where(conditions); // as IList<T>;
            return list.Count();
        }

        public void insertItem<T>(T item) where T : class
        {
            hywinContext.Set<T>().Add(item);
            hywinContext.SaveChanges();
        }

        public void updateItem<T>(T item) where T : class
        {
            Console.WriteLine("Type of T:" + typeof(T));
            var set = hywinContext.Set<T>();
            set.Attach(item);

            hywinContext.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
            hywinContext.SaveChanges();
        }

        public void deleteItem<T>(T item) where T : class
        {   //MQ: To do: process the corresponding related parts? 
            hywinContext.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
            hywinContext.SaveChanges();
        }

        #region Disposable
        public void Dispose()
        {
            hywinContext.Dispose();
        }
        #endregion
    }
}