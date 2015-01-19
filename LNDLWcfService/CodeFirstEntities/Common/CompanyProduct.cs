using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities.Common
{
    [DataContract(IsReference = true)]
    public class CompanyProduct
    {
        [DataMember]
        public int Id { get; set; }

        //[DataMember]
        //public virtual int FKCompanyID { get; set; }
        //[DataMember]
        //public virtual Company Company { get; set; }

        //[DataMember]
        //public virtual int FKProductID { get; set; }
        //[DataMember]
        //public virtual Product Product { get; set; }

        [DataMember]
        bool? isValid { get; set; }
    }
}