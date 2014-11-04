using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LNDL.Models;
//using LNDL.ServiceReference1;
using LNDLWcfService;
using System.Net;
using System.IO;

namespace LNDL.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        List<OrderEntity> orders = new List<OrderEntity>();

        public ActionResult Order()
        {
            orders = client.getOrderList().ToList();// .Get.GetTenMostExpensiveProducts().ToList();
            return View(orders);
        }

        public ActionResult Index()
        {
            string name = client.GetMessage("MQ");
            Test test = new Test();
            test.name = name;
            //ViewBag.Title = name;
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View(test);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders = client.getOrderList().ToList();// .Get.GetTenMostExpensiveProducts().ToList(); //MQ: no need to do it here

            var order = orders.Find(x=>x.id==id);

            if (order == null)
            {
                return HttpNotFound();
            }
            populateProductTypeDDL(order.productType);
            populateProductNameDDL(order.productName);

            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(OrderEntity order, string Command, FormCollection collection)
        {
            //Response.Write("Command" + Command);
            if (Command == "fileUpload")
            {
                //ServiceReference2.WCFUploaderClient uploadClient = new ServiceReference2.WCFUploaderClient();
                //uploadClient.Upload(new FileStream(collection["Package"], FileMode.Create));

                orders = client.getOrderList().ToList();
                var o = orders.Find(x => x.id == order.id);

                populateProductTypeDDL(o.productType);
                populateProductNameDDL(o.productName);
                return View(order);


                //return Content("Coming heer..." + order.clientPOFileName + collection["Package"]);
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        client.saveOrder(order);
                        return RedirectToAction("Order");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }

                populateProductTypeDDL(order.productType);
                populateProductNameDDL(order.productName);
                return View(order);
            }
        }

        private void populateProductTypeDDL(object selectedProductType = null)
        {
            var productType = from o in orders
                              select o.productType;
            var uniqueProductType = productType.Distinct().ToList();
            ViewBag.productType = new SelectList(uniqueProductType, selectedProductType);
        }

        private void populateProductNameDDL(object selectedProductName = null)
        {
            var productName = from o in orders
                              select o.productName;
            var uniqueProductName = productName.Distinct().ToList();
            ViewBag.productName = new SelectList(uniqueProductName, selectedProductName);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}