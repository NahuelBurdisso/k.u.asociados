using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using kuasociados.Data;
using System.Data.Entity.Validation;



namespace kuasociados.Services
{
    public class NotificationService: INotificationService
    {
        public KuasociadosEntities db { get; set; }

        public NotificationService() {
            this.db = new KuasociadosEntities();
        }

        public int getLatestId()
        {
            var result = db.Notifications.ToList().LastOrDefault();
            if (result != null)
            {
                int id = result.Id;
                return id;
            }
            else {
                return 0;
            }
            
        }

        public List<Notification> getActiveNotificationsbyLawyer(int? idlawyer)
        {
            List<Notification> notification1 = new List<Notification>();
            var notificationlist = db.Notifications.Where(x => (x.IdLawyer == idlawyer)).ToList();
            foreach (Notifications notification in notificationlist)
            {
                Notification notificationitem = new Notification()
                {
                    Id = notification.Id,
                    Description = notification.Description,
                    IdLawyer = notification.IdLawyer,
                    Active = notification.Active,
                };
                if (notificationitem.Active == true) {
                    notification1.Add(notificationitem);
                } 
                
            }
            return notification1;
        }

        public void deactivateNotification(int idnotification)
        {
            var result = db.Notifications.SingleOrDefault(x => x.Id == idnotification);
            if (result != null)
            {
                result.Active = false;
                db.SaveChanges();
            }
        }


        public void saveNotification(Notification notification) {

            Notifications notification1 = new Notifications()
            {
                Id = notification.Id,
                Description = notification.Description,
                IdLawyer = notification.IdLawyer,
                Active = notification.Active,
            };
            db.Notifications.Add(notification1);
           
            db.SaveChanges();
        }
    }
}
