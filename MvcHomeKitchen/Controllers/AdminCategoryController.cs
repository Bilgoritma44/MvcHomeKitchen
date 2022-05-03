using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminCategoryController : Controller
    {
        Context c = new Context();
        // GET: AdminCategory
        public ActionResult Index()
        {
            var deger = c.Categories.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category p)
        {
            c.Categories.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Categories.Find(id);
            c.Categories.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var deger = c.Categories.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Category p)
        {
            Category cate = c.Categories.Where(x => x.CategoryId == p.CategoryId).SingleOrDefault();
            cate.PhotoUrl = p.PhotoUrl;
            cate.Name = p.Name;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger2 = c.Categories.Find(id);
            ViewBag.v1 = deger2.Name;

            var deger = c.Recipes.Where(x => x.CategoryId == id).ToList();
            return View(deger);
        }
    }
}