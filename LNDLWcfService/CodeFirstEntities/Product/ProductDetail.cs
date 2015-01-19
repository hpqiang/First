using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class ProductDetail
    {
        public int Id { get; set; }

        [Required]
        public string Color { get; set; }
        [Required]
        public string Size { get; set; }

        public string imagePath { get; set; }

        public decimal pricePerUnit { get; set; }
        public decimal retailPricePerUnit { get; set; }
        public decimal discount { get; set; }

        public int totalSaleInUnit { get; set; }
        public decimal totalSaleInMoney { get; set; }
        //public MoneyType? moneyType { get; set; }

        //public List<PackageStyle> PackageStyles { get; set; }
        //public List<Order> Orders { get; set; }
        //public List<ColorAlias> aliases; 
    }
}