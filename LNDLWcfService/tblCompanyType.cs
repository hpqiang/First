namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCompanyType")]
    public partial class tblCompanyType
    {
        [StringLength(10)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }
    }
}
