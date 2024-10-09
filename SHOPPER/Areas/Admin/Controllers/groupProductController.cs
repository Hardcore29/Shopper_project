using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Areas.Admin.Controllers
{
    public class groupProductController : Controller
    {
        // GET: Admin/groupProduct
        private static bool isUpdate = false;
        [HttpGet]
        public ActionResult Index()
        {
            List<LoaiSP> l = new ShopperEntities().LoaiSPs.ToList<LoaiSP>();
            ViewData["groupProduct"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoaiSP x)
        {
            ShopperEntities db = new ShopperEntities();
            //Add
            if (!isUpdate)
            {
                db.LoaiSPs.Add(x);
            }
            else
            {
                LoaiSP y = db.LoaiSPs.Find(x.maLoai);
                y.maLoai = x.maLoai;
                y.tenLoai = x.tenLoai;
                y.ghiChu = x.ghiChu;
                isUpdate = false;
            }           
            //Save to database
            db.SaveChanges();
            //update View
            if (ModelState.IsValid)
                ModelState.Clear();
            ViewData["groupProduct"] = db.LoaiSPs.ToList<LoaiSP>();
            return View();
        }
        [HttpPost]
        public ActionResult Delete(string mlxoa)
        {
            ShopperEntities db = new ShopperEntities();
            //find loaisp object
            LoaiSP mlx = db.LoaiSPs.Where(x => x.maLoai == mlxoa).First<LoaiSP>();
            //remove
            db.LoaiSPs.Remove(mlx);
            //Save to database
            db.SaveChanges();
            //update View           
            ViewData["groupProduct"] = db.LoaiSPs.ToList<LoaiSP>();
            return View("Index");
        }
        [HttpPost]
        public ActionResult Update(string mlchinhsua)
        {
            ShopperEntities db = new ShopperEntities();
            LoaiSP mls = db.LoaiSPs.Where(x => x.maLoai == mlchinhsua).First<LoaiSP>();
            isUpdate = true;            
            ViewData["groupProduct"] = db.LoaiSPs.ToList<LoaiSP>();
            return View("Index", mls);
        }
    }
}