using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities.Order
{
    public class Sale
    {
        public int Id { get; set; }

        public decimal Amount { get; set; } //product amount, not money
        public DateTime? Date { get; set; }

        public virtual List<Payment> payment { get; set; }
    }
}