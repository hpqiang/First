namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPattern")]
    public partial class tblPattern
    {
        public tblPattern()
        {
            tblRawTextile = new HashSet<tblRawTextile>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public virtual ICollection<tblRawTextile> tblRawTextile { get; set; }
    }
}
