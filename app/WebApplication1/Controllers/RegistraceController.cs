using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Class;

namespace WebApplication1.Controllers
{
    
    public class RegistraceController : Controller
    {
        // GET: Registrace
        public ActionResult Index()
        {
            return View();
        }
      
        [HttpPost]
        public ActionResult RegistrovatUzivatele(Uzivatel uzivatel)
        {
            UzivatelDao uzivatelD = new UzivatelDao();

            uzivatelD.Insert(PasswordHasher.hashPassword(uzivatel.heslo), uzivatel.jmeno, uzivatel.prijmeni, uzivatel.login, 3, uzivatel.novinky, uzivatel.telefon, uzivatel.adresa.psc.psc, uzivatel.adresa.cp, uzivatel.adresa.mesto, uzivatel.adresa.ulice);

            Uzivatel u = uzivatelD.GetByLogin(uzivatel.login);
            if (u != null)
            {
                TempData["x"] = "Uživatel úspěšně zaregistrován";
            }else
            {
                TempData["x"] = "Registrace se nepodařila";
            }
            
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public JsonResult doesUserNameExist(string login)
        {
            UzivatelDao ud = new UzivatelDao();
            login.Trim();
            Uzivatel user = ud.GetByLogin(login);
            return Json(user == null);
        }
    }
}