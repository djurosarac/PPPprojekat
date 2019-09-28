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
    public class RacunsController : Controller
    {
        private ProjekatPPPEntities db = new ProjekatPPPEntities();

        // GET: Racuns
        public ActionResult Index()
        {
            var racun = db.Racun.Include(r => r.StavkaRacuna);
            return View(racun.ToList());
        }

        // GET: Racuns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // GET: Racuns/Create
        public ActionResult Create()
        {
            ViewBag.RbStavkeRacuna = new SelectList(db.StavkaRacuna, "RbStavkeRacuna", "RbStavkeRacuna");
            return View();
        }

        // POST: Racuns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDRacuna,RbStavkeRacuna,Datum,Vreme,UkupnaVrednost,Obradjen,Storniran")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Racun.Add(racun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RbStavkeRacuna = new SelectList(db.StavkaRacuna, "RbStavkeRacuna", "RbStavkeRacuna", racun.RbStavkeRacuna);
            return View(racun);
        }

        // GET: Racuns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            ViewBag.RbStavkeRacuna = new SelectList(db.StavkaRacuna, "RbStavkeRacuna", "RbStavkeRacuna", racun.RbStavkeRacuna);
            return View(racun);
        }

        // POST: Racuns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDRacuna,RbStavkeRacuna,Datum,Vreme,UkupnaVrednost,Obradjen,Storniran")] Racun racun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RbStavkeRacuna = new SelectList(db.StavkaRacuna, "RbStavkeRacuna", "RbStavkeRacuna", racun.RbStavkeRacuna);
            return View(racun);
        }

        // GET: Racuns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racun racun = db.Racun.Find(id);
            if (racun == null)
            {
                return HttpNotFound();
            }
            return View(racun);
        }

        // POST: Racuns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racun racun = db.Racun.Find(id);
            db.Racun.Remove(racun);
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
