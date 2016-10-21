using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using kuasociados.Contract;
using kuasociados.Contract.Models;
using WebMatrix.Data;
using WebMatrix.WebData;


namespace kuasociados.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        public IUserService userservice { get; set; }
        public IClientService clientservice { get; set; }

        public AccountController(IUserService _userservice,
                                 IClientService _clientservice)
        {
            this.userservice = _userservice;
            this.clientservice = _clientservice;
        }


        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToAction("Index", "Home");
                
            }      
            return View(model);
        }


        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            var roles = (SimpleRoleProvider)System.Web.Security.Roles.Provider;
            var membership = (SimpleMembershipProvider)System.Web.Security.Membership.Provider;

            if (ModelState.IsValid)
            { 
                this.clientservice.saveClient(model);
                int newid = this.userservice.getLastestPersonId();
                WebSecurity.CreateUserAndAccount(model.UserName, model.Password,
                                                 propertyValues: new { IdPerson = newid, });


                roles.AddUsersToRoles(new string[] { model.UserName }, new string[] { "Client" });
                return RedirectToAction("Index", "Home");
                
            }

  
            return View(model);
        }

        
        
        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

         
    }
}