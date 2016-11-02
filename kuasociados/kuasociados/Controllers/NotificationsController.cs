using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kuasociados.Contract;
using kuasociados.Contract.Models;
using WebMatrix.Data;
using WebMatrix.WebData;


namespace kuasociados.Controllers
{
    public class NotificationsController : Controller
    {
        public IUserService userservice { get; set; }
        public INotificationService notificationservice { get; set; }


        public NotificationsController(IUserService _userservice,
                                 INotificationService _notificationservice)
        {
            this.userservice = _userservice;
            this.notificationservice = _notificationservice;
        }
        // GET: Notifications

        [Authorize(Roles = "Lawyer")]
        public ActionResult Index()
        {
            int userid = WebSecurity.CurrentUserId;
            Lawyer lawyer = this.userservice.getLawyerbyUserId(userid);
            var listnotification = this.notificationservice.getActiveNotificationsbyLawyer(lawyer.Id);

            return View(listnotification);
        }

        [Authorize(Roles = "Lawyer")]
        public ActionResult DeactivateNotification(int idnotification)
        {
            this.notificationservice.deactivateNotification(idnotification);
            return RedirectToAction("Index");
        }

    }
}