using Netflix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Netflix.Controllers
{
    public class AdminController : Controller
    {
        XemPhimEntities database = new XemPhimEntities();
        // GET: Admin
        public ActionResult QuanLyPhim()
        {
            using (var dbContext = new XemPhimEntities())
            {
                var items = dbContext.Phims.ToList();

                return View(items);
            }
        }

        public ActionResult AddPhim(Phim phim)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrEmpty(phim.TenPhim))
                    ModelState.AddModelError(String.Empty, "Tên Phim không được để trống");
                if (String.IsNullOrEmpty(phim.URLPhim))
                    ModelState.AddModelError(String.Empty, "Url không được để trống");
                if (String.IsNullOrEmpty(phim.HinhMinhHoa))
                    ModelState.AddModelError(String.Empty, "Hình minh họa không được để trống");
                if (String.IsNullOrEmpty(phim.ThoiLuong))
                    ModelState.AddModelError(String.Empty, "Thời Lượng không được để trống");

                if (ModelState.IsValid)
                {
                    database.Phims.Add(phim);
                    database.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("QuanLyPhim");
        }
        public ActionResult SuaPhim(int Id)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phims.Where(i =>i.IdPhim == Id).FirstOrDefault();

            database.Dispose();
            return View(e);
        }
        public ActionResult LuuPhim(Phim s)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phims.Where(i => i.IdPhim == s.IdPhim).FirstOrDefault();
            e.TieuDe = s.TieuDe;
            e.ChiTietPhim = s.ChiTietPhim;
            e.TenPhim = s.TenPhim;
            e.URLPhim = s.URLPhim;
            e.NamSanXuat = s.NamSanXuat;
            e.ChiTietPhim = s.ChiTietPhim;
            e.DaoDien = s.DaoDien;
            e.DienVien = s.DienVien;
            e.HinhMinhHoa = s.HinhMinhHoa;
            e.TheLoai = s.TheLoai;
            database.SaveChanges();
            database.Dispose();
            return Redirect("QuanLyPhim");
        }
        public ActionResult XoaPhim(int Id)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phims.Where(i => i.IdPhim == Id).FirstOrDefault();

            database.Dispose();
            return View(e);
        }
        public ActionResult XacNhanXoaPhim(Phim s)
        {
            XemPhimEntities database = new XemPhimEntities();
            Phim e = database.Phims.Where(i => i.IdPhim == s.IdPhim).FirstOrDefault();

            database.Phims.Remove(e);
            database.SaveChanges();
            database.Dispose();
            return Redirect("QuanLyPhim");
        }
    }
}