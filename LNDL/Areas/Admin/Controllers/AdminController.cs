using Hywin.Common.LogService;
//using LNDLWcfService;
//using SelfHostMSMQtoWCFforPO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Messaging;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LNDL.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        //private readonly ILogger<AdminController> Log = Log<AdminController>.LogProvider;
        //private static IAdminSvr _adminSvr;
        public static string adminName = string.Empty;

        //public static IAdminSvr AdminSvr
        //{
        //    get
        //    {
        //        if (_adminSvr == null)
        //            throw new ApplicationException("AdminSvr is null.");
        //        return _adminSvr;
        //    }
        //    set { _adminSvr = value; }
        //}

        // GET: Admin/Admin
        public ActionResult Index(string name)
        {
            //ViewBag.name = name;
            if (adminName.Equals(string.Empty))
                adminName = name;


            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public ActionResult Configuration()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}