//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHD
    {
        public int ID { get; set; }
        public Nullable<int> SanPhamID { get; set; }
        public Nullable<int> HoaDonID { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual HoaDon_ID HoaDon_ID { get; set; }
        public virtual SanPham_ID SanPham_ID { get; set; }
    }
}
