using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Authorize]
    public class VoituresController : Controller
    {
        private MyDbEntities5 db = new MyDbEntities5();

        // GET: Voitures
        public ActionResult Index()
        {
            var voitures = db.Voitures.Include(v => v.Categorie1).Include(v => v.Marque1).Include(v => v.Module1).Include(v => v.Propretaire1);
            return View(voitures.ToList());
        }

        // GET: Voitures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // GET: Voitures/Create
        public ActionResult Create()
        {
            ViewBag.Categorie = new SelectList(db.Categories, "Id", "Nom");
            ViewBag.Marque = new SelectList(db.Marques, "Id", "Nom");
            ViewBag.Module = new SelectList(db.Modules, "Id", "Nom");
            ViewBag.Propretaire = new SelectList(db.Propretaires, "Id", "Nom");
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
          public ActionResult Create( Voiture voiture, HttpPostedFileBase imageLocation)
            {

                if (ModelState.IsValid){

                try
                {
                    if (imageLocation != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/images/voitures"), Path.GetFileName(imageLocation.FileName));
                        imageLocation.SaveAs(path);
                        ViewBag.path = path;
                        Console.WriteLine(voiture.imageLocation);


                    }
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

                    db.Voitures.Add(voiture);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Categorie = new SelectList(db.Categories, "Id", "Nom", voiture.Categorie);
                ViewBag.Marque = new SelectList(db.Marques, "Id", "Nom", voiture.Marque);
                ViewBag.Module = new SelectList(db.Modules, "Id", "Nom", voiture.Module);
                ViewBag.Propretaire = new SelectList(db.Propretaires, "Id", "Nom", voiture.Propretaire);
                return View(voiture);
            }

        public ActionResult UploadFiles(HttpPostedFileBase imageLocation)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    if (imageLocation != null)
                    {
                        string path = Path.Combine(Server.MapPath("~/App_Data/images/voitures"), Path.GetFileName(imageLocation.FileName));
                        imageLocation.SaveAs(path);
                        ViewBag.path = path;

                    }
                    ViewBag.FileStatus = "File uploaded successfully.";
                    
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }

            }
            return View("View");
        }


        // GET: Voitures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categorie = new SelectList(db.Categories, "Id", "Nom", voiture.Categorie);
            ViewBag.Marque = new SelectList(db.Marques, "Id", "Nom", voiture.Marque);
            ViewBag.Module = new SelectList(db.Modules, "Id", "Nom", voiture.Module);
            ViewBag.Propretaire = new SelectList(db.Propretaires, "Id", "Nom", voiture.Propretaire);
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,imma,capacite,charge_diesl,kilometrage,max_vitesse,montant,Marque,Module,Propretaire,Categorie,GPS")] Voiture voiture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(voiture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categorie = new SelectList(db.Categories, "Id", "Nom", voiture.Categorie);
            ViewBag.Marque = new SelectList(db.Marques, "Id", "Nom", voiture.Marque);
            ViewBag.Module = new SelectList(db.Modules, "Id", "Nom", voiture.Module);
            ViewBag.Propretaire = new SelectList(db.Propretaires, "Id", "Nom", voiture.Propretaire);
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Voiture voiture = db.Voitures.Find(id);
            if (voiture == null)
            {
                return HttpNotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Voiture voiture = db.Voitures.Find(id);
            db.Voitures.Remove(voiture);
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
