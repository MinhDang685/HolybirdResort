//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageHotel
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiaoDich
    {
        public GiaoDich()
        {
            this.ChiTietGiaoDiches = new HashSet<ChiTietGiaoDich>();
            this.KhachHangs = new HashSet<KhachHang>();
        }
    
        public int ID { get; set; }
        public string MaDoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public Nullable<int> ID_NguoiDaiDien { get; set; }
        public Nullable<int> SoNguoi { get; set; }
        public Nullable<int> SoPhong { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }
        public Nullable<int> TinhTrang { get; set; }
        public Nullable<int> TongTien { get; set; }
    
        public virtual ICollection<ChiTietGiaoDich> ChiTietGiaoDiches { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
