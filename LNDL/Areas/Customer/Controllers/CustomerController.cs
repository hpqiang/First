using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using MSMQNonSecurityService;
using System.Transactions;
using System.Messaging;
using System.Configuration;
//using WcfServiceMSMQtoWCFforPO;
using SelfHostMSMQtoWCFforPO;

namespace LNDL.Areas.Customer.Controllers
{
    public class CustomerController : Controller
    {
        public static string customerName = string.Empty;

        //public static string getCustomerName() { return customerName;}
        // GET: Customer/Customer
        public ActionResult Index(string name)
        {
            //ViewBag.name = name;
            if (customerName.Equals(string.Empty))
                customerName = name;
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewOrder(string text)
        {

            MSMQServiceReference.MSMQServiceClient msmqClient = new MSMQServiceReference.MSMQServiceClient();
            //MSMQServiceReference.MyMsg m = new MSMQServiceReference.MyMsg();
             
            
            msmqClient.ShowMessage(text);
            //m.from = customerName;
            //m.to = "Admin";
            //m.msg = text;
            //msmqClient.AddMessage(m);
            ViewBag.Message = "Posted it" + text;

            //Connect to the queue
            //MessageQueue orderQueue = new MessageQueue(@"FormatName:Direct=OS:" + ConfigurationManager.AppSettings["orderQueueName"]);
            MessageQueue orderQueue;
            //if (MessageQueue.Exists(@"FormatName:Direct=OS:" + ConfigurationManager.AppSettings["orderQueueName"]))
            if (MessageQueue.Exists(@".\private$\orders"))// + ConfigurationManager.AppSettings["orderQueueName"]))
            {
                orderQueue = new MessageQueue(@".\private$\orders");//+ ConfigurationManager.AppSettings["orderQueueName"]);
            }
            else
            {
                orderQueue = MessageQueue.Create(@".\private$\orders");// + ConfigurationManager.AppSettings["orderQueueName"]);
            }
            //Console.WriteLine("orderQueue Created...");
            // Create the purchase order
            PurchaseOrder po = new PurchaseOrder();
            po.customerId = "somecustomer.com";
            po.poNumber = Guid.NewGuid().ToString();

            PurchaseOrderLineItem lineItem1 = new PurchaseOrderLineItem();
            lineItem1.productId = "Blue Widget";
            lineItem1.quantity = 54;
            lineItem1.unitCost = 29.99F;

            PurchaseOrderLineItem lineItem2 = new PurchaseOrderLineItem();
            lineItem2.productId = "Red Widget";
            lineItem2.quantity = 890;
            lineItem2.unitCost = 45.89F;

            po.orderLineItems = new PurchaseOrderLineItem[2];
            po.orderLineItems[0] = lineItem1;
            po.orderLineItems[1] = lineItem2;

            // submit the purchase order
            Message msg = new Message();
            msg.Formatter = new BinaryMessageFormatter();
            msg.Body = po;
            msg.Label = "new order from: "+customerName;
            orderQueue.Send(msg);
            ViewBag.po = "Thanks for sending order with details below: " + po;
            //Create a transaction scope.
            //using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            //{
            //    orderQueue.Send(msg, MessageQueueTransactionType.Automatic);

            //    // Complete the transaction.
            //    scope.Complete();
            //}

            //ViewBag.po = msg.Body;

            //Console.WriteLine("Placed the order:{0}", po);
            //Console.WriteLine("Press <ENTER> to terminate client.");
            //Console.ReadLine();
            return View();
            ////return RedirectToAction("Index","Customer");
        }

        public ActionResult OrderHistory()
        {
            return View();
        }

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}