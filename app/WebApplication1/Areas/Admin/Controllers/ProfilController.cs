using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfilController : Controller
    {
        // GET: Admin/Profil
        public ActionResult Index()
        {
            Uzivatel u = new UzivatelDao().GetByLogin(User.Identity.Name);
            RezervaceDao rd = new RezervaceDao();
            IList<Rezervace> rezervace = rd.GetByUser(u.Id);
            return View(rezervace);
        }

        public ActionResult Edit()
        {
            Uzivatel u = new UzivatelDao().GetByLogin(User.Identity.Name);
            return View(u);
        }

        public ActionResult Update(Uzivatel u)
        {
            UzivatelDao ud = new UzivatelDao();
            AdresaDao ad = new AdresaDao();
            PscDao pd = new PscDao();
            PSC psc = pd.FindPsc(u.adresa.psc.psc);
            if (psc != null)
            {
                u.adresa.psc = psc;
            }
            else
            {
                pd.Create(u.adresa.psc);
            }
            Adresa adresa = ad.FindAdresa(u.adresa.mesto, u.adresa.ulice, u.adresa.cp, u.adresa.psc);
            if (adresa != null)
            {
                u.adresa = adresa;
            }
            else
            {
                ad.Create(u.adresa);
            }
            u.prava = u.prava;
            ud.Update(u);
            return RedirectToAction("Index", "Profil");
        }

    }
}
