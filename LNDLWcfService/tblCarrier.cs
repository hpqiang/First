namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblCarrier")]
    public partial class tblCarrier
    {
        public int id { get; set; }

        [StringLength(20)]
        public string name { get; set; }

        [StringLength(50)]
        public string website { get; set; }
    }
}
