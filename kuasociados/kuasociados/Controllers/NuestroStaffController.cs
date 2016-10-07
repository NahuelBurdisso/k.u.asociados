using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kuasociados.Models;

namespace kuasociados.Controllers
{
    public class NuestroStaffController : Controller
    {
        // GET: NuestroStaff
        public ActionResult Index()
        {
            //MOCK ABOGADOS
            List<Lawyer> lawyers = new List<Lawyer>();
          
            Specialty specialty1 = new Specialty();
            specialty1.idSpecialty = 1;
            specialty1.name = "Derecho Penal";
            Specialty specialty2 = new Specialty();
            specialty2.idSpecialty = 2;
            specialty2.name = "Relaciones Domésticas";


            Lawyer lawyer1 = new Lawyer();
            lawyer1.profileImg = "../Content/img/profile/profile-2.jpg";
            lawyer1.firstName = "Hernan";
            lawyer1.lastName = "Escalada";
            lawyer1.specialty = specialty1;

            Lawyer lawyer2= new Lawyer();
            lawyer2.profileImg = "../Content/img/profile/profile-1.jpg";
            lawyer2.firstName = "Jose";
            lawyer2.lastName = "Miranda";
            lawyer2.specialty = specialty2;

            Lawyer lawyer3 = new Lawyer();
            lawyer3.profileImg = "../Content/img/profile/profile-4.jpg";
            lawyer3.firstName = "Marina";
            lawyer3.lastName = "López";
            lawyer3.specialty = specialty2;

            lawyers.Add(lawyer1);
            lawyers.Add(lawyer2);
            lawyers.Add(lawyer3);

            //MOCK EMPLEADOS

            List<Employee> employees = new List<Employee>();

            Employee employee1 = new Employee();
            employee1.profileImg = "../Content/img/profile/profile-6.jpg";
            employee1.firstName = "Martín";
            employee1.lastName = "Moralez";
            employee1.job = "Recepcionista";

            Employee employee2 = new Employee();
            employee2.profileImg = "../Content/img/profile/profile-5.jpg";
            employee2.firstName = "Ana";
            employee2.lastName = "Burdisso";
            employee2.job = "Investigadora Privada";

            Employee employee3 = new Employee();
            employee3.profileImg = "../Content/img/profile/profile-10.jpg";
            employee3.firstName = "Romina";
            employee3.lastName = "Perren";
            employee3.job = "Cosultora Financiera";

            employees.Add(employee1);
            employees.Add(employee2);
            employees.Add(employee3);

            NuestroStaffModel viewModel = new NuestroStaffModel();
            viewModel.lawyers = lawyers;
            viewModel.employees = employees;

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
            specialty.lawyerList = new List<Lawyer>();
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