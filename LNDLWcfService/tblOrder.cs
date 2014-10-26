namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrder")]
    public partial class tblOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string productType { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        public int? clientId { get; set; }

        [StringLength(50)]
        public string clientPO { get; set; }

        public int? vendorId { get; set; }

        [StringLength(50)]
        public string vendorPO { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string issues { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expectDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expectEMD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? actualEMD { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? actualDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ETA { get; set; }

        [Column(TypeName = "date")]
        public DateTime? actualETA { get; set; }

        [StringLength(50)]
        public string clientDeposite { get; set; }

        [StringLength(50)]
        public string depositeToVendor { get; set; }

        [StringLength(50)]
        public string invoiceNo { get; set; }

        [StringLength(5)]
        public string wareHousing { get; set; }

        [StringLength(50)]
        public string clientPOFile { get; set; }

        [StringLength(50)]
        public string vendorPOFile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? itemCreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? itemUpdateDate { get; set; }

        public string note { get; set; }
    }
}
