using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
//using LNDLWcfService;

namespace LNDLWcfService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IHelloService”。
    [ServiceContract]
    public interface ILNDLWcfService
    {
        [OperationContract]
        string GetMessage(string name);

        [OperationContract]
        List<OrderEntity> getOrderList();

        [OperationContract]
        void saveOrder(OrderEntity o);

        //[OperationContract]
        //void SetDBInitializer();

        //[OperationContract]
        //UploadedFile Upload(Stream Uploading);

        //[OperationContract]
        //UploadedFile Transform(UploadedFile Uploading, string FileName);

    }

    [DataContract]
    public class UploadedFile
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public int FileLength { get; set; }

        [DataMember]
        public string FileName { get; set; }

        //Other information. On upload only path and size are obvious.
        //...
    }

    ////[ServiceContract(Name = "IWCFUploader")]
    [ServiceContract]
    public interface IWCFUploader
    {
        [OperationContract]
        //[OperationContract(Name = "Upload")]
        //[DataContractFormat]
        //[WebInvoke(Method = "POST",
        //            UriTemplate = "Upload/",
        //            BodyStyle = WebMessageBodyStyle.Bare,
        //            ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Upload(Stream Uploading);

        [OperationContract]
        //[OperationContract(Name = "Transform")]
        //[DataContractFormat]
        //[WebInvoke(Method = "POST",
        //            UriTemplate = "Transform",
        //    //BodyStyle = WebMessageBodyStyle.Bare,
        //            BodyStyle = WebMessageBodyStyle.Wrapped,
        //            ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Transform(UploadedFile Uploading, string FileName);
    }

    [ServiceContract]
    public interface IAdminSvr
    {
        //[OperationContract]
        //List<Customer> GetCustomers();

        //[OperationContract]
        //void InsertCustomer(Customer customer, bool commit);

        //[OperationContract]
        //void UpdateCustomer(Customer currentCustomer, bool commit);

        //[OperationContract]
        //void DeleteCustomer(String customerId, bool commit);

        //[OperationContract]
        ////List<Order> GetOrders();
        //List<OrderEntity> getOrderList1();

        //[OperationContract]
        //List<Order_Detail> GetOrderDetailForAnOrder(int orderId);

        //[OperationContract]
        //List<Order> GetOrderForACustomer(String customerId);

        //[OperationContract]
        //void CreateOrder(Order order, Order_Detail[] details);

        //[OperationContract]
        //void UpdateOrder(Order currentOrder, Order_Detail[] details, bool commit);

        //[OperationContract]
        //void DeleteOrder(int orderId, bool commit);

        //[OperationContract]
        //void DeleteAnOrderDetailFromAnOrder(int orderId, int orderDetailId, bool commit);

        //[OperationContract]
        //List<Product> GetProducts();

        //[OperationContract]
        //Product GetProductById(int id);

        //[OperationContract]
        //void InsertProduct(Product product, bool commit);

        //[OperationContract]
        //void UpdateProduct(Product currentProduct, bool commit);

        //[OperationContract]
        //void DeleteProduct(int productId, bool commit);

        //[OperationContract]
        //List<Category> GetProductCategories();

        //[OperationContract]
        //List<Supplier> GetSuppliers();

        [OperationContract]
        void Commit();
    }

}
