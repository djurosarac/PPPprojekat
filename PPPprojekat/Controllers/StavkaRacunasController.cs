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
    public class StavkaRacunasController : Controller
    {
        private ProjekatPPPEntities db = new ProjekatPPPEntities();

        // GET: StavkaRacunas
        public ActionResult Index()
        {
            var stavkaRacuna = db.StavkaRacuna.Include(s => s.Proizvod);
            return View(stavkaRacuna.ToList());
        }

        // GET: StavkaRacunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaRacuna stavkaRacuna = db.StavkaRacuna.Find(id);
            if (stavkaRacuna == null)
            {
                return HttpNotFound();
            }
            return View(stavkaRacuna);
        }

        // GET: StavkaRacunas/Create
        public ActionResult Create()
        {
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv");
            return View();
        }

        // POST: StavkaRacunas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RbStavkeRacuna,BarKodArtikla,Kolicina,Vrednost")] StavkaRacuna stavkaRacuna)
        {
            if (ModelState.IsValid)
            {
                db.StavkaRacuna.Add(stavkaRacuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaRacuna.BarKodArtikla);
            return View(stavkaRacuna);
        }

        // GET: StavkaRacunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaRacuna stavkaRacuna = db.StavkaRacuna.Find(id);
            if (stavkaRacuna == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaRacuna.BarKodArtikla);
            return View(stavkaRacuna);
        }

        // POST: StavkaRacunas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RbStavkeRacuna,BarKodArtikla,Kolicina,Vrednost")] StavkaRacuna stavkaRacuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavkaRacuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaRacuna.BarKodArtikla);
            return View(stavkaRacuna);
        }

        // GET: StavkaRacunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaRacuna stavkaRacuna = db.StavkaRacuna.Find(id);
            if (stavkaRacuna == null)
            {
                return HttpNotFound();
            }
            return View(stavkaRacuna);
        }

        // POST: StavkaRacunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StavkaRacuna stavkaRacuna = db.StavkaRacuna.Find(id);
            db.StavkaRacuna.Remove(stavkaRacuna);
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
