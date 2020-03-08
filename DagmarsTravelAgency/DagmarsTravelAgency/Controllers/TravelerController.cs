using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DagmarsTravelAgency.DAL;
using DagmarsTravelAgency.Models;

namespace DagmarsTravelAgency.Controllers
{
    public class TravelerController : Controller
    {
        private DagmarsDataContext db = new DagmarsDataContext();

        // GET: Traveler

        public ActionResult Index()
        {
            return View(db.Travelers.ToList());
        }

        // GET: Traveler/Details/5
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

        // GET: Traveler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Traveler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email")] Traveler traveler)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Travelers.Add(traveler);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(traveler);
        }

        // GET: Traveler/Edit/5
        
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
        
        /*
        // Non-working Tutorial-Code...??? => modification dropped

        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var travelerToUpdate = db.Travelers.Find(id);
            if (TryUpdateModel(travelerToUpdate, "",
               new string[] { "FirstName", "LastName", "Email" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException ) // dex )
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(travelerToUpdate);
        }

*/
        // POST: Traveler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email")] Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traveler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(traveler);
        }

        // GET: Traveler/Delete/5
        /*
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
        */
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Traveler traveler = db.Travelers.Find(id);
            if (traveler == null)
            {
                return HttpNotFound();
            }
            return View(traveler);
        }


        // POST: Traveler/Delete/5
        /*
                [HttpPost, ActionName("Delete")]
                [ValidateAntiForgeryToken]
                public ActionResult DeleteConfirmed(int id)
                {
                    Traveler traveler = db.Travelers.Find(id);
                    db.Travelers.Remove(traveler);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Traveler traveler = db.Travelers.Find(id);
                db.Travelers.Remove(traveler);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
