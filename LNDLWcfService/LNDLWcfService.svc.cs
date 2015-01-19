using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity;
using System.IO;
using LNDLWcfService.CodeFirstDAL;
using LNDLWcfService.CodeFirstEntities;
//using LNDLWcfService.CodeFirstDAL.Order;
using LNDLWcfService.Common;
using LNDLWcfService.CodeFirstEntities.Common;
//using DevTrends.WCFDataAnnotations;

namespace LNDLWcfService
{
    //[ValidateDataAnnotationsBehavior]
    public class LNDLWcfService : ILNDLWcfService, IWCFUploader
    {
        public List<Company> getCompany(int start, int amount, string search, string sortOrder)
        {
            HywinRepository hr = new HywinRepository();
            List<Company> lc;

            if (!String.IsNullOrEmpty(search))
            {
                lc = hr.GetItemList<Company>(
                    (s => s.BriefName.ToUpper().Contains(search.ToUpper()) || s.FullName.ToUpper().Contains(search.ToUpper())),
                    "Offices");
            }
            else
            {
                lc = hr.GetItemList<Company>(null, "Offices");
            }

            if (sortOrder == "name_desc")
            {
                lc = lc
                    .OrderByDescending(s => s.BriefName)
                    .Skip(start)
                    .Take(amount).ToList();
            }
            else
            {
                lc = lc
                    .OrderBy(s => s.BriefName)
                    .Skip(start)
                    .Take(amount).ToList();
            }

            List<Person> lp = new List<Person>();
            lp = hr.GetItemAll<Person>(null);
            foreach (var d in lc)
            {
                Console.WriteLine(" ID = " + d.Id
                    + " Name = " + d.BriefName
                    + " Full Name = " + d.FullName
                    + " Company Type= " + d.companyType
                    //+ " \n Address = " + c.FirstOrDefault(x=>x.Addresses.Street == d.Addresses.Street).Addresses.Street
                    );
                if (d.Offices.Count > 0)
                {
                    foreach (var x in d.Offices)
                    {
                        List<Person> selectlp = new List<Person>();
                        foreach (var y in x.People)
                        {
                            Person p;
                            //p = lp.Find(s => s.FKOfficeID == x.Id);
                            p = lp.Find(s => s.Id == x.Id);
                            selectlp.Add(p);
                            Console.WriteLine(" Offices = " + x.Id
                                                    + " " + x.buildingName
                                + "Contact: " + p.FirstName + " " + p.LastName
                                );
                        }
                        x.People = selectlp;
                    }
                }
                else
                {
                    Console.WriteLine("No person in Office: ");// + d.Offices..buildingName);
                }

            }

            Console.WriteLine("About to return from CompanyRepsitory class...");
            return lc;
        }

        public int getCompanyTotalNumber(string search)
        {
            int count = 0;
            HywinRepository hr = new HywinRepository();

            if (!String.IsNullOrEmpty(search))
            {
                return count = hr.GetItemCount<Company, int>(
                    (s => s.BriefName.ToUpper().Contains(search.ToUpper()) || s.FullName.ToUpper().Contains(search.ToUpper())));
            }
            else
            {
                return count = hr.GetItemCount<Company, int>(null);
            }
        }

        public void insertCompany(Company company)
        {
            HywinRepository hr = new HywinRepository();
            hr.insertItem<Company>(company);
        }

        public void updateCompany(Company company)
        {
            HywinRepository hr = new HywinRepository();
            hr.updateItem<Company>(company);
        }

        public void deleteCompany(Company company)
        {
            HywinRepository hr = new HywinRepository();
            hr.deleteItem<Company>(company);
        }



        /// <summary> Category Operations
        /// //
        /// </summary>
        /// <param name="start"></param>
        /// <param name="amount"></param>
        /// <param name="search"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>

