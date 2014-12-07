namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDrapery")]
    public partial class tblDrapery
    {
        public tblDrapery()
        {
            tblClientProduct = new HashSet<tblClientProduct>();
            tblVendorProduct = new HashSet<tblVendorProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public int rawTextileID { get; set; }

        public int? colorID { get; set; }

        public int? lengthID { get; set; }

        public virtual ICollection<tblClientProduct> tblClientProduct { get; set; }

        public virtual tblRawTextile tblRawTextile { get; set; }

        public virtual ICollection<tblVendorProduct> tblVendorProduct { get; set; }
    }
}
