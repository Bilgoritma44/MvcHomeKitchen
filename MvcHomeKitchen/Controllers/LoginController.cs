using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcHomeKitchen.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Writer p)
        {
            c.Writers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Success", "Login");
        }
        public ActionResult Success()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(Writer p)
        {
            var bilgi = c.Writers.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if(bilgi!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Email, false);
                Session["Email"] = bilgi.Email.ToString();
                return RedirectToAction("Index", "Recipe");
            }
            return View();
        }
        public PartialViewResult IsLogin()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.Username).FirstOrDefault();
            ViewBag.v2 = deger;
            return PartialView();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Recipe");
        }
    }
}
