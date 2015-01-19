using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities.Common
{
    [DataContract(IsReference = true)]
    public class Contact:Person
    {
        //[ForeignKey("Company")]
        //public int companyId { get; set; }
        //public virtual Company Company { get; set; } //MQ: Important---will cause recursive call and stop remoting if used???
        [DataMember]
        [Required]
        public string Title { get; set; }

        [DataMember]
        public virtual int FKOfficeID { get; set; }
        [DataMember]
        public virtual Office Office { get; set; }
    }
}