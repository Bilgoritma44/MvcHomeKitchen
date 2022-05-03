using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcHomeKitchen.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin
        public ActionResult Index()
        {
            var deger = c.Admins.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Admin p)
        {
            c.Admins.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Admins.Find(id);
            c.Admins.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Admins.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Admin p)
        {
            Admin a = c.Admins.Where(x => x.AdminId == p.AdminId).SingleOrDefault();
            a.Email = p.Email;
            a.Password = p.Password;
            a.Role = p.Role;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.Email == p.Email && x.Password == p.Password);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.Email, false);
                Session["Email"] = bilgi.Email.ToString();
                return RedirectToAction("Index","AdminCategory");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Recipe");
        }
    }
}