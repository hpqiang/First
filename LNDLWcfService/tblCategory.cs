namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCategory")]
    public partial class tblCategory
    {
        public tblCategory()
        {
            tblClientProduct = new HashSet<tblClientProduct>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        public virtual ICollection<tblClientProduct> tblClientProduct { get; set; }
    }
}
