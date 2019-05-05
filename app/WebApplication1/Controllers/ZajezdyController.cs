using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Class;

namespace WebApplication1.Controllers
{
    public class ZajezdyController : Controller
    {
        // GET: Zajezdy
        public ActionResult Index(int? page, int? view, DateTime? datumOd, DateTime? datumDo)
        {
            int totalPages;
            int totalHotels;
            int pg = 1;
            int itemsOnPage = 5;
            IList<Hotel> hotels;

            if (page.HasValue) {
                pg = page.Value;
            } 
            pg = (pg<=0) ? 1 : pg;
            
            totalHotels = GetHotelCount(view, datumOd, datumDo);
            totalPages = totalHotels / itemsOnPage;

            if (totalPages == 0)
            {
                totalPages = 1;
            }
            if (pg > totalPages)
            {
                pg = totalPages;              
            }

            hotels = GetHotels(itemsOnPage, pg, view, datumOd, datumDo);

            ViewBag.Pages = (int)Math.Ceiling((double)totalHotels / (double)itemsOnPage);

            if (view.HasValue)
                ViewBag.ViewMode = view.Value;
            if (datumOd.HasValue)
                ViewBag.DatumOd = datumOd.Value;
            if (datumDo.HasValue)
                ViewBag.DatumDo = datumDo.Value;

            ViewBag.CurrentPage = pg;

            if (pg < 3)
            {
                ViewBag.FirstPage = 1;
                ViewBag.LastPage = 5;
            }
            else
            {
                ViewBag.FirstPage = pg-2;
                ViewBag.LastPage = pg + 2;
            }

            if (ViewBag.LastPage > totalPages) {
                ViewBag.LastPage = totalPages;
            }

            ViewBag.Staty = new StatDao().GetAll();
            ZajezdDao zajezdDao = new ZajezdDao();

            foreach (Hotel hotel in hotels)
            {
                hotel.nejlevnejsiZajezd = zajezdDao.GetNejlevnejsiZajezd(hotel.Id);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView(hotels);
            }

            return View(hotels);
        }

        public ActionResult Destinace(int id)
        {
            if (id == 0)
                return View("Index", new HotelDao().GetAll());
            IList<Hotel> hotels = new HotelDao().GetHotelsInDestination(id);
            ViewBag.Destinace = new DestinaceDao().GetDestinationByState(id);
            ViewBag.Staty = new StatDao().GetAll();
            ZajezdDao zajezdDao = new ZajezdDao();
            foreach (Hotel hotel in hotels)
            {
                hotel.nejlevnejsiZajezd = zajezdDao.GetNejlevnejsiZajezd(hotel.Id);
            }
            return View("Index", hotels);
        }

        public ActionResult Stat(int id)
        {
            if (id == 0)
                return View("Index", new HotelDao().GetAll());
            IList<Hotel> hotels = new HotelDao().GetHotelsInState(id);        
            ViewBag.Staty = new StatDao().GetAll();
            ViewBag.Destinace = new DestinaceDao().GetDestinationByState(id);
            ZajezdDao zajezdDao = new ZajezdDao();
            foreach (Hotel hotel in hotels)
            {
                hotel.nejlevnejsiZajezd = zajezdDao.GetNejlevnejsiZajezd(hotel.Id);
            }
            return View("Index", hotels);       
        }

        public ActionResult Detail(int ?id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            HotelDao bookDao = new HotelDao();
            Hotel h = bookDao.GetById(id.Value);
            if(h.fotky == null)
            {
                FotografieDao fotografieDao = new FotografieDao();
                h.fotky = fotografieDao.GetPhotosByHotelId(h.Id);
            }
            return View(h);
        }

