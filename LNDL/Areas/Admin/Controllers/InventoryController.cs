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
    public class InventoryController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //List<Inventory> linv = new List<Inventory>();
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

            //linv = client.getInventory().ToList();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    linv = linv.Where(s => s.productId.ToString().ToUpper().Contains(searchString.ToUpper())).ToList();
            //}

            switch (sortOrder)
            {
                case "name_desc":
                    //linv = linv.OrderByDescending(s => s.productId).ToList();
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:  // Name ascending 
                    //linv = linv.OrderBy(s => s.productId).ToList();
                    break;
            }
            //Session["linv"] = linv;
            return View();// (linv.ToPagedList(pageNumber, Int32.Parse(pageSize)));
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
        //public ActionResult Create(Inventory inv)//, string AddressId)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //client.insertInventory(inv);
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
        //    return View(inv);
        //}

        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    linv = (List<Inventory>)Session["linv"];
        //    //List<Address> la = new List<Address>();

        //    Inventory inv = linv.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
        //    if (inv == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(inv);
        //}

        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    linv = (List<Inventory>)Session["linv"];
        //    //List<ProductDetail> lpd = new List<ProductDetail>();

        //    Inventory inv = linv.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
        //    if (inv == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    return View(inv);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        //public ActionResult Edit(Inventory inv)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            //db.Entry(course).State = EntityState.Modified;
        //            //db.SaveChanges();

        //            //client.updateInventory(inv);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (RetryLimitExceededException /* dex */)
        //    {
        //        //Log the error (uncomment dex variable name and add a line here to write a log.)
        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
        //    }
        //    //PopulateDepartmentsDropDownList(course.DepartmentID);
        //    return View(inv);
        //}

    }
}