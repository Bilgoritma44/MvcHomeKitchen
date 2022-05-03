using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminMessageController : Controller
    {
        Context c = new Context();
        // GET: AdminMessage
        public ActionResult Index()
        {
            var deger = c.Writers.ToList();
            return View(deger);
        }
        public ActionResult Gönder(int id)
        {
            var deger = c.Writers.Find(id);
            var deger2 = deger.Email;
            ViewBag.e = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult Gönder(Message p)
        {
            var email = User.Identity.Name;
            p.Sender = email;
            p.Tarih = DateTime.Now;
            c.Messages.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UserMessage()
        {
            var email = User.Identity.Name;
            var deger = c.Messages.Where(x => x.Receiver == email).ToList();
            return View(deger);
        }
        public ActionResult DeleteMesaj(int id)
        {
            var deger = c.Messages.Find(id);
            c.Messages.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("UserMessage");
        }
        public ActionResult DeleteMesaj2(int id)
        {
            var deger = c.Messages.Find(id);
            c.Messages.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cevapla(int id)
        {
            var deger = c.Messages.Find(id);
            var deger2 = deger.Sender;
            ViewBag.s = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult Cevapla(Message p)
        {
            var email = User.Identity.Name;
            p.Sender = email;
            p.Tarih = DateTime.Now;
            c.Messages.Add(p);
            c.SaveChanges();
            return RedirectToAction("UserMessage");
        }
        public ActionResult Cevapla2(int id)
        {
            var deger = c.Messages.Find(id);
            var deger2 = deger.Sender;
            ViewBag.s = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult Cevapla2(Message p)
        {
            var email = User.Identity.Name;
            p.Sender = email;
            p.Tarih = DateTime.Now;
            c.Messages.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PartialAdmin()
        {
            var email = User.Identity.Name;
            ViewBag.e = email;
            var deger = c.Messages.Where(x => x.Receiver == email).Count();
            ViewBag.s = deger;

            var deger2 = c.Messages.Where(x => x.Receiver == email).ToList();
            return PartialView(deger2);
        }
        public ActionResult AllMessage()
        {
            var email = User.Identity.Name;
            var deger2 = c.Messages.Where(x => x.Receiver == email).ToList();
            return View(deger2);
        }

       
    }
}