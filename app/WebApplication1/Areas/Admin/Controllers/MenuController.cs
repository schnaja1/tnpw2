using DataAccess.Dao;
using DataAccess.Model;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [AuthorizeRoles(Role.Administrator, Role.Zamestnanec)]
    public class MenuController : Controller
    {
        // GET: Menu
       [ChildActionOnly]
        public ActionResult Index()
        {
            UzivatelDao userDao = new UzivatelDao();
            Uzivatel user = userDao.GetByLogin(User.Identity.Name);
            return View(user);
        }
    }
}