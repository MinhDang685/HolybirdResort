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
    
    public partial class HinhThuc
    {
        public HinhThuc()
        {
            this.Phongs = new HashSet<Phong>();
        }
    
        public int ID { get; set; }
        public string ThongTin { get; set; }
    
        public virtual ICollection<Phong> Phongs { get; set; }
    }
}
