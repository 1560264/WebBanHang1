using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;
namespace WebSiteBanHang.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        public ActionResult SanPham1()
        {
            var lstSanPham = db.SanPham;
            ViewBag.lstSanPham1 = lstSanPham;
            return View();
        }
        public ActionResult SanPham2()
        {
            var lstSanPham = db.SanPham.Where(n => n.MaLoai == 2);
            ViewBag.lstSanPham2 = lstSanPham;
            return View();
        }
        public ActionResult SanPhamPartial()
        {
            //var lstSanPham = db.SanPham.Where(n => n.MaLoai == 1);
            return PartialView();
        }
	}
}