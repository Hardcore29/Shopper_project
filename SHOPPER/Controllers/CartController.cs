using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
       
        public ActionResult Index()
        {
            CartShop gh = Session["gioHang"] as CartShop;
            ViewData["Cart"] = gh;
            return View();
        }
        [HttpPost]
        public ActionResult Giam(string maspGiam)
        {
            CartShop gh = Session["gioHang"] as CartShop;
            gh.decrease(maspGiam);
            Session["gioHang"] = gh;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Tang(string maspTang)
        {
            CartShop gh = Session["gioHang"] as CartShop;
            gh.addItem(maspTang);
            Session["gioHang"] = gh;
            return RedirectToAction("Index");
        }        
        [HttpPost]
        public ActionResult RemoveItem(string maspRe)
        {
            CartShop gh = Session["gioHang"] as CartShop;
            gh.deleteItem(maspRe);
            Session["gioHang"] = gh;
            return RedirectToAction("Index");
        }
    }
}