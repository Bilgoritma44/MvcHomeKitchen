using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class WriterController : Controller
    {
        Context c = new Context();
        // GET: Writer
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult LastWriter()
        {
            var deger = c.Writers.OrderByDescending(x => x.WriterId).Take(2).ToList();
            return PartialView(deger);
        }
    }
}