using Hywin.Common.LogService;
using LNDL.Areas.Admin.Models;
using LNDLWcfService;
using SelfHostMSMQtoWCFforPO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace LNDL.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> Log = Log<AdminController>.LogProvider;
        private static IAdminSvr _adminSvr;
        public static string adminName = string.Empty;

        public static IAdminSvr AdminSvr
        {
            get
            {
                if (_adminSvr == null)
                    throw new ApplicationException("AdminSvr is null.");
                return _adminSvr;
            }
            set { _adminSvr = value; }
        }

        // GET: Admin/Admin
        public ActionResult Index(string name)
        {
            //ViewBag.name = name;
            if (adminName.Equals(string.Empty))
                adminName = name;


            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Products(AllProductsModel allProductsModel)
        {
            //try
            //{
            //    allProductsModel.Products = NorthwindSvr.GetProducts();
            //    return View(allProductsModel.Products);
            //}
            //catch (FaultException<BusinessServiceException> e)
            //{
            //    Log.Error("Web.NorthwindController.AllProducts(...) Error from Business service layer: " + e.Message);
            //    throw;
            //}
            //catch (FaultException ex)
            //{
            //    Log.Error("Web.NorthwindController.AllProducts(...) Error from Business service layer: " + ex.Message);
            //    throw;
            //}
            //catch (Exception exx)
            //{
            //    Log.Fatal("Web.NorthwindController.AllProducts(...) Error: " + exx.Message);
            //    throw;
            //}

            return View();
        }

        public ActionResult Orders()
        {
            //MessageQueue orderQueue = new MessageQueue(@"FormatName:Direct=OS:" + ConfigurationManager.AppSettings["orderQueueName"]);
            string strMsg = string.Empty;

            //SelfHostMSMQtoWCFforPO.OrderProcessorService s = new SelfHostMSMQtoWCFforPO.OrderProcessorService();
            //s.DeliverPurchaseOrder(out strMsg);
            MessageQueue orderQueue;
            orderQueue = new MessageQueue(@".\private$\orders");//+ ConfigurationManager.AppSettings["orderQueueName"]);

            //Message[] msgs = orderQueue.GetAllMessages();
            //foreach (Message msg in msgs)
            //{
            //    //orderQueue.Receive();  //Important!
            //    msg.Formatter = new BinaryMessageFormatter();

            //    strMsg += msg.Body.ToString();
            //    strMsg += "\n";
            //}

            while (orderQueue.GetAllMessages().Length > 0)
            {
                Message msg = orderQueue.Receive();

                msg.Formatter = new BinaryMessageFormatter();
                strMsg += msg.Body.ToString();
            }
            ViewBag.po = "Called or not????" + strMsg;

            return View();
        }




        public ActionResult Manufacture()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult Sales()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}