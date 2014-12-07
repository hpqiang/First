namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblPerson")]
    public partial class tblPerson
    {
        [StringLength(50)]
        public string id { get; set; }

        [Required]
        [StringLength(20)]
        public string firstName { get; set; }

        [StringLength(20)]
        public string lastName { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(20)]
        public string email { get; set; }
    }
}
