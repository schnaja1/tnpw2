using DataAccess.Model;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    [AuthorizeRoles(Role.Administrator, Role.Zamestnanec)]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}