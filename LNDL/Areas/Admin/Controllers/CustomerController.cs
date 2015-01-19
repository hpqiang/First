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
    public class CustomerController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        List<Company> companies;
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
            int count=0;

            //MQ: Strange thing for calling getInstanceList for Company???
            companies = client.getCompany(Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder).ToList();
            
            count = client.getCompanyTotalNumber(searchString);
            //count = client.getInstanceTotalNumber("Company", ViewBag.CurrentFilter as string);
            //Object[] objs;
            //objs = client.getInstanceList("Company", Int32.Parse(pageSize) * (pageNumber - 1), Int32.Parse(pageSize), ViewBag.CurrentFilter as string, sortOrder);//.ToList();
            //companies = objs.Cast<Company>().ToList();


            StaticPagedList<Company> companiesForPagedView = new StaticPagedList<Company>(companies, pageNumber, Int32.Parse(pageSize), count);

            ViewBag.CurrentPageNumber = page;
            Session["currentPage"] = page;

            Session["companies"] = companies; //MQ
            return View(companiesForPagedView);
            //return View(companies.ToPagedList(pageNumber, Int32.Parse(pageSize)));
        }

        // GET: /Company/Create
        public ActionResult Create()
        {
            companies = (List<Company>)Session["companies"];
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
        public ActionResult Create(Company company)//, string AddressId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.insertCompany(company);
                    //client.insertInstance("Company", company);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes in Customer/Create. Try again, and if the problem persists see your system administrator.");
            }
            return View(company);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            companies = (List<Company>)Session["companies"];

            Company company = companies.Find(x => x.Id == id);
            if (company == null)
            {
                return HttpNotFound();
            }
            //ViewData["AddrId"] = new SelectList(la, "Id", "Street");
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(company);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            companies = (List<Company>)Session["companies"];

            Company company = companies.Find(x => x.Id == id);
            if (company == null)
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
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseID,Title,Credits,DepartmentID")]Course course)
        public ActionResult Edit(Company company)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    client.updateCompany(company);
                    //client.updateInstance("Company", company);
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            //PopulateDepartmentsDropDownList(course.DepartmentID);
            return View(company);
        }


        // GET: /Instructor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            companies = (List<Company>)Session["companies"];

            Company company = companies.Find(x => x.Id == id);
            if (company == null)
            {
                return HttpNotFound();
            }

            return View(company);
        }

        // POST: /Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        public ActionResult DeleteConfirmed(Company company)
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
                    if (company == null)
                    {
                        return HttpNotFound();
                    }
                    client.deleteCompany(company);
                    //client.deleteInstance("Company", company);
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