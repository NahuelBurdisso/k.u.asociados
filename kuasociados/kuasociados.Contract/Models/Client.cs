using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Contract.Models
{
    public class Client: People
    {
        public virtual int IdPerson { get; set; }
    }
}