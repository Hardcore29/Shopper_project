using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class ProductSingleController : Controller
    {
        // GET: ProductSingle
        [HttpGet]
        public ActionResult Index(string masanpham)
        {
            ShopperEntities db = new ShopperEntities();
            SanPham sp = db.SanPhams.Where(x => (x.maSP.Equals(masanpham))).First<SanPham>();
            ViewBag.ctsp = sp;
            spMoi();
            return View();
        }
        [HttpPost]
        public ActionResult addToCart(string maspCart)
        {
            //Lấy giỏ hàng từ session
            CartShop gh = Session["gioHang"] as CartShop;
            //Thêm vào giỏ hàng
            gh.addItem(maspCart);
            //cập nhật lại giỏ hàng
            Session["gioHang"] = gh;
            return RedirectToAction("Index", new { masanpham = maspCart});
        }
        public void spMoi()
        {
            ShopperEntities db = new ShopperEntities();
            List<SanPham> l = db.SanPhams.Where(x => (x.daDuyet == true)).OrderByDescending(x => x.ngayDang).Take(8).ToList<SanPham>();
            ViewData["spmoi"] = l;
        }
    }
}