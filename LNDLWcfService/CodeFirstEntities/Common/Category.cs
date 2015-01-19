using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities.Common
{
    [DataContract(IsReference = true)]
    public class Category
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Display(Name = "Category")]
        public string categoryName { get; set; }

        [DataMember]
        public virtual List<Product> Products { get; set; }
    }
}