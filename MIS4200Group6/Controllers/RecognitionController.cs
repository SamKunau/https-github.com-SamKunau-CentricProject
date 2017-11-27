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
using Microsoft.AspNet.Identity;

namespace MIS4200Group6.Controllers
{
    public class RecognitionController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: Recognition
        public ActionResult Index()
        {
            Guid userID;
            Guid.TryParse(User.Identity.GetUserId(), out userID);

            var myAwards = db.CoreValues.Where(U => U.recognized == userID).OrderByDescending(U => U.recognizationDate);
            return View(myAwards.ToList());
        }

        // GET: Recognition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValue = db.CoreValues.Find(id);
            if (coreValue == null)
            {
                return HttpNotFound();
            }
            return View(coreValue);
        }

        // GET: Recognition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recognition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,award,recognizer,recognized,recognizationDate,description")] CoreValue coreValue)
        {
            if (ModelState.IsValid)
            {
                db.CoreValues.Add(coreValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coreValue);
        }

        // GET: Recognition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValue = db.CoreValues.Find(id);
            if (coreValue == null)
            {
                return HttpNotFound();
            }
            return View(coreValue);
        }

        // POST: Recognition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,award,recognizer,recognized,recognizationDate,description")] CoreValue coreValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coreValue);
        }

        // GET: Recognition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValue = db.CoreValues.Find(id);
            if (coreValue == null)
            {
                return HttpNotFound();
            }
            return View(coreValue);
        }

        // POST: Recognition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CoreValue coreValue = db.CoreValues.Find(id);
            db.CoreValues.Remove(coreValue);
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
