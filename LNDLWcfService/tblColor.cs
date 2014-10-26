namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblColor")]
    public partial class tblColor
    {
        public tblColor()
        {
            tblFabric = new HashSet<tblFabric>();
            tblRawTextile = new HashSet<tblRawTextile>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(10)]
        public string RGB { get; set; }

        public virtual ICollection<tblFabric> tblFabric { get; set; }

        public virtual ICollection<tblRawTextile> tblRawTextile { get; set; }
    }
}
