using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }
        [HttpPost]
        public ActionResult AddPassanger(Passanger passanger)
        {
            context.passangers.Add(passanger);
            context.SaveChanges();
            return View("Index");
        }
        #endregion
    }
}