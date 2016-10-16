using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface ILawyerService
    {
        int getLastestId();
        Lawyer getLawyerById(int? id);
        List<Lawyer> getLawyers();
        void saveLawyer(Lawyer lawyer);

        void deleteLawyer(int id);

        void editLawyer(Lawyer lawyer);

        List<Notification> getNotifications(int id);
    }
}