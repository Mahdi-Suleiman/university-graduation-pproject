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
    [Authorize(Roles = "Admin")]
    public class TutorCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TutorCourses
        public ActionResult Index()
        {
            var tutorCourses = db.TutorCourses.Include(t => t.Course).Include(t => t.Tutor);
            return View(tutorCourses.ToList());
        }

        // GET: TutorCourses/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorCourses tutorCourses = db.TutorCourses.Find(id);
            if (tutorCourses == null)
            {
                return HttpNotFound();
            }
            return View(tutorCourses);
        }

        // GET: TutorCourses/Create
        public ActionResult Create()
        {
            var tutors = db.Users
                        .Where(u => u.UserType == "Tutor")
                        .Select(u => new
                        {
                            Id = u.Id,
                            FullName = u.FirstName + " " + u.LastName
                        })
                        .ToList();
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name");
            ViewBag.TutorId = new SelectList(tutors, "Id", "FullName");
            return View();
        }

        // POST: TutorCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TutorId,CourseId")] TutorCourses tutorCourses)
        {
            if (ModelState.IsValid)
            {
                if (db.TutorCourses.Where(tc => tc.TutorId == tutorCourses.TutorId && tc.CourseId == tutorCourses.CourseId).Count() == 0)
                {
                    db.TutorCourses.Add(tutorCourses);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", tutorCourses.CourseId);
            ViewBag.TutorId = new SelectList(db.Users, "Id", "FirstName", tutorCourses.TutorId);
            return View(tutorCourses);
        }

        // GET: TutorCourses/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorCourses tutorCourses = db.TutorCourses.Find(id);
            if (tutorCourses == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", tutorCourses.CourseId);
            ViewBag.TutorId = new SelectList(db.Users, "Id", "FirstName", tutorCourses.TutorId);
            return View(tutorCourses);
        }

        // POST: TutorCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TutorId,CourseId")] TutorCourses tutorCourses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutorCourses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "Name", tutorCourses.CourseId);
            ViewBag.TutorId = new SelectList(db.Users, "Id", "FirstName", tutorCourses.TutorId);
            return View(tutorCourses);
        }

        // GET: TutorCourses/Delete/5
        public ActionResult Delete(string id)
        {
            string[] ids = id.Split(',');
            int courseId =Convert.ToInt32(ids[0]);
            string tutorId = ids[1];
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorCourses tutorCourses = db.TutorCourses.Where(tc=>tc.TutorId == tutorId && courseId == tc.CourseId).FirstOrDefault();
            if (tutorCourses == null)
            {
                return HttpNotFound();
            }
            return View(tutorCourses);
        }

        // POST: TutorCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            string[] ids = id.Split(',');
            int courseId = Convert.ToInt32(ids[0]);
            string tutorId = ids[1];
            TutorCourses tutorCourse = db.TutorCourses.Where(tc => tc.TutorId == tutorId && courseId == tc.CourseId).FirstOrDefault();
            db.TutorCourses.Remove(tutorCourse);
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
