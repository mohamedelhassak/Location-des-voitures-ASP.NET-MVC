using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ReservationsController : Controller
    {
        private MyDbEntities7 db = new MyDbEntities7();

        // GET: Reservations
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Client1).Include(r => r.Propretaire).Include(r => r.Voiture1);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        public ActionResult Reserver(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture v = db.Voitures.Find(id);
            if (v == null)
            {
                return HttpNotFound();
            }
            return View(v);
        }

        // GET: Reservations/Create
        public ActionResult Create()
        {
            ViewBag.client = new SelectList(db.Clients, "Id", "Nom");
            ViewBag.prop = new SelectList(db.Propretaires, "Id", "Nom");
            ViewBag.voiture = new SelectList(db.Voitures, "Id", "imma");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,client,prop,voiture,date_debut,date_fin,montant")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.client = new SelectList(db.Clients, "Id", "Nom", reservation.client);
            ViewBag.prop = new SelectList(db.Propretaires, "Id", "Nom", reservation.prop);
            ViewBag.voiture = new SelectList(db.Voitures, "Id", "imma", reservation.voiture);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.client = new SelectList(db.Clients, "Id", "Nom", reservation.client);
            ViewBag.prop = new SelectList(db.Propretaires, "Id", "Nom", reservation.prop);
            ViewBag.voiture = new SelectList(db.Voitures, "Id", "imma", reservation.voiture);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,client,prop,voiture,date_debut,date_fin,montant")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.client = new SelectList(db.Clients, "Id", "Nom", reservation.client);
            ViewBag.prop = new SelectList(db.Propretaires, "Id", "Nom", reservation.prop);
            ViewBag.voiture = new SelectList(db.Voitures, "Id", "imma", reservation.voiture);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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
