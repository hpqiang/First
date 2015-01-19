using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
using System.Data.Entity.Infrastructure;
using System.Net;
using LNDL.ServiceReference1;
using System.ServiceModel;
using LNDLWcfService.CodeFirstEntities;

namespace LNDL.Areas.Admin.Controllers
{
    public class OrderFromCustomerController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //OrderFromCustomerServiceRef.OrderFromCustomerWcfServiceClient client = new OrderFromCustomerServiceRef.OrderFromCustomerWcfServiceClient();
        List<OrderFromCustomer> orders;
        // GET: Admin/Customer
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string pageSize)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //pageSize = String.IsNullOrEmpty(pageSize) ? "5" : pageSize;
            if (pageSize == null)
            {
                if ((string)Session["PageSize"] != null)
                {
                    pageSize = (string)Session["PageSize"];
                }
                else
                {
                    pageSize = "5";
                }
            }
            else
            {
                Session["PageSize"] = pageSize;
            }

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            int pageNumber = (page ?? 1);
            int count;

            orders = client.getOrderFromCustomer(Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder).ToList();

            count = client.getOrderFromCustomerTotalNumber(searchString);

            //count = client.getInstanceTotalNumber("OrderFromCustomer", ViewBag.CurrentFilter as string);
            //Object[] objs;
            //objs = client.getInstanceList("OrderFromCustomer", Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder);//.ToList();
            //orders = objs.Cast<OrderFromCustomer>().ToList();


            StaticPagedList<OrderFromCustomer> ordersForPagedView = new StaticPagedList<OrderFromCustomer>(orders, pageNumber, Int32.Parse(pageSize), count);

            ViewBag.CurrentPageNumber = page;
            Session["currentPage"] = page;

            Session["orders"] = orders; //MQ
            return View(ordersForPagedView);
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            orders = (List<OrderFromCustomer>)Session["orders"];
            //ViewData["AddrId"] = new SelectList(la, "Id", "Street");
            //ViewData["partmentDDL"] = new SelectList(list, "Id", "PartName", employee.PartmentID);
            return View();
        }

        // POST: /Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BriefName, FullName, Type")]Company company)
        public ActionResult Create(OrderFromCustomer order)//, string AddressId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.insertOrderFromCustomer(order);
                    //client.insertInstance("OrderFromCustomer", order);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes in Customer/Create. Try again, and if the problem persists see your system administrator.");
            }
            return View(order);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders = (List<OrderFromCustomer>)Session["orders"];

            OrderFromCustomer order = orders.Find(x => x.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }
            //ViewData["AddrId"] = new SelectList(la, "Id", "Street");
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(order);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders = (List<OrderFromCustomer>)Session["orders"];

            OrderFromCustomer order = orders.Find(x => x.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }

            //foreach (Company c in companies)
            //{
            //    Address a = c.Addresses;

            //    la.Add(a);
            //}

            //ViewData["AddrId"] = new SelectList(la, "Id", "Street");

            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        public ActionResult Edit(OrderFromCustomer order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.updateOrderFromCustomer(order);
                    //client.updateInstance("OrderFromCustomer", order);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(order);
        }


        // GET: /Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            orders = (List<OrderFromCustomer>)Session["orders"];

            OrderFromCustomer order = orders.Find(x => x.Id == id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // POST: /Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult DeleteConfirmed(OrderFromCustomer order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (order == null)
                    {
                        return HttpNotFound();
                    }
                    client.deleteOrderFromCustomer(order);
                    //client.deleteInstance("OrderFromCustomer", order);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            //return View(company);
            return RedirectToAction("Index");
        }
    }
}