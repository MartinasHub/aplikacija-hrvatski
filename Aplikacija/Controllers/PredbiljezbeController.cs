using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using Aplikacija.Models;

namespace Aplikacija.Controllers
{
    [Authorize]
    public class PredbiljezbeController : Controller
    {
        private AlgebraEntities db = new AlgebraEntities();

        // GET: Predbiljezbe
        public ActionResult Index()
        {
            return View(db.Predbiljezbas.ToList());
        }

        [HttpPost]
        public ActionResult Index(string naziv)
        {
            naziv.Trim();
            var predbiljezbas = from s in db.Predbiljezbas
                           select s;

            if (!String.IsNullOrEmpty(naziv))
            {
                predbiljezbas = predbiljezbas.Where(x => x.Status.ToString().Contains(naziv) || x.Status == null);
            }

            return View(predbiljezbas.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Predbiljezba predbiljezba = db.Predbiljezbas.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Predbiljezba predbiljezba = db.Predbiljezbas.Find(id);
            if (predbiljezba == null)
            {
                return HttpNotFound();
            }
            return View(predbiljezba);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Predbiljezba predbiljezba)
        {
            if (ModelState.IsValid)
            {
                db.Entry(predbiljezba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(predbiljezba);
        }


    }
}