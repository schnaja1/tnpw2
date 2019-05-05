using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
  
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