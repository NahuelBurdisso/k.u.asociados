using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class People
    {
        public virtual int idPeople { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Nombre:")]
        public virtual string firstName { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Apellidos:")]
        public virtual string lastName { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email no es válido.")]
        [Display(Name ="Email:")]
        public virtual string email { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email no es válido.")]
        [Display(Name = "Email de confirmación:")]
        [Compare("email", ErrorMessage = "Los emails no son iguales.")]
        public virtual string emailConfirm { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(10000000, 90000000, ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "DNI:")]
        public virtual string dni { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(typeof(bool), "M", "F", ErrorMessage= "Eliga uno de los dos.")]
        [Display(Name = "Sexo:")]
        public virtual string gender { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ingrese una fecha de nacimiento:")]
        public string bornDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Ciudad:")]
        public virtual string city { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Provincia/Estado:")]
        public virtual string province{ get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Código postal:")]
        public virtual string codep { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Télefono:")]
        public virtual string tel { get; set; }
    }
}