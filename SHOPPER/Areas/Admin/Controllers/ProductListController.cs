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
    public class ProductListController : Controller
    {
        // GET: Admin/ProductList
        private static ShopperEntities db = new ShopperEntities();
        private static bool spDaDuyet;
        [HttpGet]
        public ActionResult Index(string spActive)
        {
            spDaDuyet = spActive.Equals("1");
            CNDLSanPham();
            return View();
        }
        //Xoá sản phẩm
        [HttpPost]
        public ActionResult Delete(String spXoa)
        {
            //Tìm đến bài viết cần xoá
            SanPham x = db.SanPhams.Find(spXoa);
            //Xoá
            db.SanPhams.Remove(x);
            //cập nhật dữ liệu lại cho database
            db.SaveChanges();
            //Hiển thị dữ liệu trên View
            CNDLSanPham();
            return View("Index");
        }
        //Huỷ duyệt sản phẩm
        [HttpPost]
        public ActionResult UnActive(String spKH)
        {
            //Tìm dến bài viết muốn huỷ kích hoạt
            SanPham x = db.SanPhams.Find(spKH);
            //Huỷ kích hoạt
            x.daDuyet = !spDaDuyet;
            //cập nhật dữ liệu lại cho database
            db.SaveChanges();
            //Hiển thị dữ liệu trên View
            CNDLSanPham();
            return View("Index");
        }
        //Chỉnh sửa sản phẩm
        [HttpPost]
        public ActionResult Update(SanPham spSua, HttpPostedFileBase hinhddSP)
        {
            try
            {
                SanPham m = db.SanPhams.Find(spSua.maSP);
                m.maSP = spSua.maSP;
                m.tenSP = spSua.tenSP;
                m.daDuyet = false;
                m.noiDung = spSua.noiDung;
                m.giaBan = spSua.giaBan;
                m.giamGia = spSua.giamGia;
                m.maLoai = spSua.maLoai;
                m.dvt = spSua.dvt;
                m.tinhTrang = spSua.tinhTrang;
                if (hinhddSP != null)
                {

                    string virPath = "/asset/imageProducts/";
                    string phypath = Server.MapPath("~/" + virPath); //Xđ vị trí lưu hình
                    try
                    {
                        string hinhCanSua = Server.MapPath(m.hinhDD);
                        System.IO.File.Delete(hinhCanSua);
                    }
                    catch { }
                    string ext = Path.GetExtension(hinhddSP.FileName);
                    string tenHinh = m.maSP + ext;
                    hinhddSP.SaveAs(phypath + tenHinh);
                    m.hinhDD = virPath + tenHinh;
                    ViewBag.HDD = m.hinhDD;
                }
                else
                {
                    m.hinhDD = "";
                }
                db.SaveChanges();
            return RedirectToAction("Index", "ProductList", new { spActive = 0 });
            }
            catch
            {

            }
            return View("Update");
        }
        //----Tìm sản phẩm để chỉnh sửa
        public ActionResult findSPUpdate(string maspup)
        {
            SanPham sp = db.SanPhams.Find(maspup);
            return View("Update", sp);
        }
        public void CNDLSanPham()
        {
            List<SanPham> l = db.SanPhams.Where(x => x.daDuyet == spDaDuyet).ToList<SanPham>();
            ViewData["dssp"] = l;
            ViewBag.nutDuyetSP = spDaDuyet ? "Huỷ Duyệt" : "Duyệt";
        }
    }
}