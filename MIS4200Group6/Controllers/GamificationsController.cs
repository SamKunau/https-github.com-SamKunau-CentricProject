using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MIS4200Group6.DAL;
using MIS4200Group6.Models;

namespace MIS4200Group6.Controllers
{
    public class GamificationsController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: Gamifications
        public ActionResult Index()
        {
            var gamification = db.Gamifications.Include(g => g.GiveRecogniton);
            return View(gamification.ToList());
           // return View(db.Gamifications.ToList());
        }

        // GET: Gamifications/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamification gamification = db.Gamifications.Find(id);
            if (gamification == null)
            {
                return HttpNotFound();
            }
            return View(gamification);
        }

        // GET: Gamifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gamifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,gamificationId")] Gamification gamification)
        {
            if (ModelState.IsValid)
            {
                gamification.ID = Guid.NewGuid();
                db.Gamifications.Add(gamification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gamification);
        }

        // GET: Gamifications/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamification gamification = db.Gamifications.Find(id);
            if (gamification == null)
            {
                return HttpNotFound();
            }
            return View(gamification);
        }

        // POST: Gamifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,gamificationId")] Gamification gamification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gamification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gamification);
        }

        // GET: Gamifications/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gamification gamification = db.Gamifications.Find(id);
            if (gamification == null)
            {
                return HttpNotFound();
            }
            return View(gamification);
        }

        // POST: Gamifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Gamification gamification = db.Gamifications.Find(id);
            db.Gamifications.Remove(gamification);
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
