﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Notification
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío.")]
        [Display(Name = "Nombre:")]
        public virtual string Description { get; set; }

        public virtual Lawyer Lawyer{ get; set; }
    }
}