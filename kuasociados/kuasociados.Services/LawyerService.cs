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
    public class LawyerService : ILawyerService
    {
        public KuasociadosEntities db { get; set; }
        public CaseService caseservice { get; set; }

        public UserService userservice { get; set; }

        public LawyerService()
        {
            this.db = new KuasociadosEntities();
            
    }

        public int getLastestId()
        {
            var result = db.Lawyers.ToList();
            if (result != null)
            {
                int id = db.Lawyers.Last().Id;
                return id;
            }
            else
            {
                return 0;
            }

        }

        public Lawyer getLawyerById(int? id)
        {
            var lawyer = db.Lawyers.Where(x => (x.Id == id)).SingleOrDefault();

            Lawyer lawyer1 = new Lawyer()
            {
                Id = lawyer.Id,
                IdPerson = lawyer.IdPerson,
                FirstName = lawyer.Persons.FirstName,
                LastName = lawyer.Persons.LastName,
                Email = lawyer.Persons.Email,
                Dni = lawyer.Persons.Dni,
                Gender = lawyer.Persons.Gender,
                BornDate = lawyer.Persons.BornDate,
                City = lawyer.Persons.City,
                ProfileImg = lawyer.Persons.ProfileImg,
                Province = lawyer.Persons.Province,
                Codep = lawyer.Persons.Codep,
                Tel = lawyer.Persons.Tel,
                IdSpecialty = lawyer.IdSpecialty,
            };
            this.caseservice = new CaseService();
            lawyer1.caseList = this.caseservice.getCasesbyClient(lawyer.Id);
            return lawyer1;
        }
        public List<Lawyer> getLawyers()
        {
            List<Lawyer> lawyers1 = new List<Lawyer>();
            var lawyerslist = db.Lawyers.ToList();
            foreach (Lawyers lawyer in lawyerslist)
            {
                Lawyer lawyeritem = new Lawyer()
                {
                    Id = lawyer.Id,
                    IdPerson = lawyer.IdPerson,
                    FirstName = lawyer.Persons.FirstName,
                    LastName = lawyer.Persons.LastName,
                    Email = lawyer.Persons.Email,
                    Dni = lawyer.Persons.Dni,
                    Gender = lawyer.Persons.Gender,
                    BornDate = lawyer.Persons.BornDate,
                    City = lawyer.Persons.City,
                    ProfileImg = lawyer.Persons.ProfileImg,
                    Province = lawyer.Persons.Province,
                    Codep = lawyer.Persons.Codep,
                    Tel = lawyer.Persons.Tel,
                    IdSpecialty = lawyer.IdSpecialty,
                };
                this.caseservice = new CaseService();
                lawyeritem.caseList = this.caseservice.getCasesbyClient(lawyer.Id);
                lawyers1.Add(lawyeritem);
            }
            return lawyers1;
        }
        public void saveLawyer(RegisterModel lawyer)
        {
            Persons person1 = new Persons();
            person1.FirstName = lawyer.FirstName;
            person1.LastName = lawyer.LastName;
            person1.Email = lawyer.Email;
            person1.Dni = lawyer.Dni;
            person1.Gender = lawyer.Gender;
            person1.BornDate = lawyer.BornDate;
            person1.City = lawyer.City;
            person1.ProfileImg = lawyer.ProfileImg;
            person1.Province = lawyer.Province;
            person1.Codep = lawyer.Codep;
            person1.Tel = lawyer.Tel;

            try
            {
                db.Persons.Add(person1);
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            this.userservice = new UserService();
            int newid = this.userservice.getLastestPersonId();

            Lawyers lawyer1 = new Lawyers();
            lawyer1.IdPerson = newid;
            lawyer1.IdSpecialty = lawyer.IdSpecialty;

            db.Lawyers.Add(lawyer1);
            db.SaveChanges();
        }


        public void deleteLawyer(int id)
        {
            Lawyers lawyer = db.Lawyers.Where(x => (x.Id == id)).SingleOrDefault();
            db.Lawyers.Remove(lawyer);
            db.SaveChanges();
        }

        public void editLawyer(Lawyer lawyer)
        {
            var result = db.Lawyers.SingleOrDefault(x => x.Id == lawyer.Id);
            if (result != null)
            {
                result.IdSpecialty = lawyer.IdSpecialty;
                result.Persons.LastName = lawyer.LastName;
                result.Persons.Email = lawyer.Email;
                result.Persons.Dni = lawyer.Dni;
                result.Persons.Gender = lawyer.Gender;
                result.Persons.BornDate = lawyer.BornDate;
                result.Persons.City = lawyer.City;
                result.Persons.ProfileImg = lawyer.ProfileImg;
                result.Persons.Province = lawyer.Province;
                result.Persons.Codep = lawyer.Codep;
                result.Persons.Tel = lawyer.Tel;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    var exception = ex;
                }
               
            }
        }

        public List<Notification> getNotifications(int id)
        {
            throw new NotImplementedException();
        }
    }
}
