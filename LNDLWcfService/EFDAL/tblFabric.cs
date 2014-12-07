namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblFabric")]
    public partial class tblFabric
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public int rawTextileID { get; set; }

        public int colorID { get; set; }

        public int? widthID { get; set; }

        public virtual tblColor tblColor { get; set; }

        public virtual tblFabricSize tblFabricSize { get; set; }

        public virtual tblRawTextile tblRawTextile { get; set; }
    }
}
