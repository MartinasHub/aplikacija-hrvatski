using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aplikacija.Models;

namespace Aplikacija.Controllers
{
    public class PredbiljezbaController : Controller
    {
        public static DataSet ds { get; set; }
        private AlgebraEntities db = new AlgebraEntities();

        // GET: Home
        public ActionResult Index()
        {
            List<Seminar> seminari =
                db.Seminars.Where(s => s.Popunjen == false).OrderBy(s => s.Datum).ToList();
            List<SeminarPredbiljezba> seminarPredbiljezbas = new List<SeminarPredbiljezba>();

            return View(seminari);
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

            return View(seminari.ToList());
        }

        public ActionResult Predbiljezba(int id)
        {
            DohvatiSeminar(id);
            //ViewBag.SeminarId = new SelectList(db.Seminars, "IdSeminar", "Naziv");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Predbiljezba(Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Predbiljezbas.Add(predbiljezba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(predbiljezba);
        }

        public ActionResult DohvatiSeminar(int id)
        {
            ViewBag.Seminar = (
               from s in db.Seminars
               where s.IdSeminar == id
               select s).FirstOrDefault();

            Predbiljezba predbiljezba = new Predbiljezba();
            return View(predbiljezba);
        }
    }
}