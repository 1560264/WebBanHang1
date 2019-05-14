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
            db.ThanhVien.Add(tv);
            db.SaveChanges();
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            return View();
        }

        [HttpGet]
        public ActionResult DangKy2()
        {
            ViewBag.CauHoi  = new SelectList(LoadCauHoi());
            return View();
        }
        public List<string> LoadCauHoi()
        {
            List<string> lstCH = new List<string>();
            lstCH.Add("Trường tiểu học đầu tiên?");
            lstCH.Add("Món ăn ưa thích?");
            lstCH.Add("Thức uống ưa thích?");
            lstCH.Add("Ngày ưa thích trong năm?");
            return lstCH;
        }
        [HttpPost]
        public ActionResult DangKy3(ThanhVien tv)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy3()
        {
            return View();
        }
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTenDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            ThanhVien tv = new ThanhVien();
            tv = db.ThanhVien.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (tv != null)
            {
                
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index");
                //return Content("<script>window.location.reload();</script>");
            }
            return Content("Tên đăng nhập hoặc mật khẩu không hợp lệ");
        }
        
        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
	}
}