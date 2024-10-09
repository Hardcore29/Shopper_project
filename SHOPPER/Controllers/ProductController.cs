using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ShopperEntities db = new ShopperEntities();
        List<SanPham> sp = new List<SanPham>();
        private static string ml;
        [HttpGet]
        public ActionResult Index(string maloai, string s)
        {            
            ml = maloai;
            DemSPSale();
            if (maloai != null)
            {
                //sp = db.SanPhams.Where(x => (x.daDuyet == true) && (x.maLoai.Equals(maloai))).ToList();
                //ViewBag.spTheoLoai = sp;
                if (s == "0")
                {
                    sp = db.SanPhams.Where(x => (x.daDuyet == true) && (x.maLoai.Equals(maloai))).OrderByDescending(z => z.giaBan).ToList();
                    ViewBag.spTheoLoai = sp;
                }
                else if (s == "1")
                {
                    sp = db.SanPhams.Where(x => (x.daDuyet == true) && (x.maLoai.Equals(maloai))).OrderBy(z => z.giaBan).ToList();
                    ViewBag.spTheoLoai = sp;
                }
                else if (s == null)
                {
                    sp = db.SanPhams.Where(x => (x.daDuyet == true) && (x.maLoai.Equals(maloai))).ToList();
                    ViewBag.spTheoLoai = sp;
                }
            }
            else
            {
                //sp = db.SanPhams.Where(x => (x.daDuyet == true)).ToList();
                //ViewBag.spTheoLoai = sp;
                if (s == "0")
                {
                    sp = db.SanPhams.Where(x => (x.daDuyet == true)).OrderByDescending(z => z.giaBan).ToList();
                    ViewBag.spTheoLoai = sp;
                }
                else if (s == "1")
                {
                    sp = db.SanPhams.Where(x => (x.daDuyet == true)).OrderBy(z => z.giaBan).ToList();
                    ViewBag.spTheoLoai = sp;
                }
                else if (s == null)
                {
                    sp = db.SanPhams.Where(x => (x.daDuyet == true)).ToList();
                    ViewBag.spTheoLoai = sp;
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult SapXep(string sx)
        {           
            return RedirectToAction("Index", new {maloai = ml, s = sx });
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
        //Phương thức tìm kiếm sản phẩm
        [HttpPost]
        public ActionResult Search(string text)
        {
            ShopperEntities db = new ShopperEntities();
            if (!String.IsNullOrEmpty(text))
            {
                List<SanPham> l = db.SanPhams.Where(x => (x.tenSP.Contains(text)) && (x.daDuyet == true)).ToList<SanPham>();
                ViewData["dstimkiem"] = l;
            }
            DemSPSale();
            return View();
        }
        //Phương thức xem sản phẩm đang giảm giá
        [HttpGet]
        public ActionResult OnSale()
        {
            ShopperEntities db = new ShopperEntities();
            List<SanPham> l = db.SanPhams.Where(x => (x.daDuyet == true) && (x.giamGia > 0)).ToList<SanPham>();
            ViewData["dssale"] = l;
            DemSPSale();
            return View();
        }
        private void DemSPSale()
        {
            ShopperEntities db = new ShopperEntities();
            List<SanPham> l = db.SanPhams.Where(x => (x.daDuyet == true) && (x.giamGia > 0)).ToList<SanPham>();
            ViewData["demspsale"] = l.Count();
        }
    }
}