using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
using System.Data.Entity;
namespace SHOPPER.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        ShopperEntities db = new ShopperEntities();
        [HttpGet]
        public ActionResult Index()
        {
            //Tạo 1 đối tượng khách hàng mới truyền ra cho VIew
            KhachHang x = new KhachHang();
            //Lấy thông tin đã mua hàng từ Session truyền ra cho View thông qua ViewData
            //----Lấy đơn hàng từ Session
            CartShop gh = Session["gioHang"] as CartShop;
            //----Truyền ra ngoài View
            ViewData["Cart"] = gh;
            return View();
        }
        [HttpPost]
        public ActionResult SaveToDatabase(KhachHang x)
        {
            
            //Sư dụng transaction để lưu đồng thời dữ liệu trên 3 table khác nhau
            using ( var context = new ShopperEntities())
            {
                using (DbContextTransaction trans = context.Database.BeginTransaction())
                {
                    try
                    {
                        //Tạo mớ 1 đối tượng khách hàng và thêm vào table KhachHang
                        //Cập nhật thông tin khách hàng đã tạo                                      
                                x.maKH = x.soDT;
                                //Thêm thông tin khách hàng vào database
                                context.KhachHangs.Add(x);                                          
                        //Lưu vào database ------[table KhachHang]----
                        context.SaveChanges();
                        //--------------------------------------------------------------//
                        //Tạo mới 1 đối tượng đơn hàng và thêm vào tableDonHang
                        DonHang d = new DonHang();
                        //Cập nhật thông tin đơn hàng đã tạo
                        d.soDH = string.Format("{0:MMddhhmmss}", DateTime.Now);
                        d.maKH = x.maKH;
                        d.ngayGH = DateTime.Now.AddDays(2);
                        d.ngayDat = DateTime.Now;
                        d.daKichHoat = false;
                        d.taiKhoan = "admin";                        
                        d.diaChiGH = x.diaChi;
                        //Thêm thông tin Đơn hàng vào database
                        context.DonHangs.Add(d);
                        //Lưu vào database ------[table DonHang]----
                        context.SaveChanges();
                        //--------------------------------------------------------------//
                        //Lấy danh sách món hàng từ Cartshop
                        CartShop gh = Session["gioHang"] as CartShop;
                        //Cập nhật thông tin chi tiết đơn hàng đã tạo
                        foreach (CtDonHang i in gh.SPDaChon.Values)
                        {
                            i.soDH = d.soDH;
                            context.CtDonHangs.Add(i);
                        }
                        //Lưu vào database ------[table KhachHang]----
                        context.SaveChanges();
                        //hoàn thành và commit
                        trans.Commit();
                        Session["gioHang"] = new CartShop();
                        //Chuyển dến trang thông báo
                        return RedirectToAction("Index", "Thank");
                    }
                    catch (Exception e)
                    {
                        trans.Rollback();
                        string s = e.Message;
                    }
                }
            }
                //Nếu lỗi chuyển về checkout
                return RedirectToAction("Index", "Checkout");
        }
    }
}