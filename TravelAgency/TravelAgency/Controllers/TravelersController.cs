using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelAgency;
using TravelAgency.Data;

namespace TravelAgency.Controllers
{
    public class TravelersController : Controller
    {
        private TravelerContext db = new TravelerContext();

        // GET: Travelers
        public ActionResult Index()
        {
            return View(db.Travelers.ToList());
        }

        // GET: Travelers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveler traveler = db.Travelers.Find(id);
            if (traveler == null)
            {
                return HttpNotFound();
            }
            return View(traveler);
        }

        // GET: Travelers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Travelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TravelerID,FirstName,LastName,Email,Gender,Destination,LocalTrip,AgencyName")] Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                db.Travelers.Add(traveler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(traveler);
        }

        // GET: Travelers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveler traveler = db.Travelers.Find(id);
            if (traveler == null)
            {
                return HttpNotFound();
            }
            return View(traveler);
        }

        // POST: Travelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TravelerID,FirstName,LastName,Email,Gender,Destination,LocalTrip,AgencyName")] Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traveler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traveler);
        }

        // GET: Travelers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traveler traveler = db.Travelers.Find(id);
            if (traveler == null)
            {
                return HttpNotFound();
            }
            return View(traveler);
        }

        // POST: Travelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Traveler traveler = db.Travelers.Find(id);
            db.Travelers.Remove(traveler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
