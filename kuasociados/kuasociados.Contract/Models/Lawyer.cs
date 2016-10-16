using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Lawyer : People
    {

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Especialidad:")]
        public virtual Specialty Specialty { get; set; }



        [Display(Name = "Casos que tiene a cargo:")]
        public virtual List<Case> caseList { get; set; }

        public virtual int IdPerson { get; set; }

    }
}