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
    public class ProductDetailController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //List<ProductDetail> pdl = new List<ProductDetail>();
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

            //pdl = client.getProductDetail().ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                pdl = pdl.Where(s => s.Color.ToUpper().Contains(searchString.ToUpper())).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    pdl = pdl.OrderByDescending(s => s.Color).ToList();
                    break;
                //case "Date":
                //    students = students.OrderBy(s => s.EnrollmentDate);
                //    break;
                //case "date_desc":
                //    students = students.OrderByDescending(s => s.EnrollmentDate);
                //    break;
                default:  // Name ascending 
                    pdl = pdl.OrderBy(s => s.Color).ToList();
                    break;
            }
            Session["productdetails"] = pdl;
            return View(pdl.ToPagedList(pageNumber, Int32.Parse(pageSize)));
        }


        // GET: /Company/Create
        public ActionResult Create()
        {
            //ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FullName");

            List<ProductDetail> pdl = new List<ProductDetail>();
            pdl = (List<ProductDetail>)Session["productdetails"];

            foreach (ProductDetail pd in pdl)
            {
                pdl.Add(pd);
            }

            ViewData["AddrId"] = new SelectList(pdl, "Id", "Name");

            return View();
        }

        // POST: /Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "BriefName, FullName, Type")]Company company)
        public ActionResult Create(ProductDetail pd)//, string AddressId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //client.insertProductDetail(pd);
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
            return View(pd);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdl = (List<ProductDetail>)Session["productdetails"];
            //List<Address> la = new List<Address>();

            ProductDetail pd = pdl.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
            if (pd == null)
            {
                return HttpNotFound();
            }

            return View(pd);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pdl = (List<ProductDetail>)Session["productdetails"];
            //List<ProductDetail> lpd = new List<ProductDetail>();

            ProductDetail pd = pdl.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
            if (pd == null)
            {
                return HttpNotFound();
            }

            //foreach (ProductDetail c in products)
            //{
            //    List<ProductDetail> pd = c.Details;

            //    foreach (ProductDetail p in pd)
            //    {
            //        lpd.Add(p);
            //    }
            //}

            //ViewData["AddrId"] = new SelectList(lpd, "Id", "Name");

            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(pd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        public ActionResult Edit(ProductDetail pd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //db.Entry(course).State = EntityState.Modified;
                    //db.SaveChanges();

                    //client.updateProductDetail(pd);

                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(pd);
        }
    }
}