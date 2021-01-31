using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using schema_app.Models;
using Microsoft.AspNet.Identity;

namespace schema_app.Controllers
{
    [Authorize]
    public class MaaltijdUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private string userId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        

        // GET: MaaltijdUsers
        [Authorize]
        public ActionResult Index()
        {
            var maaltijdUsers = db.MaaltijdUsers.Where(u => u.ClientId == userId).Include(m => m.Client).Include(m => m.Gerecht);
            return View(maaltijdUsers.ToList());
        }

        // GET: MaaltijdUsers/Details/5
        [Authorize]
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
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Users, "Id", "Email");
            ViewBag.GerechtRefId = new SelectList(db.Gerechten, "Id", "Naam");
            return View();
        }

        // POST: MaaltijdUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClientId,Eetmoment,GerechtRefId,voldaan")] MaaltijdUser maaltijdUser)
        {

            maaltijdUser.ClientId = userId;

            if (ModelState.IsValid)
            {
                db.MaaltijdUsers.Add(maaltijdUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Users, "Id", "Email", maaltijdUser.ClientId);
            ViewBag.GerechtRefId = new SelectList(db.Gerechten, "Id", "Naam", maaltijdUser.GerechtRefId);
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
            ViewBag.ClientId = new SelectList(db.Users, "Id", "Email", maaltijdUser.ClientId);
            ViewBag.GerechtRefId = new SelectList(db.Gerechten, "Id", "Naam", maaltijdUser.GerechtRefId);
            return View(maaltijdUser);
        }

        // POST: MaaltijdUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClientId,Eetmoment,GerechtRefId,voldaan")] MaaltijdUser maaltijdUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maaltijdUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Users, "Id", "Email", maaltijdUser.ClientId);
            ViewBag.GerechtRefId = new SelectList(db.Gerechten, "Id", "Naam", maaltijdUser.GerechtRefId);
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

        [HttpPost]
        public ActionResult CheckBoxUpdate(string ID, string Checked)
        {

            var dbCommand = "UPDATE MaaltijdUsers SET voldaan='True' WHERE Id='" + ID + "'";
            System.Diagnostics.Debug.WriteLine("My debug string here");
            if (Checked == "false" || Checked == "False")
            {
                dbCommand = "UPDATE MaaltijdUsers SET voldaan='False' WHERE Id='" + ID + "'";
            }

            db.Database.ExecuteSqlCommand(dbCommand);

            return Redirect("/MaaltijdUsers");
        }
    }
}
