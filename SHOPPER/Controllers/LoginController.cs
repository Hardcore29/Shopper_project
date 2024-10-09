using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SHOPPER.Models;
namespace SHOPPER.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string user, string pass)
        {
            try
            {
                string encode = MaHoa.mahoa(pass);
                TaiKhoan dangNhap = new ShopperEntities().TaiKhoans.
                    Where(x => (x.taiKhoan1.Equals(user.Trim())) && (x.matKhau.Equals(encode))).First<TaiKhoan>();
                bool check = dangNhap != null && dangNhap.taiKhoan1.Equals(user.Trim()) && dangNhap.matKhau.Equals(encode);
                if (check)
                {
                    Session["ttDangNhap"] = dangNhap;
                    return RedirectToAction("Index", "HomeAdmin", new { Area = "Admin" });
                }
            }
            catch
            {
                
            }
            
            return View();
        }
        [HttpGet]
        public ActionResult LogOut()
        {
            Session["ttDangNhap"] = null;
            return RedirectToAction("Index", "Login");

        }
    }
}