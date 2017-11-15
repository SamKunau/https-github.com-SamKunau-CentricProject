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
    public class CoreValuesController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: CoreValues
        public ActionResult Index()
        {
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "fullName");
            return View(db.CoreValues.ToList());
           
        }

        // GET: CoreValues/Details/5
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

        // GET: CoreValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoreValues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,award,recognizer,recognized,recognizationDate")] CoreValue coreValue)
        {
            if (ModelState.IsValid)
            {
                
                db.CoreValues.Add(coreValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coreValue);
        }

        // GET: CoreValues/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValues = db.CoreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (coreValues.recognizer == memberID)
            {
                return View(coreValues);
            }
            else
            {
                return View("NotAuthenticated");
            }

        }
        // POST: CoreValues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,award,recognizer,recognized,recognizationDate")] CoreValue coreValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coreValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coreValue);
        }

        // GET: CoreValues/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CoreValue coreValues = db.CoreValues.Find(id);
            if (coreValues == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (coreValues.recognizer == memberID)
            {
                return View(coreValues);
            }
            else
            {
                return View("NotAuthenticated");
            }
        }

        // POST: CoreValues/Delete/5
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
