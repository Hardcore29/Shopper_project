using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using SHOPPER.App_Start;
using SHOPPER.Models;
namespace SHOPPER
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //bundle
            BundleCollection bundles = BundleTable.Bundles;
            BundleConfig.BundleRegister(bundles);
            //Application object để chứa Common
            Application["all"] = new Common();
        }
        protected void Session_Start(object Sender, EventArgs e)
        {
            Session["ttDangNhap"] = null;
            //giỏ hàng rỗng
            Session["gioHang"] = new CartShop();
        }
    }
}
