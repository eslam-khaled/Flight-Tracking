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
        #region DB Context
        ApplicationDbContext context;
        public StageController()
        {
            context = new ApplicationDbContext();
        }
        #endregion

        #region Show Stage Details
        // GET: Stage
        public ActionResult StageDetails(int id )
        {
            var Details = context.Stages.Where(x => x.StageID == id).FirstOrDefault();
            Details.EstimatedTime += Convert.ToInt32(Details.ExtraTime);
            return View("_StageDetails", Details);
        }
        #endregion

        #region Add Extra Time
        [HttpGet]
        public ActionResult AddExtraTime()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExtraTime(Stages stages, int id)
        {
            var addEx = context.Stages.Where(x => x.StageID == id).SingleOrDefault();
            addEx.ExtraTime = stages.ExtraTime;
            context.SaveChanges();
            return RedirectToAction("StageDetails");
        }
        #endregion
    }
}