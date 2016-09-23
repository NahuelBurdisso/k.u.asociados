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
        [Display(Name = "Estado:")]
        public virtual string name { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de iniciación:")]
        public string initiationDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Comentario:")]
        public virtual string comment { get; set; }


    }
}