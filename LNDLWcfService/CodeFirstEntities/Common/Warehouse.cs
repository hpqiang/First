using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class Warehouse 
    {
        public int Id { get; set; }
        public string phoneNumber { get; set; }
        public string Area { get; set; }

        public int AddressId { get; set; }
        //public Address Address { get; set; }

        public List<Product> Products { get; set; }
    }
}