namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShippingMarkBase")]
    public partial class tblShippingMarkBase
    {
        public int id { get; set; }

        [StringLength(20)]
        public string POnumber { get; set; }

        [StringLength(40)]
        public string itemName { get; set; }

        public int? colorID { get; set; }

        public int? itemTypeID { get; set; }

        [StringLength(20)]
        public string material { get; set; }

        [StringLength(20)]
        public string description { get; set; }
    }
}
