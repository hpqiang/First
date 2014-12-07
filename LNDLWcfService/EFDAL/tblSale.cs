namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSale")]
    public partial class tblSale
    {
        public int id { get; set; }

        public int? productID { get; set; }

        public int? clientID { get; set; }

        public int? fromShipORstock { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public double? discount { get; set; }

        [StringLength(5)]
        public string USDorCAD { get; set; }

        public double? amountSold { get; set; }

        [StringLength(10)]
        public string unitInMeterORInchORyard { get; set; }

        [Column(TypeName = "date")]
        public DateTime? biddingDate { get; set; }

        public int? carrierID { get; set; }
    }
}
