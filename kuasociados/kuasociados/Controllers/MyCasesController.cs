﻿using System;
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
    public class MyCasesController : Controller
    {
        public IUserService userservice;
        public IClientService clientservice;
        public ILawyerService lawyerservice;
        public INotificationService notificationservice;
        public IStateService stateservice;
        public ICaseService caseservice;


        public MyCasesController(IUserService _userservice,
                                 IClientService _clientservice,
                                 ILawyerService _lawyerservice,
                                 INotificationService _notificationservice,
                                 IStateService _stateservice,
                                 ICaseService _caseservice) {
            this.userservice = _userservice;
            this.clientservice = _clientservice;
            this.lawyerservice = _lawyerservice;
            this.notificationservice = _notificationservice;
            this.stateservice = _stateservice;
            this.caseservice = _caseservice;
        }

        // GET: MyCases
        [Authorize(Roles = "Client")]
        public ActionResult ClientCases()
        {
            var userid = WebSecurity.CurrentUserId;
            var client = this.userservice.getClientbyUserId(userid);
            return View(client);
        }

        [Authorize(Roles = "Client")]
        public ActionResult SendNotification(int idLawyer)
        {
            ViewBag.idLawyer = idLawyer;
            return View();
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendNotification(Notification notification)
        {
            int newid = this.notificationservice.getLatestId() + 1;
            //../ Content / img / background - 10.jpg
            notification.Id = newid;
            notification.Active = true;
            if (ModelState.IsValid)
            {
                this.notificationservice.saveNotification(notification);
                return RedirectToAction("ClientCases");
            }
            else
            {
                return View(notification);
            }
        }
        // GET: MyCases
        [Authorize(Roles = "Lawyer")]
        public ActionResult LawyerCases()
        {
            var userid = WebSecurity.CurrentUserId;
            var lawyer = this.userservice.getLawyerbyUserId(userid);
            return View(lawyer);
        }

        [Authorize(Roles = "Lawyer")]
 
        public ActionResult AddComment(int? idstate)
        {
            State state = this.stateservice.getStateById(idstate);
            if (state == null)
            {
                return HttpNotFound();
            }
            return View(state);
        }

        [Authorize(Roles = "Lawyer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(State state)
        {
            if (ModelState.IsValid)
            {
                this.stateservice.addComment(state);
                return RedirectToAction("LawyerCases");
            }
            return View(state);
        }

        [Authorize(Roles = "Lawyer")]
        public ActionResult CreateState(int IdCase)
        {
            ViewBag.IdCase = IdCase;
            return View();
        }

        [Authorize(Roles = "Lawyer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateState(State state)
        {
            int newid = this.stateservice.getLastestId() + 1;

            state.Id = newid;
            if (ModelState.IsValid)
            {
                this.stateservice.saveState(state);
                return RedirectToAction("LawyerCases");
            }
            else
            {
                return View(state);
            }
        }

        [Authorize(Roles = "Lawyer")]
        public ActionResult CreateCase(int IdLawyer)
        {
            ViewBag.IdLawyer = IdLawyer;
            ViewBag.ClientList = this.clientservice.getClients();
            return View();
        }
       
        [Authorize(Roles = "Lawyer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCase(Case _case)
        {
            int newid = this.caseservice.getLastestId() + 1;

            _case.Id = newid;
            if (ModelState.IsValid)
            {
                this.caseservice.saveCase(_case);
                return RedirectToAction("LawyerCases");
            }
            else
            {
                return View(_case);
            }
        }

    }
}
