using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeFunctioningPatterns.Web.MVC.Models;

namespace TimeFunctioningPatterns.Web.MVC.Controllers
{
    public class RhythmVersionControllerV1Nemjo : Controller
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

        public ActionResult GetMemos(int? id, string memoType)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            var ver = GetRhythmVersion(id.Value);
            IEnumerable<Memo> memos = null;

            switch (memoType)
            {
                case "fatback":
                    memos = ver?.GetFatbackMemos();
                    ViewBag.Title = "FatbackMemos";
                    break;
                case "snare":
                    memos = ver?.GetSnareAndBassMemos();
                    ViewBag.Title = "SnareAndBassMemos";
                    break;
                case "hihat":
                    memos = ver?.GetHiHatMemos();
                    ViewBag.Title = "HiHatMemos";
                    break;
                default:
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.RhythmVersion =
                ver?.Description ?? "Could not find requested rhythm version.";

            return View(memos);
        }

        //public ActionResult FatbackMemos(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var ver = GetRhythmVersion(id.Value);
        //    var memos = ver?.GetFatbackMemos();
        //    ViewBag.RhythmVersion = 
        //        ver?.Description ?? "Could not find requested rhythm version.";

        //    return View(memos);
        //}

        //public ActionResult SnareAndBassMemos(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var ver = GetRhythmVersion(id.Value);
        //    var memos = ver?.GetSnareAndBassMemos();
        //    ViewBag.RhythmVersion =
        //        ver?.Description ?? "Could not find requested rhythm version.";

        //    return View(memos);
        //}

        //public ActionResult HiHatMemos(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }

        //    var ver = GetRhythmVersion(id.Value);
        //    var memos = ver?.GetHiHatMemos();
        //    ViewBag.RhythmVersion =
        //        ver?.Description ?? "Could not find requested rhythm version.";

        //    return View(memos);
        //}

        public ActionResult AddMemo()
        {
            throw new NotImplementedException();

            return View();
        }

        private RhythmVersion GetRhythmVersion(int id)
        {
            using (var db = new TfplDbContext())
            {
                var ver = db.RhythmVariants.FirstOrDefault(v => v.Id == id);
                ver.Memos = db.Memos.AsEnumerable().Where(m => m.RhythmVersion == ver).ToList();

                return ver;
            }
        }
    }
}