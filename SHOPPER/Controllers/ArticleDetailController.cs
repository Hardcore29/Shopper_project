using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class ArticleDetailController : Controller
    {
        // GET: ArticleDetail
        public ActionResult Index(string mabaiviet)
        {
            ShopperEntities db = new ShopperEntities();
            BaiViet bv = db.BaiViets.Where(x => x.maBV == mabaiviet).First<BaiViet>();
            ViewBag.ctbv = bv;
            return View();
        }
    }
}