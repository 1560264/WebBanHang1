using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;
namespace WebSiteBanHang.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult Index()
        {
            var lstSP1 = db.SanPham.Where(n => n.MaLoai == 1);
            ViewBag.lstSP1 = lstSP1;

            var lstSP2 = db.SanPham.Where(n => n.MaLoai == 2);
            ViewBag.lstSP2 = lstSP2;

            var lstSP3 = db.SanPham.Where(n => n.MaLoai == 3);
            ViewBag.lstSP3 = lstSP3;

            return View();
        }

        public ActionResult MenuPartial()
        {
            var lstSanPham = db.SanPham;
            return PartialView(lstSanPham);
        }

        [HttpPost]
        public ActionResult DangKy2(ThanhVien tv)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(ThanhVien tv)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
	}
}