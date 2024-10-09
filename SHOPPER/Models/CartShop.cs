using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHOPPER.Models
{
    public class CartShop
    {
        public string maKH { get; set; }
        public string taikhoan { get; set; }
        public DateTime ngayDatHang { get; set; }
        public DateTime ngayGiao { get; set; }
        public string diaChi { get; set; }
        public SortedList<string, CtDonHang> SPDaChon { get; set; }
        public CartShop()
        {
            this.maKH = "";
            this.taikhoan = "";
            this.ngayDatHang = DateTime.Now;
            this.ngayGiao = DateTime.Now.AddDays(2);
            this.diaChi = "";
            this.SPDaChon = new SortedList<string, CtDonHang>();
        }
        //phương thức trả về true nếu không có sản phẩm trong giỏ hàng
        public bool isEmpty()
        {
            return (SPDaChon.Keys.Count == 0);
        }
        //Thêm mặt hàng vào giỏ hàng
        public void addItem(string masp)
        {
            if (SPDaChon.Keys.Contains(masp))
            {
                CtDonHang x = SPDaChon.Values[SPDaChon.IndexOfKey(masp)];
                x.soLuong++;
               
            }
            else
            {
                CtDonHang i = new CtDonHang();
                i.maSP = masp;
                i.soLuong = 1;
                SanPham z = Common.getProductById(masp);
                i.giaBan = z.giaBan;
                i.giamGia = z.giamGia;
                SPDaChon.Add(masp, i);
            }
        }
        //cập nhật sản phẩm nếu trùng
        public void updateItem(CtDonHang x)
        {
            this.SPDaChon.Remove(x.maSP);
            this.SPDaChon.Add(x.maSP, x);
        }
        //Xoá mặt hàng đã chọn
        public void deleteItem(string masp)
        {
            if (SPDaChon.Keys.Contains(masp))
            {
                SPDaChon.Remove(masp);
            }
        }
        //Giảm số lượng mặt hàng
        public void decrease(string masp)
        {
            if (SPDaChon.Keys.Contains(masp))
            {
                CtDonHang x = SPDaChon.Values[SPDaChon.IndexOfKey(masp)];
                if(x.soLuong > 1)
                {
                    x.soLuong--;
                    
                }
                else
                {
                    deleteItem(masp);
                }
            }
        }
        //Tính giá 1 mặt hàng trong giỏ hàng
        public long CostOfOneProduct(CtDonHang x)
        {
            return (long)(x.giaBan * x.soLuong - (x.giaBan * x.soLuong * x.giamGia / 100));
        }
        //Tổng giá trị đơn hàng
        public long totalCartShop()
        {
            long result = 0;
            foreach (CtDonHang i in SPDaChon.Values)
            {
                result += CostOfOneProduct(i);
            }
            return result;
        }
    }
}