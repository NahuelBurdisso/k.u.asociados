using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface IStateService
    {
        State getStateById(int? id);
        List<State> getStatesbyCase(int? idcase);
        void saveState(State state);

    }
}