using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class People
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Nombre:")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Apellido:")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email no es válido.")]
        [Display(Name = "Email:")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El email no es válido.")]
        [Display(Name = "Email de confirmación:")]
        [Compare("email", ErrorMessage = "Los emails no son iguales.")]
        public virtual string EmailConfirm { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(10000000, 90000000, ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "DNI:")]
        public virtual string Dni { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Display(Name = "Sexo:")]
        public virtual string Gender { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [DataType(DataType.Date)]
        [Display(Name = "Ingrese una fecha de nacimiento:")]
        public DateTime BornDate { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Ciudad:")]
        public virtual string City { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Provincia/Estado:")]
        public virtual string Province{ get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Código postal:")]
        public virtual string Codep { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [StringLength(160, MinimumLength = 3)]
        [Display(Name = "Télefono:")]
        public virtual string Tel { get; set; }

        
        [Display(Name = "Imagen de Perfil:")]
        public virtual string ProfileImg { get; set; } //TODO analizar que tipo es
    }
}