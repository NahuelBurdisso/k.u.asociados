﻿using System;
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
        public INotificationService notificationservice { get; set; }

        public SharedController(IUserService _userservice,
                                 INotificationService _notificationservice )
        {
            this.userservice = _userservice;
            this.notificationservice = _notificationservice;
        }

        // GET: Shared
        [Authorize(Roles = "Lawyer")]
        public int GetActiveNotificationsQuant()
        {
            int userid = WebSecurity.CurrentUserId;
            Lawyer lawyer = this.userservice.getLawyerbyUserId(userid);
            var listnotification = this.notificationservice.getActiveNotificationsbyLawyer(lawyer.Id);
            
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