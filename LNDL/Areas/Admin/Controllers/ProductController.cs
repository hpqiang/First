//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

////using LNDLWcfService.CodeFirstEntities;
//using PagedList;
//using System.Data.Entity.Infrastructure;
//using System.Net;

//namespace LNDL.Areas.Admin.Controllers
//{
//    public class ProductController : Controller
//    {
//        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
//        //List<Product> products = new List<Product>();
//        // GET: Admin/Customer
//        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page, string pageSize)
//        {
//            ViewBag.CurrentSort = sortOrder;
//            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
//            //pageSize = String.IsNullOrEmpty(pageSize) ? "5" : pageSize;
//            if (pageSize == null)
//            {
//                if ((string)Session["PageSize"] != null)
//                {
//                    pageSize = (string)Session["PageSize"];
//                }
//                else
//                {
//                    pageSize = "5";
//                }
//            }
//            else
//            {
//                Session["PageSize"] = pageSize;
//            }

//            if (searchString != null)
//            {
//                page = 1;
//            }
//            else
//            {
//                searchString = currentFilter;
//            }

//            ViewBag.CurrentFilter = searchString;

//            int pageNumber = (page ?? 1);
//            //return View(orders.ToPagedList(pageNumber, Int32.Parse(pageSize)));

//            //products = client.getProduct().ToList();

//            if (!String.IsNullOrEmpty(searchString))
//            {
//                products = products.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
//            }

//            switch (sortOrder)
//            {
//                case "name_desc":
//                    products = products.OrderByDescending(s => s.Name).ToList();
//                    break;
//                //case "Date":
//                //    students = students.OrderBy(s => s.EnrollmentDate);
//                //    break;
//                //case "date_desc":
//                //    students = students.OrderByDescending(s => s.EnrollmentDate);
//                //    break;
//                default:  // Name ascending 
//                    products = products.OrderBy(s => s.Name).ToList();
//                    break;
//            }
//            Session["products"] = products;
//            return View(products.ToPagedList(pageNumber, Int32.Parse(pageSize)));
//        }


//        // GET: /Company/Create
//        public ActionResult Create()
//        {
//            //ViewBag.InstructorID = new SelectList(db.Instructors, "ID", "FullName");

//            List<ProductDetail> lpd = new List<ProductDetail>();
//            products = (List<Product>)Session["products"];

//            //foreach (Product c in products)
//            //{
//            //    List<ProductDetail> pd = c.Details;

//            //    foreach(ProductDetail p in pd)
//            //    { 
//            //        lpd.Add(p);
//            //    }
//            //}

//            //ViewData["AddrId"] = new SelectList(lpd, "Id", "Name");

//            return View();
//        }

//        // POST: /Company/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        ////public ActionResult Create([Bind(Include = "BriefName, FullName, Type")]Company company)
//        //public ActionResult Create(Product product)//, string AddressId)
//        //{
//        //    try
//        //    {
//        //        if (ModelState.IsValid)
//        //        {
//        //            //client.insertProduct(product);
//        //            //companies.Add(company);

//        //            //db.SaveChanges();
//        //            return RedirectToAction("Index");
//        //        }
//        //    }
//        //    catch (RetryLimitExceededException /* dex */)
//        //    {
//        //        //Log the error (uncomment dex variable name and add a line here to write a log.
//        //        ModelState.AddModelError("", "Unable to save changes in Customer/Create. Try again, and if the problem persists see your system administrator.");
//        //    }
//        //    return View(product);
//        //}

//        //public ActionResult Details(int? id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    }
//        //    products = (List<Product>)Session["products"];
//        //    //List<Address> la = new List<Address>();

//        //    Product product = products.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
//        //    if (product == null)
//        //    {
//        //        return HttpNotFound();
//        //    }

//        //    return View(product);
//        //}

//        //public ActionResult Edit(int? id)
//        //{
//        //    if (id == null)
//        //    {
//        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//        //    }
//        //    products = (List<Product>)Session["products"];
//        //    List<ProductDetail> lpd = new List<ProductDetail>();

//        //    Product product = products.Find(x => x.Id == id);// .Where(x => x.Id == id); //db.Courses.Find(id);
//        //    if (product == null)
//        //    {
//        //        return HttpNotFound();
//        //    }

