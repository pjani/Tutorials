using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeFunctioningPatterns.Web.MVC.Models;

namespace TimeFunctioningPatterns.Web.MVC.Controllers
{
    public class RhythmController : Controller
    {
        // GET: Rhythm
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            using (var db = new TfplDbContext())
            {
                var versions =
                    (from v in db.RhythmVariants
                    group v by v.Rhythm into g
                    select new { RhythmDesc = g.Key.Description, Versions = g.ToList() }).First();

                ViewBag.RhythmDescription = versions.RhythmDesc;
                return View(versions.Versions);
            }
        }

        public ActionResult FatbackMemos(int id)
        {
            // get Fatback memos of rhythm version

            return View();
        }

        public ActionResult SnareAndBassMemos(int id)
        {
            // get SnareAndBass memos of rhythm version

            return View();
        }

        public ActionResult HiHatMemos(int id)
        {
            // get HiHat memos of rhythm version

            return View();
        }
    }
}