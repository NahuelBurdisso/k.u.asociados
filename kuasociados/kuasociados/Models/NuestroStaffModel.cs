using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace kuasociados.Models
{
    public class NuestroStaffModel
    {
        public List<Lawyer> lawyers {get; set;}
        public List<Employee> employees {get; set;}
    }
}