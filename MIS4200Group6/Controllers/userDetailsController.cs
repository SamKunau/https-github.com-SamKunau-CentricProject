using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using MIS4200Group6.DAL;
using MIS4200Group6.Models;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;
using System.IO;
using System.Drawing;

namespace MIS4200Group6.Controllers
{
    public class userDetailsController : Controller
    {
        private CentricContext db = new CentricContext();

        // GET: userDetails

        public ActionResult Index(string searchString)
        {
            var testuserdetails = from u in db.UserDetails select u;
            if (!String.IsNullOrEmpty(searchString))
            {
                testuserdetails = testuserdetails.Where(u => u.lastName.Contains(searchString) || u.firstName.Contains(searchString));
                return View(testuserdetails.ToList());
            }
            return View(db.UserDetails.ToList());
        }

        // GET: userDetails/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            return View(userDetails);
        }

        // GET: userDetails/Create

        [HttpGet]
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.email = User.Identity.Name;
                return View();
            }
            else
            {
                return View("NotAuthenticated2");
            }
            
        }

        // POST: userDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,email,firstName,lastName,phoneNumber,office,Position,HireDate,numberOfYears,photo")] userDetails userDetails)
        {

           
            if (ModelState.IsValid)
            {
                
                HttpPostedFileBase file = Request.Files["photo"];
                
                if (file != null && file.FileName != null && file.FileName != "")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension !=".jpeg" && fi.Extension !=".jpg" && fi.Extension !="gif")
                    {
                        TempData["Errormsg"] = "Image File Extension is not valid";
                        return View(userDetails);
                    }
                    else
                    {
                        userDetails.photo = userDetails.ID + fi.Extension;
                        file.SaveAs(Server.MapPath("~/Content/Images/" + userDetails.ID + fi.Extension));

                    }
                }

                Guid memberId;
                Guid.TryParse(User.Identity.GetUserId(), out memberId);
                userDetails.ID = memberId;
                userDetails.email = User.Identity.Name;
                //userDetails.ID = Guid.NewGuid();
                db.UserDetails.Add(userDetails); 
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(userDetails);
        }

        // GET: userDetails/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (userDetails.ID == memberID)
            {
                return View(userDetails);
            }
            else
            {
                return View("NotAuthenticated2");
            }

        }

        // POST: userDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,email,firstName,lastName,phoneNumber,office,Position,HireDate,numberOfYears,photo")] userDetails userDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetails).State = EntityState.Modified;
                HttpPostedFileBase file = Request.Files["photo"];
                if (file !=null && file.FileName !=null && file.FileName !="")
                {
                    FileInfo fi = new FileInfo(file.FileName);
                    if (fi.Extension !=".jpeg" && fi.Extension !=".jpg" && fi.Extension !="gif")
                    {
                        TempData["Errormsg"] = "Image File Extension is not valid";
                        return View(userDetails);
                    }
                    else
                    {
                        userDetails imageOld = db.UserDetails.Find(userDetails.ID);
                        string imageName = imageOld.photo;
                        string path = Server.MapPath("~/Content/Images/" + imageName);
                    try
                        {
                            if (System.IO.File.Exists(path))
                            {
                                System.IO.File.Delete(path);
                            }
                            else
                            {

                            }
                        }
                        catch (Exception Ex)
                        {

                        }
                        userDetails.photo = userDetails.ID + fi.Extension;
                        file.SaveAs(Server.MapPath("~/Content/Images/" + userDetails.ID + fi.Extension));
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetails);
        }

        // GET: userDetails/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userDetails userDetails = db.UserDetails.Find(id);
            if (userDetails == null)
            {
                return HttpNotFound();
            }
            Guid memberID;
            Guid.TryParse(User.Identity.GetUserId(), out memberID);
            if (userDetails.ID == memberID)
            {
                return View(userDetails);
            }
            else
            {
                return View("NotAuthenticated2");
            }
            //return View(userDetails);
        }

        // POST: userDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            userDetails userDetails = db.UserDetails.Find(id);
            string imageName = userDetails.photo;
            string path = Server.MapPath("~/Content/Images/" + imageName);
            try
            {
                System.IO.File.Delete(path);
            }
            catch (Exception Ex)
            {

            }
            db.UserDetails.Remove(userDetails);
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
