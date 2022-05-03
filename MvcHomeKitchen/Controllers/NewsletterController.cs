using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class NewsletterController : Controller
    {
        Context c = new Context();
        // GET: Newsletter
        public PartialViewResult AboneOl()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult AboneOl(Newsletter p)
        {
            c.Newsletters.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Recipe");
        }
    }
}