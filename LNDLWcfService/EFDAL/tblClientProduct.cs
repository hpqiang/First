namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblClientProduct")]
    public partial class tblClientProduct
    {
        public int id { get; set; }

        public int companyID { get; set; }

        public int categoryID { get; set; }

        public int productID { get; set; }

        public virtual tblCategory tblCategory { get; set; }

        public virtual tblCompany tblCompany { get; set; }

        public virtual tblCurtain tblCurtain { get; set; }

        public virtual tblDrapery tblDrapery { get; set; }
    }
}
