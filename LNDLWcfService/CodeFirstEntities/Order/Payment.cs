using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities.Order
{
    public enum PaymentStatus
    {
        DEPOSIT,
        INVOICED,
        PAID
    }

    public class Payment
    {
        public int Id { get; set; }

        //[ForeignKey("OrderFromCustomer")]
        //public int orderId { get; set; }
        public PaymentStatus paymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Date { get; set; }
    }
}