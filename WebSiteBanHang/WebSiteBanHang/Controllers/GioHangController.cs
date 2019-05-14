using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHang.Models;
namespace WebSiteBanHang.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanHangEntities db = new QuanLyBanHangEntities();
        //
        // GET: /GioHang/
        public ActionResult XemChiTiet()
        {
            List<itemGioHang> lstGH = LayGioHang();
            return View(lstGH);
        }
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                ViewBag.TongSoLuong = 0;
                ViewBag.TongTien = 0;
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        public List<itemGioHang> LayGioHang()
        {
            List<itemGioHang> lstGioHang = (List<itemGioHang>)Session["GioHang"];
            if (lstGioHang == null)
            {
                lstGioHang = new List<itemGioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }
        public ActionResult ThemGioHang(int MaSP,string strURL)
        {
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<itemGioHang> lstGioHang = LayGioHang();
            itemGioHang spCheck = lstGioHang.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck != null)
            {
                if (sp.SoLuongTon < spCheck.SoLuong)
                {
                    return View("ThongBao");
                }
                spCheck.SoLuong++;
                spCheck.ThanhTien = spCheck.SoLuong * spCheck.DonGia;
                return Redirect(strURL);
            }
            itemGioHang itemGH = new itemGioHang(MaSP);
            if (sp.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            lstGioHang.Add(itemGH);
            return Redirect(strURL);
        }
        public double TongSoLuong()
        {
            List<itemGioHang> lstGH = Session["GioHang"] as List<itemGioHang>;
            if (lstGH == null) return 0;
            return lstGH.Sum(n => n.SoLuong);
        }
        public decimal TongTien()
        {
            List<itemGioHang> lstGH = Session["GioHang"] as List<itemGioHang>;
            if (lstGH == null) return 0;
            return lstGH.Sum(n => n.ThanhTien);
        }
        public ActionResult SuaGioHang(int MaSP)
        {
            if(Session["GioHang"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<itemGioHang> lstGH = LayGioHang();
            itemGioHang spCheck = lstGH.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.GioHang = lstGH;
            return View(spCheck);
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<itemGioHang> lstGH = LayGioHang();
            itemGioHang spCheck = lstGH.SingleOrDefault(n => n.MaSP == MaSP);
            if (spCheck == null)
            {
                return RedirectToAction("Index", "Home");
            }
            lstGH.Remove(spCheck);
            return RedirectToAction("XemChiTiet");
        }

        [HttpPost]
        public ActionResult CapNhatGioHang(itemGioHang itemGH)
        {
            SanPham spCheck = db.SanPham.Single(n => n.MaSP == itemGH.MaSP);
            if (spCheck.SoLuongTon < itemGH.SoLuong)
            {
                return View("ThongBao");
            }
            List<itemGioHang> lstGH = LayGioHang();
            itemGioHang itemGHUD = lstGH.Find(n => n.MaSP == itemGH.MaSP);
            itemGHUD.SoLuong = itemGH.SoLuong;
            itemGHUD.ThanhTien = itemGHUD.SoLuong * itemGHUD.DonGia;
            return RedirectToAction("XemChiTiet");
            
        }

        public ActionResult DatHang(KhachHang kh)
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            KhachHang kh1=new KhachHang();
            if (Session["ThanhVien"] == null)
            {
                kh1 = kh;
                db.KhachHang.Add(kh1);
                
            }
            else
            {
                ThanhVien tv=Session["ThanhVien"] as ThanhVien;
                kh1.TenKH = tv.HoTen;
                kh1.DiaChi = tv.DiaChi;
                kh1.DienThoai = tv.SoDienThoai;
                kh1.Email = tv.Email;
                db.KhachHang.Add(kh1);
            }
            
            DatHang dh = new DatHang();
            dh.MaKH = kh1.MaKH;
            dh.NgayDat = DateTime.Now;
            dh.TinhTrangGiao = false;
            dh.DaThanhToan = false;
            dh.UuDai = 0;
            dh.DaHuy = false;
            db.DatHang.Add(dh);
            
            List<itemGioHang> lstGH = LayGioHang();
            foreach (var item in lstGH)
            {
                ChiTietDatHang ctdh = new ChiTietDatHang();
                ctdh.MaDH = dh.MaDH;
                ctdh.MaSP = item.MaSP;
                ctdh.TenSP = item.TenSP;
                ctdh.SoLuong = item.SoLuong;
                ctdh.DonGia = item.DonGia;
                db.ChiTietDatHang.Add(ctdh);
            }
            db.SaveChanges();
            Session["GioHang"] = null;
            return RedirectToAction("XemChiTiet");
        }
	}
}