//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Web.Mvc;
namespace SHOPPER.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaiViet
    {
        public string maBV { get; set; }
        public string tenBV { get; set; }
        public string hinhDD { get; set; }
        public string ndTomTat { get; set; }
        public Nullable<System.DateTime> ngayDang { get; set; }
        public Nullable<int> Solandoc { get; set; }
        [AllowHtml]
        public string noiDung { get; set; }
        public string taiKhoan { get; set; }
        public Nullable<bool> daDuyet { get; set; }
    
        public virtual TaiKhoan TaiKhoan1 { get; set; }
    }
}
