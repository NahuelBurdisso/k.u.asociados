using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class Client: People
    {
        public virtual int idClient { get; set; }

        [Display(Name = "Ingrese una Imagen de Perfil:")]
        public virtual string profileImg { get; set; } //TODO analizar que tipo es

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Casos de los que participa:")]
        public virtual List<Case> caseList { get; set; }

    }
}