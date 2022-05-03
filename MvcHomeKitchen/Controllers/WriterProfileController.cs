using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class WriterProfileController : Controller
    {
        Context c = new Context();
        // GET: WriterProfile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Profilem()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger2 = c.Writers.Where(x => x.WriterId == deger).ToList();
            return View(deger2);
        }
        public ActionResult MyRecipe()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger2 = c.Recipes.Where(x => x.WriterId == deger).ToList();
            return View(deger2);
        }
        public ActionResult MyBlog()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger2 = c.Blogs.Where(x => x.WriterId == deger).ToList();
            return View(deger2);
        }
        public ActionResult MyComment()
        {
            var email = User.Identity.Name;
            var deger = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger2 = c.RecipeComments.Where(x => x.WriterId == deger).ToList();
            return View(deger2);
        }
        public ActionResult DeleteComment(int id)
        {
            var comment = c.RecipeComments.Find(id);
            c.RecipeComments.Remove(comment);
            c.SaveChanges();
            return RedirectToAction("MyComment", "WriterProfile");
        }
        public ActionResult UpdateComment(int id)
        {
            var deger = c.RecipeComments.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateComment(RecipeComment p)
        {
            RecipeComment comment = c.RecipeComments.Where(x => x.RecipeCommentId == p.RecipeCommentId).SingleOrDefault();
            comment.Context = p.Context;
            c.SaveChanges();
            return RedirectToAction("MyComment", "WriterProfile");
        }
        public ActionResult Yazar()
        {
            var deger = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == deger).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v3 = userid;
            Class3 cs = new Class3();
            cs.Deger1 = c.Writers.ToList();
            cs.Deger2 = c.Follows.ToList();

            foreach (var x in cs.Deger1)
            {
                foreach (var y in cs.Deger2)
                {
                    if (y.TakipEden == userid && y.TakipEdilen == x.WriterId && y.IsTakip == true)
                    {
                        x.Follow = true;
                        break;
                    }
                    else
                    {
                        x.Follow = false;
                       
                    }

                }

            }

            return View(cs);
        }
        public ActionResult OlanBiten()
        {
            ArrayList follow = new ArrayList();
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            //var deger = c.Follows.Where(x => x.TakipEden == userid).Select(y=>y.TakipEdilen).FirstOrDefault();

            Class4 cs = new Class4();

            cs.Deger1 = c.Follows.Where(x=>x.TakipEden==userid).ToList();
            cs.Deger2 = c.Recipes.ToList();


            //foreach (var y in c.Follows.ToList())
            //{
            //    if(y.TakipEden==userid)
            //    {
            //        var deger2 = c.Recipes.Where(x=>x.WriterId==y.TakipEdilen).ToList();
            //        return View(deger2);
            //    } 

            //}

            return View(cs);
        }
        public ActionResult AddRecipe()
        {
            List<SelectListItem> category = (from x in c.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.CategoryId.ToString()
                                         }).ToList();
            ViewBag.d1 = category;
            return View();
        }
        [HttpPost]
        public ActionResult AddRecipe(Recipe p)
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId = userid;
            c.Recipes.Add(p);
            c.SaveChanges();
            return RedirectToAction("MyRecipe", "WriterProfile");
        }
        public ActionResult AddBlog()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddBlog(Blog p)
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId = userid;
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("MyBlog", "WriterProfile");
        }
        public ActionResult DeleteRecipe(int id)
        {
            var deger = c.Recipes.Find(id);
            c.Recipes.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("MyRecipe", "WriterProfile");
        }
        public ActionResult UpdateRecipe(int id)
        {
            List<SelectListItem> cate = (from x in c.Categories.ToList()

                                         select new SelectListItem
                                         {
                                             Text = x.Name,
                                             Value = x.CategoryId.ToString()
                                         }).ToList();

            ViewBag.d2 = cate;

            var deger = c.Recipes.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateRecipe(Recipe p)
        {
            Recipe recipe = c.Recipes.Where(x => x.RecipeId == p.RecipeId).SingleOrDefault();
            recipe.Url = p.Url;
            recipe.Title = p.Title;
            recipe.Context = p.Context;
            recipe.Person = p.Person;
            recipe.Preparation = p.Preparation;
            recipe.Cooking = p.Cooking;
            recipe.CategoryId = p.CategoryId;
            c.SaveChanges();
            return RedirectToAction("MyRecipe", "WriterProfile");
        }
        public ActionResult DeleteBlog(int id)
        {
            var deger = c.Blogs.Find(id);
            c.Blogs.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("MyBlog", "WriterProfile");
        }
        public ActionResult UpdateBlog(int id)
        {
            var deger = c.Blogs.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            Blog blog = c.Blogs.Where(x => x.BlogId == p.BlogId).SingleOrDefault();
            blog.Url = p.Url;
            blog.Title = p.Title;
            blog.Context = p.Context;
            c.SaveChanges();
            return RedirectToAction("MyBlog", "WriterProfile");
        }
        public ActionResult UpdateProfile(int id)
        {
            var deger = c.Writers.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateProfile(Writer p)
        {
            Writer w = c.Writers.Where(x => x.WriterId == p.WriterId).SingleOrDefault();
            w.Name = p.Name;
            w.Surname = p.Surname;
            w.Username = p.Username;
            w.Email = p.Email;
            w.Password = p.Password;
            w.PhotoUrl = p.PhotoUrl;
            c.SaveChanges();
            return RedirectToAction("Profilem", "WriterProfile");
        }
        public PartialViewResult Partial1()
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();

            ViewBag.d1 = userid;
            return PartialView();
        }
        public ActionResult RecipeBook()
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            Class5 cs = new Class5();
            cs.Deger2 = c.RecipeBooks.Where(x=>x.WriterId==userid).ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult RecipeBook(RecipeBook p)
        {
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            p.WriterId = userid;
            c.RecipeBooks.Add(p);
            c.SaveChanges();
            return RedirectToAction("RecipeBook", "WriterProfile");

        }
        public ActionResult UpdateRecipeBook(int id)
        {
            var deger = c.RecipeBooks.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult UpdateRecipeBook(RecipeBook p)
        {
            RecipeBook book = c.RecipeBooks.Where(x => x.RecipeBookId == p.RecipeBookId).SingleOrDefault();
            book.BookName = p.BookName;
            c.SaveChanges();
            return RedirectToAction("RecipeBook","WriterProfile");
        }
        public ActionResult DeleteRecipeBook(int id)
        {
            var deger = c.RecipeBooks.Find(id);
            c.RecipeBooks.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("RecipeBook", "WriterProfile");
        }

           
        }
    }
