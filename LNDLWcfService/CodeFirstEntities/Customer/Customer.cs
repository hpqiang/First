using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    //public enum CustomerType
    //{
    //    DEPARTMENT,
    //    RETAIL
    //}

    public class Customer : CompanyNew
    {
        //public int Id { get; set; }

        public string logo { get; set; }

        public List<Employee>   Employees { get; set; }
        public List<Office>     Offices { get; set; }
        public List<Warehouse>  WareHouses { get; set; }
        public List<Product>    Products { get; set; }
        public List<Order>      Orders { get; set; } //??
    }
}