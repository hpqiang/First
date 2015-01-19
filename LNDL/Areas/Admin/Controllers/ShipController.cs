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
    public class ShipController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        List<Shipping> ls = new List<Shipping>();
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

            //ls = client.getShipping().ToList();

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    ls = ls.Where(s => s.productId.ToString().ToUpper().Contains(searchString.ToUpper())).ToList();
            //}

            switch (sortOrder)
            {
                case "name_desc":
                    //ls = ls.OrderByDescending(s => s.productId).ToList();
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:  // Name ascending 
                    //ls = ls.OrderBy(s => s.productId).ToList();
                    break;
            }
            //Session["ls"] = ls;
            return View(ls.ToPagedList(pageNumber, Int32.Parse(pageSize)));
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BriefName, FullName, Type")]Company company)
        public ActionResult Create(Shipping ship)//, string AddressId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //client.insertShipping(ship);
                    //companies.Add(company);

                    //db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes in Customer/Create. Try again, and if the problem persists see your system administrator.");
            }
            return View(ship);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls = (List<Shipping>)Session["ls"];
            //List<Address> la = new List<Address>();

            Shipping s = ls.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }

            return View(s);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ls = (List<Shipping>)Session["ls"];
            //List<ProductDetail> lpd = new List<ProductDetail>();

            Shipping s = ls.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
            if (s == null)
            {
                return HttpNotFound();
            }

            //foreach (Product c in ofcs)
            //{
            //    List<ProductDetail> pd = c.Details;

            //    foreach (ProductDetail p in pd)
            //    {
            //        lpd.Add(p);
            //    }
            //}

            //foreach (Company c in companies)
            //{
            //    Address a = c.Addresses;

            //    la.Add(a);
            //}


            //ViewData["AddrId"] = new SelectList(lpd, "Id", "Name");

            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        public ActionResult Edit(Shipping ship)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(course).State = EntityState.Modified;
                    //db.SaveChanges();

                    //client.updateShipping(ship);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(ship);
        }

    }
}