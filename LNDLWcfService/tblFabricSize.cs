namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFabricSize")]
    public partial class tblFabricSize
    {
        public tblFabricSize()
        {
            tblFabric = new HashSet<tblFabric>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string width { get; set; }

        [StringLength(20)]
        public string unit { get; set; }

        public virtual ICollection<tblFabric> tblFabric { get; set; }
    }
}
