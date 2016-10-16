using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Nombre de usuario:")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}