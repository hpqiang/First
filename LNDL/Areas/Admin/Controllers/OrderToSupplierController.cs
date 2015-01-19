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
    public class OrderToSupplierController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //OrderFromCustomerServiceRef.OrderFromCustomerWcfServiceClient client = new OrderFromCustomerServiceRef.OrderFromCustomerWcfServiceClient();
        List<OrderToSupplier> orders;
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

            orders = client.getOrderToSupplier(Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder).ToList();

            count = client.getOrderToSupplierTotalNumber(searchString);

            StaticPagedList<OrderToSupplier> ordersForPagedView = new StaticPagedList<OrderToSupplier>(orders, pageNumber, Int32.Parse(pageSize), count);

            ViewBag.CurrentPageNumber = page;
            Session["currentPage"] = page;

            Session["ordersToSupplier"] = orders; //MQ
            return View(ordersForPagedView);
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            orders = (List<OrderToSupplier>)Session["ordersToSupplier"];
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
        public ActionResult Create(OrderToSupplier order)//, string AddressId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.insertOrderToSupplier(order);
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
            orders = (List<OrderToSupplier>)Session["ordersToSupplier"];

            OrderToSupplier order = orders.Find(x => x.Id == id);
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
            orders = (List<OrderToSupplier>)Session["ordersToSupplier"];

            OrderToSupplier order = orders.Find(x => x.Id == id);
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
        public ActionResult Edit(OrderToSupplier order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.updateOrderToSupplier(order);
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
            orders = (List<OrderToSupplier>)Session["ordersToSupplier"];

            OrderToSupplier order = orders.Find(x => x.Id == id);
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
        public ActionResult DeleteConfirmed(OrderToSupplier order)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (order == null)
                    {
                        return HttpNotFound();
                    }
                    client.deleteOrderToSupplier(order);
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