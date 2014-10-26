namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCurtain")]
    public partial class tblCurtain
    {
        public tblCurtain()
        {
            tblClientProduct = new HashSet<tblClientProduct>();
            tblVendorProduct = new HashSet<tblVendorProduct>();
        }

        public int id { get; set; }

        [StringLength(30)]
        public string name { get; set; }

        public virtual ICollection<tblClientProduct> tblClientProduct { get; set; }

        public virtual ICollection<tblVendorProduct> tblVendorProduct { get; set; }
    }
}
