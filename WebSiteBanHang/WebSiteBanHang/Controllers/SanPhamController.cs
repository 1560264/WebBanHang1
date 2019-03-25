using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        [ChildActionOnly]
        public ActionResult SanPhamStyle1Partial()
        {

            return PartialView();

        }
        [ChildActionOnly]
        public ActionResult SanPhamStyle2Partial()
        {

            return PartialView();

        }
        public ActionResult XemChiTiet(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == id);
            if (sp == null) return HttpNotFound();

            return View(sp);
        }
        public ActionResult SanPham(int? MaLoaiSP, int MaNSX)
        {
            var lstSP = db.SanPham.Where(n => n.MaLoai == MaLoaiSP && n.MaNSX == MaNSX);
            if (lstSP.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(lstSP);
        }
    }
}