        public List<Category> getCategory(int start, int amount)
        {
            HywinRepository hr = new HywinRepository();
            List<Category> lp;

            lp = hr.GetItemList<Category>(null, null); //MQ: Temp set the associateClass name, not a good solution

            Console.WriteLine("About to return from getCategory class...");
            return lp;
        }

        public int getCategoryTotalNumber()
        {
            int count = 0;
            HywinRepository hr = new HywinRepository();

            return count = hr.GetItemCount<Category, int>(null);
        }

        public void insertCategory(Category category)
        {
            HywinRepository hr = new HywinRepository();
            hr.insertItem<Category>(category);
        }

        public void updateCategory(Category category)
        {
            HywinRepository hr = new HywinRepository();
            hr.updateItem<Category>(category);
        }

        public void deleteCategory(Category category)
        {
            HywinRepository hr = new HywinRepository();
            hr.deleteItem<Category>(category);
        }

        //end of Category

        /// <summary>
        /// /
        /// </summary>
        /// <param name="start"></param>
        /// <param name="amount"></param>
        /// <param name="search"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>

        //public Object[] getInstanceList(string className, int start, int amount, string search, string sortOrder)
        //{
        //    HywinRepository hr = new HywinRepository();

        //    switch (className)
        //    {
        //        case "Company":
        //            List<Company> lcom;
        //            lcom = getCompany(start, amount, search, sortOrder);
        //            return lcom.ToArray();
        //        case "Category":
        //            List<Category> lc;
        //            lc = hr.GetItemList<Category>(null, null); //MQ: Temp set the associateClass name, not a good solution
        //            Console.WriteLine("About to return from getInstanceList method...");
        //            return lc.ToArray();
        //        case "Product":
        //            List<Product> lp;
        //            //lp = hr.GetItemList<Product>(null, "Photos"); //MQ: Temp set the associateClass name, not a good solution
        //            lp = getProduct(start, amount, search, sortOrder);
        //            Console.WriteLine("About to return from getInstanceList method...");
        //            return lp.ToArray();
        //        case "OrderFromCustomer":
        //            List<OrderFromCustomer> lo;
        //            lo = getOrderFromCustomer(start, amount, search, sortOrder);
        //            Console.WriteLine("About to return from getInstanceList method...");
        //            return lo.ToArray();
        //        default:
        //            Console.WriteLine("Not processed in getInstanceList method...");
        //            return null;
        //    }
        //}

        //public int getInstanceTotalNumber(string className, string search)
        //{
        //    int count = 0;
        //    HywinRepository hr = new HywinRepository();

        //    //Typeof(className);
        //    //Type myClassType = Type.GetType(className);
        //    //return count = hr.GetItemCount<typeof(myClassType),int>(null);
        //    //Object myClass = Activator.CreateInstance(myClassType);
        //    //return count = hr.GetItemCount<myClassType, int>(null);
        //    switch (className)
        //    {
        //        case "Company":
        //            return count = hr.GetItemCount<Company, int>(null); //MQ: Need to follow style in Product?
        //        case "Category":
        //            return count = hr.GetItemCount<Category, int>(null);
        //        case "Product":
        //            if (!String.IsNullOrEmpty(search))
        //            {
        //                return count = hr.GetItemCount<Product, int>(
        //                    (s => s.Name.ToUpper().Contains(search.ToUpper()))
        //                    );
        //            }
        //            else
        //            {
        //                return count = hr.GetItemCount<Product, int>(null);
        //            }
        //        case "OrderFromCustomer":
        //            if (!String.IsNullOrEmpty(search))
        //            {
        //                return count = hr.GetItemCount<OrderFromCustomer, int>(
        //                    (s => s.purchaseOrderNumber.ToUpper().Contains(search.ToUpper()))
        //                    );
        //            }
        //            else
        //            {
        //                return count = hr.GetItemCount<OrderFromCustomer, int>(null);
        //            }
        //        default:
        //            Console.WriteLine("Not processed in getInstanceTotalNumber method...");
        //            return 0;
        //    }
        //}

