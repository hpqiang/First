namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblShippingMarkCurtain")]
    public partial class tblShippingMarkCurtain
    {
        public int id { get; set; }

        public int shippingMarkBaseID { get; set; }

        [StringLength(20)]
        public string size { get; set; }

        [Column("Q'TY")]
        public int? Q_TY { get; set; }

        [Column("G.W.")]
        [StringLength(20)]
        public string G_W_ { get; set; }

        [StringLength(20)]
        public string LXWXH { get; set; }

        [Column(" # of BOX")]
        [StringLength(20)]
        public string C___of_BOX { get; set; }
    }
}
