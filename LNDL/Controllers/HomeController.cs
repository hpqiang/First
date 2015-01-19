using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using LNDL.Models;
using LNDL.ServiceReference1;
//using LNDLWcfService;
using System.Net;
using System.IO;

using LNDL.EFDAL;
using System.Web.Security;
using Microsoft.AspNet.Identity;
//using LNDLWcfService.CodeFirstDAL;
using PagedList;
using System.Web.Helpers;
using LNDL.Models;

namespace LNDL.Controllers
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class HomeController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //List<OrderEntity> orders = new List<OrderEntity>();

        //CompanyContext cc = new CompanyContext();

        public void DoSomething(string pageSize)
        {
            //Do something. dropdownlist variable is your dropdown value
            ViewBag.PageSize = pageSize;

            //var list = new[] {   
            //        new Person { Id = 1, Name = "Name1" }, 
            //        new Person { Id = 2, Name = "Name2" }, 
            //        new Person { Id = 3, Name = "Name3" } 
            //};

            //var selectList = new SelectList(list, "Id", "Name", 2);
            //ViewData["People"] = selectList;

            return;// pageSize;
            //return View();
        }
        //public /*ActionResult*/ ViewResult Order(string sortOrder, string currentFilter, string searchString, int? page, string pageSize)//, string PeopleClass)
        //{
        //    ViewBag.CurrentSort = sortOrder;
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    pageSize = String.IsNullOrEmpty(pageSize) ? "5" : pageSize;
        //    ViewBag.PageSize = pageSize;
        //    //ViewBag.PageSize = Request.QueryString["PeopleClass"]; //PeopleClass;//options.Find(x=>x.Value == ).ToString();

        //    //var options = new List<SelectListItem>();

        //    //options.Add(new SelectListItem { Value = "1", Text = "5" });
        //    //options.Add(new SelectListItem { Value = "2", Text = "10" });
        //    //options.Add(new SelectListItem { Value = "3", Text = "20", Selected = true });

        //    //ViewData["options"] = options;

        //    //Html.DropDownList("PeopleClass", (SelectList)ViewData["People"])

        //    if (searchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        searchString = currentFilter;
        //    }

        //    ViewBag.CurrentFilter = searchString;

        //    //sortOrder = ViewBag.NameSortParm;

        //    orders = client.getOrderList1((string)(ViewBag.NameSortParm), currentFilter, searchString, page).ToList();// .Get.GetTenMostExpensiveProducts().ToList();

        //    //int pageSize = 5;
        //    int pageNumber = (page ?? 1);
        //    return View(orders.ToPagedList(pageNumber, Int32.Parse(pageSize)));
        //}

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

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    orders = client.getOrderList().ToList();// .Get.GetTenMostExpensiveProducts().ToList(); //MQ: no need to do it here

        //    var order = orders.Find(x => x.id == id);

        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    populateProductTypeDDL(order.productType);
        //    populateProductNameDDL(order.productName);

        //    return View(order);
        //}

        //[HttpPost]
        //public ActionResult Edit(OrderEntity order, string Command, FormCollection collection)
        //{
        //    //Response.Write("Command" + Command);
        //    if (Command == "fileUpload")
        //    {
        //        //ServiceReference2.WCFUploaderClient uploadClient = new ServiceReference2.WCFUploaderClient();
        //        //uploadClient.Upload(new FileStream(collection["Package"], FileMode.Create));

        //        orders = client.getOrderList().ToList();
        //        var o = orders.Find(x => x.id == order.id);

        //        populateProductTypeDDL(o.productType);
        //        populateProductNameDDL(o.productName);
        //        return View(order);


        //        //return Content("Coming heer..." + order.clientPOFileName + collection["Package"]);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                client.saveOrder(order);
        //                return RedirectToAction("Order");
        //            }
        //        }
        //        catch
        //        {
        //            ModelState.AddModelError("", "Unable to save changes");
        //        }

        //        populateProductTypeDDL(order.productType);
        //        populateProductNameDDL(order.productName);
        //        return View(order);
        //    }
        //}

        //private void populateProductTypeDDL(object selectedProductType = null)
        //{
        //    var productType = from o in orders
        //                      select o.productType;
        //    var uniqueProductType = productType.Distinct().ToList();
        //    ViewBag.productType = new SelectList(uniqueProductType, selectedProductType);
        //}

        //private void populateProductNameDDL(object selectedProductName = null)
        //{
        //    var productName = from o in orders
        //                      select o.productName;
        //    var uniqueProductName = productName.Distinct().ToList();
        //    ViewBag.productName = new SelectList(uniqueProductName, selectedProductName);
        //}

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
                        switch (role)
                        {
                            case "admin":
                                return RedirectToAction("Index", "Admin", new { area = "Admin", name = name });
                            case "supplier":
                                return RedirectToAction("Index", "Supplier", new { area = "Supplier", name = name });
                            case "customer":
                                return RedirectToAction("Index", "Customer", new { area = "Customer", name = name });
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


        public ActionResult MyChart()
        {
            var bytes = new Chart(width: 400, height: 200)
                .AddSeries(
                    chartType: "pie",
                    xValue: new[] { "Math", "English", "Computer", "Urdu" },
                    yValues: new[] { "60", "70", "68", "88" })
                .GetBytes("png");
            return File(bytes, "image/png");
        }

    }
}