using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public enum AddressType
    {
        CAN = 1,
        CHN,
        USA
    };

    [DataContract(IsReference=true)]
    public class Address
    {
        //protected Address() { }
        [Key, ForeignKey("Office")]
        public int Address_Id { get; set; }
        //public int Id { get; set; }

        [DataMember]
        //[Required]
        public string Number { get; set; }
        [DataMember]
        //[Required]
        public string Street { get; set; }
        //[Required]
        [DataMember]
        public string City { get; set; }
        //[Required]
        [DataMember]
        public string State { get; set; }
        [DataMember]
        //[Required]
        public string Country { get; set; }
        [DataMember]
        //[Required]
        public string ZipCode { get; set; }

        [DataMember]
        public AddressType? addressType { get; set; }

        [DataMember]
        public virtual Office Office { get; set; }
    }
}