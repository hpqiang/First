namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblManufacturing")]
    public partial class tblManufacturing
    {
        public tblManufacturing()
        {
            tblShipping = new HashSet<tblShipping>();
        }

        public int id { get; set; }

        public int? orderToVendorPOID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expectedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? actualTapeOutDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? actualShippingDate { get; set; }

        public int? shipperID { get; set; }

        public virtual ICollection<tblShipping> tblShipping { get; set; }
    }
}
