using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminStatisticController : Controller
    {
        Context c = new Context();
        // GET: AdminStatistic
        public ActionResult Index()
        {
            var d1 = c.Writers.Count();
            ViewBag.a1 = d1;
            var d2 = c.Categories.Count();
            ViewBag.a2 = d2;
            var d3 = c.Recipes.Count();
            ViewBag.a3 = d3;
            var d4 = c.Newsletters.Count();
            ViewBag.a4 = d4;
            var d5 = c.RecipeComments.Count();
            ViewBag.a5 = d5;
            var d6 = c.RecipeBooks.Count();
            ViewBag.a6 = d6;
            var d7 = c.Recipes.OrderByDescending(x => x.YorumSayi).Take(1).Select(y => y.Title).FirstOrDefault();
            ViewBag.a7 = d7;
            var d8 = c.Recipes.OrderByDescending(x => x.Sayi).Take(1).Select(y => y.Title).FirstOrDefault();
            ViewBag.a8 = d8;
            var d9 = c.Admins.Count();
            ViewBag.a9 = d9;
            var d10 = c.Follows.GroupBy(s => s.TakipEdilen).FirstOrDefault();
            var deger = c.Writers.Where(x => x.WriterId == d10.Key).Select(y=>y.Name).FirstOrDefault();
            var deger2 = c.Writers.Where(x => x.WriterId == d10.Key).Select(y=>y.Surname).FirstOrDefault();
            ViewBag.a10 = deger + " " + deger2;
            var d11 = c.Blogs.Count();
            ViewBag.a11 = d11;
            var d12 = c.Caloris.Count();
            ViewBag.a12 = d12;


            return View();
        }
    }
}