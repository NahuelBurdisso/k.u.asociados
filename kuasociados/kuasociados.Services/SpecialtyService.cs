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
    public class SpecialtyService : ISpecialtyService
    {
        public KuasociadosEntities db { get; set; }

        public SpecialtyService()
        {
            this.db = new KuasociadosEntities();
        }

        public Specialty getSpecialtyById(int? id)
        {
            var specialty = db.Specialties.Where(x => (x.Id == id)).SingleOrDefault();
            var specialty1 = new Specialty()
            {
                Id = specialty.Id,
                Description = specialty.Description,
            };
         
            return specialty1;
        }
        public List<Specialty> getSpecialties()
        {
            List<Specialty> specialties1 = new List<Specialty>();
            var lawyerslist = db.Specialties.ToList();
            foreach (Specialties specialty in lawyerslist)
            {
                Specialty specialtyitem = new Specialty()
                {
                    Id = specialty.Id,
                    Description = specialty.Description,
                };

                specialties1.Add(specialtyitem);
            }
            return specialties1;
        }
        
    }
}
