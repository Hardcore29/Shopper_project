using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class ThankController : Controller
    {
        // GET: Thank
        public ActionResult Index()
        {
            CartShop gh = Session["gioHang"] as CartShop;
            ViewData["Cart"] = gh;
            return View();
        }
    }
}