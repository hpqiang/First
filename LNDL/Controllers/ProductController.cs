using LNDL.ProductServiceReference;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WcfProductService.EFDAL;

namespace LNDL.Controllers
{
    public class ProductController : Controller
    {
        ProductServiceReference.ProductServiceClient client = new ProductServiceReference.ProductServiceClient();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Overview
        public ActionResult Overview()
        {
            List<tblProduct> p = new List<tblProduct>();
            p = client.GetProductEntities().ToList();
            return View(p);
        }
        
        // GET: Fabric
        public ActionResult Fabric()
        {
            List<tblFabric> f = new List<tblFabric>();
            f = client.GetFabricEntities().ToList();
            return View(f);
        }

        // GET: Curtain
        public ActionResult Curtain()
        {
            List<tblCurtain> c = new List<tblCurtain>();
            c = client.GetCurtainEntities().ToList();
            return View(c);
        }

        // GET: Bedding
        public ActionResult Bed()
        {
            List<tblBed> b = new List<tblBed>();
            b = client.GetBedEntities().ToList();
            return View(b);
        }

    }
}