using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeFunctioningPatterns.Web.MVC.Models;

namespace TimeFunctioningPatterns.Web.MVC.Controllers
{
    public class MemoController : Controller
    {
        private TfplDbContext db = new TfplDbContext();

        // GET: Memo
        public ActionResult Index(int? id, string memoType)
        {
            //System.Diagnostics.Debugger.Launch();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            IEnumerable<Memo> memos;

            var ver = GetRhythmVersion(id.Value);

            switch (memoType)
            {
                case "fatback":
                    memos = ver?.GetFatbackMemos();
                    ViewBag.Title = "Fatback memos";
                    break;
                case "snare":
                    memos = ver?.GetSnareAndBassMemos();
                    ViewBag.Title = "Snare and bass memos";
                    break;
                case "hihat":
                    memos = ver?.GetHiHatMemos();
                    ViewBag.Title = "Hi-hat memos";
                    break;
                default:
                    memos = ver.Memos.ToList();
                    break;
            }

            ViewBag.RhythmVersion =
                ver?.Description ?? "Could not find requested rhythm version.";
            ViewBag.MemoType = memoType;

            return View(memos);
        }

        // GET: Memo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.Memos.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // GET: Memo/Create
        public ActionResult Create(int? versionId, string memoType)
        {
            Memo memo = null;
            switch (memoType)
            {
                case "fatback":
                    memo = new FatBackMemo();
                    break;
                case "snare":
                    memo = new SnareAndBassMemo();
                    break;
                case "hihat":
                    memo = new HiHatMemo();
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            memo.RhythmVersionId = versionId ?? 0;
            return View(memo);
        }

        // POST: Memo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Created,Tempo,OverallRating")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Memos.Add(memo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memo);
        }

        // GET: Memo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.Memos.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // POST: Memo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Created,Tempo,OverallRating")] Memo memo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memo);
        }

        // GET: Memo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Memo memo = db.Memos.Find(id);
            if (memo == null)
            {
                return HttpNotFound();
            }
            return View(memo);
        }

        // POST: Memo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Memo memo = db.Memos.Find(id);
            db.Memos.Remove(memo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private RhythmVersion GetRhythmVersion(int id)
        {
            var ver = db.RhythmVariants.Find(id);
            if (ver == null)
                return null;

            ver.Memos = db.Memos
                .AsEnumerable()
                .Where(m => m.RhythmVersion == ver)
                .ToList();

            return ver;
        }

        //private Memo CreateMemoByType(string memoType)
        //{

        //}
    }
}
