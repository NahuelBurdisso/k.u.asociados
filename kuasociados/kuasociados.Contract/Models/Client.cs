using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Client: People
    {
        public virtual int IdPerson { get; set; }

        [Display(Name = "Casos que tiene a cargo:")]
        public virtual List<Case> caseList { get; set; }
    }
}