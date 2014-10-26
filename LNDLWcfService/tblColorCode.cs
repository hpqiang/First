namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblColorCode")]
    public partial class tblColorCode
    {
        public int id { get; set; }

        [StringLength(20)]
        public string colorcodeName { get; set; }
    }
}
