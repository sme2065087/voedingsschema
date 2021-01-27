using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using schema_app.Models;

namespace schema_app.Controllers
{
    public class GerechtenController : Controller
    {
        private GerechtDb db = new GerechtDb();

        // GET: Gerechten
        public ActionResult Index()
        {
            return View(db.Gerechten.ToList());
        }

        // GET: Gerechten/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerecht maaltijd = db.Gerechten.Find(id);
            if (maaltijd == null)
            {
                return HttpNotFound();
            }
            return View(maaltijd);
        }

        // GET: Gerechten/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerechten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam")] Gerecht maaltijd)
        {
            if (ModelState.IsValid)
            {
                db.Gerechten.Add(maaltijd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maaltijd);
        }

        // GET: Gerechten/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerecht maaltijd = db.Gerechten.Find(id);
            if (maaltijd == null)
            {
                return HttpNotFound();
            }
            return View(maaltijd);
        }

        // POST: Gerechten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam")] Gerecht maaltijd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maaltijd).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maaltijd);
        }

        // GET: Gerechten/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerecht maaltijd = db.Gerechten.Find(id);
            if (maaltijd == null)
            {
                return HttpNotFound();
            }
            return View(maaltijd);
        }

        // POST: Gerechten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gerecht maaltijd = db.Gerechten.Find(id);
            db.Gerechten.Remove(maaltijd);
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
