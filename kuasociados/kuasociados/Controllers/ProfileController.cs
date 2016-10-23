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
    public class ProfileController : Controller
    {
        public IUserService userservice;
        public IClientService clientservice;
        public ILawyerService lawyerservice;
        public INotificationService notificationservice;
        public IStateService stateservice;
        public ICaseService caseservice;


        public ProfileController(IUserService _userservice,
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
        public ActionResult ClientProfile()
        {
            var userid = WebSecurity.CurrentUserId;
            var client = this.userservice.getClientbyUserId(userid);
            return View(client);
        }

        
        // GET: MyCases
        [Authorize(Roles = "Lawyer")]
        public ActionResult LawyerProfile()
        {
            var userid = WebSecurity.CurrentUserId;
            var lawyer = this.userservice.getLawyerbyUserId(userid);
            return View(lawyer);
        }

        [Authorize(Roles = "Lawyer")]
        public ActionResult EditLawyerProfile(int? idlawyer)
        {
            Lawyer lawyer = this.lawyerservice.getLawyerById(idlawyer);
            if (lawyer == null)
            {
                return HttpNotFound();
            }
            return View(lawyer);
        }

        [Authorize(Roles = "Lawyer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditLawyerProfile(Lawyer lawyer)
        {
            if (ModelState.IsValid)
            {
                this.lawyerservice.editLawyer(lawyer);
                return RedirectToAction("LawyerCases");
            }
            return View(lawyer);
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
