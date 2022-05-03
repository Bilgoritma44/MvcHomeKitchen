using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminRecipeCommentController : Controller
    {
        Context c = new Context();
        // GET: AdminRecipeComment
        public ActionResult Index()
        {
            var deger = c.RecipeComments.ToList();
            return View(deger);
        }
        public ActionResult Delete(int id)
        {
            var deger = c.RecipeComments.Find(id);
            c.RecipeComments.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> writer = (from x in c.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.Name+" "+x.Surname,
                                               Value=x.WriterId.ToString()

                                           }).ToList();
            ViewBag.w = writer; 
            List<SelectListItem> recipe = (from x in c.Recipes.ToList()
                                           select new SelectListItem
                                           {
                                               Text=x.Title,
                                               Value=x.RecipeId.ToString()

                                           }).ToList();
            ViewBag.r= recipe;

            var deger = c.RecipeComments.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(RecipeComment p)
        {
            RecipeComment rc = c.RecipeComments.Where(x => x.RecipeCommentId == p.RecipeCommentId).SingleOrDefault();
            rc.WriterId = p.WriterId;
            rc.RecipeId = p.RecipeId;
            rc.Context = p.Context;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}