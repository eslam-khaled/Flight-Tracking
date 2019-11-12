using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightTracking.Controllers
{
    public class PassangerController : Controller
    {
        // GET: Passanger
        public ActionResult Index()
        {
            return View();
        }
    }
}