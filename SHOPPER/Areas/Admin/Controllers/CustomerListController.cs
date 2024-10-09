using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Areas.Admin.Controllers
{
    public class CustomerListController : Controller
    {
        // GET: Admin/CustomerList
        public ActionResult Index()
        {
            ShopperEntities db = new ShopperEntities();
            List<KhachHang> l = db.KhachHangs.ToList<KhachHang>();
            ViewData["kh"] = l;
            return View();
        }
    }
}