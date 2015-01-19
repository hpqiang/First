﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class CompanyNew
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Abbreviation")]
        public string BriefName { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Type { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public DateTime? DateSince { get; set; }
        public bool IsActive { get; set; }
    }
}