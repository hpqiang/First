using LNDLWcfService.CodeFirstEntities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public enum ShippingStatus
    {
        PREPARE,
        ONROUTE,
        ARRIVECUSTOM,
        ARRIVEWAREHOUSE
    }

    public class Shipping
    {
        public int Id { get; set; }

        //[ForeignKey("Company")]
        //public int shipperId { get; set; }
        //public int productId { get; set; }
        //public int productDetailId { get; set; }
        //[ForeignKey("Address")]
        //public int shipFromId { get; set; }
        //[ForeignKey("Address")]
        //public int shipToId { get; set; }
        public DateTime? start { get; set; }
        public DateTime? expectTime { get; set; }
        public DateTime? arrivalTime { get; set; }
        public ShippingStatus shippingStatus { get; set; }
        //public int amount { get; set; }
        //MQ: To do-- a new LineItem with actual product amount
        //public List<ShipList> shipList {get;set;}
        public virtual List<LineItem> lineItems { get; set; }

    }
}