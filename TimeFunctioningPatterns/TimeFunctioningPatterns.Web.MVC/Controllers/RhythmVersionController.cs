﻿using System;
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
    public class RhythmVersionController : Controller
    {
        private TfplDbContext db = new TfplDbContext();

        // GET: RhythmVersion
        public ActionResult Index()
        {
            return View(db.RhythmVariants.ToList());
        }

        // GET: RhythmVersion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RhythmVersion rhythmVersion = db.RhythmVariants.Find(id);
            if (rhythmVersion == null)
            {
                return HttpNotFound();
            }
            return View(rhythmVersion);
        }

        // GET: RhythmVersion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RhythmVersion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] RhythmVersion rhythmVersion)
        {
            if (ModelState.IsValid)
            {
                db.RhythmVariants.Add(rhythmVersion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rhythmVersion);
        }

        // GET: RhythmVersion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RhythmVersion rhythmVersion = db.RhythmVariants.Find(id);
            if (rhythmVersion == null)
            {
                return HttpNotFound();
            }
            return View(rhythmVersion);
        }

        // POST: RhythmVersion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] RhythmVersion rhythmVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rhythmVersion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rhythmVersion);
        }

        // GET: RhythmVersion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RhythmVersion rhythmVersion = db.RhythmVariants.Find(id);
            if (rhythmVersion == null)
            {
                return HttpNotFound();
            }
            return View(rhythmVersion);
        }

        // POST: RhythmVersion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RhythmVersion rhythmVersion = db.RhythmVariants.Find(id);
            db.RhythmVariants.Remove(rhythmVersion);
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
