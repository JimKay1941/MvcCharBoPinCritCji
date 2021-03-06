﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcCharBoPinCritCji.Models;

namespace MvcCharBoPinCritCji.Controllers
{
    public class CharBopoPinCritsController : Controller
    {
        private ChineseStudyEntities db = new ChineseStudyEntities();

        //GET: CharBopoPinCrits/Onechar
        public ActionResult Onechar()
        {
            return View();
        }

        // POST: CharBopoPinCrits/Onechar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Onechar")]
        public ActionResult Subset([Bind(Include = "ID,Char,Bopo,Pin,Crit,Cji")] CharBopoPinCrit charBopoPinCrit)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Onechar");
            }

            return RedirectToAction("Subset", new { Char = charBopoPinCrit.Char});

            //return RedirectToAction("Subset", new RouteValueDictionary(
            //    new { controller = charBopoPinCrit, action = "Subset", Char = charBopoPinCrit.Char }));
        }

        // GET: CharBopoPinCrits/Subset/Char
        public ActionResult Subset(string Char)
        {
            if (Char == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model =
                (this.db.CharBopoPinCrits.Where(p => p.Char == Char)
                );
            return View(model);
        }

        // GET: CharBopoPinCrits
        public ActionResult Index()
        {
            return View(db.CharBopoPinCrits.ToList());
        }

        // GET: CharBopoPinCrits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharBopoPinCrit charBopoPinCrit = db.CharBopoPinCrits.Find(id);
            if (charBopoPinCrit == null)
            {
                return HttpNotFound();
            }
            return View(charBopoPinCrit);
        }

        // GET: CharBopoPinCrits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CharBopoPinCrits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Char,Bopo,Pin,Crit,Cji")] CharBopoPinCrit charBopoPinCrit)
        {
            if (ModelState.IsValid)
            {
                db.CharBopoPinCrits.Add(charBopoPinCrit);
                db.SaveChanges();
                return View(charBopoPinCrit);
            }

            return RedirectToAction("Subset", new { Char = charBopoPinCrit.Char });
        }

        // GET: CharBopoPinCrits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharBopoPinCrit charBopoPinCrit = db.CharBopoPinCrits.Find(id);
            if (charBopoPinCrit == null)
            {
                return HttpNotFound();
            }
            return View(charBopoPinCrit);
        }

        // POST: CharBopoPinCrits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Char,Bopo,Pin,Crit,Cji")] CharBopoPinCrit charBopoPinCrit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charBopoPinCrit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charBopoPinCrit);
        }

        // GET: CharBopoPinCrits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CharBopoPinCrit charBopoPinCrit = db.CharBopoPinCrits.Find(id);
            if (charBopoPinCrit == null)
            {
                return HttpNotFound();
            }
            return View(charBopoPinCrit);
        }

        // POST: CharBopoPinCrits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharBopoPinCrit charBopoPinCrit = db.CharBopoPinCrits.Find(id);
            db.CharBopoPinCrits.Remove(charBopoPinCrit);
            db.SaveChanges();

            return View(charBopoPinCrit);
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
