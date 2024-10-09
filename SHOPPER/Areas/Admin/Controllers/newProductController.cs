using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
using SHOPPER.Areas.Admin.Models;
using System.IO;
namespace SHOPPER.Areas.Admin.Controllers
{
    public class newProductController : Controller
    {
        // GET: Admin/newProduct
        [HttpGet]
        public ActionResult Index()
        {
            SanPham x = new SanPham();
            //Thiết lập thông tin mặc định
            x.ngayDang = DateTime.Now;
            x.taiKhoan = CommonAdmin.getTenTK();
            ViewBag.HDDSP = "/Areas/Admin/AdminAsset/images/avatar3.png";
            return View(x);
        }
        [HttpPost]
        public ActionResult Index(SanPham x, HttpPostedFileBase hinhddsp)
        {
            try
            {
                //Nhận thông tin
                //Xử lý thông tin nhận về
                x.daDuyet = false;
                x.ngayDang = DateTime.Now;
                x.taiKhoan = CommonAdmin.getTenTK();
                //Xử lý hình
                if (hinhddsp != null)
                {
                    string virPath = "/asset/imageProducts/";
                    string phypath = Server.MapPath("~/" + virPath); //Xđ vị trí lưu hình
                    string ext = Path.GetExtension(hinhddsp.FileName);
                    string tenHinh = x.maSP + ext;
                    hinhddsp.SaveAs(phypath + tenHinh);
                    x.hinhDD = virPath + tenHinh;
                    ViewBag.HDDSP = x.hinhDD;
                }
                else
                {
                    x.hinhDD = "";
                }
                //Cập nhật đối tượng bài viết vừa đăng vào Data Models
                ShopperEntities db = new ShopperEntities();
                db.SanPhams.Add(x);
                //Lưu thông tin xuống database
                db.SaveChanges();
                return RedirectToAction("Index", "ProductList", new { spActive = 0 });
            }
            catch
            {
            }
            return View(x);
        }
        
    }
    
}