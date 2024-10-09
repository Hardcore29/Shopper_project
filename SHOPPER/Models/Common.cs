using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPPER.Models
{
    public class Common
    {
       
         static   ShopperEntities db = new ShopperEntities();
        
        //Lấy ra loại sản phẩm
        public IEnumerable<LoaiSP> loaisanpham()
        {
            return db.LoaiSPs;
        }
        //Lấy tất cả sản phẩm
        public IEnumerable<SanPham> tatCaSP()
        {
            return db.SanPhams.Where(x => x.daDuyet == true);
        }
        //Lấy thông tin sp theo mã sp
        public static SanPham getProductById(string masp)
        {
            return db.SanPhams.Find(masp);
        }
        //Lấy tên sản phẩm theo mã loại
        public static string getNameProduct(string masp)
        {
            return db.SanPhams.Find(masp).tenSP;
        }
        //Lấy hình sản phẩm theo mã loại
        public static string getImageProduct(string masp)
        {
            return db.SanPhams.Find(masp).hinhDD;
        }
        //phương thức hiển thị giá gốc của sản phẩm (không có giảm giá)
        public string giaGoc(string x)
        {
            SanPham z = db.SanPhams.Find(x);
            if (z.giamGia != 0)
            {
                return z.giaBan.ToString();
            }
            return "";
        }
    }
}