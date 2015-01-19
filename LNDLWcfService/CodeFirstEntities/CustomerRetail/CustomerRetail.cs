using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class CustomerRetail
    {
        public int Id { get; set; }

        public int customerId { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
        public DateTime? transactionDate { get; set; }
        public PaymentStatus payment { get; set; }
        public bool? fromInventory { get; set; }
    }
}