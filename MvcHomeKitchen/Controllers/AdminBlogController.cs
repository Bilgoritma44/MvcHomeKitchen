using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminBlogController : Controller
    {
        Context c = new Context();
        // GET: AdminBlog
        public ActionResult Index()
        {
            var deger = c.Blogs.ToList();
            return View(deger);
        }
        public ActionResult Add()
        {
            List<SelectListItem> writer = (from x in c.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name+" "+x.Surname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.w = writer;

            return View();
        }
        [HttpPost]
        public ActionResult Add(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var deger = c.Blogs.Find(id);
            c.Blogs.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> writer = (from x in c.Writers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name+" "+x.Surname,
                                               Value = x.WriterId.ToString()
                                           }).ToList();
            ViewBag.w = writer;

            var deger = c.Blogs.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(Blog p)
        {
            Blog b = c.Blogs.Where(x => x.BlogId == p.BlogId).SingleOrDefault();
            b.Url = p.Url;
            b.Title = p.Title;
            b.Context = p.Title;
            b.WriterId = p.WriterId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            var deger2 = c.Blogs.Find(id);
            ViewBag.b = deger2.Title;

            var deger = c.BlogComments.Where(x => x.BlogId == id).ToList();
            return View(deger);
        }
    }
}