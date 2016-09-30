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
            return View();
        }
        public ActionResult CreateLawyer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLawyer(Lawyer lawyer)
        {

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

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }
    }
}