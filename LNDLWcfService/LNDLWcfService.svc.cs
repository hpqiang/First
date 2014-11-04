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
            List<OrderEntity> l = new List<OrderEntity>();

            var x = from o in db.tblOrder
                    select o;

            foreach(var y in x)
            {
                OrderEntity order = new OrderEntity();

                order.id = y.id;
                order.productType = y.productType;
                order.productName = y.productName;
                order.startDate = y.startDate;
                order.expectDate = y.expectDate;
                order.clientPOFilePath = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A")? "(TBD)" : y.clientPOFile.ToString().Substring(0, y.clientPOFile.ToString().LastIndexOf('/'));
                order.clientPOFileName = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(Empty)" : y.clientPOFile.ToString().Substring(y.clientPOFile.ToString().LastIndexOf('/') + 1, y.clientPOFile.ToString().Length - y.clientPOFile.ToString().LastIndexOf('/') - 1);

                order.vendorPOFilePath = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A")? "(TBD)" : y.vendorPOFile.ToString().Substring(0, y.vendorPOFile.ToString().LastIndexOf('/'));
                order.vendorPOFileName = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(Empty)" : y.vendorPOFile.ToString().Substring(y.vendorPOFile.ToString().LastIndexOf('/') + 1, y.vendorPOFile.ToString().Length - y.vendorPOFile.ToString().LastIndexOf('/') - 1);
                l.Add(order);
            }

            return l;
            //using (Sample db = new Sample())
            //{
                var query = (from o in db.tblOrder
                            select  new OrderEntity()
                            {
                                id = o.id,
                                productType = o.productType,
                                productName = o.productName,
                                startDate = o.startDate,
                                expectDate = o.expectDate,
                                clientPOFilePath = o.clientPOFile,// == null ? "(TBD)" : o.clientPOFile.ToString().Substring(0, o.clientPOFile.ToString().LastIndexOf('/')-1),
                                //clientPOFileName = o.clientPOFile == null ? "(Empty)" : o.clientPOFile.ToString().Substring(o.clientPOFile.ToString().LastIndexOf('/') + 1, o.clientPOFile.ToString().Length),
                                vendorPOFilePath = o.vendorPOFile // == null ? "(TBD)" : o.vendorPOFile.ToString().Substring(0, o.vendorPOFile.ToString().LastIndexOf('/')),
                                //vendorPOFileName = o.vendorPOFile == null ? "(Empty)" : o.vendorPOFile.ToString().Substring(o.vendorPOFile.ToString().LastIndexOf('/') + 1, o.vendorPOFile.ToString().Length)
                            }
                            ); //.Take(10);
                foreach (var q in query)
                {
                    //q.clientPOFilePath = q.clientPOFilePath.ToString().Substring(q.clientPOFilePath.ToString().LastIndexOf('/'), q.clientPOFilePath.ToString().Length);
                    //int len = q.clientPOFilePath.ToString().Length;
                    //string x = q.clientPOFilePath.Substring(0,5);
                    //Console.Write(q.clientPOFilePath + "\n");
                    //Console.Write(len + "\n");
                    if (q.clientPOFilePath != null)
                    {
                        string s = q.clientPOFilePath.ToString();
                        int start = 0;
                        int end = 0;
                        if (q.clientPOFilePath.ToString() != "N/A" && q.clientPOFilePath.ToString() != "TBD")
                        {
                            start = q.clientPOFilePath.ToString().LastIndexOf('/');
                            end = q.clientPOFilePath.ToString().Length;

                            q.clientPOFileName = s.Substring(start+1, end-start-1);
                            Console.WriteLine(q.clientPOFileName + " " + start + " " + end);
                        }
                        else
                            q.clientPOFileName = "Empty";

                        s = q.vendorPOFilePath.ToString();
                        start = 0;
                        end = 0;
                        if (q.vendorPOFilePath.ToString() != "N/A" && q.vendorPOFilePath.ToString() != "TBD")
                        {
                            start = q.vendorPOFilePath.ToString().LastIndexOf('/');
                            end = q.vendorPOFilePath.ToString().Length;

                            q.vendorPOFileName = s.Substring(start+1, end-start-1);
                            Console.WriteLine(q.vendorPOFileName + " " + start + " " + end);
                        }
                        else
                            q.vendorPOFileName = "Empty";
                    }
                }
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
                tblorder.startDate = o.startDate;
                tblorder.expectDate = o.expectDate;
                tblorder.clientPOFile = o.clientPOFilePath + "/" + o.clientPOFileName;
                tblorder.vendorPOFile = o.vendorPOFilePath + "/" + o.vendorPOFileName;
                //Console.WriteLine(o.clientPOFilePath);
                //Console.WriteLine(o.clientPOFileName);
                //Console.WriteLine(o.vendorPOFilePath);
                //Console.WriteLine(o.vendorPOFileName);
                db.Entry(tblorder).State = EntityState.Modified;
                db.SaveChanges();
            //}
            return;
        }
    }

   

}
