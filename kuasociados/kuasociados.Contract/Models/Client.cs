using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Client: People
    {
        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Casos de los que participa:")]
        public virtual List<Case> Cases { get; set; }

    }
}