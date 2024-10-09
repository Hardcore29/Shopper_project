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
    public class ArticleSingleController : Controller
    {
        // GET: Admin/ArticleSingle
        [HttpGet]
        public ActionResult Index()
        {
            BaiViet x = new BaiViet();
            //Thiết lập 1 số thông tin mặc định
            x.ngayDang = DateTime.Now;
            x.Solandoc = 0;
            x.taiKhoan = CommonAdmin.getTenTK();
            ViewBag.HDDBV = "/Areas/Admin/AdminAsset/images/avatar3.png";
            return View(x);
        }
        [HttpPost]
        public ActionResult Index(BaiViet x, HttpPostedFileBase hinhDaiDienBV)
        {
                try
                {
                    //Nhận thông tin
                    //Xử lý thông tin nhận về
                    x.daDuyet = false;
                    x.ngayDang = DateTime.Now;
                    x.taiKhoan = CommonAdmin.getTenTK();
                    x.Solandoc = 0;
                    //Xử lý hình
                    if (hinhDaiDienBV != null)
                    {
                        string virPath = "/asset/imageArticles/";
                        string phypath = Server.MapPath("~/" + virPath); //Xđ vị trí lưu hình
                        string ext = Path.GetExtension(hinhDaiDienBV.FileName);
                        string tenHinh = x.maBV + "-DD" + ext;
                        hinhDaiDienBV.SaveAs(phypath + tenHinh);
                        x.hinhDD = virPath + tenHinh;
                        ViewBag.HDDBV = x.hinhDD;
                    }
                    else
                    {
                        x.hinhDD = "";
                    }
                    //Cập nhật đối tượng bài viết vừa đăng vào Data Models
                    ShopperEntities db = new ShopperEntities();
                    db.BaiViets.Add(x);
                    //Lưu thông tin xuống database
                    db.SaveChanges();
                    return RedirectToAction("Index", "ArticleList", new { isActive = 0 });
                }
                catch
                {

                }
            return View(x);
        }
    }
}