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
using System.Net;
using System.Net.Mail;
using Microsoft.AspNet.Identity;

namespace MIS4200Group6.Controllers
{
    public class GiveRecognitionsController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: GiveRecognitions
        public ActionResult Index()
        {
            var giveRecognitions = db.GiveRecognitions.Include(g => g.UserDetails).Include(g => g.UserDetails);
            return View(giveRecognitions.ToList());
        }

        // GET: GiveRecognitions/Details/5
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

        // GET: GiveRecognitions/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "fullName");
                ViewBag.ID = new SelectList(db.UserDetails, "ID", "fullName");
                return View();
            }
            else
            {
                return View("NotAuthenticated2");
            }
            
        }

        // POST: GiveRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeRecognitionID,values,CurentDateTime,RecognitionComments,EmployeeGivingRecog,ID")] GiveRecognition giveRecognition)
        {
            if (ModelState.IsValid)
            {
                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                giveRecognition.EmployeeGivingRecog = memberId;
                db.GiveRecognitions.Add(giveRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "email", giveRecognition.EmployeeGivingRecog);
            ViewBag.ID = new SelectList(db.UserDetails, "ID", "email", giveRecognition.ID);
            return View(giveRecognition);
        }

        // GET: GiveRecognitions/Edit/5
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
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (giveRecognition.EmployeeGivingRecog == memberID)
            {
                ViewBag.EmployeeGivingRecog = new SelectList(db.UserDetails, "ID", "fullName", giveRecognition.EmployeeGivingRecog);
                ViewBag.ID = new SelectList(db.UserDetails, "ID", "fullName", giveRecognition.ID);
                return View(giveRecognition);
            }
            else
            {
                return View("NotAuthenticated2");
            }

          
        }

        // POST: GiveRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeRecognitionID, values, CurentDateTime,RecognitionComments,EmployeeGivingRecog,ID")] GiveRecognition giveRecognition)
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

        // GET: GiveRecognitions/Delete/5
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
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (giveRecognition.EmployeeGivingRecog == memberID)
            {
                return View(giveRecognition);
            }
            else
            {
                return View("NotAuthenticated2");
            }
        }

        // POST: GiveRecognitions/Delete/5
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
