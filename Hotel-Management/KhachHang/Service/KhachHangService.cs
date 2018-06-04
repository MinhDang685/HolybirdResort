using ManageHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class KhachHangService
    {
        public KhachHang getKhachHangByCMND(String CMND) {
            using (var db = new ManageHotelEntities())
            {
                KhachHang khachhang = db.KhachHangs.Where(kh => kh.CMND == CMND).FirstOrDefault();

                return khachhang;
            }
        }
    }
}
