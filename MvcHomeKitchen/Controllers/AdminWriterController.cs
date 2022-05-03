using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminWriterController : Controller
    {
        Context c = new Context();
        // GET: AdminWriter
        public ActionResult Index()
        {
            var deger = c.Writers.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Writer p)
        {
            c.Writers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Writers.Find(id);
            c.Writers.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Writers.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Writer p)
        {
            Writer w = c.Writers.Where(x => x.WriterId == p.WriterId).SingleOrDefault();
            w.PhotoUrl = p.PhotoUrl;
            w.Name = p.Name;
            w.Surname = p.Surname;
            w.Username = p.Username;
            w.Email = p.Email;
            w.Password = p.Password;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            Class6 cs = new Class6();

            var deger = c.Writers.Find(id);
            ViewBag.b = deger.Name + " " + deger.Surname;

            cs.Deger1= c.Follows.Where(x => x.TakipEden == id).ToList();
            cs.Deger2 = c.Writers.ToList();
            return View(cs);
        }
    }
}