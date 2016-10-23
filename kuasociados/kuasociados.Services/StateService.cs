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


        public int getLastestId()
        {
            var result = db.States.ToList();
            if (result != null)
            {
                int id = result.Last().Id;
                return id;
            }
            else
            {
                return 0;
            }

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
                IdCase = state.IdCase,
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
                Description = state.Description,
                IdCase = state.IdCase,
            };

            db.States.Add(state1);
            db.SaveChanges();
        }
        public void addComment(State state)
        {
            var result = db.States.SingleOrDefault(x => x.Id == state.Id);
            if (result != null)
            {
                result.Comment = state.Comment;
                db.SaveChanges();
            }
        }
    }
}
