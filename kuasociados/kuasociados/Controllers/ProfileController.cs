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
        public IEmployeeService employeeservice;


        public ProfileController(IUserService _userservice,
                                 IClientService _clientservice,
                                 ILawyerService _lawyerservice,
                                 INotificationService _notificationservice,
                                 IStateService _stateservice,
                                 IEmployeeService _employeeservice,
                                 ICaseService _caseservice) {
            this.userservice = _userservice;
            this.clientservice = _clientservice;
            this.lawyerservice = _lawyerservice;
            this.notificationservice = _notificationservice;
            this.stateservice = _stateservice;
            this.caseservice = _caseservice;
            this.employeeservice = _employeeservice;
        }

        // GET: MyCases

        public ActionResult EmployeeProfile(int? idemployee)
        {
            int userid = WebSecurity.CurrentUserId;
            Employee employeeforauth = this.userservice.getEmployeebyUserId(userid);
            ViewBag.isauthenticated = employeeforauth.Id;
            if (idemployee != null)
            {              
                var employee = this.employeeservice.getEmployeeById(idemployee);
                return View(employee);
            }
            else
            {

                Employee employee = this.userservice.getEmployeebyUserId(userid);
                return View(employee);
            }
        }

        
        // GET: MyCases
        public ActionResult LawyerProfile(int? idlawyer)
        {
            int userid = WebSecurity.CurrentUserId;
            Lawyer lawyerforauth = this.userservice.getLawyerbyUserId(userid);
            ViewBag.isauthenticated = lawyerforauth.Id;

            if (idlawyer != null)
            {
                var lawyer = this.lawyerservice.getLawyerById(idlawyer);
                return View(lawyer);
            }
            else
            {
                Lawyer lawyer = this.userservice.getLawyerbyUserId(userid);
                return View(lawyer); 
            }
            
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
                return RedirectToAction("LawyerProfile");
            }
            return View(lawyer);
        }


        [Authorize(Roles = "Employee")]
        public ActionResult EditEmployeeProfile(int? idemployee)
        {
            Employee employee = this.employeeservice.getEmployeeById(idemployee);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        [Authorize(Roles = "Lawyer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployeeProfile(Employee employee)
        {
            if (ModelState.IsValid)
            {
                this.employeeservice.editEmployee(employee);
                return RedirectToAction("EmployeeProfile");
            }
            return View(employee);
        }

    }
}
