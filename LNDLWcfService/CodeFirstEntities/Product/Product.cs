using LNDLWcfService.CodeFirstEntities.Common;
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
    public class Product
    {
        //protected Product()
        //{
        //}

        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        [Display(Name = "Product Number")]
        public string productNumber { get; set; }
        [DataMember]
        [Display(Name = "Starndard Cost")]
        public decimal standardCost { get; set; }
        [DataMember]
        [Display(Name = "List Price")]
        public decimal listPrice { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public string Weight { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        [Display(Name = "Sale Start Date")]
        public DateTime? startSaleDate { get; set; }
        [DataMember]
        [Display(Name = "Sale End Date")]
        public DateTime? endSaleDate { get; set; }

        //[Required]
        [ForeignKey("Category")]
        [DataMember]
        public int categoryId { get; set; }
        [DataMember]
        public virtual Category Category { get; set; }

        [DataMember]
        public virtual List<Photo> Photos { get; set; }
        //public virtual List<LineItem> lineItems { get; set; }

        [DataMember]
        public virtual List<CompanyProduct> ProductCompany { get; set; }

        [DataMember]
        public virtual List<OrderFromCustomer> customerOrders { get; set; }

        [DataMember]
        public virtual List<OrderToSupplier> supplierOrders { get; set; }
    }
}