        public JsonResult SearchHotels(string query)
        {
            HotelDao hd = new HotelDao();
            IList<Hotel> hotels = hd.searchHotel(query);
            List<string> names = (from Hotel b in hotels select b.nazev).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string phrase)
        {
            
            HotelDao hd = new HotelDao();
            IList<Hotel> hotels = hd.searchHotel(phrase);
            ZajezdDao zajezdDao = new ZajezdDao();
            foreach (Hotel hotel in hotels)
            {
                hotel.nejlevnejsiZajezd = zajezdDao.GetNejlevnejsiZajezd(hotel.Id);
            }
            if (Request.IsAjaxRequest())
            {
                return PartialView("Index", hotels);
            }
            return View("Index", hotels);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rezervace(int? z)
        {
            if (!z.HasValue)
                return RedirectToAction("Index");
            ZajezdDao zd = new ZajezdDao();
            Zajezd zajzed = zd.GetById(z.Value);
            Rezervace r = new Rezervace();
            r.zajezd = zajzed; 
            return View(r);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rezervovat(Rezervace r, int? zi)
        {
            if (!zi.HasValue)
                return RedirectToAction("Index");
            ZajezdDao zj = new ZajezdDao();
            Zajezd z = zj.GetById(zi.Value);
            r.zajezd = z;
            RezervaceDao rd = new RezervaceDao();
            int pocet = r.pocetDeti + r.pocetDeti;
            if (pocet > r.zajezd.kapacita) {
                TempData["Rezervace"] = "Omlouváme se, ale nepodařilo se vytvořit rezervaci z důvodu nedostatečné kapacity";
                return RedirectToAction("Detail", "Zajezdy",z.hotel.Id);
            }
            UzivatelDao ud = new UzivatelDao();
            Uzivatel uzivatel = ud.GetByLogin(User.Identity.Name);
            int kap = r.zajezd.kapacita - pocet;
            z.kapacita = kap;
            r.uzivatel = uzivatel;
            rd.Create(r);
            zj.Update(r.zajezd);
            IList<Uzivatel> uzivatele = new UzivatelDao().GetUsersNotInRole(new UzivatelskaPravaDao().GetById(2));
            
            foreach (Uzivatel u in uzivatele)
            {
                MailClient.sendMail(u.login, "Vytvořená nová rezervace", "Vážený zaměstnanče, byla vytvořena nová rezervace od uživatele" + r.uzivatel.jmeno + " " + r.uzivatel.prijmeni + ".");
            }

            TempData["Rezervace"] = "Rezervace proběhla úspěšně";
            return RedirectToAction("Index", "Zajezdy");
        }

        private int GetHotelCount(int? view, DateTime? datumOd, DateTime? datumDo)
        {
            if (view == 1)
            {
                return GetCountWithZajezdDao(datumOd, datumDo);
            }
            return GetCountWithHotelDao(datumOd, datumDo);
        }

        private int GetCountWithHotelDao(DateTime? datumOd, DateTime? datumDo)
        {
            HotelDao hotelDao = new HotelDao();
            if (datumOd.HasValue && datumDo.HasValue)
            {
                return hotelDao.GetCountWithDateFromAndTo(datumOd.Value, datumDo.Value);
            }
            if (datumOd.HasValue)
            {
                return hotelDao.GetCountWithDateFrom(datumOd.Value);
            }
            if (datumDo.HasValue)
            {
                return hotelDao.GetCountWithDateTo(datumDo.Value);
            }
            return hotelDao.GetCountOfAllHotels();
        }

        private int GetCountWithZajezdDao(DateTime? datumOd, DateTime? datumDo)
        {
            ZajezdDao zd = new ZajezdDao();
            if (datumOd.HasValue && datumDo.HasValue)
            {
                return zd.GetCountWithDateFromAndTo(datumOd.Value, datumDo.Value);
            }
            if (datumOd.HasValue)
            {
                return zd.GetCountWithDateFrom(datumOd.Value);
            }
            if (datumDo.HasValue)
            {
                return zd.GetCountWithDateTo(datumDo.Value);
            }
            return zd.GetCountOfAllHotels();
        }

        private IList<Hotel> GetHotelsWithZajezdDao(int itemsOnPage, int pg, DateTime? datumOd, DateTime? datumDo)
        {
            ZajezdDao zd = new ZajezdDao();
            if (datumOd.HasValue && datumDo.HasValue)
            {
                return zd.GetZajezdyWithDateFromAndTo(itemsOnPage, pg, datumOd.Value, datumDo.Value);
            }
            if (datumOd.HasValue)
            {
                return zd.GetZajezdyWithDateFrom(itemsOnPage, pg, datumOd.Value);
            }
            if (datumDo.HasValue)
            {
                return zd.GetZajezdyWithDateTo(itemsOnPage, pg, datumDo.Value);
            }
            return zd.GetHotelsIdPaged(itemsOnPage, pg);
        }

        private IList<Hotel> GetHotelsWithHotelDao(int itemsOnPage, int pg, DateTime? datumOd, DateTime? datumDo)
        {
            HotelDao hotelDao = new HotelDao();
            if (datumOd.HasValue && datumDo.HasValue)
            {
                return hotelDao.GetZajezdyWithDateFromAndTo(itemsOnPage, pg, datumOd.Value, datumDo.Value);
            }
            if (datumOd.HasValue)
            {
                return hotelDao.GetZajezdyWithDateFrom(itemsOnPage, pg, datumOd.Value);
            }
            if (datumDo.HasValue)
            {
                return hotelDao.GetZajezdyWithDateTo(itemsOnPage, pg, datumDo.Value);
            }
            return hotelDao.GetHotelsPaged(itemsOnPage, pg);
        }

        private IList<Hotel> GetHotels(int itemsOnPage, int pg, int? view, DateTime? datumOd, DateTime? datumDo)
        {
            if (view == 1)
            {
                return GetHotelsWithZajezdDao(itemsOnPage, pg, datumOd, datumDo);
            }
            return GetHotelsWithHotelDao(itemsOnPage, pg, datumOd, datumDo);
        }
    }
}