        //public void insertInstance(string className, Object obj)
        //{
        //    HywinRepository hr = new HywinRepository();
        //    switch (className)
        //    {
        //        case "Category":
        //            hr.insertItem<Category>((Category)obj);
        //            return;
        //        default:
        //            Console.WriteLine("Not processed in insertCategory method...");
        //            return;
        //    }
        //}

        //public void updateInstance(string className, Object obj)
        //{
        //    HywinRepository hr = new HywinRepository();
        //    switch (className)
        //    {
        //        case "Category":
        //            hr.updateItem<Category>((Category)obj);
        //            return;
        //        default:
        //            Console.WriteLine("Not processed in updateCategory method...");
        //            return;
        //    }
        //}

        //public void deleteInstance(string className, Object obj)
        //{
        //    HywinRepository hr = new HywinRepository();
        //    switch (className)
        //    {
        //        case "Category":
        //            hr.deleteItem<Category>((Category)obj);
        //            return;
        //        default:
        //            Console.WriteLine("Not processed in deleteCategory method...");
        //            return;
        //    }
        //}


        //end of Instance

        public List<Product> getProduct(int start, int amount, string search, string sortOrder)
        {
            HywinRepository hr = new HywinRepository();
            List<Product> lp;

            if (!String.IsNullOrEmpty(search))
            {
                lp = hr.GetItemList<Product>(
                    (s => s.Name.ToUpper().Contains(search.ToUpper())),
                    "Photos");
            }
            else
            {
                lp = hr.GetItemList<Product>(null, "Photos");
            }

            if (sortOrder == "name_desc")
            {
                lp = lp
                    .OrderByDescending(s => s.Name)
                    .Skip(start)
                    .Take(amount).ToList();
            }
            else
            {
                lp = lp
                    .OrderBy(s => s.Name)
                    .Skip(start)
                    .Take(amount).ToList();
            }

            //List<Person> lp = new List<Person>();
            //lp = cr.GetItemAll<Person>(null);
            //foreach (var d in lc)
            //{
            //    Console.WriteLine(" ID = " + d.Id
            //        + " Name = " + d.BriefName
            //        + " Full Name = " + d.FullName
            //        + " Company Type= " + d.companyType
            //        //+ " \n Address = " + c.FirstOrDefault(x=>x.Addresses.Street == d.Addresses.Street).Addresses.Street
            //        );
            //    if (d.Offices.Count > 0)
            //    {
            //        foreach (var x in d.Offices)
            //        {
            //            List<Person> selectlp = new List<Person>();
            //            foreach (var y in x.People)
            //            {
            //                Person p;
            //                p = lp.Find(s => s.FKOfficeID == x.Id);
            //                selectlp.Add(p);
            //                Console.WriteLine(" Offices = " + x.Id
            //                                        + " " + x.buildingName
            //                    + "Contact: " + p.FirstName + " " + p.LastName
            //                    );
            //            }
            //            x.People = selectlp;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("No person in Office: ");// + d.Offices..buildingName);
            //    }

            //}

            Console.WriteLine("About to return from ProductWcfService class...");
            return lp;
        }

        public int getProductTotalNumber(string search)
        {
            int count = 0;
            HywinRepository hr = new HywinRepository();

            if (!String.IsNullOrEmpty(search))
            {
                return count = hr.GetItemCount<Product, int>(
                    (s => s.Name.ToUpper().Contains(search.ToUpper()))
                    );
            }
            else
            {
                return count = hr.GetItemCount<Product, int>(null);
            }
        }

        public void insertProduct(Product product)
        {
            HywinRepository hr = new HywinRepository();
            hr.insertItem<Product>(product);
        }

        public void updateProduct(Product product)
        {
            HywinRepository hr = new HywinRepository();
            hr.updateItem<Product>(product);
        }

        public void deleteProduct(Product product)
        {
            HywinRepository hr = new HywinRepository();
            hr.deleteItem<Product>(product);
        }

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

