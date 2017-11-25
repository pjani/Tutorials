using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeFunctioningPatterns.Web.MVC.Models;

namespace TimeFunctioningPatterns.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var db = new TfplDbContext())
            {
                List<Rhythm> rhythms = db.Rhythms.ToList();

                return View(rhythms);
            }
        }

        [OutputCache(Duration = 10)]
        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}