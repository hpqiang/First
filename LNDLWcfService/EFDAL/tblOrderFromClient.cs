namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOrderFromClient")]
    public partial class tblOrderFromClient
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

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string issues { get; set; }

        [Column(TypeName = "date")]
        public DateTime? startDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? expectDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? unitPrice { get; set; }

        [StringLength(10)]
        public string currency { get; set; }

        [StringLength(10)]
        public string unit { get; set; }

        public int? expectedQty { get; set; }

        [StringLength(50)]
        public string clientDeposite { get; set; }

        public int? orderToVendorId { get; set; }

        [StringLength(50)]
        public string invoiceNo { get; set; }

        public int? actualQty { get; set; }

        [StringLength(5)]
        public string wareHousing { get; set; }

        [StringLength(50)]
        public string clientPOFile { get; set; }

        [Column(TypeName = "date")]
        public DateTime? itemCreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? itemUpdateDate { get; set; }

        public string note { get; set; }
    }
}
