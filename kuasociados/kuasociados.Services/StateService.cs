using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using kuasociados.Data;



namespace kuasociados.Services
{
    public class StateService : IStateService
    {
        public KuasociadosEntities db { get; set; }

       
        public StateService()
        {
            this.db = new KuasociadosEntities();
        }

        public State getStateById(int? id)
        {
            var state = db.States.Where(x => (x.Id == id)).SingleOrDefault();
            
            var state1 = new State()
            {
                Id = state.Id,
                InitiationDate = state.InitiationDate,
                Description = state.Description,
                Comment = state.Comment,
            };

            return state1;
        }

        public List<State> getStatesbyCase(int? idcase)
        {
            List<State> state1 = new List<State>();
            var stateslist = db.States.Where(x => (x.IdCase == idcase)).ToList();

            foreach (States state in stateslist)
            {

                State stateitem = new State()
                {
                    Id = state.Id,
                    InitiationDate = state.InitiationDate,
                    Comment = state.Comment,
                    Description = state.Description,
                    IdCase = state.IdCase,

            };
                state1.Add(stateitem);
            }
            return state1;
        }

        public void saveState(State state)
        {
            States state1 = new States()
            {
                Id = state.Id,
                InitiationDate = state.InitiationDate,
                Comment = state.Comment,
                IdCase = state.IdCase,
            };

            db.States.Add(state1);
            db.SaveChanges();
        }
    }
}
