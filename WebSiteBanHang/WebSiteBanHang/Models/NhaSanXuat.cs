//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebSiteBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            this.SanPham = new HashSet<SanPham>();
        }
    
        public int MaNSX { get; set; }
        public string TenNSX { get; set; }
        public string ThongTin { get; set; }
        public string Logo { get; set; }
    
        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
