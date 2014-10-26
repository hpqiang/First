namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStock")]
    public partial class tblStock
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string productType { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        [StringLength(50)]
        public string color { get; set; }

        [StringLength(50)]
        public string size { get; set; }

        [StringLength(20)]
        public string amount { get; set; }

        [StringLength(20)]
        public string unit { get; set; }

        [StringLength(20)]
        public string positionRack { get; set; }

        [StringLength(20)]
        public string positionLayer { get; set; }
    }
}
