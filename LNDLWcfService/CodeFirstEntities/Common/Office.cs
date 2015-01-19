using LNDLWcfService.CodeFirstEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{

    public enum OfficeType
    {
        OFFICE,
        WAREHOUSE
    }
    
    [DataContract(IsReference=true)]
    public class Office
    {
        //protected Office() { }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string buildingName { get; set; }
        [DataMember]
        public string phoneNumber { get; set; }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public OfficeType? type { get; set; }

        [DataMember]
        public virtual int FKCompanyID { get; set; }
        [DataMember]
        public virtual Company Company { get; set; }

        [DataMember]
        public virtual Address Address { get; set; }

        [DataMember]
        public List<Person> People { get; set; }
    }
}