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
            };

            case1.Lawyer = new Lawyer();
            case1.Lawyer.Id = _case.IdLawyer;
            case1.Client = new Client();
            case1.Client.Id = _case.IdClient;

            return case1;
        }
        public List<Case> getCases()
        {
            List<Case> case1 = new List<Case>();
            var caseslist = db.Cases.ToList();
            
            foreach (Cases _case in caseslist)
            {

                Case caseitem = new Case()
                {
                    Id = _case.Id,
                    InitiationDate = _case.InitiationDate,
                };

                case1.Add(caseitem);
            }
            return case1;
        }

        public void saveCases(Case _case)
        {
            Cases case1 = new Cases()
            {
                Id = _case.Id,
                InitiationDate = _case.InitiationDate,
                IdLawyer = _case.Lawyer.Id,
                IdClient = _case.Client.Id,
            };
           
            db.Cases.Add(case1);
            db.SaveChanges();
        }

        public List<Case> getCasesbyLawyer(int? idlawyer)
        {
            throw new NotImplementedException();
        }

        public List<Case> getCasesbyClient(int? idclient)
        {
            throw new NotImplementedException();
        }

        public void saveCase(Case _case)
        {
            throw new NotImplementedException();
        }
    }
}
