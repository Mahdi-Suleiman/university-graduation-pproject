using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace tutor.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
        public string Image { get; set; }
        public string About { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        [Display(Name ="One Hour Price")]
        public double OneHourPrice { get; set; }
        [Display(Name = "Two Hour Price")]
        public double TwoHourPrice { get; set; }
        [Display(Name = "Three Hour Price")]
        public double ThreeHourPrice { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<tutor.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<tutor.Models.StudyPlace> StudyPlaces { get; set; }

        public System.Data.Entity.DbSet<tutor.Models.Lecture> Lectures { get; set; }

        public System.Data.Entity.DbSet<tutor.Models.TutorCourses> TutorCourses { get; set; }
    }
}