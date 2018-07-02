using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_Management
{
    public partial class ThanhToan : Form
    {
        private HOLYBIRDRESORTEntities HE = new HOLYBIRDRESORTEntities();

        public ThanhToan(int idGiaoDich)
        {
            InitializeComponent();
            showHoaDon(idGiaoDich);
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void showHoaDon(int idGiaoDich)
        {
            GiaoDich gd = HE.sp_LayGiaoDichTheoId(idGiaoDich).Single();
            lbMaDoanHoaDon.Text = gd.MaDoan;
            lbTongTienHoaDon.Text = gd.TongTien.ToString();
            KhachHang kh = HE.sp_LayTenNguoiDaiDienTheoId(gd.ID_NguoiDaiDien).Single();
            lbDaiDienHoaDon.Text = kh.HoTen;
            List<ChiTietGiaoDich> ctgds = HE.sp_LayChiTietGiaoDichTheoIdGiaoDich(gd.ID).ToList();
            if (GridHoaDon.RowCount > 0)
            {
                GridHoaDon.Rows.Clear();
            }
            for (int i = 0; i < ctgds.Count; i++)
            {
                string stt = (i + 1).ToString();
                sp_LayThongTinPhong_Result phong = HE.sp_LayThongTinPhong(ctgds[i].ID_MaPhong).Single();
                string maPhong = phong.MaPhong;
                int donGia = (int)phong.DonGia;
                int thoiGian = 1;
                if(ctgds[i].NgayBatDau != null && ctgds[i].NgayKetThuc != null)
                {
                    TimeSpan time = (TimeSpan)(ctgds[i].NgayKetThuc - ctgds[i].NgayBatDau);
                    thoiGian = time.Days;
                }
                int thanhTien = (int)ctgds[i].ThanhTien;
                String[] row = new String[]{
                          stt,
                          maPhong,
                          donGia.ToString(),
                          thoiGian.ToString(),
                          thanhTien.ToString()
                        };
                GridHoaDon.Rows.Add(row);
            }
        }

        private void btn_hoan_thanh_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
