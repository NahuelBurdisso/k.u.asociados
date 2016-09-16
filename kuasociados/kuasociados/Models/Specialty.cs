using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class Specialty
    {
        public virtual int idSpecialty { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Ingrese un nombre para la especialdad:")]
        public virtual string name { get; set; }

        public virtual List<Lawyer> lawyerList { get; set; }
    }
}