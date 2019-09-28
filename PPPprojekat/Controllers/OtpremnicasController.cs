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
    public class OtpremnicasController : Controller
    {
        private ProjekatPPPEntities db = new ProjekatPPPEntities();

        // GET: Otpremnicas
        public ActionResult Index()
        {
            var otpremnica = db.Otpremnica.Include(o => o.StavkaOtpremnice);
            return View(otpremnica.ToList());
        }

        // GET: Otpremnicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otpremnica otpremnica = db.Otpremnica.Find(id);
            if (otpremnica == null)
            {
                return HttpNotFound();
            }
            return View(otpremnica);
        }

        // GET: Otpremnicas/Create
        public ActionResult Create()
        {
            ViewBag.RbStavkeOtpremnice = new SelectList(db.StavkaOtpremnice, "RbStavkeOtpremnice", "Opis");
            return View();
        }

        // POST: Otpremnicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOtpremnice,RbStavkeOtpremnice,BarKodArtikla,Kolicina,Opis")] Otpremnica otpremnica)
        {
            if (ModelState.IsValid)
            {
                db.Otpremnica.Add(otpremnica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RbStavkeOtpremnice = new SelectList(db.StavkaOtpremnice, "RbStavkeOtpremnice", "Opis", otpremnica.RbStavkeOtpremnice);
            return View(otpremnica);
        }

        // GET: Otpremnicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otpremnica otpremnica = db.Otpremnica.Find(id);
            if (otpremnica == null)
            {
                return HttpNotFound();
            }
            ViewBag.RbStavkeOtpremnice = new SelectList(db.StavkaOtpremnice, "RbStavkeOtpremnice", "Opis", otpremnica.RbStavkeOtpremnice);
            return View(otpremnica);
        }

        // POST: Otpremnicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOtpremnice,RbStavkeOtpremnice,BarKodArtikla,Kolicina,Opis")] Otpremnica otpremnica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otpremnica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RbStavkeOtpremnice = new SelectList(db.StavkaOtpremnice, "RbStavkeOtpremnice", "Opis", otpremnica.RbStavkeOtpremnice);
            return View(otpremnica);
        }

        // GET: Otpremnicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Otpremnica otpremnica = db.Otpremnica.Find(id);
            if (otpremnica == null)
            {
                return HttpNotFound();
            }
            return View(otpremnica);
        }

        // POST: Otpremnicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Otpremnica otpremnica = db.Otpremnica.Find(id);
            db.Otpremnica.Remove(otpremnica);
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
