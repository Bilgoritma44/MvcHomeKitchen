using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminRecipeController : Controller
    {
        Context c = new Context();
        // GET: AdminRecipe
        public ActionResult Index()
        {
            var deger = c.Recipes.ToList();
            return View(deger);
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Recipes.Find(id);
            c.Recipes.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Name,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();

            ViewBag.cs = category;

            var deger = c.Recipes.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Recipe p)
        {
            Recipe r = c.Recipes.Where(x => x.RecipeId == p.RecipeId).SingleOrDefault();
            r.Url = p.Url;
            r.Title = p.Title;
            r.Context = p.Context;
            r.Person = p.Person;
            r.Preparation = p.Preparation;
            r.Cooking = p.Cooking;
            r.CategoryId = p.CategoryId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger2 = c.Recipes.Find(id);
            ViewBag.b = deger2.Title;

            var deger = c.RecipeComments.Where(x => x.RecipeId == id).ToList();
            return View(deger);
        }
    }
}