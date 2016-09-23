using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class Employee: People
    {
        public virtual int idEmployee { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Imagen de Perfil:")]
        public virtual string profileImg { get; set; } //TODO analizar que tipo es

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Puesto laboral:")]
        public virtual string  job { get; set; }   
    }
}