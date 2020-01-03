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
    [Authorize]
    public class PropretairesController : Controller
    {
        private MyDbEntities5 db = new MyDbEntities5();

        // GET: Propretaires
        public ActionResult Index()
        {
            var propretaires = db.Propretaires.Include(p => p.PropretaireType);
            return View(propretaires.ToList());
        }

        // GET: Propretaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propretaire propretaire = db.Propretaires.Find(id);
            if (propretaire == null)
            {
                return HttpNotFound();
            }
            return View(propretaire);
        }

        // GET: Propretaires/Create
        public ActionResult Create()
        {
            ViewBag.PropetaireType = new SelectList(db.PropretaireTypes, "Id", "Nom");
            return View();
        }

        // POST: Propretaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Email,Tel,PropetaireType")] Propretaire propretaire)
        {
            if (ModelState.IsValid)
            {
                db.Propretaires.Add(propretaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PropetaireType = new SelectList(db.PropretaireTypes, "Id", "Nom", propretaire.PropetaireType);
            return View(propretaire);
        }

        // GET: Propretaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propretaire propretaire = db.Propretaires.Find(id);
            if (propretaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.PropetaireType = new SelectList(db.PropretaireTypes, "Id", "Nom", propretaire.PropetaireType);
            return View(propretaire);
        }

        // POST: Propretaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Email,Tel,PropetaireType")] Propretaire propretaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propretaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PropetaireType = new SelectList(db.PropretaireTypes, "Id", "Nom", propretaire.PropetaireType);
            return View(propretaire);
        }

        // GET: Propretaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Propretaire propretaire = db.Propretaires.Find(id);
            if (propretaire == null)
            {
                return HttpNotFound();
            }
            return View(propretaire);
        }

        // POST: Propretaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Propretaire propretaire = db.Propretaires.Find(id);
            db.Propretaires.Remove(propretaire);
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
