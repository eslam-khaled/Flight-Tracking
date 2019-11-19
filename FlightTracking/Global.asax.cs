using FlightTracking.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FlightTracking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //add super admin to manage database using full action
            //delete that after you run that for frist time from here to 


            //var context = new ApplicationDbContext();
            //if (!context.Users.Any(user => user.UserName == "superadmin@app.com"))
            //{
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var userManager = new UserManager<ApplicationUser>(userStore);
            //    var applicationUser = new ApplicationUser() { UserName = "superadmin@app.com" };
            //    userManager.Create(applicationUser, "P@ssw0rd");

            //    var roleStore = new RoleStore<IdentityRole>(context);
            //    var roleManager = new RoleManager<IdentityRole>(roleStore);
            //    roleManager.Create(new IdentityRole("SuperAdmin"));

            //    userManager.AddToRole(applicationUser.Id, "SuperAdmin");
            //}



            //to here

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
