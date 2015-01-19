using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using LNDLWcfService.CodeFirstEntities;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Net;

namespace LNDL.Areas.Admin.Controllers
{
    public class OrderSummaryController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //List<OrderFromCustomer> ofcs = new List<OrderFromCustomer>();
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
            //return View(orders.ToPagedList(pageNumber, Int32.Parse(pageSize)));

            //ofcs = client.getOrderFromCustomer().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                //ofcs = ofcs.Where(s => s.orderNumber.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    //ofcs = ofcs.OrderByDescending(s => s.orderNumber).ToList();
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:  // Name ascending 
                    //ofcs = ofcs.OrderBy(s => s.orderNumber).ToList();
                    break;
            }
            //Session["ofcs"] = ofcs;
            return View(ofcs.ToPagedList(pageNumber, Int32.Parse(pageSize)));
        }


        // GET: /Company/Create
        public ActionResult Create()
        {
            //ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FullName");

            //List<OrderFromCustomer> lofc = new List<OrderFromCustomer>();
            //ofcs = (List<OrderFromCustomer>)Session["ofcs"];

            //foreach (OrderFromCustomer ofc in ofcs)
            //{
            //    List<OrderFromCustomer> lo = c.Details;

            //    foreach (ProductDetail p in pd)
            //    {
            //        lpd.Add(p);
            //    }
            //}

            //ViewData["AddrId"] = new SelectList(lpd, "Id", "Name");

            return View();
        }

        // POST: /Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BriefName, FullName, Type")]Company company)
        //public ActionResult Create(OrderFromCustomer ofc)//, string AddressId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //client.insertOrderFromCustomer(ofc);
        //            //companies.Add(company);

        //            //db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (RetryLimitExceededException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.
        //        ModelState.AddModelError("", "Unable to save changes in Customer/Create. Try again, and if the problem persists see your system administrator.");
        //    }
        //    return View(ofc);
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ofcs = (List<OrderFromCustomer>)Session["ofcs"];
        //    //List<Address> la = new List<Address>();

        //    OrderFromCustomer ofc = ofcs.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
        //    if (ofc == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(ofc);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ofcs = (List<OrderFromCustomer>)Session["ofcs"];
        //    //List<ProductDetail> lpd = new List<ProductDetail>();

        //    OrderFromCustomer ofc = ofcs.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
        //    if (ofc == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    //foreach (Product c in ofcs)
        //    //{
        //    //    List<ProductDetail> pd = c.Details;

        //    //    foreach (ProductDetail p in pd)
        //    //    {
        //    //        lpd.Add(p);
        //    //    }
        //    //}

        //    //foreach (Company c in companies)
        //    //{
        //    //    Address a = c.Addresses;

        //    //    la.Add(a);
        //    //}


        //    //ViewData["AddrId"] = new SelectList(lpd, "Id", "Name");

        //    //PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(ofc);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        //public ActionResult Edit(OrderFromCustomer ofc)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //db.Entry(course).State = EntityState.Modified;
        //            //db.SaveChanges();

        //            //client.updateOrderFromCustomer(ofc);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (RetryLimitExceededException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.)
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    }
        //    //PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(ofc);
        //}
    }
}