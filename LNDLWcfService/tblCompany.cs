namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCompany")]
    public partial class tblCompany
    {
        public tblCompany()
        {
            tblClientProduct = new HashSet<tblClientProduct>();
            tblOrderClientVendorMapping = new HashSet<tblOrderClientVendorMapping>();
            tblOrderClientVendorMapping1 = new HashSet<tblOrderClientVendorMapping>();
            tblVendorProduct = new HashSet<tblVendorProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string briefName { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string street { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string state { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(10)]
        public string postCode { get; set; }

        [StringLength(20)]
        public string companyType { get; set; }

        [StringLength(50)]
        public string contactPerson { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(20)]
        public string alternativePhone { get; set; }

        [StringLength(20)]
        public string fax { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string website { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateSince { get; set; }

        public virtual ICollection<tblClientProduct> tblClientProduct { get; set; }

        public virtual ICollection<tblOrderClientVendorMapping> tblOrderClientVendorMapping { get; set; }

        public virtual ICollection<tblOrderClientVendorMapping> tblOrderClientVendorMapping1 { get; set; }

        public virtual ICollection<tblVendorProduct> tblVendorProduct { get; set; }
    }
}
