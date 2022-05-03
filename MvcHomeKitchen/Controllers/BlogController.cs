using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        // GET: Blog
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        public ActionResult Detail(int id)
        {
            var deger = c.BlogComments.Where(x => x.BlogId == id).Count();
            ViewBag.v1 = deger;
            Class2 cs = new Class2();
            cs.Deger1 = c.Blogs.Where(x=>x.BlogId==id).ToList();
            cs.Deger2 = c.BlogComments.Where(x=>x.BlogId==id).ToList();
            return View(cs);
        }
        public PartialViewResult AddComment(int id)
        {
            var deger = c.Blogs.Where(x => x.BlogId == id).Select(y => y.BlogId).FirstOrDefault();
            ViewBag.v1 = deger;
            return PartialView();
        }
        [HttpPost]
        public ActionResult AddComment(BlogComment p)
        {
            p.WriterId = 3;
            c.BlogComments.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Blog");
        }
        public PartialViewResult LastBlog()
        {
            var deger = c.Blogs.OrderByDescending(x => x.BlogId).Take(1).ToList();
            return PartialView(deger);
        }
    }
}