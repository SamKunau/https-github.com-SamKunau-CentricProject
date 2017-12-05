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
    public class MyRecognitionsController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: MyRecognitions
        public ActionResult Index()
        {
            Guid userID;
            Guid.TryParse(User.Identity.GetUserId(), out userID);

            var giveRecognitions = db.GiveRecognitions.Where(g => g.ID == userID).OrderByDescending(g => g.CurentDateTime);
            return View(giveRecognitions.ToList());
        }

        // GET: MyRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiveRecognition giveRecognition = db.GiveRecognitions.Find(id);
            if (giveRecognition == null)
            {
                return HttpNotFound();
            }
            return View(giveRecognition);
        }

        // GET: MyRecognitions/Create
        public ActionResult Create()
        {
            /*ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email");
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email");*/
            return View();
        }

        // POST: MyRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeRecognitionID,CurentDateTime,values,RecognitionComments,EmployeeGivingRecog,ID")] GiveRecognition giveRecognition)
        {
            if (ModelState.IsValid)
            {
                db.GiveRecognitions.Add(giveRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           /*ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", giveRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", giveRecognition.ID);*/
            return View(giveRecognition);
        }

        // GET: MyRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiveRecognition giveRecognition = db.GiveRecognitions.Find(id);
            if (giveRecognition == null)
            {
                return HttpNotFound();
            }
           /* ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", giveRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", giveRecognition.ID);*/
            return View(giveRecognition);
        }

        // POST: MyRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeRecognitionID,CurentDateTime,values,RecognitionComments,EmployeeGivingRecog,ID")] GiveRecognition giveRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giveRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", giveRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", giveRecognition.ID);
            return View(giveRecognition);
        }

        // GET: MyRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiveRecognition giveRecognition = db.GiveRecognitions.Find(id);
            if (giveRecognition == null)
            {
                return HttpNotFound();
            }
            return View(giveRecognition);
        }

        // POST: MyRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GiveRecognition giveRecognition = db.GiveRecognitions.Find(id);
            db.GiveRecognitions.Remove(giveRecognition);
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
