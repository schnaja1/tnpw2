using DataAccess.Dao;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using WebApplication1.Class;
using System.Drawing.Imaging;

namespace WebApplication1.Areas.Admin.Controllers
{
    [AuthorizeRoles(Role.Administrator)]
    public class HotelController : Controller
    {
        // GET: Admin/Hotel
       
        public ActionResult Add()
        {
            ViewBag.Stravovani = new ZpusobStravovaniDao().GetAll();
            return View();
        }

        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files, Hotel hotel, int stravovani)
        {
            HotelDao hd = new HotelDao();
            StatDao sd = new StatDao();
            Stat s = sd.FindStat(hotel.destinace.stat.jmeno);
            if (s == null)
            {
                sd.Create(hotel.destinace.stat);
            }
            else
            {
                hotel.destinace.stat = s;
            }
            DestinaceDao dd = new DestinaceDao();
            Destinace d = dd.FindDestinace(hotel.destinace.nazev);
            if (d == null)
            {

                dd.Create(hotel.destinace);
            }
            else
            {
                hotel.destinace = d;
            }

            ZpusobStravovani st = new ZpusobStravovaniDao().GetById(stravovani);
            hotel.stravovani = st;
            hd.Create(hotel);
            FotografieDao fd = new FotografieDao();
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    Fotografie f = new Fotografie();

                    Stream str = file.InputStream;

                    Image image = Image.FromStream(file.InputStream);
                    Image smallImage = ImageHelper.ScaleImage(Image.FromStream(str), 300, 200);

                    Bitmap b = new Bitmap(image);
                    Bitmap sb = new Bitmap(smallImage);
                    Guid guid = Guid.NewGuid();
                    string imageName = guid.ToString() + ".png";
                   
                    b.Save(Server.MapPath("~/Images/hotely/" + imageName), ImageFormat.Jpeg);
                    sb.Save(Server.MapPath("~/Images/hotely/nahled/" + imageName), ImageFormat.Jpeg);
                    smallImage.Dispose();
                    b.Dispose();

                    f.fotografie = "~/Images/hotely/" + imageName;
                    f.nahled = "~/Images/hotely/nahled/" + imageName;
                    f.hotel = hotel;
                    f.popisek = hotel.nazev;
                    fd.Create(f);
                }

                    TempData["x"] = "Hotel úspěšně přidán";               
            }
            IList<Uzivatel> odberatele = new UzivatelDao().GetUsersWithNews();
            foreach (Uzivatel u in odberatele) {
                MailClient.sendMail(u.login,"Nový hotel","V naši nabídce se objevil nový hotel: "+hotel.nazev+" nacházející se v "+hotel.destinace.stat.jmeno+" - "+hotel.destinace.nazev+" více na www.eurotravel.cz");
            }
            return RedirectToAction("Index", "Zajezdy");
        }

        [HttpPost]
        public ActionResult UpdateHotel(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Zajezdy");
            }

            HotelDao hotelDao = new HotelDao();
            Hotel hotel = hotelDao.GetById(id.Value);
            ZpusobStravovaniDao zsDao = new ZpusobStravovaniDao();
            ViewBag.Stravovani = zsDao.GetAll();
            return View(hotel);
        }

        public ActionResult UpdateInDB(IEnumerable<HttpPostedFileBase> files, Hotel hotel, int stravovani)
        {
            HotelDao hd = new HotelDao();
            StatDao sd = new StatDao();
            Stat s = sd.FindStat(hotel.destinace.stat.jmeno);
            if (s == null)
            {
                sd.Create(hotel.destinace.stat);
            }
            else
            {
                hotel.destinace.stat = s;
            }

            DestinaceDao dd = new DestinaceDao();
            Destinace d = dd.FindDestinace(hotel.destinace.nazev);
            if (d == null)
            {

                dd.Create(hotel.destinace);
            }
            else
            {
                hotel.destinace = d;
            }

            ZpusobStravovani st = new ZpusobStravovaniDao().GetById(stravovani);
            hotel.stravovani = st;
            
            FotografieDao fd = new FotografieDao();
            hotel.fotky = fd.GetPhotosByHotelId(hotel.Id);
            hd.Update(hotel);

            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    Fotografie f = new Fotografie();

                    Stream str = file.InputStream;

                    Image image = Image.FromStream(file.InputStream);
                    Image smallImage = ImageHelper.ScaleImage(Image.FromStream(str), 300, 200);

                    Bitmap b = new Bitmap(image);
                    Bitmap sb = new Bitmap(smallImage);
                    Guid guid = Guid.NewGuid();
                    string imageName = guid.ToString() + ".png";

                    b.Save(Server.MapPath("~/Images/hotely/" + imageName), ImageFormat.Jpeg);
                    sb.Save(Server.MapPath("~/Images/hotely/nahled/" + imageName), ImageFormat.Jpeg);
                    smallImage.Dispose();
                    b.Dispose();

                    f.fotografie = "~/Images/hotely/" + imageName;
                    f.nahled = "~/Images/hotely/nahled/" + imageName;
                    f.hotel = hotel;
                    f.popisek = hotel.nazev;
                    fd.Create(f);
                }
               
            }
           
            return RedirectToAction("Index", "Zajezdy");
        }
        public ActionResult Delete(int? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("Index", "Zajezdy");
            }

            HotelDao hd = new HotelDao();
            Hotel h = hd.GetById(id.Value);
            ZajezdDao zd = new ZajezdDao();
            RezervaceDao rd = new RezervaceDao();
            IList<Zajezd> z = zd.GetByHotel(h.Id);
            if (z.Count() > 0)
            {
                foreach (Zajezd r in z)
                {
                    IList<Rezervace> rezervace = rd.GetByZajezd(r.Id);
                    if (rezervace.Count() > 0)
                    {
                        foreach (Rezervace rez in rezervace)
                        {
                            rd.Delete(rez);
                        }
                    }
                    zd.Delete(r);
                }
            }
            if(h.fotky.Count > 0)
            {
                FotografieDao fd = new FotografieDao();
                foreach(Fotografie f in h.fotky)
                {
                    System.IO.File.Delete(Server.MapPath(f.fotografie));
                    System.IO.File.Delete(Server.MapPath(f.nahled));
                    fd.Delete(f);
                }
            }

            hd.Delete(h);


            TempData["x"] = "Hotel úspěšně smazán";
            
 
            return RedirectToAction("Index","Zajezdy");
        }
    }
}