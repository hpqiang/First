using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LNDLWcfService.CodeFirstEntities
{
    public class Employee:Person
    {
        public DateTime? HireDate { get; set; }

        //MQ: Sales list here? 
    }
}