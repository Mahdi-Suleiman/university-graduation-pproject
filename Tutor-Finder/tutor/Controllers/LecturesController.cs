using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tutor.Models;

namespace tutor.Controllers
{

    [Authorize]
    public class LecturesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lectures
        public ActionResult Index()
        {
            var lectures = db.Lectures.Include(l => l.Course).Include(l => l.StudyPlace);
            return View(lectures.ToList());
        }

        // GET: Lectures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // GET: Lectures/Create
        public ActionResult Create(string tutorId)
        {
            List<Course> courses = new List<Course>();
            foreach (var tutorCourse in db.TutorCourses.Where(tc=>tc.TutorId==tutorId))
            {
                courses.Add(tutorCourse.Course);
            }
            var tutor = db.Users.Where(t => t.Id == tutorId).FirstOrDefault();
            string tutorName = tutor.FirstName + " " + tutor.LastName;
            ViewBag.CourseId = new SelectList(courses, "Id", "Name");
            ViewBag.StudyPlaceId = new SelectList(db.StudyPlaces, "Id", "Name");
            ViewBag.TId = tutorId;
            ViewBag.TutorName = tutorName;
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TutorId,Id,StartTime,Duration,StudyPlaceId,CourseId")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                var tutor = db.Users.Where(t=>t.Id == lecture.TutorId).FirstOrDefault();
                switch (lecture.Duration)
                {
                    case 1:
                        lecture.Price = tutor.OneHourPrice;
                        break;
                    case 2:
                        lecture.Price = tutor.TwoHourPrice;
                        break;
                    case 3:
                        lecture.Price = tutor.ThreeHourPrice;
                        break;
                    default:
                        break;
                }
                lecture.Confirmed = false;
                lecture.StudentId = User.Identity.GetUserId();
                db.Lectures.Add(lecture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", lecture.CourseId);
            ViewBag.StudyPlaceId = new SelectList(db.StudyPlaces, "Id", "Name", lecture.StudyPlaceId);
            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", lecture.CourseId);
            ViewBag.StudyPlaceId = new SelectList(db.StudyPlaces, "Id", "Name", lecture.StudyPlaceId);
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TutorId,StudentId,StartTime,Duration,Price,StudyPlaceId,CourseId")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", lecture.CourseId);
            ViewBag.StudyPlaceId = new SelectList(db.StudyPlaces, "Id", "Name", lecture.StudyPlaceId);
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            db.Lectures.Remove(lecture);
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



        // GET: Lectures/Delete/5
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Accept")]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptConfirmed(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            lecture.Confirmed = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
