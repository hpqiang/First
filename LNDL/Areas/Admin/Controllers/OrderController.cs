//using LNDLWcfService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Messaging;

namespace LNDL.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        ServiceReference1.LNDLWcfServiceClient client = new ServiceReference1.LNDLWcfServiceClient();
        //List<OrderEntity> orders = new List<OrderEntity>();

        // GET: Admin/Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewOrder()
        {
            string strMsg = string.Empty;

            MessageQueue orderQueue;
            orderQueue = new MessageQueue(@".\private$\orders");//+ ConfigurationManager.AppSettings["orderQueueName"]);

            while (orderQueue.GetAllMessages().Length > 0)
            {
                Message msg = orderQueue.Receive();

                msg.Formatter = new BinaryMessageFormatter();
                strMsg += msg.Body.ToString();
            }
            ViewBag.po = "Called or not????" + strMsg;

            return View();
        }

        public ActionResult OrderSummary()
        {
            return View();
        }

        public /*ActionResult*/ ViewResult OrderInSample(string sortOrder, string currentFilter, string searchString, int? page, string pageSize)//, string PeopleClass)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //pageSize = String.IsNullOrEmpty(pageSize) ? "5" : pageSize;
            //ViewBag.PageSize = pageSize;
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

            //orders = client.getOrderList1((string)(ViewBag.NameSortParm), currentFilter, searchString, page).ToList();// .Get.GetTenMostExpensiveProducts().ToList();

            int pageNumber = (page ?? 1);
            return View(orders.ToPagedList(pageNumber, Int32.Parse(pageSize)));
        }
    }
}