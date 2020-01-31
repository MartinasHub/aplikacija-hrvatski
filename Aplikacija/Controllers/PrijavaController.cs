using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplikacija.Models;
using System.Web.Security;
namespace Aplikacija.Controllers
{
    public class PrijavaController : Controller
    {
        [HttpGet]
    public ActionResult Prijava()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Prijava(ZaposleniciPrijava prijava, string returnUrl)
    {
            if (ModelState.IsValid)
            {


                using (AlgebraEntities db = new AlgebraEntities())
                {
                    var zaposlenik = db.Zaposleniks.Where(
                       x => x.KorisnickoIme.Equals(prijava.KorisnickoIme) &&
                       x.Password.Equals(prijava.Password)).FirstOrDefault();
                    if (zaposlenik != null)
                    {
                        Session["IdZaposlenik"] = zaposlenik.IdZaposlenik.ToString();
                        Session["KorisnickoIme"] = zaposlenik.KorisnickoIme.ToString();
                        if (zaposlenik.RememberMe == false)
                        {
                            FormsAuthentication.SetAuthCookie(prijava.KorisnickoIme, true);
                        }
                        if (zaposlenik.RememberMe == true)
                        {
                            FormsAuthentication.SetAuthCookie(prijava.KorisnickoIme, false);
                        }
                        return RedirectToAction("Index", "Predbiljezbe");
                    }
                    else
                    {
                        ViewBag.Poruka = "Unijeli ste netočne podatke";
                    }
                }
            }

            return View(prijava);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Odjava()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Predbiljezba");
        }
    }
}