using LNDLWcfService.Common;
using LNDLWcfService.CodeFirstEntities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LNDLWcfService.HywinWcfServices.ProductService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IProductWcfService
    {
        [OperationContract]
        [ApplyDataContractResolver]
        List<Product> getProduct(int start, int amount, string search, string sortOrder);
        [OperationContract]
        int getProductTotalNumber(string search);
        [OperationContract]
        void insertProduct(Product product);
        [OperationContract]
        void updateProduct(Product product);
        [OperationContract]
        void deleteProduct(Product product);
    }
}
