using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tutor.Models;

namespace tutor.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudyPlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudyPlaces
        public ActionResult Index()
        {
            return View(db.StudyPlaces.ToList());
        }

        // GET: StudyPlaces/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyPlace studyPlace = db.StudyPlaces.Find(id);
            if (studyPlace == null)
            {
                return HttpNotFound();
            }
            return View(studyPlace);
        }

        // GET: StudyPlaces/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudyPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudyPlace studyPlace, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(path);
                studyPlace.Image = upload.FileName;
                db.StudyPlaces.Add(studyPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studyPlace);
        }

        // GET: StudyPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyPlace studyPlace = db.StudyPlaces.Find(id);
            if (studyPlace == null)
            {
                return HttpNotFound();
            }
            return View(studyPlace);
        }

        // POST: StudyPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Location,PhoneNumber")] StudyPlace studyPlace, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string oldPath = Path.Combine(Server.MapPath("~/Uploads"), studyPlace.Image);

                if (upload != null)
                {
                    System.IO.File.Delete(oldPath);
                    string path = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(path);
                    studyPlace.Image = upload.FileName;
                }
                db.Entry(studyPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studyPlace);
        }

        // GET: StudyPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyPlace studyPlace = db.StudyPlaces.Find(id);
            if (studyPlace == null)
            {
                return HttpNotFound();
            }
            return View(studyPlace);
        }

        // POST: StudyPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudyPlace studyPlace = db.StudyPlaces.Find(id);
            db.StudyPlaces.Remove(studyPlace);
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
