using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminRecipeBookController : Controller
    {
        Context c = new Context();
        // GET: AdminRecipeBook
        public ActionResult Index()
        {
            var deger = c.RecipeBooks.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            List<SelectListItem> writer = (from x in c.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name + " " + x.Surname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.w = writer;
            return View();
        }
        [HttpPost]
        public ActionResult Add(RecipeBook p)
        {
            c.RecipeBooks.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.RecipeBooks.Find(id);
            c.RecipeBooks.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> writer = (from x in c.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name + " " + x.Surname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.w = writer;

            var deger = c.RecipeBooks.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(RecipeBook p)
        {
            RecipeBook rp = c.RecipeBooks.Where(x => x.RecipeBookId == p.RecipeBookId).SingleOrDefault();
            rp.BookName = p.BookName;
            rp.WriterId = p.WriterId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            Class7 cs = new Class7();

            cs.Deger1 = c.AddBooks.Where(x => x.RecipeBookId == id).ToList();
            cs.Deger2 = c.Recipes.ToList();

            return View(cs);
        }
    }
}