using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities.Order
{

    public enum OrderStatus
    {
        RECEIVED,
        ISSUES,
        MANU, //Manufactering
        SHIP,
        ARRIVE
    }

    public enum MoneyType
    {
        USD,
        RMB,
        CAD
    }

    [DataContract(IsReference = true)]
    public class LineItem
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int orderQty { get; set; }
        [DataMember]
        public decimal unitPrice { get; set; }
        [DataMember]
        public decimal unitPriceDiscount { get; set; }
        [DataMember]
        public decimal lineTotal { get; set; }

        [DataMember]
        public MoneyType moneyType { get; set; }

        [DataMember]
        public OrderStatus orderStatus { get; set; }

        [DataMember]
        public DateTime? issueDate { get; set; }
        [DataMember]
        public DateTime? expectedDatebyCustomer { get; set; }
        [DataMember]
        public DateTime? expectedDate { get; set; }
        [DataMember]
        public DateTime? manufacturingDate { get; set; }
        [DataMember]
        public DateTime? exMillDate { get; set; }
        [DataMember]
        public DateTime? shippingDate { get; set; }
        [DataMember]
        public DateTime? arriveDate { get; set; }
        [DataMember]
        public DateTime? inWareHouseDate { get; set; }

        [DataMember]
        [ForeignKey("OrderFromCustomer")]
        public int customerOrderId { get; set; }
        [DataMember]
        public OrderFromCustomer OrderFromCustomer { get; set; }

        [DataMember]
        [ForeignKey("OrderToSupplier")]
        public int supplierOrderId { get; set; }
        [DataMember]
        public OrderToSupplier OrderToSupplier { get; set; }

        //[DataMember]
        //[ForeignKey("Product")]
        //public int productId { get; set; }
        //[DataMember]
        //public Product Product { get; set; }

        [DataMember]
        [ForeignKey("Shipping")]
        public int shippingId { get; set; }
        [DataMember]
        public Shipping Shipping { get; set; }
    }
}