using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Institution
    {

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Dirección")]
        public virtual string Direccion { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Horario de atención:")]
        public virtual string HorarioAtencion { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Display(Name = "Teléfono:")]
        public virtual string Tel { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Display(Name = "Celular:")]
        public virtual string Celular { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Display(Name = "Mail:")]
        public virtual string Mail { get; set; }
    }
}