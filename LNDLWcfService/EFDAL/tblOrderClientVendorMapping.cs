namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderClientVendorMapping")]
    public partial class tblOrderClientVendorMapping
    {
        public int id { get; set; }

        public int? clientId { get; set; }

        [StringLength(50)]
        public string clientPO { get; set; }

        public int? vendorId { get; set; }

        [StringLength(50)]
        public string vendorPO { get; set; }

        public virtual tblCompany tblCompany { get; set; }

        public virtual tblCompany tblCompany1 { get; set; }
    }
}
