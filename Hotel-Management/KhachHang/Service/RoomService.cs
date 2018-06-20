using ManageHotel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageHotel.Service
{
    public class RoomService
    {
        public Phong getPhong(int id)
        {
            using (var db = new ManageHotelEntities())
            {
                 Phong result = db.Phongs.Where(x => x.ID == id).FirstOrDefault();
                 return result;
            }
        }

        public Phong createPhong(String maPhong, String viTriTang, int hang, int donGia, int hinhThuc, int trangThai)
        {
            Phong p = new Phong();
            p.MaPhong = maPhong;
            p.ViTriTang = viTriTang;
            p.Hang = hang;
            p.DonGia = donGia;
            p.HinhThuc = hinhThuc;
            p.TrangThai = trangThai;

            return p;
        }

        public sp_SearchAvailableRoom_Result createPhongSearch(int id, String maPhong, String viTriTang, int hang, int donGia, int hinhThuc, int trangThai, String ngayBatDau, String ngayKetThuc)
        {
            sp_SearchAvailableRoom_Result p = new sp_SearchAvailableRoom_Result();
            p.ID = id;
            p.MaPhong = maPhong;
            p.ViTriTang = viTriTang;
            p.Hang = hang;
            p.DonGia = donGia;
            p.HinhThuc = hinhThuc;
            p.TrangThai = trangThai;
            p.ngayBatDau = ngayBatDau;
            p.ngayKetThuc = ngayKetThuc;

            return p;
        }
    }
}
