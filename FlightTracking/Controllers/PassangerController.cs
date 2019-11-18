using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Windows;
using FlightTracking.Models;


namespace FlightTracking.Controllers
{
    public class PassangerController : Controller
    {
        ApplicationDbContext context;
        public PassangerController()
        {
            context = new ApplicationDbContext();
        }

        #region Get All Passangers
        //GET: Passanger
        public ActionResult Details(int id)
        {
            var Passanger = context.passangers.Find(id);
            return PartialView("Details", Passanger);
        }

        //take id of stage and return all passanger in this stage
        // [HttpPost]
        public ActionResult Index(int? id)
        {
            var AllPassangers = context.passangers.Where(x => x.Stages.StageID == id).ToList();
            return View("_Index", AllPassangers);
        }
        #endregion
        //take id of plane and return all passanger in this plane
        #region details
        public ActionResult Planepassaner(int id)
        {
            var passangers = context.passangers.Where(a => a.PassangerPlaneId == id).ToList();
            return PartialView("_indexpassanger", passangers);
        }
        #endregion

        #region Add Passanger
        [HttpGet]
        public ActionResult AddPassanger()
        {
            return PartialView("_partialpassangeradd");
        }
        [HttpPost]
        public ActionResult AddPassanger(int id,Passanger passanger)
        {
            Stages stages = context.Stages.Where(x => x.StageID == 1).FirstOrDefault();
            passanger.Stages = stages;
            passanger.PassangerPlaneId = id;
            context.passangers.Add(passanger);
            context.SaveChanges();
           
            return PartialView("_AppendPassanger", passanger);
            
        }
        #endregion

        //DeletePassanger
        #region Delete
        //[HttpGet]
        //public ActionResult DeletePassanger(int? id)
        //{
        //    var ResDetails = context.passangers.Where(x => x.Id == id).FirstOrDefault();
        //    return View(ResDetails);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DeletePassanger(int id )
        {
            var MyDel = context.passangers.Where(c => c.Id == id).FirstOrDefault();
            context.passangers.Remove(MyDel);
            context.SaveChanges();
            return RedirectToAction("Details","Plane", new { id=MyDel.PassangerPlaneId } );
        }
        #endregion

        //EditPassanger
        #region Edit
        [HttpGet]
        public ActionResult EditPassanger(int? id)
        {
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
       // [HttpPost]
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
                GoNext.PassangerStageId += 4;
                context.SaveChanges();
                return RedirectToAction("StageDetails", "Stage", new { id = GoNext.PassangerStageId - 4 });
            }
            return View();
        }
        #endregion
    }
}