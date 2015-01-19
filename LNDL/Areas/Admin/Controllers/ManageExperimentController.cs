//using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PagedList;
//using LNDLWcfService;
using LNDL.ServiceReference1;

namespace LNDL.Areas.Admin.Controllers
{
    public class ManageExperimentController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //List<Company> companies = new List<Company>();
        //IQueryable<Company> companies; // = new IQueryable<Company>();

        // GET: Admin/Manage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Customers()
        {
            companies = client.getCompany().ToList();
            return View(companies);
        }

        public ActionResult Suppliers()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }
        public ActionResult Manufacture()
        {
            return View();
        }

        public ActionResult Shipping()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }
    }
}