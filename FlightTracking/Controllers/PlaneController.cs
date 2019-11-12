using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlightTracking.Models;
namespace FlightTracking.Controllers
{

    public class PlaneController : Controller
    {
        ApplicationDbContext context;

        public PlaneController()
        {

            context = new ApplicationDbContext();

        }


        // GET: Plane
        #region Details
        public ActionResult Index()
        {
            var plane = context.planes.ToList();
            return View(plane);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var plane = context.planes.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }
        #endregion

        //update plane
        #region update
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = context.planes.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Plane plane)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                context.Entry(plane).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        #endregion
        // create Plane
        #region Create
        public ActionResult create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult create(Plane plane)
        {
            if (plane == null)
            {

            }
            context.planes.Add(plane);
            context.SaveChanges();
            return View("create");
        }
        #endregion
        // delete Plane
        #region delete
        public ActionResult delete(int id)
        {
            var record = context.planes.Find(id);
            context.planes.Remove(record);
            context.SaveChanges();
            return View();
        }
        #endregion

    }
}