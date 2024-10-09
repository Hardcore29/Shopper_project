using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SHOPPER.App_Start
{
    public class BundleConfig
    {
        public static void BundleRegister(BundleCollection bundle)
        {
            //style cho trang công khai
            bundle.Add(new StyleBundle("~/bundles/css1").Include("~/fonts/icomoon/style.css",
                                                                 "~/Content/bootstrap.min.css",
                                                                 "~/Content/magnific-popup.css",
                                                                 "~/Content/jquery-ui.css",
                                                                 "~/Content/owl.carousel.min.css",
                                                                 "~/Content/owl.theme.default.min.css",
                                                                 "~/Content/aos.css",
                                                                 "~/Content/style.css"));
            //scripts cho trang công khai
            bundle.Add(new ScriptBundle("~/bundles/script1").Include("~/Scripts/jquery-3.3.1.min.js",
                                                                     "~/Scripts/jquery-ui.js",
                                                                     "~/Scripts/popper.min.js",
                                                                     "~/Scripts/bootstrap.min.js",
                                                                     "~/Scripts/owl.carousel.min.js",
                                                                     "~/Scripts/jquery.magnific-popup.min.js",
                                                                     "~/Scripts/aos.js",
                                                                     "~/Scripts/main.js"));
            // style cho trang admin
            bundle.Add(new StyleBundle("~/bundles/css2").Include("~/Areas/Admin/AdminAsset/Content/bootstrap.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/font-awesome.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/ionicons.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/AdminLTE.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/skins/_all-skins.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/morris.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/jquery-jvectormap.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/bootstrap-datepicker.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/daterangepicker.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/bootstrap3-wysihtml5.min.css",
                                                                 "~/Areas/Admin/AdminAsset/Content/dataTables.bootstrap.min.css"));
            //scripts cho trang admin
            bundle.Add(new ScriptBundle("~/bundles/script2").Include("~/Areas/Admin/AdminAsset/Scripts/jquery.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery-ui.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/bootstrap.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/raphael.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/morris.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery.sparkline.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery-jvectormap-1.2.2.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery-jvectormap-world-mill-en.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery.knob.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/moment.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/daterangepicker.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/bootstrap-datepicker.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/bootstrap3-wysihtml5.all.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery.slimscroll.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/fastclick.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/adminlte.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/demo.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/jquery.dataTables.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/dataTables.bootstrap.min.js",
                                                                     "~/Areas/Admin/AdminAsset/Scripts/ckeditor.js"));
        }
    }
}