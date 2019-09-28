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
    public class StavkaProfakturesController : Controller
    {
        private ProjekatPPPEntities db = new ProjekatPPPEntities();

        // GET: StavkaProfaktures
        public ActionResult Index()
        {
            var stavkaProfakture = db.StavkaProfakture.Include(s => s.Proizvod);
            return View(stavkaProfakture.ToList());
        }

        // GET: StavkaProfaktures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaProfakture stavkaProfakture = db.StavkaProfakture.Find(id);
            if (stavkaProfakture == null)
            {
                return HttpNotFound();
            }
            return View(stavkaProfakture);
        }

        // GET: StavkaProfaktures/Create
        public ActionResult Create()
        {
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv");
            return View();
        }

        // POST: StavkaProfaktures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RbStavkeProfakture,BarKodArtikla,Kolicina,JedinicnaCena,Vrednost,Opis")] StavkaProfakture stavkaProfakture)
        {
            if (ModelState.IsValid)
            {
                db.StavkaProfakture.Add(stavkaProfakture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaProfakture.BarKodArtikla);
            return View(stavkaProfakture);
        }

        // GET: StavkaProfaktures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaProfakture stavkaProfakture = db.StavkaProfakture.Find(id);
            if (stavkaProfakture == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaProfakture.BarKodArtikla);
            return View(stavkaProfakture);
        }

        // POST: StavkaProfaktures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RbStavkeProfakture,BarKodArtikla,Kolicina,JedinicnaCena,Vrednost,Opis")] StavkaProfakture stavkaProfakture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stavkaProfakture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarKodArtikla = new SelectList(db.Proizvod, "BarKodArtikla", "Naziv", stavkaProfakture.BarKodArtikla);
            return View(stavkaProfakture);
        }

        // GET: StavkaProfaktures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StavkaProfakture stavkaProfakture = db.StavkaProfakture.Find(id);
            if (stavkaProfakture == null)
            {
                return HttpNotFound();
            }
            return View(stavkaProfakture);
        }

        // POST: StavkaProfaktures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StavkaProfakture stavkaProfakture = db.StavkaProfakture.Find(id);
            db.StavkaProfakture.Remove(stavkaProfakture);
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
