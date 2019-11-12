using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightTracking.Controllers
{
    public class PlaneController : Controller
    {
        // GET: Plane
        public ActionResult Index()
        {
            return View();
        }
    }
}