using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using am108217MIS4200.DAL;
using am108217MIS4200.Models;

namespace am108217MIS4200.Controllers
{
    public class VetsController : Controller
    {
        private am108217SDContext db = new am108217SDContext();

        // GET: Vets
        public ActionResult Index()
        {
            var vet = db.Vet.Include(v => v.owner);
            return View(vet.ToList());
        }

        // GET: Vets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vet.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // GET: Vets/Create
        public ActionResult Create()
        {
            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName");
            return View();
        }

        // POST: Vets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vetID,vetFirstName,vetLastName,vetAddress,vetEmail,vetPhone,ownerID")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Vet.Add(vet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName", vet.ownerID);
            return View(vet);
        }

        // GET: Vets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vet.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName", vet.ownerID);
            return View(vet);
        }

        // POST: Vets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vetID,vetFirstName,vetLastName,vetAddress,vetEmail,vetPhone,ownerID")] Vet vet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName", vet.ownerID);
            return View(vet);
        }

        // GET: Vets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vet vet = db.Vet.Find(id);
            if (vet == null)
            {
                return HttpNotFound();
            }
            return View(vet);
        }

        // POST: Vets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vet vet = db.Vet.Find(id);
            db.Vet.Remove(vet);
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
