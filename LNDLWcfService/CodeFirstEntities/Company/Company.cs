using LNDLWcfService.CodeFirstEntities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public enum CompanyType
    {
        BUYER_CUSTOMER,  //customer
        RETAIL_CUSTOMER,
        SUPPLIER, //supplier
        IMPORTER, //importer
        SHIPPER  //shipper
    }

    [DataContract(IsReference=true)]
    public /*partial*/ class Company// : IValidatableObject
    {
        //protected Company()
        //{
        //    //List<Office> Offices = new List<Office>();
        //}

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        //[Required]
        [Display(Name = "Abbreviation")]
        public string BriefName { get; set; }
        [DataMember]
        //[Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [DataMember]
        [DisplayName("Customer Type")]
        public CompanyType? companyType { get; set; }
        [DataMember]
        public string Phone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        [Display(Name = "web site")]
        public string WebSite { get; set; }
        [DataMember]
        [Display(Name = "date since")]
        public DateTime? DateSince { get; set; }
        [DataMember]
        [Display(Name = "Is Active(Y/N)")]
        public bool IsActive { get; set; }
        [DataMember]
        public string logo { get; set; }
        [DataMember]
        [DisplayName("Country")]
        public string country { get; set; }

        [DataMember]
        public virtual List<Office> Offices { get; set; }

        [DataMember]
        public virtual List<CompanyProduct> CompanyProduct { get; set; }
        //public virtual List<Contact> Contacts { get; set; }

        //public virtual List<OrderFromCustomer> OrderFromCustomer { get; set; }
        //public virtual List<OrderToSupplier> OrderToSupplier { get; set; }
    }
}