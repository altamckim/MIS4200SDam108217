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
    public class PetsController : Controller
    {
        private am108217SDContext db = new am108217SDContext();

        // GET: Pets
        public ActionResult Index()
        {
            var pet = db.Pet.Include(p => p.owner);
            return View(pet.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "fullName");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "petID,petName,petBreed,petAge,petColor,adoptionDate,ownerID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pet.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName", pet.ownerID);
            return View(pet);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName", pet.ownerID);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "petID,petName,petBreed,petAge,petColor,adoptionDate,ownerID")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ownerID = new SelectList(db.Owner, "ownerID", "firstName", pet.ownerID);
            return View(pet);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pet.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pet.Find(id);
            db.Pet.Remove(pet);
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
