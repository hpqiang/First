using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;

namespace LNDLWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“HelloService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 HelloService.svc 或 HelloService.svc.cs，然后开始调试。
    public class LNDLWcfService : ILNDLWcfService
    {
        private Sample db = new Sample();

        public string GetMessage(string name)
        {
            return "Hello " + name;
        }


        //public List<OrderEntity> getOrderList()
        public List<OrderEntity> getOrderList()
        {
            //using (Sample db = new Sample())
            //{
                var query = (from o in db.tblOrder
                            select new OrderEntity()
                            {
                                id = o.id,
                                productType = o.productType,
                                productName = o.productName
                            }); //.Take(10);
                //Console.Write("query is "+query.ToList()+"<br />");
                return query.ToList();
            //}
        }

        public void saveOrder(OrderEntity o)
        {
            //Console.Write("Order: " + o.id +" "+o.productType + " "+o.productName + "\n");
            //using(Sample db = new Sample())
            //{
                tblOrder tblorder = new tblOrder();
                tblorder.id = o.id;
                tblorder.productType = o.productType;
                tblorder.productName = o.productName;
                db.Entry(tblorder).State = EntityState.Modified;
                db.SaveChanges();
            //}
            return;
        }
    }
}
