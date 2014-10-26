namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCurtainUPC")]
    public partial class tblCurtainUPC
    {
        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string color { get; set; }

        [StringLength(20)]
        public string size { get; set; }

        [StringLength(20)]
        public string UPC { get; set; }

        [StringLength(20)]
        public string newUPC { get; set; }

        public int? inStock { get; set; }

        [StringLength(10)]
        public string unit { get; set; }
    }
}
