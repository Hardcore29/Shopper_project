using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            ShopperEntities db = new ShopperEntities();
            List<BaiViet> l = db.BaiViets.Where(x => x.daDuyet == true).ToList<BaiViet>();
            ViewData["ltcbv"] = l;
            return View();
        }
    }
}