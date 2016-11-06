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
    public class InstitutionService : IInstitutionService
    {
        public KuasociadosEntities db { get; set; }

        public InstitutionService()
        {
            this.db = new KuasociadosEntities();
        }

        public Institution getInstitutionInfo()
        {
            var institution = db.Institutions.SingleOrDefault();


            var institution1 = new Institution()
            {
                Direccion = institution.Direccion,
                HorarioAtencion = institution.HorarioAtencion,
                Tel = institution.Tel,
                Celular = institution.Celular,
                Mail = institution.Mail,

            };

            return institution1;
        }

        public void editInstitutionInfo(Institution institution)
        {
            var result = db.Institutions.SingleOrDefault();
            if (result != null)
            {
                result.Direccion = institution.Direccion;
                result.HorarioAtencion = institution.HorarioAtencion;
                result.Tel = institution.Tel;
                result.Celular = institution.Celular;
                result.Mail = institution.Mail;
                db.SaveChanges();
            }
        }
    }
}
