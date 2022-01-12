using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tutor.Models;

namespace tutor.Controllers
{
    [Authorize]
    public class EditPricingsController : Controller
    {
        private ApplicationDbContext db;

        public EditPricingsController()
        {
            db = new ApplicationDbContext();
        }
        // GET: EditPricings
        public ActionResult Index()
        {
            var UserId = User.Identity.GetUserId();
            var user = db.Users.Where(a => a.Id == UserId).SingleOrDefault();
            EditPricingViewModel editPricing = new EditPricingViewModel()
            {
                OneHourPrice = user.OneHourPrice,
                TwoHourPrice = user.TwoHourPrice,
                ThreeHourPrice = user.ThreeHourPrice
            };
            return View(editPricing);
        }

        [HttpPost]
        public ActionResult Index(EditPricingViewModel editPricing)
        {
            if (ModelState.IsValid)
            {
                var UserId = User.Identity.GetUserId();
                var CurrentUser = db.Users.Where(a => a.Id == UserId).SingleOrDefault();
                CurrentUser.OneHourPrice = editPricing.OneHourPrice;
                CurrentUser.TwoHourPrice = editPricing.TwoHourPrice;
                CurrentUser.ThreeHourPrice = editPricing.ThreeHourPrice;
                db.Entry(CurrentUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Pricing updated successfuly.";
            }
            return View();
        }
    }
}
