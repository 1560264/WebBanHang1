using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteBanHang.Models
{
    public class itemGioHang
    {
        public string TenSP { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string HinhAnh { get; set; }
        public itemGioHang(int iMaSP,int sl)
        {
            using (QuanLyBanHangEntities db = new QuanLyBanHangEntities())
            {
                SanPham sp = db.SanPham.Single(n => n.MaSP == iMaSP);
                this.MaSP = iMaSP;
                this.TenSP = sp.TenSP;
                this.DonGia = sp.DonGia.Value;
                this.HinhAnh = sp.HinhAnh;
                this.SoLuong = sl;
                this.ThanhTien = this.DonGia * this.SoLuong;
            }
        }
        public itemGioHang(int iMaSP)
        {
            using (QuanLyBanHangEntities db = new QuanLyBanHangEntities())
            {
                SanPham sp = db.SanPham.Single(n => n.MaSP == iMaSP);
                this.MaSP = iMaSP;
                this.TenSP = sp.TenSP;
                this.DonGia = sp.DonGia.Value;
                this.HinhAnh = sp.HinhAnh;
                this.SoLuong = 1;
                this.ThanhTien = this.DonGia * this.SoLuong;
            }
        }
        public itemGioHang()
        {

        }
    }
}