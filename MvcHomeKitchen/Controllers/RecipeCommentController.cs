using MvcHomeKitchen.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcHomeKitchen.Controllers
{
    public class RecipeCommentController : Controller
    {
        Context c = new Context();
        // GET: RecipeComment
        public ActionResult Index()
        {
            return View();
        }
    }
}