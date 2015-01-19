using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class Shipper
    {
        public int Id { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Office>   Offices { get; set; }
        public List<Order>    Orders { get; set; } //??
    }
}