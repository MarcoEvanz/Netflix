using Netflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netflix.Controllers
{
    public class HomeController : Controller
    {
        XemPhimEntities database = new XemPhimEntities();
        public ActionResult TrangChu()
        {
            using (var dbContext = new XemPhimEntities())
            {
                var items = dbContext.Phims.ToList();

                return View(items);
            }
        }
        public ActionResult TimKiem(string searching)
        {
            return View(database.Phims.Where(x => x.TenPhim.Contains(searching) || searching == null).ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ChiTietPhim(int Id)
        {
            var Phim = database.Phims.FirstOrDefault(s => s.IdPhim == Id);
            return View(Phim);
        }
        public ActionResult XemPhim(int Id)
        {
            var Phim = database.Phims.FirstOrDefault(s => s.IdPhim == Id);
            return View(Phim);
        }
    }
}