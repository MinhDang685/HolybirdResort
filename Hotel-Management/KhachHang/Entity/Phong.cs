//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManageHotel.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Phong
    {
        public Phong()
        {
            this.ChiTietGiaoDiches = new HashSet<ChiTietGiaoDich>();
        }
    
        public int ID { get; set; }
        public string MaPhong { get; set; }
        public string ViTriTang { get; set; }
        public Nullable<int> Hang { get; set; }
        public Nullable<int> HinhThuc { get; set; }
        public Nullable<int> DonGia { get; set; }
        public Nullable<int> TrangThai { get; set; }
    
        public virtual ICollection<ChiTietGiaoDich> ChiTietGiaoDiches { get; set; }
        public virtual Hang Hang1 { get; set; }
        public virtual HinhThuc HinhThuc1 { get; set; }
        public virtual TrangThaiPhong TrangThaiPhong { get; set; }
    }
}
