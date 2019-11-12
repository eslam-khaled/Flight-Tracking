using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightTracking.Models;
namespace FlightTracking.Controllers
{

    public class PlaneController : Controller
    {
        ApplicationDbContext context;

        public PlaneController(){

            context = new ApplicationDbContext(); 

        }

        
        // GET: Plane
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult create( Plane plane)
        {
            if (plane == null)
            {
                
            }
            context.planes.Add(plane);
            context.SaveChanges();
            return View("create");
        }
        public ActionResult delete(int id)
        {
            var record = context.planes.Find(id);
            context.planes.Remove(record);
            context.SaveChanges();
            return View();
        }

    }
}