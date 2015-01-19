using LNDLWcfService.CodeFirstEntities;
using LNDLWcfService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LNDLWcfService.HywinWcfServices.OrderFromCustomerService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IOrderWcfService”。
    [ServiceContract]
    public interface IOrderFromCustomerWcfService
    {
        [OperationContract]
        [ApplyDataContractResolver]
        List<OrderFromCustomer> getOrderFromCustomer(int start, int amount, string search, string sortOrder);
        [OperationContract]
        int getOrderFromCustomerTotalNumber(string search);
        [OperationContract]
        void insertOrderFromCustomer(OrderFromCustomer order);
        [OperationContract]
        void updateOrderFromCustomer(OrderFromCustomer order);
        [OperationContract]
        void deleteOrderFromCustomer(OrderFromCustomer order);
    }
}
