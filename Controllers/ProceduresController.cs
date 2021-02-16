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
    public class ProceduresController : Controller
    {
        private am108217SDContext db = new am108217SDContext();

        // GET: Procedures
        public ActionResult Index()
        {
            return View(db.Procedure.ToList());
        }

        // GET: Procedures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedure.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // GET: Procedures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "procedureID,procedureType,procedureDate,procedureCost")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Procedure.Add(procedure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedure);
        }

        // GET: Procedures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedure.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "procedureID,procedureType,procedureDate,procedureCost")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedure);
        }

        // GET: Procedures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedure.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        // POST: Procedures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procedure procedure = db.Procedure.Find(id);
            db.Procedure.Remove(procedure);
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
