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
    public class Recog2Controller : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: Recog2
        public ActionResult Index()
        {
            var recog2 = db.Recog2.Include(r => r.Giver).Include(r => r.UserDetails);
            return View(recog2.ToList());
        }

        // GET: Recog2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recog2 recog2 = db.Recog2.Find(id);
            if (recog2 == null)
            {
                return HttpNotFound();
            }
            return View(recog2);
        }

        // GET: Recog2/Create
        public ActionResult Create()
        {
            // ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email");
            // ViewBag.ID = new SelectList(db.UserDetails, "ID", "email");
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "fullName");
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "fullName");

            return View();
        }

        // POST: Recog2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeRecognitionID,CurentDateTime,RecognitionComments,EmployeeGivingRecog,ID")] Recog2 recog2)
        {
            if (ModelState.IsValid)
            {
                db.Recog2.Add(recog2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", recog2.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", recog2.ID);
            return View(recog2);
        }

        // GET: Recog2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recog2 recog2 = db.Recog2.Find(id);
            if (recog2 == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", recog2.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", recog2.ID);
            return View(recog2);
        }

        // POST: Recog2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeRecognitionID,CurentDateTime,RecognitionComments,EmployeeGivingRecog,ID")] Recog2 recog2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recog2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", recog2.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", recog2.ID);
            return View(recog2);
        }

        // GET: Recog2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recog2 recog2 = db.Recog2.Find(id);
            if (recog2 == null)
            {
                return HttpNotFound();
            }
            return View(recog2);
        }

        // POST: Recog2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recog2 recog2 = db.Recog2.Find(id);
            db.Recog2.Remove(recog2);
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
