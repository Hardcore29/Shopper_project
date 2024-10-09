using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
using SHOPPER.Areas.Admin.Models;
namespace SHOPPER.Areas.Admin.Controllers
{
    public class ArticleListController : Controller
    {
        // GET: Admin/ArticleList
        private static ShopperEntities db = new ShopperEntities();
        private static bool daDuyet;
        [HttpGet]
        public ActionResult Index(string isActive)
        {
            daDuyet = isActive.Equals("1");
            CNDLBaiViet();
            return View();
        }
        //-----Xoá bài viết-----
        [HttpPost]
        public ActionResult Delete(string bvXoa)
        {
            //Tìm đến bài viết cần xoá
            BaiViet x = db.BaiViets.Find(bvXoa);
            //Xoá
            db.BaiViets.Remove(x);
            //cập nhật dữ liệu lại cho database
            db.SaveChanges();
            //Hiển thị dữ liệu trên View
            CNDLBaiViet();
            return View("Index");
        }
        //-----Duyệt / Huỷ Duyệt bài viết-----
        [HttpPost]
        public ActionResult UnActive(string bvKH)
        {
            //Tìm dến bài viết muốn huỷ kích hoạt
            BaiViet x = db.BaiViets.Find(bvKH);
            //Huỷ kích hoạt
            x.daDuyet = !daDuyet;
            //cập nhật dữ liệu lại cho database
            db.SaveChanges();
            //Hiển thị dữ liệu trên View
            CNDLBaiViet();
            return View("Index");
        }
        //Chỉnh sửa
        [HttpPost]
        public ActionResult Update(BaiViet bvSua, HttpPostedFileBase hinhddBV)
        {
            try
            {
                            BaiViet m = db.BaiViets.Find(bvSua.maBV);
                            m.maBV = bvSua.maBV;
                            m.tenBV = bvSua.tenBV;
                            m.ndTomTat = bvSua.ndTomTat;
                            m.daDuyet = false;
                            m.noiDung = bvSua.noiDung;
                if (hinhddBV != null)
                {
                    
                    string virPath = "/asset/imageArticles/";
                    string phypath = Server.MapPath("~/" + virPath); //Xđ vị trí lưu hình
                    try
                    {
                        string hinhCanSua = Server.MapPath(m.hinhDD);
                        System.IO.File.Delete(hinhCanSua);
                    }
                    catch
                    {

                    }                   
                    string ext = Path.GetExtension(hinhddBV.FileName);
                    string tenHinh = m.maBV + "-DD"+ ext;
                    hinhddBV.SaveAs(phypath + tenHinh);
                    m.hinhDD = virPath + tenHinh;
                    ViewBag.HDD = m.hinhDD;
                }
                else
                {
                    m.hinhDD = "";
                }
                db.SaveChanges();               
                return RedirectToAction("Index", "ArticleList", new { isActive = 0});
            }
            catch
            {

            }
            return View("Update");
        }
        public ActionResult findBVUpdate(string mabvup)
        {
            BaiViet bv = db.BaiViets.Find(mabvup);
            return View("Update", bv);
        }
        //-----Hàm hiển thị dữ liệu ra View-----        
        public void CNDLBaiViet()
        {
            List<BaiViet> l = db.BaiViets.Where(x => x.daDuyet == daDuyet).ToList<BaiViet>();
            ViewData["dsbv"] = l;
            string[] A = { daDuyet ? "fa-close" : "fa-check", daDuyet ? "Huỷ duyệt bài viết" : "Duyệt bài viết" };
            ViewBag.nutDuyet = A;
        }
    }
}