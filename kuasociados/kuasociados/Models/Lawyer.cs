using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class Lawyer : People
    {
        public virtual int idLawyer { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Elija una especialidad:")]
        public virtual Specialty specialty { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Ingrese una Imagen de Perfil:")]
        public virtual string profileImg { get; set; } //TODO analizar que tipo es

        [Display(Name = "Casos que tiene a cargo:")]
        public virtual List<Case> caseList { get; set; }



    }
}