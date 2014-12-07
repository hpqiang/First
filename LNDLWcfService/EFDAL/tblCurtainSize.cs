namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCurtainSize")]
    public partial class tblCurtainSize
    {
        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(20)]
        public string unit { get; set; }
    }
}
