using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNDLWcfService
{
    public class OrderEntity
    {
        public int id { get; set; }
        public string productType { get; set; }
        public string productName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? startDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? expectDate { get; set; }
        public string clientPOFilePath { get; set; }
        public string clientPOFileName { get; set; }
        public string vendorPOFilePath { get; set; }
        public string vendorPOFileName { get; set; }

        //public string ToShortDateString()
        //{
        //    throw new NotImplementedException();
        //}
    }
}