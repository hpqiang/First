using LNDLWcfService.CodeFirstEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LNDLWcfService.Common;
using LNDLWcfService.CodeFirstEntities.Common;

namespace LNDLWcfService
{
    [ServiceContract]
    public interface ILNDLWcfService
    {
        [OperationContract]
        [ApplyDataContractResolver]
        List<Company> getCompany(int start, int amount, string search, string sortOrder);
        [OperationContract]
        int getCompanyTotalNumber(string search);
        [OperationContract]
        void insertCompany(Company company);
        [OperationContract]
        void updateCompany(Company company);
        [OperationContract]
        void deleteCompany(Company company);

        [OperationContract]
        [ApplyDataContractResolver]
        List<Category> getCategory(int start, int amount);
        [OperationContract]
        int getCategoryTotalNumber();
        [OperationContract]
        void insertCategory(Category category);
        [OperationContract]
        void updateCategory(Category category);
        [OperationContract]
        void deleteCategory(Category category);

        //[OperationContract]
        //[ApplyDataContractResolver]
        //Object[] getInstanceList(string className, int start, int amount, string search, string sortOrder);
        //[OperationContract]
        //[ApplyDataContractResolver]
        //int getInstanceTotalNumber(string className, string search);
        //[OperationContract]
        //[ApplyDataContractResolver]
        //void insertInstance(string className, Object obj);
        //[OperationContract]
        //[ApplyDataContractResolver]
        //void updateInstance(string className, Object obj);
        //[OperationContract]
        //[ApplyDataContractResolver]
        //void deleteInstance(string className, Object obj);

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

        [OperationContract]
        [ApplyDataContractResolver]
        List<OrderToSupplier> getOrderToSupplier(int start, int amount, string search, string sortOrder);
        [OperationContract]
        int getOrderToSupplierTotalNumber(string search);
        [OperationContract]
        void insertOrderToSupplier(OrderToSupplier order);
        [OperationContract]
        void updateOrderToSupplier(OrderToSupplier order);
        [OperationContract]
        void deleteOrderToSupplier(OrderToSupplier order);

        //[OperationContract]
        //List<ProductDetail> getProductDetail();
        //[OperationContract]
        //void insertProductDetail(ProductDetail pd);
        //[OperationContract]
        //void updateProductDetail(ProductDetail pd);

        //[OperationContract]
        //List<OrderFromCustomer> getOrderFromCustomer();
        //[OperationContract]
        //void insertOrderFromCustomer(OrderFromCustomer ofc);
        //[OperationContract]
        //void updateOrderFromCustomer(OrderFromCustomer ofc);

        //[OperationContract]
        //List<OrderToSupplier> getOrderToSupplier();
        //[OperationContract]
        //void insertOrderToSupplier(OrderToSupplier ots);
        //[OperationContract]
        //void updateOrderToSupplier(OrderToSupplier ots);

        //[OperationContract]
        //List<OrderToOrder> getOrderToOrder();
        //[OperationContract]
        //void insertOrderToOrder(OrderToOrder oto);
        //[OperationContract]
        //void updateOrderToOrder(OrderToOrder oto);

        //[OperationContract]
        //List<Inventory> getInventory();
        //[OperationContract]
        //void insertInventory(Inventory inv);
        //[OperationContract]
        //void updateInventory(Inventory inv);

        //[OperationContract]
        //List<Shipping> getShipping();
        //[OperationContract]
        //void insertShipping(Shipping ship);
        //[OperationContract]
        //void updateShipping(Shipping ship);

        //[OperationContract]
        //List<OrderEntity> getOrderList();

        //[OperationContract]
        //List<OrderEntity> getOrderList1(string sortOrder, string currentFilter, string searchString, int? page);

        //[OperationContract]
        //void saveOrder(OrderEntity o);

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
}
