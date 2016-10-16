using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Employee: People
    { 
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Puesto laboral:")]
        public virtual string  Job { get; set; }

        public virtual int IdPerson { get; set; }
    }
}