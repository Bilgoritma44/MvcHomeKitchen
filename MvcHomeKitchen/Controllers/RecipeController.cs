using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        Context c = new Context();
        // GET: Recipe
        public ActionResult Index()
        {
            var deger = c.Recipes.ToList();
            return View(deger);
        }
        public ActionResult Detail(int id)
        {
            Class1 cs = new Class1(); 
            
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();

            ViewBag.u = userid;

            var deger = c.Recipes.Where(x => x.RecipeId == id).Select(y => y.RecipeId).FirstOrDefault();
            ViewBag.v2 = deger;

            var d1 = c.RecipeComments.Where(x => x.RecipeId == id).Count();
            ViewBag.v1 = d1;

            List<SelectListItem> book = (from x in c.RecipeBooks.Where(x => x.WriterId == userid).ToList()

                                         select new SelectListItem
                                         {
                                             Text = x.BookName,
                                             Value = x.RecipeBookId.ToString()
                                         }).ToList();

            ViewBag.b = book;


            cs.Deger1 = c.Recipes.Where(x => x.RecipeId == id).ToList();
            cs.Deger2 = c.RecipeComments.Where(x => x.RecipeId == id).ToList();
            cs.Deger3 = c.RecipeBooks.ToList();
            cs.Deger4 = c.AddBooks.ToList();

            foreach (var x in cs.Deger1)
            {
                foreach (var y in cs.Deger4)
                {
                    if (y.WriterId == userid && y.RecipeId == x.RecipeId)
                    {
                        x.Status = true;
                        break;
                    }
                    else
                    {
                        x.Status = false;

                    }
                }

            }

            var sayi = c.AddBooks.Where(x => x.RecipeId == id).Count();
            ViewBag.sayi = sayi;

            return View(cs);
            

        }
        [HttpPost]
        public ActionResult Detail(AddBook p)
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();

            p.WriterId = userid;
            c.AddBooks.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Recipe");
        }
        public PartialViewResult AddComment(int id)
        {
            var deger = c.Recipes.Where(x => x.RecipeId == id).Select(y => y.RecipeId).FirstOrDefault();
            ViewBag.v1 = deger;
            var email = User.Identity.Name;
            var deger2 = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v2 = deger2;
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddComment(RecipeComment p)
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId = deger;
            c.RecipeComments.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Recipe");
        }
        
        public PartialViewResult Partial1()
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();

            List<SelectListItem> book = (from x in c.RecipeBooks.Where(x => x.WriterId == userid).ToList()

                                         select new SelectListItem
                                         {
                                             Text = x.BookName,
                                             Value = x.RecipeBookId.ToString()
                                         }).ToList();

            ViewBag.b = book;
            return PartialView();
        }
        public ActionResult DeleteBook(int id)
        {
            var deger = c.AddBooks.Find(id);
            c.AddBooks.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index", "Recipe");
        }
        public PartialViewResult LastRecipe()
        {
            var deger = c.Recipes.OrderByDescending(x=>x.RecipeId).Take(2).ToList();
            return PartialView(deger);
        }
        public ActionResult TrendRecipe()
        {
            var deger = c.Recipes.OrderByDescending(x => x.Sayi).ToList();
            return View(deger);
        }
    }
}