//        //    //foreach (Product c in products)
//        //    //{
//        //    //    List<ProductDetail> pd = c.Details;

//        //    //    foreach (ProductDetail p in pd)
//        //    //    {
//        //    //        lpd.Add(p);
//        //    //    }
//        //    //}
            
//        //    //foreach (Company c in companies)
//        //    //{
//        //    //    Address a = c.Addresses;

//        //    //    la.Add(a);
//        //    //}


//        //    //ViewData["AddrId"] = new SelectList(lpd, "Id", "Name");

//        //    //PopulateDepartmentsDropDownList(course.DepartmentID);
//        //    return View(product);
//        //}

//        //[HttpPost]
//        //[ValidateAntiForgeryToken]
//        ////public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
//        //public ActionResult Edit(Product product)
//        //{
//        //    try
//        //    {
//        //        if (ModelState.IsValid)
//        //        {
//        //            //db.Entry(course).State = EntityState.Modified;
//        //            //db.SaveChanges();

//        //            //client.updateProduct(product);

//        //            return RedirectToAction("Index");
//        //        }
//        //    }
//        //    catch (RetryLimitExceededException /* dex */)
//        //    {
//        //        //Log the error (uncomment dex variable name and add a line here to write a log.)
//        //        ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
//        //    }
//        //    //PopulateDepartmentsDropDownList(course.DepartmentID);
//        //    return View(product);
//        //}

//    }
//}

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
using LNDLWcfService.CodeFirstEntities.Common;

namespace LNDL.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //ProductServiceRef.ProductWcfServiceClient client = new ProductServiceRef.ProductWcfServiceClient();
        List<Product> products;
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
            int count = 0;

            products = client.getProduct(Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder).ToList();
            
            count = client.getProductTotalNumber(searchString);

            //count = client.getInstanceTotalNumber("Product", ViewBag.CurrentFilter as string);
            //Object[] objs;
            //objs = client.getInstanceList("Product", Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder);//.ToList();
            //products = objs.Cast<Product>().ToList();

            StaticPagedList<Product> productsForPagedView = new StaticPagedList<Product>(products, pageNumber, Int32.Parse(pageSize), count);

            ViewBag.CurrentPageNumber = page;
            Session["currentPage"] = page;

            Session["products"] = products; //MQ
            return View(productsForPagedView);
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            products = (List<Product>)Session["products"];
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
        public ActionResult Create(Product product)//, string AddressId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.insertProduct(product);
                    //client.insertInstance("Product", product);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes in Customer/Create. Try again, and if the problem persists see your system administrator.");
            }
            return View(product);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products = (List<Product>)Session["products"];

            Product product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            //ViewData["AddrId"] = new SelectList(la, "Id", "Street");
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products = (List<Product>)Session["products"];

            Product product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            //foreach (Company c in companies)
            //{
            //    Address a = c.Addresses;

            //    la.Add(a);
            //}
            int count = client.getCategoryTotalNumber();
            //int count = client.getInstanceTotalNumber("Category",null);
            List<Category> lc; // = new List<Category>();
            //Object[] objs;
            lc = client.getCategory(0, 0).ToList(); //MQ: start 0, amount 0 is fake here?
            //objs = client.getInstanceList("Category",0, count,null,null);//.ToList();
            //lc = objs.Cast<Category>().ToList();

            ViewData["CatId"] = new SelectList(lc, "Id", "categoryName");

            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.updateProduct(product);
                    //client.updateInstance("Product",product);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(product);
        }


        // GET: /Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            products = (List<Product>)Session["products"];

            Product product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: /Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult DeleteConfirmed(Product product)
        {
            //Instructor instructor = db.Instructors
            //  .Include(i => i.OfficeAssignment)
            //  .Where(i => i.ID == id)
            //  .Single();

            //instructor.OfficeAssignment = null;
            //db.Instructors.Remove(instructor);

            //var department = db.Departments
            //    .Where(d => d.InstructorID == id)
            //    .SingleOrDefault();
            //if (department != null)
            //{
            //    department.InstructorID = null;
            //}

            //db.SaveChanges();
            try
            {
                if (ModelState.IsValid)
                {
                    if (product == null)
                    {
                        return HttpNotFound();
                    }
                    client.deleteProduct(product);
                    //client.deleteInstance("Product", product);
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