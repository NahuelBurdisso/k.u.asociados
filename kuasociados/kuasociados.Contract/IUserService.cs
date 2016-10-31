using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;


namespace kuasociados.Contract
{
    public interface IUserService
    {
        int getLastestPersonId();
        Lawyer getLawyerbyUserId(int userid);

        Client getClientbyUserId(int userid);
        Employee getEmployeebyUserId(int userid);
    }
}
