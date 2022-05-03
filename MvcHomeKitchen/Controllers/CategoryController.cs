using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class CategoryController : Controller
    {
        Context c = new Context();
        // GET: Category
        public ActionResult Index()
        {
            var deger = c.Categories.ToList();
            return View(deger);
        }
        public ActionResult Detail(int id)
        {
            var deger = c.Recipes.Where(x => x.CategoryId == id).ToList();
            return View(deger);
        }
        public PartialViewResult LastCategory()
        {
            var deger2 = c.Recipes.Where(x=>x.CategoryId==1).Count();
            ViewBag.d2 = deger2;

            var deger = c.Categories.Take(3).ToList();
            return PartialView(deger);
        }
    }
}