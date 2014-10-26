namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCurtainInsertCard")]
    public partial class tblCurtainInsertCard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(50)]
        public string cardImage1 { get; set; }

        [StringLength(50)]
        public string cardImage2 { get; set; }
    }
}
