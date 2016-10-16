using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;

namespace kuasociados.Contract
{
    public interface INotificationService
    {
        Notification getNotificationById(int? id);
        List<Notification> getNotificationsbyLawyer(int? idlawyer);
        void saveNotification(Notification notification);

    }
}