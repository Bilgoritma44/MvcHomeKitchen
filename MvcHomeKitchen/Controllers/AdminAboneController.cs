using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminAboneController : Controller
    {
        Context c = new Context();
        // GET: AdminAbone
        public ActionResult Index()
        {
            var deger = c.Newsletters.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Newsletter p)
        {
            c.Newsletters.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Newsletters.Find(id);
            c.Newsletters.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Newsletters.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Newsletter p)
        {
            Newsletter n = c.Newsletters.Where(x => x.NewsletterId == p.NewsletterId).SingleOrDefault();
            n.Email = p.Email;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}