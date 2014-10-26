namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShippingMarkFabric")]
    public partial class tblShippingMarkFabric
    {
        public int id { get; set; }

        public int shippingMarkBaseID { get; set; }

        [StringLength(10)]
        public string width { get; set; }

        [StringLength(10)]
        public string length { get; set; }

        [Column("Roll#")]
        public int? Roll_ { get; set; }
    }
}
