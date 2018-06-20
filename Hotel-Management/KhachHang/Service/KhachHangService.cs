using ManageHotel;
using ManageHotel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageHotel.Service
{
    public class KhachHangService
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

        public KhachHang createKhachHang(sp_LayDanhSachDoan_Result res)
        {
            KhachHang kh = new KhachHang();
            kh.ID = res.ID;
            kh.ID_GiaoDich = res.ID_GiaoDich;
            kh.HoTen = res.HoTen;
            kh.CMND = res.CMND;
            kh.MatKhau = res.MatKhau;
            return kh;
        }

        public KhachHang createKhachHang(int ID, int ID_GiaoDich, String HoTen, String CMND, String MatKhau)
        {
            KhachHang kh = new KhachHang();
            kh.ID = ID;
            kh.ID_GiaoDich = ID_GiaoDich;
            kh.HoTen = HoTen;
            kh.CMND = CMND;
            kh.MatKhau = MatKhau;
            return kh;
        }

        public sp_LayThongTinDoan_Result layThongTinDoan(int idDoan)
        {
            using (var db = new ManageHotelEntities())
            {
                var thongTinDoan = db.sp_LayThongTinDoan(idDoan).ToList();
                if (thongTinDoan.Count > 0)
                {
                    return thongTinDoan[0];
                }
                return null;
            }
        }
        public List<KhachHang> getDanhSachDoan(int idDoan)
        {
            List<KhachHang> listKH = new List<KhachHang>();
            using (var db = new ManageHotelEntities())
            {
                var list = db.sp_LayDanhSachDoan(idDoan).ToList();
                foreach (var kh in list)
                {
                    listKH.Add(createKhachHang(kh));
                }
                return listKH;
            }
        }

        public void themChiTietGiaoDich(ChiTietGiaoDich ct)
        {
            using (var db = new ManageHotelEntities())
            {
                db.sp_ThemChiTietGiaoDich(ct.ID_GiaoDich, ct.ID_MaPhong, 
                    ct.ID_KhachHang, ct.NgayBatDau, ct.NgayKetThuc);
            }
        }
        public void capNhatChiTietGiaoDich(ChiTietGiaoDich ct)
        {
            using (var db = new ManageHotelEntities())
            {
                db.sp_CapNhatChiTietGiaoDich(ct.ID, ct.ID_GiaoDich, ct.ID_MaPhong, 
                    ct.ID_KhachHang, ct.NgayBatDau, ct.NgayKetThuc);
            }
        }
        public void xoaChiTietGiaoDich(int id)
        {
            using (var db = new ManageHotelEntities())
            {
                db.sp_XoaChiTietGiaoDich(id);
            }
        }

        public void xoaChiTietGiaoDichTheoMaDoan(int idDoan)
        {
            using (var db = new ManageHotelEntities())
            {
                db.sp_XoaChiTietGiaoDichTheoDoan(idDoan);
            }
        }
        public List<sp_LayChiTietGiaoDichTheoDoan_Result> layChiTietGiaoDichTheoMaDoan(int idDoan)
        {
            using (var db = new ManageHotelEntities())
            {
                return db.sp_LayChiTietGiaoDichTheoDoan(idDoan).ToList();
            }
        }

        public void capNhatTinhTrangGiaoDich(int idDoan, int tinhTrang)
        {
            using (var db = new ManageHotelEntities())
            {
                db.sp_CapNhatTinhTrangGiaoDich(idDoan, tinhTrang);
            }
        }
    }
}
