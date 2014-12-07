using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LNDL.Areas.Supplier.Controllers
{
    public class SupplierController : Controller
    {
        public static string supplierName = string.Empty;

        // GET: Supplier/Supplier
        public ActionResult Index(string name)
        {
            //ViewBag.name = name;
            if (supplierName.Equals(string.Empty))
                supplierName = name;
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Product()
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

        public ActionResult Invoice()
        {
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}