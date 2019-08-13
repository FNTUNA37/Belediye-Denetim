using NHibernate.Linq;
using StajProjesi.Models;
using StajProjesi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StajProjesi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.User.Identity.Name))
            {
                return Redirect("/home");
            }
                return View();
           
            
        }
        [HttpPost]
        public ActionResult Login(Login formData, string returnUrl)
        {
            User user = Database.Session.Query<User>().SingleOrDefault(x => x.KullanıcıAdı.Equals(formData.KullanıcıAdı));
            if (formData.Sifre == null)
            {
                return View();
            }
            if (user == null || !user.CheckPassword(formData.Sifre))
            {
                ModelState.AddModelError("KullanıcıAdı", "Kullanıcı Adı veya Şifre Yanlış");
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            FormsAuthentication.SetAuthCookie(formData.KullanıcıAdı, true);


            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return Redirect("/home");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}