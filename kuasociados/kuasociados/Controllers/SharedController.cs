using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using kuasociados.Contract;
using kuasociados.Contract.Models;
using WebMatrix.Data;
using WebMatrix.WebData;


namespace kuasociados.Controllers
{
    public class SharedController : Controller
    {
        public IUserService userservice { get; set; }
        public IClientService clientservice { get; set; }
        public INotificationService notificationservice { get; set; }

        public SharedController(IUserService _userservice,
                                 IClientService _clientservice,
                                 INotificationService _notificationservice )
        {
            this.userservice = _userservice;
            this.clientservice = _clientservice;
            this.notificationservice = _notificationservice;
        }

        // GET: Shared

        public int GetNotifications(int idlawyer)
        {
            var listnotification = this.notificationservice.getActiveNotificationsbyLawyer(idlawyer);
            
            var cantnotification = listnotification.Count();
            if (cantnotification != 0)
            {
                return cantnotification;
            }
            else
            {
                return 0;
            }
        }
    }
}