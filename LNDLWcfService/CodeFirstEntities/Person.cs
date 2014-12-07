using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        public int ManagerId { get; set; }
        [Required]
        public string CompanyPhone { get; set; }
        public string MobilePhone { get; set; }
        [Required]
        public string Email { get; set; }
        public string photo { get; set; }

        public int companyId { get; set; }
        public virtual Company Company { get; set; }

    }
}