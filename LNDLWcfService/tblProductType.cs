namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblProductType")]
    public partial class tblProductType
    {
        public int id { get; set; }

        [Required]
        [StringLength(20)]
        public string productType { get; set; }
    }
}
