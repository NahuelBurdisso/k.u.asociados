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
    public class CaseService : ICaseService
    {
        public KuasociadosEntities db { get; set; }

        public LawyerService lawyerservice { get; set; }
        public ClientService clientservice { get; set; }
        public StateService stateservice { get; set; }
        public CaseService()
        {
            this.db = new KuasociadosEntities();
        }

        public Case getCaseById(int? id)
        {
            var _case = db.Cases.Where(x => (x.Id == id)).SingleOrDefault();


            var case1 = new Case()
            {
                Id = _case.Id,
                InitiationDate = _case.InitiationDate,
                IdLawyer = _case.IdLawyer,
                IdClient = _case.IdClient,
                Description = _case.Description,
                StateHistory = this.stateservice.getStatesbyCase(_case.Id),
            };

            return case1;
        }


        public void saveCases(Case _case)
        {
            Cases case1 = new Cases()
            {
                Id = _case.Id,
                InitiationDate = _case.InitiationDate,
                IdLawyer = _case.IdLawyer,
                IdClient = _case.IdClient,
                Description = _case.Description,
            };
           
            db.Cases.Add(case1);
            db.SaveChanges();
        }

        public List<Case> getCasesbyLawyer(int? idlawyer)
        {
            List<Cases> caseslist = db.Cases.Where(x => (x.IdLawyer == idlawyer)).ToList();
            var caseslist1 = new List<Case>();

            foreach (Cases  _case in caseslist)
            {
                Case caseitem = new Case()
                {
                    Id = _case.Id,
                    InitiationDate = _case.InitiationDate,
                    IdLawyer = _case.IdLawyer,
                    IdClient = _case.IdClient,
                    Description = _case.Description,
                    StateHistory = this.stateservice.getStatesbyCase(_case.Id),
                };
           
                caseslist1.Add(caseitem);
            }
            return caseslist1;
        }

        public List<Case> getCasesbyClient(int? idclient)
        {
            List<Cases> caseslist = db.Cases.Where(x => (x.IdClient == idclient)).ToList();
            var caseslist1 = new List<Case>();

            foreach (Cases _case in caseslist)
            {
                Case caseitem = new Case()
                {
                    Id = _case.Id,
                    InitiationDate = _case.InitiationDate,
                    IdLawyer = _case.IdLawyer,
                    IdClient = _case.IdClient,
                    Description = _case.Description,
                };

                this.stateservice = new StateService();
                caseitem.StateHistory = this.stateservice.getStatesbyCase(_case.Id);

                caseslist1.Add(caseitem);
            }
            return caseslist1;
        }

        public void saveCase(Case _case)
        {
            throw new NotImplementedException();
        }
    }
}
