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
        public bool checkLoginUserName(String CMND, String Password){
            KhachHang user = this.getKhachHangByCMND(CMND);
            if (user == null) {
                return false;
            }
            else{
                if (user.MatKhau == Password) {
                    return true;
                }
            }
            return false;
        }
    }
}
