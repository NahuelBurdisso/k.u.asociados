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
            ////MOCK ABOGADOS
            //List<Lawyer> lawyers = new List<Lawyer>();

            //Specialty specialty1 = new Specialty();
            //specialty1.Id = 1;
            //specialty1.Description = "Derecho Penal";
            //Specialty specialty2 = new Specialty();
            //specialty2.Id = 2;
            //specialty2.Description = "Relaciones Domésticas";


            //Lawyer lawyer1 = new Lawyer();
            //lawyer1.ProfileImg = "../Content/img/profile/profile-2.jpg";
            //lawyer1.FirstName = "Hernan";
            //lawyer1.LastName = "Escalada";
            //lawyer1.Specialty = specialty1;

            //Lawyer lawyer2= new Lawyer();
            //lawyer2.ProfileImg = "../Content/img/profile/profile-1.jpg";
            //lawyer2.FirstName = "Jose";
            //lawyer2.LastName = "Miranda";
            //lawyer2.Specialty = specialty2;

            //Lawyer lawyer3 = new Lawyer();
            //lawyer3.ProfileImg = "../Content/img/profile/profile-4.jpg";
            //lawyer3.FirstName = "Marina";
            //lawyer3.LastName = "López";
            //lawyer3.Specialty = specialty2;

            //lawyers.Add(lawyer1);
            //lawyers.Add(lawyer2);
            //lawyers.Add(lawyer3);

            ////MOCK EMPLEADOS

            //List<Employee> employees = new List<Employee>();

            //Employee employee1 = new Employee();
            //employee1.ProfileImg = "../Content/img/profile/profile-6.jpg";
            //employee1.FirstName = "Martín";
            //employee1.LastName = "Moralez";
            //employee1.Job = "Recepcionista";

            //Employee employee2 = new Employee();
            //employee2.ProfileImg = "../Content/img/profile/profile-5.jpg";
            //employee2.FirstName = "Ana";
            //employee2.LastName = "Burdisso";
            //employee2.Job = "Investigadora Privada";

            //Employee employee3 = new Employee();
            //employee3.ProfileImg = "../Content/img/profile/profile-10.jpg";
            //employee3.FirstName = "Romina";
            //employee3.LastName = "Perren";
            //employee3.Job = "Cosultora Financiera";

            //employees.Add(employee1);
            //employees.Add(employee2);
            //employees.Add(employee3);


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