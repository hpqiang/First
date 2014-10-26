namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblRawTextile")]
    public partial class tblRawTextile
    {
        public tblRawTextile()
        {
            tblDrapery = new HashSet<tblDrapery>();
            tblFabric = new HashSet<tblFabric>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [StringLength(10)]
        public string type { get; set; }

        [Required]
        [StringLength(20)]
        public string material { get; set; }

        public int colorID { get; set; }

        public int? colorCodeID { get; set; }

        public int? patternID { get; set; }

        [StringLength(20)]
        public string GSM { get; set; }

        [StringLength(20)]
        public string construction { get; set; }

        public bool? isFR { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public virtual tblColor tblColor { get; set; }

        public virtual ICollection<tblDrapery> tblDrapery { get; set; }

        public virtual ICollection<tblFabric> tblFabric { get; set; }

        public virtual tblPattern tblPattern { get; set; }
    }
}
