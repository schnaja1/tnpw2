using DataAccess.Dao;
using DataAccess.Model;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Class;

namespace WebApplication1.Controllers
{
    
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prihlaseni(string login, string password)
        {
            UzivatelDao uzivatelDao = new UzivatelDao();
            Uzivatel u = uzivatelDao.GetByLogin(login);
            if ( u != null)            
            {
                if (Membership.ValidateUser(login, PasswordHasher.hashPassword(password)))
                {
                    TempData["x"] = "Úspěšně přihlášen";
                    FormsAuthentication.SetAuthCookie(login, false);
                    if (u.prava.nazev == "Zakaznik")
                    {
                        return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    if (u.prava.nazev == "Administrator" || u.prava.nazev == "Zamestnanec")
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                     return RedirectToAction("Index", "Login");               
                }
                    TempData["error"] = "Špatně zadané heslo";
                    return RedirectToAction("Index", "Login");
            }

            TempData["error"] = "uživatel nenalezen";
            return RedirectToAction("Index", "Login");
        }            

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }

    }
}