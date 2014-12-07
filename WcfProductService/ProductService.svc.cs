using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfProductService.EFDAL;

namespace WcfProductService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 Service1.svc 或 Service1.svc.cs，然后开始调试。
    public class ProductService : IProductService
    {
        private ProductEntities p = new ProductEntities();

        public List<tblProduct> GetProductEntities()
        {
            Console.WriteLine("11111111");
            var x = from product in p.tblProduct
                    select product;
            Console.WriteLine("About to return....");
            return x.ToList();
            //return null;
        }
        public List<tblCurtain> GetCurtainEntities()
        {
            var x = from c in p.tblCurtain
                    select c;
            return x.ToList();
        }
        public List<tblFabric> GetFabricEntities()
        {
            var x = from f in p.tblFabric
                    select f;
            return x.ToList();
        }
        public List<tblBed> GetBedEntities()
        {
            var x = from b in p.tblBed
                    select b;
            return x.ToList();
        }

        public string GetMessage(string name)
        {
            //ProductEntities p = new ProductEntities();
            //return p;
            return "Hello " + name;
        }

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
