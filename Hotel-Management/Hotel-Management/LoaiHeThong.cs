
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
    
public partial class LoaiHeThong
{

    public LoaiHeThong()
    {

        this.HeThongs = new HashSet<HeThong>();

    }


    public int ID { get; set; }

    public string LoaiHeThong1 { get; set; }



    public virtual ICollection<HeThong> HeThongs { get; set; }

}

}
