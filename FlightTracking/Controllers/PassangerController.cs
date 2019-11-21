using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows;
using FlightTracking.Models;
using System.Net;


namespace FlightTracking.Controllers
{
    [Authorize]
    public class PassangerController : Controller
    {
        string path="../images/";
        ApplicationDbContext context;
        public PassangerController()
        {
            context = new ApplicationDbContext();
        }


        #region Get Passangers
 
        //GET: Passanger By Stage ID
            public ActionResult Index(int? id =1)
        {
            var AllPassangers = context.passangers.Where(x => x.Stages.StageID == id).ToList();
          //  var AllPassangers = context.passangers.Where(x => x.Id == id).ToList();
            return View("Index", AllPassangers);
        }
        public ActionResult Planepassaner(int id)
        {
            var passangers = context.passangers.Where(a => a.PassangerPlaneId == id).ToList();
            return PartialView("_indexpassanger", passangers);
        }
        #endregion

        #region details
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Details(int id)
        {
            var p = context.passangers.Find(id);
            return View("Details",p);

        }
        #endregion
        [Authorize(Roles ="SuperAdmin")]
        #region Add Passanger
        [HttpGet]
        public ActionResult AddPassanger()
        {
            return PartialView("_partialpassangeradd");
        }
        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult AddPassanger(int id,Passanger passanger)
        {
            //Stages stages = context.Stages.Where(x => x.StageID == 1).FirstOrDefault();
            //passanger.Stages = stages;
            if (ModelState.IsValid)
            {
                passanger.PassangerStageId = 1;
                passanger.PassangerPlaneId = id;
                context.passangers.Add(passanger);
                context.SaveChanges();
                return PartialView("_AppendPassanger", passanger);
            }
            return PartialView("_AppendPassanger", passanger);
            
        }
        #endregion

        //DeletePassanger
        #region Delete
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult DeletePassanger(int? id)
        {
            Passanger passanger = context.passangers.Find(id);
            int ?planeid = passanger.PassangerPlaneId;
            context.passangers.Remove(passanger);
            context.SaveChanges();
            return RedirectToAction("Details","Plane",new { id= planeid });
        }

        //[HttpPost]
      
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePassanger(Passanger passanger, int id)
        //{
        //    var MyDel = context.passangers.Where(c => c.Id == id).FirstOrDefault();
        //    context.passangers.Remove(MyDel);
        //    context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        #endregion

        //EditPassanger
        #region Edit
        [HttpGet]
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult EditPassanger(int? id)
        {
            Passanger passanger = context.passangers.Find(id);
            var ResDetails = context.passangers.Where(x => x.Id == id).FirstOrDefault();
            return View(ResDetails);
        }

        [HttpPost]
   
        [ValidateAntiForgeryToken]
        public ActionResult EditPassanger(Passanger passanger, int id)
        {
            var MyEdit = context.passangers.Where(c => c.Id == id).FirstOrDefault();
            MyEdit.Name = passanger.Name;
            MyEdit.Nationality = passanger.Nationality;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        #region Next Stage
        //[HttpGet]
        //public ActionResult MoveToNextStage()
        //{
        //    return RedirectToAction("");
        //}

        public ActionResult MoveToNextStage(int? id)
        {
            var GoNext = context.passangers.Where(x=>x.Id==id).SingleOrDefault();
            if (GoNext.PassangerStageId < 5)
            {
                GoNext.PassangerStageId += 1;
                context.SaveChanges();
                return RedirectToAction("StageDetails", "Stage", new { id = GoNext.PassangerStageId -1 });
            }
            else if (GoNext.PassangerStageId == 5)
            {
                return PartialView("Error");
            }
            return View();
        }
        #endregion
        #region Passanger Search
        [AllowAnonymous]
        public ActionResult PassangerSearch()
        {
            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public ActionResult PassangerSearch(int? Id)
        {

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passanger passanger = context.passangers.Find(Id);
            if (passanger == null)
            {
                return HttpNotFound();
            }
            else
            {
                var result = (from p in context.passangers
                              join s in context.Stages
                              on p.PassangerStageId equals s.StageID
                              where p.Id == Id
                              select new PassangerSearch
                              {
                                  PicturePath = path + s.Picture.Trim(),
                                  PassangerName = p.Name,
                                  PassangerNationality = p.Nationality,
                                  StageName = s.StageName,
                                  StageExtraTime = s.ExtraTime,
                                  StageEstimatedTime = s.EstimatedTime
                              }).FirstOrDefault();

                return View("PassangerSearchDetails", result);
            }

        }
        #endregion
    }
}