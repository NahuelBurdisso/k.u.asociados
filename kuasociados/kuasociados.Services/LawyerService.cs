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
            var specialty = new Specialty() {
                Id = lawyer.Specialties.Id,
                Description = lawyer.Specialties.Description,
            };
            
            Lawyer lawyer1 = new Lawyer()
            {
                Id = lawyer.Id,
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
                Specialty = specialty,
            };
            return lawyer1;
        }
        public List<Lawyer> getLawyers()
        {
            List<Lawyer> lawyers1 = new List<Lawyer>();
            var lawyerslist = db.Lawyers.ToList();
            foreach (Lawyers lawyer in lawyerslist)
            {
                var specialty = new Specialty()
                {
                    Id = lawyer.Specialties.Id,
                    Description = lawyer.Specialties.Description,
                };
                Lawyer lawyeritem = new Lawyer()
                {
                    Id = lawyer.Id,
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
                    Specialty = specialty,
                };

                lawyers1.Add(lawyeritem);
            }
            return lawyers1;
        }
        public void saveLawyers(Lawyer lawyer)
        {
            Lawyers lawyer1 = new Lawyers()
            {
                Id = lawyer.Id,
                IdSpecialty = lawyer.Specialty.Id,
            };
            lawyer1.Persons.LastName = lawyer.LastName;
            lawyer1.Persons.Email = lawyer.Email;
            lawyer1.Persons.Dni = lawyer.Dni;
            lawyer1.Persons.Gender = lawyer.Gender;
            lawyer1.Persons.BornDate = lawyer.BornDate;
            lawyer1.Persons.City = lawyer.City;
            lawyer1.Persons.ProfileImg = lawyer.ProfileImg;
            lawyer1.Persons.Province = lawyer.Province;
            lawyer1.Persons.Codep = lawyer.Codep;
            lawyer1.Persons.Tel = lawyer.Tel;
  
            db.Lawyers.Add(lawyer1);
            db.SaveChanges();
        }

        public void deleteLawyer(int id)
        {
            Lawyers lawyer = db.Lawyers.Where(x => (x.Id == id)).SingleOrDefault();
            db.Lawyers.Remove(lawyer);
            db.SaveChanges();
        }

        public void editNews(Lawyer lawyer)
        {
            var result = db.Lawyers.SingleOrDefault(x => x.Id == lawyer.Id);
            if (result != null)
            {
                result.Id = lawyer.Id;
                result.IdSpecialty = lawyer.Specialty.Id;
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
                db.SaveChanges();
            }
        }
    }
}
