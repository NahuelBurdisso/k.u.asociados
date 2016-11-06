using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface IInstitutionService
    {
        Institution getInstitutionInfo();

        void editInstitutionInfo(Institution institution);
    }
}