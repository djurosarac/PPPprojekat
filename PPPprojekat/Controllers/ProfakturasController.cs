﻿using System;
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
    public class ProfakturasController : Controller
    {
        private ProjekatPPPEntities db = new ProjekatPPPEntities();

        // GET: Profakturas
        public ActionResult Index()
        {
            var profaktura = db.Profaktura.Include(p => p.StavkaProfakture);
            return View(profaktura.ToList());
        }

        // GET: Profakturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profaktura profaktura = db.Profaktura.Find(id);
            if (profaktura == null)
            {
                return HttpNotFound();
            }
            return View(profaktura);
        }

        // GET: Profakturas/Create
        public ActionResult Create()
        {
            ViewBag.RbStavkeProfakture = new SelectList(db.StavkaProfakture, "RbStavkeProfakture", "Opis");
            return View();
        }

        // POST: Profakturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProfakture,RbStavkeProfakture,Datum,Vreme,UkupnaVrednost")] Profaktura profaktura)
        {
            if (ModelState.IsValid)
            {
                db.Profaktura.Add(profaktura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RbStavkeProfakture = new SelectList(db.StavkaProfakture, "RbStavkeProfakture", "Opis", profaktura.RbStavkeProfakture);
            return View(profaktura);
        }

        // GET: Profakturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profaktura profaktura = db.Profaktura.Find(id);
            if (profaktura == null)
            {
                return HttpNotFound();
            }
            ViewBag.RbStavkeProfakture = new SelectList(db.StavkaProfakture, "RbStavkeProfakture", "Opis", profaktura.RbStavkeProfakture);
            return View(profaktura);
        }

        // POST: Profakturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProfakture,RbStavkeProfakture,Datum,Vreme,UkupnaVrednost")] Profaktura profaktura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profaktura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RbStavkeProfakture = new SelectList(db.StavkaProfakture, "RbStavkeProfakture", "Opis", profaktura.RbStavkeProfakture);
            return View(profaktura);
        }

        // GET: Profakturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profaktura profaktura = db.Profaktura.Find(id);
            if (profaktura == null)
            {
                return HttpNotFound();
            }
            return View(profaktura);
        }

        // POST: Profakturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profaktura profaktura = db.Profaktura.Find(id);
            db.Profaktura.Remove(profaktura);
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
