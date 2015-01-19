//using LNDLWcfService.CodeFirstEntities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace LNDLWcfService.CodeFirstDAL
//{
//    public class ProductRepository
//    {
//        public List<Product> GetProducts()
//        {
//            ProductContext productContext = new ProductContext();

//            List<Product> p = productContext.Products
//                //.Include("Details")
//                .ToList();

//            foreach (var d in p)
//            {
//                Console.WriteLine(" ID = " + p.FirstOrDefault(x => x.Id == d.Id).Id
//                    + " Name = " + p.FirstOrDefault(x => x.Name == d.Name).Name
//                    + " Color = " + p.FirstOrDefault(x => x.Color == d.Color).Color
//                    );
//                //foreach (var x in d.Details)
//                //{
//                //    Console.WriteLine(" Details = " + d.Details.FirstOrDefault(a => a.Color == x.Color).Color
//                //        + " " + d.Details.FirstOrDefault(a => a.Size == x.Size).Size
//                //        );
//                //}
//            }
//            Console.WriteLine("About to return from ProductRepsitory class...");
//            return p;
//        }

//        public void insertProduct(Product p)
//        {
//            ProductContext productContext = new ProductContext();

//            productContext.Products.Add(p);
//            productContext.SaveChanges();
//        }

//        public void updateProduct(Product p)
//        {
//            ProductContext productContext = new ProductContext();

//            //db.Entry(course).State = EntityState.Modified;
//            //db.SaveChanges();
//            productContext.Entry(p).State = System.Data.Entity.EntityState.Modified;
//            productContext.SaveChanges();
//        }

//        public List<ProductDetail> GetProductDetails()
//        {
//            ProductContext productContext = new ProductContext();

//            List<ProductDetail> pdl = productContext.ProductDetails
//                .ToList();

//            foreach (var pd in pdl)
//            {
//                Console.WriteLine(" ID = " + pd.Id
//                    + " Color = " + pd.Color
//                    + " Size = " + pd.Size
//                    );
//            }
//            Console.WriteLine("About to return from ProductRepsitory class for productDetails...");
//            return pdl;
//        }

//        public void insertProductDetail(ProductDetail pd)
//        {
//            ProductContext productContext = new ProductContext();

//            productContext.ProductDetails.Add(pd);
//            productContext.SaveChanges();
//        }

//        public void updateProductDetail(ProductDetail pd)
//        {
//            ProductContext productContext = new ProductContext();

//            //db.Entry(course).State = EntityState.Modified;
//            //db.SaveChanges();
//            productContext.Entry(pd).State = System.Data.Entity.EntityState.Modified;
//            productContext.SaveChanges();
//        }
//    }
//}

using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LNDLWcfService.CodeFirstDAL
{
    public class ProductRepository : IDisposable
    {
        private ProductContext productContext = new ProductContext();

        public List<T> GetItemAll<T>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = conditions == null ?
                productContext.Set<T>() : productContext.Set<T>().Where(conditions); // as IList<T>;
            return list.ToList();
        }

        public List<T> GetItemList<T>(Expression<Func<T, bool>> conditions, string AssociateClass) where T : class
        {
            var list = conditions == null ?
                    productContext.Set<T>()
                    .Include(AssociateClass)
                    : productContext.Set<T>()
                    .Include(AssociateClass)
                    .Where(conditions);
            return list.ToList();
        }

        public int GetItemCount<T, S>(Expression<Func<T, bool>> conditions) where T : class
        {
            var list = conditions == null ? productContext.Set<T>() : productContext.Set<T>().Where(conditions); // as IList<T>;
            return list.Count();
        }

        public void insertItem<T>(T item) where T : class
        {
            productContext.Set<T>().Add(item);
            productContext.SaveChanges();
        }

        public void updateItem<T>(T item) where T : class
        {
            Console.WriteLine("Type of T:" + typeof(T));
            var set = productContext.Set<T>();
            set.Attach(item);

            productContext.Entry<T>(item).State = System.Data.Entity.EntityState.Modified;
            productContext.SaveChanges();
        }

        public void deleteItem<T>(T item) where T : class
        {   //MQ: To do: process the corresponding related parts? 
            productContext.Entry<T>(item).State = System.Data.Entity.EntityState.Deleted;
            productContext.SaveChanges();
        }

        #region Disposable
        public void Dispose()
        {
            productContext.Dispose();
        }
        #endregion
    }
}
