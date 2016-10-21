using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kuasociados.Contract.Models;
using kuasociados.Contract;
using System.Net;

namespace kuasociados.Controllers
{
    public class NuestroStaffController : Controller
    {
        public ILawyerService lawyerservice;
        public IEmployeeService employeeservice;
        public ISpecialtyService specialtyservice;
        public NuestroStaffController(ILawyerService _lawyerservice,
                                      IEmployeeService _employeeservice,
                                      ISpecialtyService _specialtyservice)
        {
            this.lawyerservice = _lawyerservice;
            this.employeeservice = _employeeservice;
            this.specialtyservice = _specialtyservice;
        }
        // GET: NuestroStaff
        public ActionResult Index()
        {
            var employeeslist = this.employeeservice.getEmployees();
            var lawyerslist = this.lawyerservice.getLawyers();

            NuestroStaffModel viewModel = new NuestroStaffModel();
            viewModel.lawyers = lawyerslist;
            viewModel.employees = employeeslist;

            return View(viewModel);
        }
        public ActionResult CreateLawyer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLawyer(Lawyer lawyer)
        {
            /**BUSCAR ID PEOPLE */
            /**BUSCAR ID LAWYER */
            lawyer.caseList = new List<Case>();
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(lawyer);
            }
        }
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            /**BUSCAR ID PEOPLE */
            /**BUSCAR ID EMPLOYEE */
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
        public ActionResult CreateSpecialty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSpecialty(Specialty specialty)
        {
            /*BUSCAR PROXIMO ID*/
        
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(specialty);
            }
        }
    }
}