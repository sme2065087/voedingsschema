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
    public class MaaltijdUsersController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: MaaltijdUsers
        public ActionResult Index()
        {
            var maaltijdUsers = db.MaaltijdUsers.Include(m => m.AspNetUser).Include(m => m.Gerecht);
            return View(maaltijdUsers.ToList());
        }

        // GET: MaaltijdUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaaltijdUser maaltijdUser = db.MaaltijdUsers.Find(id);
            if (maaltijdUser == null)
            {
                return HttpNotFound();
            }
            return View(maaltijdUser);
        }

        // GET: MaaltijdUsers/Create
        public ActionResult Create()
        {
            ViewBag.AspNetUserRefId = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.GerechtRefId = new SelectList(db.Gerechts, "Id", "Naam");
            return View();
        }

        // POST: MaaltijdUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AspNetUserRefId,Eetmoment,GerechtRefId,voldaan")] MaaltijdUser maaltijdUser)
        {
            if (ModelState.IsValid)
            {
                db.MaaltijdUsers.Add(maaltijdUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AspNetUserRefId = new SelectList(db.AspNetUsers, "Id", "Email", maaltijdUser.AspNetUserRefId);
            ViewBag.GerechtRefId = new SelectList(db.Gerechts, "Id", "Naam", maaltijdUser.GerechtRefId);
            return View(maaltijdUser);
        }

        // GET: MaaltijdUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaaltijdUser maaltijdUser = db.MaaltijdUsers.Find(id);
            if (maaltijdUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.AspNetUserRefId = new SelectList(db.AspNetUsers, "Id", "Email", maaltijdUser.AspNetUserRefId);
            ViewBag.GerechtRefId = new SelectList(db.Gerechts, "Id", "Naam", maaltijdUser.GerechtRefId);
            return View(maaltijdUser);
        }

        // POST: MaaltijdUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AspNetUserRefId,Eetmoment,GerechtRefId,voldaan")] MaaltijdUser maaltijdUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maaltijdUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AspNetUserRefId = new SelectList(db.AspNetUsers, "Id", "Email", maaltijdUser.AspNetUserRefId);
            ViewBag.GerechtRefId = new SelectList(db.Gerechts, "Id", "Naam", maaltijdUser.GerechtRefId);
            return View(maaltijdUser);
        }

        // GET: MaaltijdUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaaltijdUser maaltijdUser = db.MaaltijdUsers.Find(id);
            if (maaltijdUser == null)
            {
                return HttpNotFound();
            }
            return View(maaltijdUser);
        }

        // POST: MaaltijdUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaaltijdUser maaltijdUser = db.MaaltijdUsers.Find(id);
            db.MaaltijdUsers.Remove(maaltijdUser);
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
