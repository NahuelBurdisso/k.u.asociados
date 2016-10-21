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
    public class MyCasesController : Controller
    {
        public IUserService userservice;
        public IClientService clientservice;
        public ILawyerService lawyerservice;

        public MyCasesController(IUserService _userservice,
                                 IClientService _clientservice,
                                 ILawyerService _lawyerservice) {
            this.userservice = _userservice;
            this.clientservice = _clientservice;
            this.lawyerservice = _lawyerservice;
        }

        // GET: MyCases
        [Authorize(Roles = "Client")]
        public ActionResult ClientCases()
        {
            var userid = WebSecurity.CurrentUserId;
            var client = this.userservice.getClientbyUserId(userid);
            return View(client);
        }

        public ActionResult LawyerCases()
        {
            return View();
        }

        // GET: MyCases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyCases/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyCases/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyCases/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyCases/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyCases/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
