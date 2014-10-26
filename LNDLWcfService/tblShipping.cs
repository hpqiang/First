namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShipping")]
    public partial class tblShipping
    {
        public int id { get; set; }

        public int? manufacturingID { get; set; }

        public int? orderToVendorID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expectedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? actualArrivingDate { get; set; }

        public bool? ifPutToStock { get; set; }

        public int? stockID { get; set; }

        public virtual tblManufacturing tblManufacturing { get; set; }
    }
}
