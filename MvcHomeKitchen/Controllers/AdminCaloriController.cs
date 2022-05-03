using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminCaloriController : Controller
    {
        Context c = new Context();
        // GET: AdminCalori
        public ActionResult Index()
        {
            var deger = c.Caloris.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Calori p)
        {
            c.Caloris.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Caloris.Find(id);
            c.Caloris.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Caloris.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Calori p)
        {
            Calori cr = c.Caloris.Where(x => x.CaloriId == p.CaloriId).SingleOrDefault();
            cr.PhotoUrl = p.PhotoUrl;
            cr.Title = p.Title;
            cr.Description = p.Description;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}