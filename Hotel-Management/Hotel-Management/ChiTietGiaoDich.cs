//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hotel_Management
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietGiaoDich
    {
        public ChiTietGiaoDich()
        {
            this.DichVuPhongs = new HashSet<DichVuPhong>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_GiaoDich { get; set; }
        public Nullable<int> ID_MaPhong { get; set; }
        public Nullable<int> ID_KhachHang { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual GiaoDich GiaoDich { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual Phong Phong { get; set; }
        public virtual ICollection<DichVuPhong> DichVuPhongs { get; set; }
    }
}
