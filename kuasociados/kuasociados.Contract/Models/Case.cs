using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Case
    {

        public virtual int Id { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "El abogado a cargo:")]
        public virtual Lawyer Lawyer { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "El cliente relacionado:")]
        public virtual Client Client { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de iniciación:")]
        public DateTime InitiationDate { get; set; }  

        [Display(Name = "Historial:")]
        public virtual List<State> StateHistory { get; set; }
    }
}