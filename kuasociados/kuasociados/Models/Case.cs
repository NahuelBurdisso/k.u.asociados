using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class Case
    {
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "El abogado a cargo:")]
        public virtual Lawyer lawyer { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de iniciación:")]
        public string initiationDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Especialidad:")]
        public virtual Specialty specialty { get; set; }

        [Display(Name = "Estado actual:")]
        public virtual State actualState { get; set; }

        [Display(Name = "Historial:")]
        public virtual List<State> stateHistory { get; set; }
    }
}