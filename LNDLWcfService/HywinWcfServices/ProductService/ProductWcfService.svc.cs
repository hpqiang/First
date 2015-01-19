using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using LNDLWcfService.CodeFirstEntities;
using LNDLWcfService.CodeFirstDAL;

namespace LNDLWcfService.HywinWcfServices.ProductService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class ProductWcfService : IProductWcfService
    {
        public List<Product> getProduct(int start, int amount, string search, string sortOrder)
        {
            HywinRepository hr = new HywinRepository();
            List<Product> lp;

            if (!String.IsNullOrEmpty(search))
            {
                lp = hr.GetItemList<Product>(
                    (s => s.Name.ToUpper().Contains(search.ToUpper())),
                    "Photos");
            }
            else
            {
                lp = hr.GetItemList<Product>(null, "Photos");
            }

            if (sortOrder == "name_desc")
            {
                lp = lp
                    .OrderByDescending(s => s.Name)
                    .Skip(start)
                    .Take(amount).ToList();
            }
            else
            {
                lp = lp
                    .OrderBy(s => s.Name)
                    .Skip(start)
                    .Take(amount).ToList();
            }

            //List<Person> lp = new List<Person>();
            //lp = cr.GetItemAll<Person>(null);
            //foreach (var d in lc)
            //{
            //    Console.WriteLine(" ID = " + d.Id
            //        + " Name = " + d.BriefName
            //        + " Full Name = " + d.FullName
            //        + " Company Type= " + d.companyType
            //        //+ " \n Address = " + c.FirstOrDefault(x=>x.Addresses.Street == d.Addresses.Street).Addresses.Street
            //        );
            //    if (d.Offices.Count > 0)
            //    {
            //        foreach (var x in d.Offices)
            //        {
            //            List<Person> selectlp = new List<Person>();
            //            foreach (var y in x.People)
            //            {
            //                Person p;
            //                p = lp.Find(s => s.FKOfficeID == x.Id);
            //                selectlp.Add(p);
            //                Console.WriteLine(" Offices = " + x.Id
            //                                        + " " + x.buildingName
            //                    + "Contact: " + p.FirstName + " " + p.LastName
            //                    );
            //            }
            //            x.People = selectlp;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No person in Office: ");// + d.Offices..buildingName);
            //    }

            //}

            Console.WriteLine("About to return from ProductWcfService class...");
            return lp;
        }

        public int getProductTotalNumber(string search)
        {
            int count = 0;
            HywinRepository hr = new HywinRepository();

            if (!String.IsNullOrEmpty(search))
            {
                return count = hr.GetItemCount<Product, int>(
                    (s => s.Name.ToUpper().Contains(search.ToUpper()))
                    );
            }
            else
            {
                return count = hr.GetItemCount<Product, int>(null);
            }
        }

        public void insertProduct(Product product)
        {
            HywinRepository hr = new HywinRepository();
            hr.insertItem<Product>(product);
        }

        public void updateProduct(Product product)
        {
            HywinRepository hr = new HywinRepository();
            hr.updateItem<Product>(product);
        }

        public void deleteProduct(Product product)
        {
            HywinRepository hr = new HywinRepository();
            hr.deleteItem<Product>(product);
        }
    }
}
