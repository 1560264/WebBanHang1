﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebSiteBanHang.Models
{
    [MetadataTypeAttribute(typeof(ThanhVienMetadata))]
    public partial class ThanhVien
    {
        internal sealed class ThanhVienMetadata
        {
            public int MaTV { get; set; }
            [DisplayName("Tài\tkhoản")]
            public string TaiKhoan { get; set; }
            public string MatKhau { get; set; }
            public string HoTen { get; set; }
            public string DiaChi { get; set; }
            public string Email { get; set; }
            public string SoDienThoai { get; set; }
            public string CauHoi { get; set; }
            public string CauTraLoi { get; set; }
            public Nullable<int> MaLTV { get; set; }
        }
    }
}