using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class State
    {
   
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Estado:")]
        public virtual string Description { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de iniciación:")]
        public virtual DateTime InitiationDate { get; set; }

        [Display(Name = "Comentario:")]
        public virtual string Comment { get; set; }

       
        public virtual int IdCase { get; set; }

    }
}