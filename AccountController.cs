using Asim.Identity;
using Asim.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Asim.Controllers
{
    public class AccountController : Controller
    {
      
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;


       


        public AccountController()
        { var userStore=
          new  UserStore<ApplicationUser> (new  odevContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore =
         new RoleStore<ApplicationRole>(new odevContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);

        }
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Account
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user  = new ApplicationUser();
                user.Ad = model.Ad;
                user.Soyad = model.Soyad;
                user.Email = model.Email;
                user.UserName = model.UserName;
               
         
                var result = UserManager.Create(user, model.Şifre);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError","Kullanıcı oluşturma hatası");
                }
                    
            }

            return View(model);
        }


       





        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        // GET: Account
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);
                    if(!String.IsNullOrEmpty(ReturnUrl))
                    {
                        Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulunamadı.");
                }
            }

            return View(model);
        }

        // GET: Account
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index","Home");
        }
       
      
    }

}