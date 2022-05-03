using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class AdminBlogCommentController : Controller
    {
        Context c = new Context();
        // GET: AdminBlogComment
        public ActionResult Index()
        {
            var deger = c.BlogComments.ToList();
            return View(deger);
        }
        public ActionResult Delete(int id)
        {
            var deger = c.BlogComments.Find(id);
            c.BlogComments.Remove(deger);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Update(int id)
        {
            List<SelectListItem> blog = (from x in c.Blogs.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Title,
                                             Value = x.BlogId.ToString()
                                         }).ToList();
            ViewBag.b = blog; 
            
            List<SelectListItem> writer = (from x in c.Writers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.Name+" "+x.Surname,
                                             Value = x.WriterId.ToString()
                                         }).ToList();
            ViewBag.w = writer;


            var deger = c.BlogComments.Find(id);
            return View(deger);
        }
        [HttpPost]
        public ActionResult Update(BlogComment p)
        {
            BlogComment bc = c.BlogComments.Where(x => x.BlogCommentId == p.BlogCommentId).SingleOrDefault();
            bc.Context = p.Context;
            bc.WriterId = p.WriterId;
            bc.BlogId = p.BlogId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}