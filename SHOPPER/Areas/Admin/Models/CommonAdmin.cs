using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SHOPPER.Models;
namespace SHOPPER.Areas.Admin.Models
{
    public class CommonAdmin
    {
        //Phương thức cho phép đọc thông tin tài khoản đã đăng nhập từ Session
        public static TaiKhoan ttDangNhap()
        {
            TaiKhoan tk = new TaiKhoan();
            tk = HttpContext.Current.Session["ttDangNhap"] as TaiKhoan;
            return tk;
        }
        //Lấy tên tài khoản đã đăng nhập trong hệ thống
        public static string getTenTK()
        {
            return ttDangNhap().taiKhoan1;
        }
        public IEnumerable<LoaiSP> getLoai()
        {
            ShopperEntities db = new ShopperEntities();
            return db.LoaiSPs;
        }
    }
}