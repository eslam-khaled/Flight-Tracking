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
        public ActionResult Index()
        {
            var AllPassangers = context.passangers.ToList();
            return View(AllPassangers);
        }
        #endregion

        #region Add Passanger
        [HttpGet]
        public ActionResult AddPassanger()
        {
            var passangerVM = new PassangerStageVM
            {
                passanger = new Passanger(),
                stages = context.Stages
            };
            return View(passangerVM);
        }
        [HttpPost]
        public ActionResult AddPassanger(Passanger passanger)
        {
            var stages = context.Stages.ToList();
            context.passangers.Add(passanger);
            context.SaveChanges();
            var passangerVM = new PassangerStageVM
            {
                stages = stages
            };
            return RedirectToAction("Index");
            return PartialView("_partialpassangeradd");
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
    }
}