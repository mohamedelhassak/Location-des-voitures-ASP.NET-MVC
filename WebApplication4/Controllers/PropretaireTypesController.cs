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
    public class PropretaireTypesController : Controller
    {
        private MyDbEntities6 db = new MyDbEntities6();

        // GET: PropretaireTypes
        public ActionResult Index()
        {
            return View(db.PropretaireTypes.ToList());
        }

        // GET: PropretaireTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropretaireType propretaireType = db.PropretaireTypes.Find(id);
            if (propretaireType == null)
            {
                return HttpNotFound();
            }
            return View(propretaireType);
        }

        // GET: PropretaireTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropretaireTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom")] PropretaireType propretaireType)
        {
            if (ModelState.IsValid)
            {
                db.PropretaireTypes.Add(propretaireType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propretaireType);
        }

        // GET: PropretaireTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropretaireType propretaireType = db.PropretaireTypes.Find(id);
            if (propretaireType == null)
            {
                return HttpNotFound();
            }
            return View(propretaireType);
        }

        // POST: PropretaireTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom")] PropretaireType propretaireType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propretaireType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propretaireType);
        }

        // GET: PropretaireTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropretaireType propretaireType = db.PropretaireTypes.Find(id);
            if (propretaireType == null)
            {
                return HttpNotFound();
            }
            return View(propretaireType);
        }

        // POST: PropretaireTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropretaireType propretaireType = db.PropretaireTypes.Find(id);
            db.PropretaireTypes.Remove(propretaireType);
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
