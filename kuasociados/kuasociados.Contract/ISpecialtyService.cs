using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface ISpecialtyService
    {
        Specialty getSpecialtyById(int id);
        List<Specialty> getSpecialties();

    }
}