using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class State
    {
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Ingrese un nombre de estado:")]
        public virtual string name { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ingrese una fecha de iniciación:")]
        public string initiationDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Ingrese un comentario:")]
        public virtual string comment { get; set; }


    }
}