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
    public class ContactoController : Controller
    {
        public IUserService userservice { get; set; }
        public IInstitutionService institutionservice { get; set; }


        public ContactoController(IUserService _userservice,
                                 IInstitutionService _institutionservice)
        {
            this.userservice = _userservice;
            this.institutionservice = _institutionservice;
        }

        // GET: Contacto
        public ActionResult Index()
        {
            var institution = this.institutionservice.getInstitutionInfo();
            return View(institution);
        }

        [Authorize(Roles = "Secretary")]
        public ActionResult EditInstitution()
        {
            var institution = this.institutionservice.getInstitutionInfo();
            if (institution == null)
            {
                return HttpNotFound();
            }
            return View(institution);
        }

        [Authorize(Roles = "Secretary")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditInstitution(Institution institution)
        {
            if (ModelState.IsValid)
            {
                this.institutionservice.editInstitutionInfo(institution);
                return RedirectToAction("Index");
            }
            return View(institution);
        }

    }
}