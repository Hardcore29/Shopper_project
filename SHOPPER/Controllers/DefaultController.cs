using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        ShopperEntities db = new ShopperEntities();
        public ActionResult Index()
        {
            List<SanPham> l = db.SanPhams.Where(x => (x.daDuyet == true)).OrderByDescending(x => x.ngayDang).Take(8).ToList<SanPham>();
            ViewData["layspmoi"] = l;
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
            return RedirectToAction("Index");
        }       
        
    }
}