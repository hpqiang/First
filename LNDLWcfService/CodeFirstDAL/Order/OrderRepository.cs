using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LNDLWcfService.CodeFirstEntities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LNDLWcfService.CodeFirstDAL.Order
{
    public class OrderRepository
    {
        public List<OrderFromCustomer> GetOrderFromCustomer()
        {
            OrderContext orderContext = new OrderContext();

            List<OrderFromCustomer> ofc = orderContext.OrderFromCustomer
                .Include("OrderProduct")
                .ToList();

            foreach (var d in ofc)
            {
                Console.WriteLine(" ID = " + ofc.FirstOrDefault(x => x.Id == d.Id).Id
                    + " PONumber = " + ofc.FirstOrDefault(x => x.purchaseOrderNumber == d.purchaseOrderNumber).purchaseOrderNumber
                    + " IssueDate = " + ofc.FirstOrDefault(x => x.orderDate == d.orderDate).orderDate
                    );
                //foreach (var x in d.OrderProduct)
                //{
                //    Console.WriteLine(" Products = " + d.OrderProduct.FirstOrDefault(a => a.Product.Name == x.Product.Name).Product.Name
                //        + "\n and Quantity " + d.OrderProduct.FirstOrDefault(a => a.Qty == x.Qty).Qty
                //        );
                //}
            }
            Console.WriteLine("About to return from OrderRepsitory class...");
            return ofc;
        }

        public void insertOrderFromCustomer(OrderFromCustomer ofc)
        {
            OrderContext orderContext = new OrderContext();

            orderContext.OrderFromCustomer.Add(ofc);
            orderContext.SaveChanges();
        }

        public void updateOrderFromCustomer(OrderFromCustomer ofc)
        {
            OrderContext orderContext = new OrderContext();

            //db.Entry(course).State = EntityState.Modified;
            //db.SaveChanges();
            orderContext.Entry(ofc).State = System.Data.Entity.EntityState.Modified;
            orderContext.SaveChanges();
        }

        public List<OrderToSupplier> GetOrderToSupplier()
        {
            OrderContext orderContext = new OrderContext();

            List<OrderToSupplier> ots = orderContext.OrderToSupplier
                //.Include("Details")
                .ToList();

            foreach (var d in ots)
            {
                Console.WriteLine(" ID = " + ots.FirstOrDefault(x => x.Id == d.Id).Id
                    + " PONumber = " + ots.FirstOrDefault(x => x.purchaseOrderNumber == d.purchaseOrderNumber).purchaseOrderNumber
                    + " IssueDate = " + ots.FirstOrDefault(x => x.orderDate == d.orderDate).orderDate
                    );
                //foreach (var x in d.OrderProduct)
                //{
                //    Console.WriteLine(" Products = " + d.OrderProduct.FirstOrDefault(a => a.Product.Name == x.Product.Name).Product.Name
                //        + "\n and Quantity " + d.OrderProduct.FirstOrDefault(a => a.Qty == x.Qty).Qty
                //        );
                //}
            }
            Console.WriteLine("About to return from OrderRepsitory for OrderToSupplier class...");
            return ots;
        }

        public void insertOrderToSupplier(OrderToSupplier ots)
        {
            OrderContext orderContext = new OrderContext();

            orderContext.OrderToSupplier.Add(ots);
            orderContext.SaveChanges();
        }

        public void updateOrderToSupplier(OrderToSupplier ots)
        {
            OrderContext orderContext = new OrderContext();

            //db.Entry(course).State = EntityState.Modified;
            //db.SaveChanges();
            orderContext.Entry(ots).State = System.Data.Entity.EntityState.Modified;
            orderContext.SaveChanges();
        }

        //public List<OrderToOrder> GetOrderToOrder()
        //{
        //    OrderContext orderContext = new OrderContext();

        //    List<OrderToOrder> oto = orderContext.OrderToOrder
        //        //.Include("Details")
        //        .ToList();

        //    foreach (var d in oto)
        //    {
        //        Console.WriteLine(" ID = " + oto.FirstOrDefault(x => x.Id == d.Id).Id
        //            + " OrderStatus = " + oto.FirstOrDefault(x => x.orderStatus == d.orderStatus).orderStatus
        //            //+ " InProcess = " + oto.FirstOrDefault(x => x.inProcess == d.inProcess).inProcess
        //            );
        //        //foreach (var x in d.OrderFromCustomer)
        //        //{
        //        //    Console.WriteLine(" OrderNumber = " + x.OrderFromCustomer.FirstOrDefault(a => a.OrderNumber == x.OrderNumber).OrderNumber
        //        //        + "\n and Quantity " + x.OrderProduct.FirstOrDefault(a => a.Qty == x.Qty).Qty
        //        //        );
        //        //}
        //    }
        //    Console.WriteLine("About to return from OrderRepsitory for OrderToSupplier class...");
        //    return oto;
        //}

        //public void insertOrderToOrder(OrderToOrder oto)
        //{
        //    OrderContext orderContext = new OrderContext();

        //    orderContext.OrderToOrder.Add(oto);
        //    orderContext.SaveChanges();
        //}

        //public void updateOrderToOrder(OrderToOrder oto)
        //{
        //    OrderContext orderContext = new OrderContext();

        //    //db.Entry(course).State = EntityState.Modified;
        //    //db.SaveChanges();
        //    orderContext.Entry(oto).State = System.Data.Entity.EntityState.Modified;
        //    orderContext.SaveChanges();
        //}


        

    }
}