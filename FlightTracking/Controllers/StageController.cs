using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightTracking.Models;

namespace FlightTracking.Controllers
{
    public class StageController : Controller
    {
        ApplicationDbContext context;
        public StageController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Stage
        public ActionResult StageDetails(int id = 2)
        {
            var Details = context.Stages.Where(x => x.StageID == id).FirstOrDefault();
            return PartialView("_StageDetails", Details);
        }
    }
}