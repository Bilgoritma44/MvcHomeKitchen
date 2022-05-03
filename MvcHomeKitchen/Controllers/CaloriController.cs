using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class CaloriController : Controller
    {
        Context c = new Context();
        // GET: Calori
        public ActionResult Index()
        {
            var deger = c.Caloris.ToList();
            return View(deger);
        }
        public ActionResult Detail(int id)
        {
            var deger = c.Caloris.Where(x=>x.CaloriId==id).ToList();
            return View(deger);
        }
    }
}