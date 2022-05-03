using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class PartialController : Controller
    {
        Context c = new Context();
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Photo()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger2 = c.Writers.Find(deger);
            ViewBag.p = deger2.PhotoUrl;
            ViewBag.a = deger2.Name + " " + deger2.Surname;
            ViewBag.b = deger2.Email;
            return PartialView();
        }
        public PartialViewResult Mesaj()
        {
            var email = User.Identity.Name;
            var deger = c.Messages.Where(x => x.Receiver == email).Count();
            ViewBag.d = deger;
            return PartialView();
        }
        public PartialViewResult Navbar()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger2 = c.Writers.Find(deger);
            ViewBag.f = deger2.PhotoUrl;
            ViewBag.r = deger2.Name + " " + deger2.Surname;

            var deger3 = c.Messages.Where(x => x.Receiver == email).ToList();
            var deger4 = c.Messages.Where(x => x.Receiver == email).Count();
            ViewBag.k = deger4;
            return PartialView(deger3);
        }
    }
}