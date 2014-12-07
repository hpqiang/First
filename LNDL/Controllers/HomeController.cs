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

using LNDL.EFDAL;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using LNDLWcfService.CodeFirstDAL;

namespace LNDL.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        List<OrderEntity> orders = new List<OrderEntity>();

        CompanyContext cc = new CompanyContext();


        public ActionResult Order()
        {
            orders = client.getOrderList().ToList();// .Get.GetTenMostExpensiveProducts().ToList();
            return View(orders);
        }

        //[Authorize]
        public ActionResult Index()
        {
            //client.SetDBInitializer();
            return View();
        }

        //[Authorize(Roles="admin")]
        public ActionResult AdminIndex()
        {
            ViewBag.Message = "This can be viewed by admin only";
            return View();
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
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult About(string text)
        {
            MSMQServiceReference.MSMQServiceClient msmqClient = new MSMQServiceReference.MSMQServiceClient();

            msmqClient.ShowMessage(text);
            ViewBag.Message = "Posted it" + text;
            return View();
        }

        private SampleEntities db = new SampleEntities();
        public ActionResult LoginMyUser()
        {
            //var users = from u in db.tblUsers
            //            select u;

            //return View(users);

            return View();
        }

        [HttpPost]
        public ActionResult LoginMyUser(LNDL.EFDAL.tblUsers model)//, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //var users = from u in db.tblUsers
                //            select u;

                string name = model.name;
                string password = model.password;

                bool userValid = db.tblUsers.Any(user => user.name == name && user.password == password);

                if (userValid)
                {
                    //FormsAuthentication.SetAuthCookie(name, false);
                    //if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    //&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    //{
                    //    return Redirect(returnUrl);
                    //}
                    //else
                    
                    {
                        //ViewBag.Message = "Redirecting....";
                        string role;
                        var uRole = from u in db.tblUsers
                                    where (u.name == name && u.password == password)
                                    select u.role;
                        role = uRole.FirstOrDefault().ToString();
                        //Console.WriteLine(role);
                        switch(role)
                        {
                            case "admin":
                                return RedirectToAction("Index", "Admin", new { area="Admin", name=name});
                            case "supplier":
                                return RedirectToAction("Index", "Supplier", new { area = "Supplier",name=name});
                            case "customer":
                                return RedirectToAction("Index", "Customer", new { area = "Customer",name=name});
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The username or password are not correct");
                }

            }
            return View(model); //Something is wrong
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}