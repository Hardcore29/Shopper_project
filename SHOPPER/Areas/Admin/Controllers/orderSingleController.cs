using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Areas.Admin.Controllers
{
    public class orderSingleController : Controller
    {
        // GET: Admin/orderSingle
        public ActionResult Index(string madh)
        {
            ShopperEntities db = new ShopperEntities();
            List<CtDonHang> a = db.CtDonHangs.Where(x => x.soDH == madh).ToList<CtDonHang>();
            ViewData["ctdh"] = a;
            DonHang b = db.DonHangs.Find(madh);
            ViewData["ttdh"] = b; 
            return View();
        }
    }
}