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
            
            return View();
        }
        public ActionResult MenuPartial()
        {
            var lstSanPham = db.SanPham;
            return PartialView(lstSanPham);
        }
	}
}