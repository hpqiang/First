using LNDLWcfService.CodeFirstEntities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    [DataContract(IsReference = true)]
    public class OrderToSupplier
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        [Display(Name = "PO Number")]
        public string purchaseOrderNumber { get; set; }
        [DataMember]
        [Display(Name = "Sale Order Number")]
        public string salesOrderNumber { get; set; }
        [DataMember]
        [Display(Name = "Order Date")]
        public DateTime? orderDate { get; set; }
        [DataMember]
        [Display(Name = "Due Date")]
        public DateTime? dueDate { get; set; }
        [DataMember]
        [Display(Name = "Date Modified")]
        public DateTime? modifiedDate { get; set; }
        //public bool onLineOrder { get; set; }
        [DataMember]
        [Display(Name = "Sub Total")]
        public int subTotal { get; set; }
        [DataMember]
        [Display(Name = "PDF File")]
        public string orderPDFPath { get; set; }

        //[DataMember]
        //[ForeignKey("Product")]
        //public virtual int FKProductID { get; set; }
        //[DataMember]
        //public virtual Product Product { get; set; }

        [DataMember]
        public virtual List<Product> Products { get; set; }

        //public int promotionId{get;set;}
        [DataMember]
        public virtual List<LineItem> LineItems { get; set; }
        [DataMember]
        public virtual List<Payment> payment { get; set; }
        //public virtual List<OrderToOrder> orderToOrders { get; set; }

        [DataMember]
        public virtual List<Shipping> Shipping { get; set; }
    }
}