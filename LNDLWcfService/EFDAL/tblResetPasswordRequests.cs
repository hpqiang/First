namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblResetPasswordRequests
    {
        public Guid id { get; set; }

        public int? userID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ResetRequestDateTime { get; set; }

        public virtual tblUsers tblUsers { get; set; }
    }
}
