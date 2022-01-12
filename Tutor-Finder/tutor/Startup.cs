using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using tutor.Models;

[assembly: OwinStartupAttribute(typeof(tutor.Startup))]
namespace tutor
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        public void CreateDefaultRolesAndUsers()
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admin"))
            {
                role.Name = "Admin";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin";
                user.FirstName = "Ahmad";
                user.LastName = "Aladham";
                user.UserType = "Admin";
                user.Email = "aladhamahmad588a@gmail.com";
                user.Image = "default.png";
                var check = userManager.Create(user, "123Aa.");
                if (check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
        }

    }
}
