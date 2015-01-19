using LNDLWcfService.CodeFirstDAL;
using LNDLWcfService.CodeFirstEntities;
using LNDLWcfService.HywinWcfServices.OrderFromCustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LNDLWcfService.HywinWcfServices.OrderFromCustomerService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“OrderWcfService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 OrderWcfService.svc 或 OrderWcfService.svc.cs，然后开始调试。
    public class OrderFromCustomerWcfService : IOrderFromCustomerWcfService
    {
        public List<OrderFromCustomer> getOrderFromCustomer(int start, int amount, string search, string sortOrder)
        {
            HywinRepository hr = new HywinRepository();
            List<OrderFromCustomer> lp;

            if (!String.IsNullOrEmpty(search))
            {
                lp = hr.GetItemList<OrderFromCustomer>(
                    (s => s.purchaseOrderNumber.ToUpper().Contains(search.ToUpper())),
                    "Products");
            }
            else
            {
                lp = hr.GetItemList<OrderFromCustomer>(null, "Products");
            }

            if (sortOrder == "name_desc")
            {
                lp = lp
                    .OrderByDescending(s => s.purchaseOrderNumber)
                    .Skip(start)
                    .Take(amount).ToList();
            }
            else
            {
                lp = lp
                    .OrderBy(s => s.purchaseOrderNumber)
                    .Skip(start)
                    .Take(amount).ToList();
            }

            Console.WriteLine("About to return from OrderFromCustomerWcfService class...");
            return lp;
        }

        public int getOrderFromCustomerTotalNumber(string search)
        {
            int count = 0;
            HywinRepository hr = new HywinRepository();

            if (!String.IsNullOrEmpty(search))
            {
                return count = hr.GetItemCount<OrderFromCustomer, int>(
                    (s => s.purchaseOrderNumber.ToUpper().Contains(search.ToUpper()))
                    );
            }
            else
            {
                return count = hr.GetItemCount<OrderFromCustomer, int>(null);
            }
        }

        public void insertOrderFromCustomer(OrderFromCustomer order)
        {
            HywinRepository hr = new HywinRepository();
            hr.insertItem<OrderFromCustomer>(order);
        }

        public void updateOrderFromCustomer(OrderFromCustomer order)
        {
            HywinRepository hr = new HywinRepository();
            hr.updateItem<OrderFromCustomer>(order);
        }

        public void deleteOrderFromCustomer(OrderFromCustomer order)
        {
            HywinRepository hr = new HywinRepository();
            hr.deleteItem<OrderFromCustomer>(order);
        }
    }
}
