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
    public class RhythmController : Controller
    {
        private TfplDbContext db = new TfplDbContext();

        // GET: Rhythm
        public ActionResult Index()
        {
            return View(db.Rhythms.ToList());
        }

        // GET: Rhythm/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rhythm rhythm = db.Rhythms.Find(id);
            if (rhythm == null)
            {
                return HttpNotFound();
            }
            return View(rhythm);
        }

        // GET: Rhythm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rhythm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] Rhythm rhythm)
        {
            if (ModelState.IsValid)
            {
                db.Rhythms.Add(rhythm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rhythm);
        }

        // GET: Rhythm/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rhythm rhythm = db.Rhythms.Find(id);
            if (rhythm == null)
            {
                return HttpNotFound();
            }
            return View(rhythm);
        }

        // POST: Rhythm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] Rhythm rhythm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rhythm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rhythm);
        }

        // GET: Rhythm/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rhythm rhythm = db.Rhythms.Find(id);
            if (rhythm == null)
            {
                return HttpNotFound();
            }
            return View(rhythm);
        }

        // POST: Rhythm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rhythm rhythm = db.Rhythms.Find(id);
            db.Rhythms.Remove(rhythm);
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
    }
}
