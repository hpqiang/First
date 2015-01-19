using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    [DataContract(IsReference = true)]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        //[Required]
        public string Title { get; set; }
        //[Required]
        //public string Title { get; set; }
        //[DataMember]
        //public int ManagerId { get; set; }
        //[Required]
        //public string CompanyPhone { get; set; }
        [DataMember]
        public string MobilePhone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string photo { get; set; }

        //[DataMember]
        //public virtual int FKOfficeID { get; set; }
        //[DataMember]
        //public virtual Office Office { get; set; }


    }
}