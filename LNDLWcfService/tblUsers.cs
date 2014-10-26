namespace LNDLWcfService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUsers
    {
        public tblUsers()
        {
            tblResetPasswordRequests = new HashSet<tblResetPasswordRequests>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? createDate { get; set; }

        public int? logOnTries { get; set; }

        public bool? isLocked { get; set; }

        [Column(TypeName = "date")]
        public DateTime? lockedDate { get; set; }

        public virtual ICollection<tblResetPasswordRequests> tblResetPasswordRequests { get; set; }
    }
}