        public List<OrderToSupplier> getOrderToSupplier(int start, int amount, string search, string sortOrder)
        {
            HywinRepository hr = new HywinRepository();
            List<OrderToSupplier> lp;

            if (!String.IsNullOrEmpty(search))
            {
                lp = hr.GetItemList<OrderToSupplier>(
                    (s => s.purchaseOrderNumber.ToUpper().Contains(search.ToUpper())),
                    "Products");
            }
            else
            {
                lp = hr.GetItemList<OrderToSupplier>(null, "Products");
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

        public int getOrderToSupplierTotalNumber(string search)
        {
            int count = 0;
            HywinRepository hr = new HywinRepository();

            if (!String.IsNullOrEmpty(search))
            {
                return count = hr.GetItemCount<OrderToSupplier, int>(
                    (s => s.purchaseOrderNumber.ToUpper().Contains(search.ToUpper()))
                    );
            }
            else
            {
                return count = hr.GetItemCount<OrderToSupplier, int>(null);
            }
        }

        public void insertOrderToSupplier(OrderToSupplier order)
        {
            HywinRepository hr = new HywinRepository();
            hr.insertItem<OrderToSupplier>(order);
        }

        public void updateOrderToSupplier(OrderToSupplier order)
        {
            HywinRepository hr = new HywinRepository();
            hr.updateItem<OrderToSupplier>(order);
        }

        public void deleteOrderToSupplier(OrderToSupplier order)
        {
            HywinRepository hr = new HywinRepository();
            hr.deleteItem<OrderToSupplier>(order);
        }

        //public List<ProductDetail> getProductDetail()
        //{
        //    ProductRepository pr = new ProductRepository();
        //    List<ProductDetail> pdl = pr.GetProductDetails();

        //    return pdl;
        //}

        //public void insertProductDetail(ProductDetail pd)
        //{
        //    ProductRepository pr = new ProductRepository();
        //    pr.insertProductDetail(pd);
        //}

        //public void updateProductDetail(ProductDetail pd)
        //{
        //    ProductRepository pr = new ProductRepository();
        //    pr.updateProductDetail(pd);
        //}

        //public List<OrderFromCustomer> getOrderFromCustomer()
        //{
        //    OrderRepository or = new OrderRepository();
        //    List<OrderFromCustomer> ofc = or.GetOrderFromCustomer();

        //    return ofc;
        //}

        //public void insertOrderFromCustomer(OrderFromCustomer ofc)
        //{
        //    OrderRepository or = new OrderRepository();
        //    or.insertOrderFromCustomer(ofc);
        //}

        //public void updateOrderFromCustomer(OrderFromCustomer ofc)
        //{
        //    OrderRepository or = new OrderRepository();
        //    or.updateOrderFromCustomer(ofc);
        //}

        //public List<OrderToSupplier> getOrderToSupplier()
        //{
        //    OrderRepository or = new OrderRepository();
        //    List<OrderToSupplier> ots = or.GetOrderToSupplier();

        //    return ots;
        //}

        //public void insertOrderToSupplier(OrderToSupplier ots)
        //{
        //    OrderRepository or = new OrderRepository();
        //    or.insertOrderToSupplier(ots);
        //}

        //public void updateOrderToSupplier(OrderToSupplier ots)
        //{
        //    OrderRepository or = new OrderRepository();
        //    or.updateOrderToSupplier(ots);
        //}

        //public List<OrderToOrder> getOrderToOrder()
        //{
        //    OrderRepository or = new OrderRepository();
        //    List<OrderToOrder> oto = or.GetOrderToOrder();

        //    return oto;
        //}

        //public void insertOrderToOrder(OrderToOrder oto)
        //{
        //    OrderRepository or = new OrderRepository();
        //    or.insertOrderToOrder(oto);
        //}

        //public void updateOrderToOrder(OrderToOrder oto)
        //{
        //    OrderRepository or = new OrderRepository();
        //    or.updateOrderToOrder(oto);
        //}

        //public List<Inventory> getInventory()
        //{
        //    InventoryRepository ir = new InventoryRepository();
        //    List<Inventory> lir = ir.GetInventory();

        //    return lir;
        //}

        //public void insertInventory(Inventory inv)
        //{
        //    InventoryRepository ir = new InventoryRepository();
        //    ir.insertInventory(inv);
        //}

        //public void updateInventory(Inventory inv)
        //{
        //    InventoryRepository ir = new InventoryRepository();
        //    ir.updateInventory(inv);
        //}

        //public List<Shipping> getShipping()
        //{
        //    ShipRepository sr = new ShipRepository();
        //    List<Shipping> lsr = sr.GetShipping();

        //    return lsr;
        //}

        //public void insertShipping(Shipping ship)
        //{
        //    ShipRepository sr = new ShipRepository();
        //    sr.insertShipping(ship);
        //}

        //public void updateShipping(Shipping ship)
        //{
        //    ShipRepository sr = new ShipRepository();
        //    sr.updateShipping(ship);
        //}

        //public List<OrderEntity> getOrderList1()
        //{
        //    return getOrderList();
        //}

        //public List<OrderEntity> getOrderList()

        //public List<OrderEntity> getOrderList1(string sortOrder, string currentFilter, string searchString, int? page)
        //{
        //    List<OrderEntity> l = new List<OrderEntity>();


        //    var orders = from o in db.tblOrder
        //                 select o;
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        orders = orders.Where(s => s.productName.ToUpper().Contains(searchString.ToUpper())
        //                               || s.productType.ToUpper().Contains(searchString.ToUpper()));
        //    }

        //    Console.WriteLine("sort order: " + sortOrder);
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            orders = orders.OrderByDescending(s => s.productName);
        //            break;
        //        //case "Date":
        //        //    students = students.OrderBy(s => s.EnrollmentDate);
        //        //    break;
        //        //case "date_desc":
        //        //    students = students.OrderByDescending(s => s.EnrollmentDate);
        //        //    break;
        //        default:  // Name ascending 
        //            orders = orders.OrderBy(s => s.productName);
        //            break;
        //    }
        //    foreach (var y in orders)
        //    {
        //        OrderEntity order = new OrderEntity();

        //        order.id = y.id;
        //        order.productType = y.productType;
        //        order.productName = y.productName;
        //        order.startDate = y.startDate;
        //        order.expectDate = y.expectDate;
        //        order.clientPOFilePath = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(TBD)" : y.clientPOFile.ToString().Substring(0, y.clientPOFile.ToString().LastIndexOf('/'));
        //        order.clientPOFileName = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(Empty)" : y.clientPOFile.ToString().Substring(y.clientPOFile.ToString().LastIndexOf('/') + 1, y.clientPOFile.ToString().Length - y.clientPOFile.ToString().LastIndexOf('/') - 1);

        //        order.vendorPOFilePath = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(TBD)" : y.vendorPOFile.ToString().Substring(0, y.vendorPOFile.ToString().LastIndexOf('/'));
        //        order.vendorPOFileName = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(Empty)" : y.vendorPOFile.ToString().Substring(y.vendorPOFile.ToString().LastIndexOf('/') + 1, y.vendorPOFile.ToString().Length - y.vendorPOFile.ToString().LastIndexOf('/') - 1);
        //        l.Add(order);
        //    }
        //    return l;
        //    //var x = from o in db.tblOrder
        //    //        //.Take(pageSize)
        //    //        select o;

        //    //foreach (var y in x)
        //    //{
        //    //    OrderEntity order = new OrderEntity();

        //    //    order.id = y.id;
        //    //    order.productType = y.productType;
        //    //    order.productName = y.productName;
        //    //    order.startDate = y.startDate;
        //    //    order.expectDate = y.expectDate;
        //    //    order.clientPOFilePath = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(TBD)" : y.clientPOFile.ToString().Substring(0, y.clientPOFile.ToString().LastIndexOf('/'));
        //    //    order.clientPOFileName = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(Empty)" : y.clientPOFile.ToString().Substring(y.clientPOFile.ToString().LastIndexOf('/') + 1, y.clientPOFile.ToString().Length - y.clientPOFile.ToString().LastIndexOf('/') - 1);

        //    //    order.vendorPOFilePath = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(TBD)" : y.vendorPOFile.ToString().Substring(0, y.vendorPOFile.ToString().LastIndexOf('/'));
        //    //    order.vendorPOFileName = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(Empty)" : y.vendorPOFile.ToString().Substring(y.vendorPOFile.ToString().LastIndexOf('/') + 1, y.vendorPOFile.ToString().Length - y.vendorPOFile.ToString().LastIndexOf('/') - 1);
        //    //    l.Add(order);
        //    //}

        //    //return l;
        //}

        //public List<OrderEntity> getOrderList()
        //{
        //    List<OrderEntity> l = new List<OrderEntity>();

        //    var x = from o in db.tblOrder
        //            select o;

        //    foreach (var y in x)
        //    {
        //        OrderEntity order = new OrderEntity();

        //        order.id = y.id;
        //        order.productType = y.productType;
        //        order.productName = y.productName;
        //        order.startDate = y.startDate;
        //        order.expectDate = y.expectDate;
        //        order.clientPOFilePath = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(TBD)" : y.clientPOFile.ToString().Substring(0, y.clientPOFile.ToString().LastIndexOf('/'));
        //        order.clientPOFileName = (y.clientPOFile == null || y.clientPOFile == "TBD" || y.clientPOFile == "N/A") ? "(Empty)" : y.clientPOFile.ToString().Substring(y.clientPOFile.ToString().LastIndexOf('/') + 1, y.clientPOFile.ToString().Length - y.clientPOFile.ToString().LastIndexOf('/') - 1);

        //        order.vendorPOFilePath = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(TBD)" : y.vendorPOFile.ToString().Substring(0, y.vendorPOFile.ToString().LastIndexOf('/'));
        //        order.vendorPOFileName = (y.vendorPOFile == null || y.vendorPOFile == "TBD" || y.vendorPOFile == "N/A") ? "(Empty)" : y.vendorPOFile.ToString().Substring(y.vendorPOFile.ToString().LastIndexOf('/') + 1, y.vendorPOFile.ToString().Length - y.vendorPOFile.ToString().LastIndexOf('/') - 1);
        //        l.Add(order);
        //    }

        //    return l;
        //    //using (Sample db = new Sample())
        //    //{
        //    var query = (from o in db.tblOrder
        //                 select new OrderEntity()
        //                 {
        //                     id = o.id,
        //                     productType = o.productType,
        //                     productName = o.productName,
        //                     startDate = o.startDate,
        //                     expectDate = o.expectDate,
        //                     clientPOFilePath = o.clientPOFile,// == null ? "(TBD)" : o.clientPOFile.ToString().Substring(0, o.clientPOFile.ToString().LastIndexOf('/')-1),
        //                     //clientPOFileName = o.clientPOFile == null ? "(Empty)" : o.clientPOFile.ToString().Substring(o.clientPOFile.ToString().LastIndexOf('/') + 1, o.clientPOFile.ToString().Length),
        //                     vendorPOFilePath = o.vendorPOFile // == null ? "(TBD)" : o.vendorPOFile.ToString().Substring(0, o.vendorPOFile.ToString().LastIndexOf('/')),
        //                     //vendorPOFileName = o.vendorPOFile == null ? "(Empty)" : o.vendorPOFile.ToString().Substring(o.vendorPOFile.ToString().LastIndexOf('/') + 1, o.vendorPOFile.ToString().Length)
        //                 }
        //                ); //.Take(10);
        //    foreach (var q in query)
        //    {
        //        //q.clientPOFilePath = q.clientPOFilePath.ToString().Substring(q.clientPOFilePath.ToString().LastIndexOf('/'), q.clientPOFilePath.ToString().Length);
        //        //int len = q.clientPOFilePath.ToString().Length;
        //        //string x = q.clientPOFilePath.Substring(0,5);
        //        //Console.Write(q.clientPOFilePath + "\n");
        //        //Console.Write(len + "\n");
        //        if (q.clientPOFilePath != null)
        //        {
        //            string s = q.clientPOFilePath.ToString();
        //            int start = 0;
        //            int end = 0;
        //            if (q.clientPOFilePath.ToString() != "N/A" && q.clientPOFilePath.ToString() != "TBD")
        //            {
        //                start = q.clientPOFilePath.ToString().LastIndexOf('/');
        //                end = q.clientPOFilePath.ToString().Length;

        //                q.clientPOFileName = s.Substring(start + 1, end - start - 1);
        //                Console.WriteLine(q.clientPOFileName + " " + start + " " + end);
        //            }
        //            else
        //                q.clientPOFileName = "Empty";

        //            s = q.vendorPOFilePath.ToString();
        //            start = 0;
        //            end = 0;
        //            if (q.vendorPOFilePath.ToString() != "N/A" && q.vendorPOFilePath.ToString() != "TBD")
        //            {
        //                start = q.vendorPOFilePath.ToString().LastIndexOf('/');
        //                end = q.vendorPOFilePath.ToString().Length;

        //                q.vendorPOFileName = s.Substring(start + 1, end - start - 1);
        //                Console.WriteLine(q.vendorPOFileName + " " + start + " " + end);
        //            }
        //            else
        //                q.vendorPOFileName = "Empty";
        //        }
        //    }
        //    return query.ToList();
        //    //}
        //}

        //public void saveOrder(OrderEntity o)
        //{
        //    //Console.Write("Order: " + o.id +" "+o.productType + " "+o.productName + "\n");
        //    //using(Sample db = new Sample())
        //    //{
        //    tblOrder tblorder = new tblOrder();
        //    tblorder.id = o.id;
        //    tblorder.productType = o.productType;
        //    tblorder.productName = o.productName;
        //    tblorder.startDate = o.startDate;
        //    tblorder.expectDate = o.expectDate;
        //    tblorder.clientPOFile = o.clientPOFilePath + "/" + o.clientPOFileName;
        //    tblorder.vendorPOFile = o.vendorPOFilePath + "/" + o.vendorPOFileName;
        //    //Console.WriteLine(o.clientPOFilePath);
        //    //Console.WriteLine(o.clientPOFileName);
        //    //Console.WriteLine(o.vendorPOFilePath);
        //    //Console.WriteLine(o.vendorPOFileName);
        //    db.Entry(tblorder).State = EntityState.Modified;
        //    db.SaveChanges();
        //    //}
        //    return;
        //}

        //public void SetDBInitializer()
        //{
        //    Console.WriteLine("Calling SetDBInitializer...");
        //    //CompanyContext cc = new CompanyContext();
        //    //Database.SetInitializer<CompanyContext>(new CompanyInitializer());

        //    //cc.Database.Initialize(true);

        //}

        public UploadedFile Upload(Stream Uploading)
        {

            Console.WriteLine("In Upload...");


            UploadedFile upload = new UploadedFile
            {
                FilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
            };

            //Console.WriteLine(upload.FilePath.ToString());
            //int length = 0;
            //using (FileStream writer = new FileStream(upload.FilePath, FileMode.Create))
            //{
            //    int readCount;
            //    var buffer = new byte[8192];
            //    while ((readCount = Uploading.Read(buffer, 0, buffer.Length)) != 0)
            //    {
            //        writer.Write(buffer, 0, readCount);
            //        length += readCount;
            //    }
            //}

            //upload.FileLength = length;

            return upload;
        }

        public UploadedFile Transform(UploadedFile Uploading, string FileName)
        {
            Uploading.FileName = FileName;
            return Uploading;
        }

    }
}
