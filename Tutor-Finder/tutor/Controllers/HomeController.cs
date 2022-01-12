using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutor.Models;

namespace tutor.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        public HomeController()
        {
            db = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Tutors()
        {
            return View();
        }

        public ActionResult StudyPlaces()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchName)
        {
            var result = db.Users.Where(u => (u.FirstName.Contains(searchName)
            || u.LastName.Contains(searchName)) && u.UserType == "Tutor").ToList();
            var courseResults = db.TutorCourses.Where(tc => tc.Course.Name.Contains(searchName)).Select(tc=>tc.Tutor).Where(u=>u.UserType=="Tutor").ToList();
            ViewBag.CourseResults = courseResults;
            var searchResults = result.Union(courseResults);
            return View(searchResults);
        }
    }
}