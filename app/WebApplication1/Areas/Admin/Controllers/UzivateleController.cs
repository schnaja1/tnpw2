using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Class;

namespace WebApplication1.Areas.Admin.Controllers
{
    [AuthorizeRoles(Role.Administrator, Role.Zamestnanec)]
    public class UzivateleController : Controller
    {
        // GET: Admin/Uzivatele
        public ActionResult Index(int? page)
        {
            int pg;
            int itemsOnPage = 20;
            if (page.HasValue)
            {
                pg = page.Value;
            }
            else
            {
                pg = 1;
            }
              pg = (pg <= 0) ? 1 : pg;
            int totalUsers;
            int totalPages;

            UzivatelDao uzivatelDao = new UzivatelDao();
            IList<Uzivatel> uzivatele = uzivatelDao.GetUsersPaged(itemsOnPage, pg, out totalUsers);
            totalPages = totalUsers / itemsOnPage;
            if (totalPages == 0)
            {
                totalPages = 1;
            }
            if (pg > totalPages)
            {
                pg = totalPages;
                uzivatele = uzivatelDao.GetUsersPaged(itemsOnPage, pg, out totalUsers);
            }

            ViewBag.Pages = (int)Math.Ceiling((double)totalUsers / (double)itemsOnPage);
            ViewBag.CurrentPage = pg;
            if (pg < 3)
            {
                ViewBag.FirstPage = 1;
                ViewBag.LastPage = 5;
            }
            else
            {
                ViewBag.FirstPage = pg - 2;
                ViewBag.LastPage = pg + 2;
            }
            if (ViewBag.LastPage > totalPages)
            {
                ViewBag.LastPage = totalPages;
            }

            return View(uzivatele);
        }

        public JsonResult SearchUzivatel(string query)
        {
            UzivatelDao uzivatelDao = new UzivatelDao();
            IList<Uzivatel> uzivatele = uzivatelDao.SearchByLogin(query);
            List<string> names = (from Uzivatel u in uzivatele select u.login).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string phrase)
        {
            UzivatelDao uzivatelDao = new UzivatelDao();
            IList<Uzivatel> uzivatele = uzivatelDao.SearchByLogin(phrase);

            if (Request.IsAjaxRequest())
            {
                return PartialView("Index", uzivatele);
            }        
            return View("Index", uzivatele);          
        }


        public ActionResult Detail(int? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            Uzivatel u = new UzivatelDao().GetById(id.Value);
            RezervaceDao rd = new RezervaceDao();
            
            ViewBag.Rezervace = rd.GetByUser(u.Id);
            return View(u);
        }

        public ActionResult Rezervuj(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            RezervaceDao rd = new RezervaceDao();
            Rezervace r = rd.GetById(id.Value);

            MailClient.sendMail(r.uzivatel.login, "Potvrzení rezervace zájezdu", "Vážený zákazníku, vaše rezervace byla úspěšně evidována jako zaplacená.");
            string deti = ".";
            if (r.pocetDeti > 0)
            {
                deti = "a pro" + r.pocetDeti + " dětí.";
            }
            MailClient.sendMail(r.zajezd.hotel.email, "Rezervace zájezdu", "Na váš hotel"+r.zajezd.hotel.nazev+" byla vytvořena rezervace pro"+r.pocetDospelych+" dospělých osob"+deti);


            r.zaplaceno = true;
            rd.Update(r);

            return RedirectToAction("Detail", "Uzivatele", new { id = r.uzivatel.Id });
        }

        [AuthorizeRoles(Role.Administrator)]
        public ActionResult Smaz(int? id)
        {

            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            RezervaceDao rd = new RezervaceDao();
            Rezervace r = rd.GetById(id.Value);
            Zajezd z = r.zajezd;


            MailClient.sendMail(r.uzivatel.login, "Zrušení rezervace zájezdu", "Vážený zákazníku, vaše rezervace byla zrušena.");

            int pocet = r.pocetDeti + r.pocetDospelych;
            z.kapacita = z.kapacita + pocet;
            rd.Update(r);
            rd.Delete(r);

            return RedirectToAction("Detail","Uzivatele",new {id = r.uzivatel.Id });
        }

        [AuthorizeRoles(Role.Administrator)]
        public ActionResult Autorizuj(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            UzivatelDao uzivatelDao = new UzivatelDao();
            Uzivatel u = uzivatelDao.GetById(id.Value);
            UzivatelskaPrava prava = new UzivatelskaPravaDao().FindPrava(2);
            u.prava = prava;
            uzivatelDao.Update(u);
            return RedirectToAction("Index");
        }

    }
}