using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using System.Net;
using WebMatrix.Data;
using WebMatrix.WebData;

namespace kuasociados.Controllers
{
    public class NuestroStaffController : Controller
    {
        public IUserService userservice;
        public ILawyerService lawyerservice;
        public IEmployeeService employeeservice;
        public ISpecialtyService specialtyservice;
        public NuestroStaffController(ILawyerService _lawyerservice,
                                      IEmployeeService _employeeservice,
                                      ISpecialtyService _specialtyservice,
                                      IUserService _userservice)
        {
            this.lawyerservice = _lawyerservice;
            this.employeeservice = _employeeservice;
            this.specialtyservice = _specialtyservice;
            this.userservice = _userservice;
        }

        // GET: NuestroStaff

        public ActionResult Index()
        {
            var employeeslist = this.employeeservice.getEmployees();
            var lawyerslist = this.lawyerservice.getLawyers();

            NuestroStaffModel viewModel = new NuestroStaffModel();
            viewModel.lawyers = lawyerslist;
            viewModel.employees = employeeslist;
            ViewBag.SpecialtyList = this.specialtyservice.getSpecialties();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateLawyer()
        {
            ViewBag.SpecialtyList = this.specialtyservice.getSpecialties();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLawyer(RegisterModel model)
        {
            var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
            var membership = (SimpleMembershipProvider)System.Web.Security.Membership.Provider;

            if (ModelState.IsValid)
            {
                this.lawyerservice.saveLawyer(model);
                int newid = this.userservice.getLastestPersonId();
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                                                 propertyValues: new { IdPerson = newid, });


                roles.AddUsersToRoles(new string[] { model.UserName }, new string[] { "Lawyer" });
                return RedirectToAction("Index", "Home");

            }


            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateEmployee(RegisterModel model)
        {
            var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
            var membership = (SimpleMembershipProvider)System.Web.Security.Membership.Provider;

            if (ModelState.IsValid && model.Job != "")
            {
                this.employeeservice.saveEmployee(model);
                int newid = this.userservice.getLastestPersonId();
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                                                 propertyValues: new { IdPerson = newid, });


                roles.AddUsersToRoles(new string[] { model.UserName }, new string[] { "Employee" });
                return RedirectToAction("Index", "Home");

            }


            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateSpecialty()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSpecialty(Specialty specialty)
        {
            int newid = this.specialtyservice.getLatestId() + 1;
            //../ Content / img / background - 10.jpg
            specialty.Id = newid;

            if (ModelState.IsValid)
            {
                this.specialtyservice.saveSpecialty(specialty);
                return RedirectToAction("Index");
            }
            else
            {
                return View(specialty);
            }
        }
    }
}