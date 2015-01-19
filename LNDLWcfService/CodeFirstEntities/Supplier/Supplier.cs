using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class Supplier
    {
        public int Id { get; set; }

        public string logo { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Office> Offices { get; set; }
        public List<Product> Products { get; set; }
        public List<Shipper> Shippers { get; set; }
        public List<Order> Orders { get; set; } //??
    }
}