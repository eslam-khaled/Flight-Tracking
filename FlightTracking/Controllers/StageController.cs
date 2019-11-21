using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightTracking.Models;
using FlightTracking.ViewModels;

namespace FlightTracking.Controllers
{
    [Authorize]
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
        //public ActionResult StageDetails(int id)
        //{
        //    //id of stage
        //    var Details = context.Stages.Where(x => x.StageID == id).FirstOrDefault();
        //    Details.EstimatedTime += Convert.ToInt32(Details.ExtraTime);
        //    return View("_StageDetails", Details);
        //}
        #endregion

        public ActionResult StageDetails(int id)
        {
            //id of stage
            if (User.IsInRole("OnPlaneManager") && id != 1)
            {
                id = 1;
            }
            else if (User.IsInRole("LuggageManager") && id != 2)
            {
                id = 2;
            }
            else if (User.IsInRole("InspectingManager") && id != 3)
            {
                id = 3;
            }
            else if (User.IsInRole("CustomManager") && id != 4)
            {
                id = 4;
            }
            else if (User.IsInRole("PapersManager") && id != 5)
            {
                id = 5;
            }
            

            var Details = context.Stages.Where(x => x.StageID == id).FirstOrDefault();
            //Details.EstimatedTime += Convert.ToInt32(Details.ExtraTime);
            var passenger = context.passangers.Where(x => x.PassangerStageId == id).ToList();
            PassangerStageVM vs = new PassangerStageVM { passanger = passenger, stages = Details };
            
            return View("StageDetails", vs);
        }


        #region Add Extra Time
        //[HttpGet]
        //public ActionResult AddExtraTime()
        //{
        //    return View();
        //}

            
        [HttpPost]
        public ActionResult AddExtraTime(PassangerStageVM s, int id)
        {
            try
            {
                Stages addEx = context.Stages.Where(x => x.StageID == id).SingleOrDefault();
                List<Passanger> pa = context.passangers.Where(x => x.PassangerStageId == id).ToList();
                addEx.ExtraTime = s.stages.ExtraTime;
                addEx.EstimatedTime += Convert.ToInt32(addEx.ExtraTime);
                s.passanger = pa;
                s.stages = addEx;
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

            return RedirectToAction("StageDetails", new { id = id });
        }
        #endregion
    }
}