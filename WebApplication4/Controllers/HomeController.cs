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
    
    public class HomeController : Controller
    {
        private MyDbEntities6 db = new MyDbEntities6();
        public ActionResult Index()
        {
            ViewBag.cat = new SelectList(db.Categories,"Id","Nom");
            ViewBag.mar = new SelectList(db.Marques,"Id","Nom");
            var voitures = db.Voitures.Include(v => v.Categorie1).Include(v => v.Marque1).Include(v => v.Module1).Include(v => v.Propretaire1).OrderBy(v=>v.montant);
            return View(voitures.ToList());
         
        }
        [HttpPost]
        public ActionResult Index(int? catId,int? marId)
        {
 
            if (marId == null)
            {
                ViewBag.cat = new SelectList(db.Categories, "Id", "Nom");
                ViewBag.mar = new SelectList(db.Marques, "Id", "Nom");
                var voitures = db.Voitures.Include(v => v.Categorie1).Include(v => v.Marque1).Include(v => v.Module1).Include(v => v.Propretaire1).OrderBy(v => v.montant).Where(x => x.Categorie1.Id == catId );
                return View(voitures.ToList());
            }
            else if (catId==null)
            {
                ViewBag.cat = new SelectList(db.Categories, "Id", "Nom");
                ViewBag.mar = new SelectList(db.Marques, "Id", "Nom");
               var  voitures = db.Voitures.Include(v => v.Categorie1).Include(v => v.Marque1).Include(v => v.Module1).Include(v => v.Propretaire1).OrderBy(v => v.montant).Where(x => x.Marque1.Id == marId);
                return View(voitures.ToList());
            }
            else if (catId == null&& marId==null)
            {
                ViewBag.cat = new SelectList(db.Categories, "Id", "Nom");
                ViewBag.mar = new SelectList(db.Marques, "Id", "Nom");
                var voitures = db.Voitures.Include(v => v.Categorie1).Include(v => v.Marque1).Include(v => v.Module1).Include(v => v.Propretaire1).OrderBy(v => v.montant);
                return View(voitures.ToList());
            }
            else
            {
                ViewBag.cat = new SelectList(db.Categories, "Id", "Nom");
                ViewBag.mar = new SelectList(db.Marques, "Id", "Nom");
                var voitures = db.Voitures.Include(v => v.Categorie1).Include(v => v.Marque1).Include(v => v.Module1).Include(v => v.Propretaire1).OrderBy(v => v.montant).Where(x => x.Categorie1.Id == catId && x.Marque1.Id == marId);
                return View(voitures.ToList());
            }

        }

        public ActionResult voiture_info(int? id)
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


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}