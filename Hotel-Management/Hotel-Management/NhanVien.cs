
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
    
public partial class NhanVien
{

    public int ID { get; set; }

    public string TenDangNhap { get; set; }

    public string MatKhau { get; set; }

    public Nullable<int> ID_HeThong { get; set; }



    public virtual HeThong HeThong { get; set; }

}

}
