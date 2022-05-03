using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class FollowController : Controller
    {
        Context c = new Context();
        // GET: Follow
        public ActionResult Add(int id)
        {
           
            var deger = c.Writers.Where(x => x.WriterId == id).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.v1 = deger;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Follow p)
        {
            var user = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == user).Select(y => y.WriterId).FirstOrDefault();
            p.TakipEden = userid;
            p.IsTakip = true;
            c.Follows.Add(p);
            c.SaveChanges();
            return RedirectToAction("Yazar", "WriterProfile");

        }
        public ActionResult Delete(int id)
        {
            var takip = c.Writers.Find(id);
            var email = User.Identity.Name;
            var userid = c.Writers.Where(x => x.Email == email).Select(y => y.WriterId).FirstOrDefault();
            var deger = c.Follows.Where(x => x.TakipEden == userid && x.TakipEdilen == takip.WriterId && x.IsTakip == true).Select(y => y.FollowId).SingleOrDefault();
            var d2=c.Follows.Find(deger);
            c.Follows.Remove(d2);
            c.SaveChanges();
            return RedirectToAction("Yazar", "WriterProfile");
        }
    }
}