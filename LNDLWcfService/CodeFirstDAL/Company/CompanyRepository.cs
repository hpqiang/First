using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class CompanyRepository:IDisposable
    {
        private CompanyContext companyContext = new CompanyContext();

        public List<T> GetItemAll<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = conditions == null ?
                companyContext.Set<T>() : companyContext.Set<T>().Where(conditions); // as IList<T>;
            return list.ToList();
        }

        public List<T> GetItemList<T>(Expression<Func<T, bool>> conditions, string AssociateClass) where T:class
        {
            var list = conditions == null ?
                    companyContext.Set<T>()
                    .Include(AssociateClass)
                    : companyContext.Set<T>()
                    .Include(AssociateClass)
                    .Where(conditions);
           return list.ToList();
        }

        public int GetItemCount<T,S>(Expression<Func<T, bool>> conditions) where T:class
        {
            var list = conditions == null ? companyContext.Set<T>() : companyContext.Set<T>().Where(conditions); // as IList<T>;
            return list.Count();
        }

        public void insertItem<T>(T item) where T:class
        {
            companyContext.Set<T>().Add(item);
            companyContext.SaveChanges();
        }

        public void updateItem<T>(T item) where T:class
        {
            Console.WriteLine("Type of T:" + typeof(T));
            var set = companyContext.Set<T>();
            set.Attach(item);

            companyContext.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
            companyContext.SaveChanges();
        }

        public void deleteItem<T>(T item) where T : class
        {   //MQ: To do: process the corresponding related parts? 
            companyContext.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
            companyContext.SaveChanges();
        }

        #region Disposable
        public void Dispose()
        {
            companyContext.Dispose();
        }
        #endregion
    }
}