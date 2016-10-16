using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface ICaseService
    {
        Case getCaseById(int? id);
        List<Case> getCasesbyLawyer(int? idlawyer);
        List<Case> getCasesbyClient(int? idclient);
        void saveCase(Case _case);

    }
}