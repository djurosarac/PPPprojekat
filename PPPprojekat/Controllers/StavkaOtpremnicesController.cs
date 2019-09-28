using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PPPprojekat;

namespace PPPprojekat.Controllers
{
    public class StavkaOtpremnicesController : Controller
    {
        private ProjekatPPPEntities db = new ProjekatPPPEntities();

        // GET: StavkaOtpremnices
        public ActionResult Index()
        {
            var stavkaOtpremnice = db.StavkaOtpremnice.Include(s => s.Proizvod);
            return View(stavkaOtpremnice.ToList());
        }

        // GET: StavkaOtpremnices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaOtpremnice stavkaOtpremnice = db.StavkaOtpremnice.Find(id);
            if (stavkaOtpremnice == null)
            {
                return HttpNotFound();
            }
            return View(stavkaOtpremnice);
        }

        // GET: StavkaOtpremnices/Create
        public ActionResult Create()
        {
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv");
            return View();
        }

        // POST: StavkaOtpremnices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RbStavkeOtpremnice,BarKodArtikla,Kolicina,Opis")] StavkaOtpremnice stavkaOtpremnice)
        {
            if (ModelState.IsValid)
            {
                db.StavkaOtpremnice.Add(stavkaOtpremnice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaOtpremnice.BarKodArtikla);
            return View(stavkaOtpremnice);
        }

        // GET: StavkaOtpremnices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaOtpremnice stavkaOtpremnice = db.StavkaOtpremnice.Find(id);
            if (stavkaOtpremnice == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaOtpremnice.BarKodArtikla);
            return View(stavkaOtpremnice);
        }

        // POST: StavkaOtpremnices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RbStavkeOtpremnice,BarKodArtikla,Kolicina,Opis")] StavkaOtpremnice stavkaOtpremnice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavkaOtpremnice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaOtpremnice.BarKodArtikla);
            return View(stavkaOtpremnice);
        }

        // GET: StavkaOtpremnices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaOtpremnice stavkaOtpremnice = db.StavkaOtpremnice.Find(id);
            if (stavkaOtpremnice == null)
            {
                return HttpNotFound();
            }
            return View(stavkaOtpremnice);
        }

        // POST: StavkaOtpremnices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StavkaOtpremnice stavkaOtpremnice = db.StavkaOtpremnice.Find(id);
            db.StavkaOtpremnice.Remove(stavkaOtpremnice);
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
