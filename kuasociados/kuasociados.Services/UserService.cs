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
    public class UserService: IUserService
    {
        public KuasociadosEntities db { get; set; }


        public UserService()
        {
            this.db = new KuasociadosEntities();
        }
        
        public int getLastestPersonId()
        {
            var result = db.Persons.ToList().LastOrDefault();
            if (result != null)
            {
                int id = result.Id;
                return id;
            }
            else
            {
                return 0;
            }
        }

        public void saveUser(RegisterModel user)
        {

        }
    }
}
