using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Aplikacija.Models;

namespace Aplikacija.Controllers
{
    [Authorize]

    public class SeminariController : Controller
    {
        private AlgebraEntities db = new AlgebraEntities();
        // GET: Seminari
        public ActionResult Index()
        {
            BrojPolaznika();
            List<Seminar> sem = db.Seminars.ToList();
            foreach (var item in sem)
{
                item.BrojPolaznika = (
                           from s in db.Predbiljezbas
                           where s.IdSeminar == item.IdSeminar
                           select s.IdSeminar).Count();
            }
            return View(sem);
        }

        [HttpPost]
        public ActionResult Index(string naziv)
        {
            naziv.Trim();
            var seminari = from s in db.Seminars
                           select s;

            if (!String.IsNullOrEmpty(naziv))
            {
                seminari = seminari.Where(x => x.Naziv.Contains(naziv) && x.Popunjen == false);
            }
            BrojPolaznika();
            return View(seminari.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeminar,Naziv,Opis,Datum,Popunjen")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Seminars.Add(seminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seminar);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Seminar seminar = db.Seminars.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeminar,Naziv,Opis,Datum,Popunjen")] Seminar seminar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seminar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seminar);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seminar seminar = db.Seminars.Find(id);
            if (seminar == null)
            {
                return HttpNotFound();
            }
            return View(seminar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seminar seminar = db.Seminars.Find(id);
            db.Seminars.Remove(seminar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public void BrojPolaznika()
        {
            ViewBag.BrojPolaznika = db.Predbiljezbas.Count();
            //return View();
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