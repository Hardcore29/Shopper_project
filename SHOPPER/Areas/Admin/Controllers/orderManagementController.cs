using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Areas.Admin.Controllers
{
    public class orderManagementController : Controller
    {
        // GET: Admin/orderManagement
        private static ShopperEntities db = new ShopperEntities();
        private static bool daDuyet;
        public ActionResult Index()
        {
            List<DonHang> l =   db.DonHangs.Where(x => (x.daKichHoat == false) && (x.ghiChu == null)).
                                OrderByDescending(x => x.ngayDat).ToList<DonHang>();
            ViewData["dsdh"] = l;
            return View();
        }
        //Phương thức xoá đơn hàng
        [HttpPost]
        public ActionResult Delete(string dhXoa)
        {
            //Tìm đến bài viết cần xoá
            try
            {
                foreach(CtDonHang i in db.CtDonHangs)
                {
                    if (i.soDH == dhXoa)
                    {
                        db.CtDonHangs.Remove(i);
                    }
                }
            } catch { }
            DonHang x = db.DonHangs.Find(dhXoa);
            //Xoá
            db.DonHangs.Remove(x);
            //cập nhật dữ liệu lại cho database
            db.SaveChanges();
            //Hiển thị dữ liệu trên View           
            return RedirectToAction("DHDaHuy");
        }
        //Phương thức và View cho đơn hàng đã huỷ
        public ActionResult DHDaHuy()
        {
            List<DonHang> l = db.DonHangs.Where(z => (z.daKichHoat == false) && (z.ghiChu == "Đã huỷ")).ToList<DonHang>();
            ViewData["dsdhdh"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult UnActive(string dhKH)
        {
            DonHang x = db.DonHangs.Find(dhKH);
            x.daKichHoat = false;
            x.ghiChu = "Đã huỷ";
            db.SaveChanges();           
            return RedirectToAction("DHDaHuy");
        }
        //Phương thức và View cho đơn hàng đang giao
        public ActionResult Active()
        {           
            List<DonHang> l = db.DonHangs.Where(z => (z.daKichHoat == true) && (z.ghiChu == "Đang giao")).ToList<DonHang>();
            ViewData["dsdhdg"] = l;
            return View();
        }
        [HttpPost]
        public ActionResult ActiveControl(string dhKH)
        {
            DonHang x = db.DonHangs.Find(dhKH);
            x.daKichHoat = true;
            x.ngayGH = DateTime.Now;
            x.ghiChu = "Đang giao";
            db.SaveChanges();
            return RedirectToAction("Active");
        }
        //PHương thức và View cho đơn hàng đã hoàn thành
        public ActionResult finish()
        {
            List<DonHang> l = db.DonHangs.Where(z => (z.daKichHoat == true) && (z.ghiChu == "Hoàn thành")).ToList<DonHang>();
            ViewData["dsdhht"] = l;
            return View();
        }
        public ActionResult finishControl(string dhht)
        {
            DonHang x = db.DonHangs.Find(dhht);
            x.daKichHoat = true;
            x.ghiChu = "Hoàn thành";
            db.SaveChanges();
            return RedirectToAction("finish");
        }
    }
}