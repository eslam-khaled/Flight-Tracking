using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlightTracking.Models;
using FlightTracking.ViewModels;

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
        // GET: Passanger
        public ActionResult Index(int? id)
        {
            var AllPassangers = context.passangers.Where(x=>x.Stages.StageID == id).ToList();
            return View("_Index", AllPassangers);
        }
        #endregion

        #region Add Passanger
        [HttpGet]
        public ActionResult AddPassanger()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPassanger(Passanger passanger)
        {
            Stages stages = context.Stages.Where(x => x.StageID == 1).FirstOrDefault();
            passanger.Stages = stages;
            context.passangers.Add(passanger);
            context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        #endregion

        //DeletePassanger
        #region Delete
        [HttpGet]
        public ActionResult DeletePassanger(int? id)
        {
            Passanger passanger = context.passangers.Find(id);
            var ResDetails = context.passangers.Where(x => x.Id == id).FirstOrDefault();
            return View(ResDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePassanger(Passanger passanger, int id)
        {
            var MyDel = context.passangers.Where(c => c.Id == id).FirstOrDefault();
            context.passangers.Remove(MyDel);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion

        //EditPassanger
        #region Edit
        [HttpGet]
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
        [HttpGet]
        public ActionResult MoveToNextStage ()
        {
            return View("_NextStage");
        }
        [HttpPost]
        public ActionResult MoveToNextStage(int? id)
        {
            var GoNext = context.passangers.Where(x => x.Stages.StageID == id).SingleOrDefault();
            //GoNext. += 1;
            context.SaveChanges();
            return View("_NextStage");
        }
        #endregion
    }
}