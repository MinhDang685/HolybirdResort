using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using DevComponents.DotNetBar;

namespace Hotel_Management
{
    public partial class QuanLy : DevComponents.DotNetBar.RibbonForm
    {
        private HOLYBIRDRESORTEntities HE = new HOLYBIRDRESORTEntities();
        private NhanVien NV = null;

        public QuanLy()
        {
            InitializeComponent();
        }

        public QuanLy(NhanVien nv)
        {

            InitializeComponent();
            CaiDatFormQuanLy(nv);
        }



        private void CaiDatFormQuanLy(NhanVien nv)
        {
            NV = nv;
            lbTenNhanVien.Text = NV.TenDangNhap.ToString();
        }

        private void ribbonTabItem2_Click(object sender, EventArgs e)
        {
            panel1.Show();

        }

        private void ribbonTabItem1_Click(object sender, EventArgs e)
        {
            ribbonPanel1.Show();
            panel3.Hide();
        }

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void QuanLy_Load(object sender, EventArgs e)
        {

        }

        private void GridThongTinDoan_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.GridThongTinDoan.Rows[e.RowIndex].Cells["Column1"].Value = (e.RowIndex + 1).ToString();
        }

        private String TaoMaDoan()
        {
            String MaDoan = "";

            String NgayGioHienTai = DateTime.Now.ToString();

            string[] temp = NgayGioHienTai.Split(new char[] { ' ', ':', '/' });

            for (int i = 0; i < temp.Length; i++)
            {
                MaDoan += temp[i];
            }

            return MaDoan;
        }

        private String ThongBaoTaiKhoanDoan(GiaoDich gd)
        {
            String ThongBao = "Tên đăng nhập: ";
            ThongBao += gd.TenDangNhap.ToString();
            ThongBao += "\r";
            ThongBao += "Mật khẩu     : ";
            ThongBao += gd.MatKhau.ToString();

            return ThongBao;
        }

        private GiaoDich gd = new GiaoDich();

        private void TaoGiaoDichMoi()
        {
            try
            {

                gd.NgayBatDau = ThoiDiemBatDau.Value;
                gd.NgayKetThuc = ThoiDiemKetThuc.Value;

                gd.MaDoan = TaoMaDoan();

                gd.TenDangNhap = GridThongTinDoan.Rows[0].Cells[2].Value.ToString();
                gd.MatKhau = gd.MaDoan.Substring(9, 6);

                gd.SoNguoi = GridThongTinDoan.RowCount - 1;

                //chưa tính đến tongtien,tinh trang, sophong, id nguoi dai dien
                HE.sp_TaoMoiGiaoDich(gd.MaDoan, gd.TenDangNhap, gd.MatKhau, gd.SoNguoi, gd.NgayBatDau, gd.NgayKetThuc);
                //HE.GiaoDiches.Add(gd);
                //HE.SaveChanges();

            }
            catch
            {
                MessageBox.Show("Không thể tạo giao dịch!");
            }
        }

        private void RefreshDuLieu()
        {
            foreach(DataGridViewRow row in GridThongTinDoan.Rows)
            {
                row.Cells[1].Value = null;
                row.Cells[2].Value = null;
            }
            ThoiDiemBatDau.ResetValue();
            ThoiDiemKetThuc.ResetValue();
        }

        private void LuuDanhSachDoanVaCapNhatGiaoDich()
        {
            //lấy id giao dịch vừa tạo để gán vào cho từng thành viên

            //tìm theo cmnd của trưởng đoàn là username
            String CMNDTruongDoan = GridThongTinDoan.Rows[0].Cells[2].Value.ToString();

            try
            {
                int ID_GiaoDich = (int)HE.sp_TimIDGiaoDichTheoCMNDTruongDoan(CMNDTruongDoan).Max();

                //gd = HE.GiaoDiches.Single(t => t.TenDangNhap.Equals(CMNDTruongDoan));//đây là giao dịch sau khi đã có id

                //gán id giao dịch cho trưởng đoàn và lưu thông tin trưởng đoàn trước để lấy id người đại diện
                KhachHang TruongDoan = new KhachHang();
                TruongDoan.ID_GiaoDich = ID_GiaoDich;
                TruongDoan.HoTen = GridThongTinDoan.Rows[0].Cells[1].Value.ToString();
                TruongDoan.CMND = GridThongTinDoan.Rows[0].Cells[2].Value.ToString();

                //luu thông tin trưởng đoàn
                HE.sp_LuuThongTinKhachHang(TruongDoan.ID_GiaoDich, TruongDoan.HoTen, TruongDoan.CMND);
                //HE.KhachHangs.Add(TruongDoan);
                //HE.SaveChanges();

                //sau khi lưu thì lấy lại id của trưởng đoàn để cập nhật cho bảng giao dich
                int ID_TruongDoan = (int)HE.sp_LayIDKhachHangTheoCMND(CMNDTruongDoan).Max();
                //TruongDoan = HE.KhachHangs.Single(t => t.CMND.Equals(CMNDTruongDoan));

                //cập nhật cho bảng giao dịch
                HE.sp_CapNhatIDTruongDoanChoGiaoDich(ID_TruongDoan, ID_GiaoDich);
                //gd.ID_NguoiDaiDien = TruongDoan.ID;
                //HE.SaveChanges();

                //gán ID giao dịch cho từng thành viên còn lại
                for (int i = 1; i < GridThongTinDoan.RowCount - 1; i++)
                {
                    KhachHang kh = new KhachHang();
                    kh.ID_GiaoDich = ID_GiaoDich;
                    kh.HoTen = GridThongTinDoan.Rows[i].Cells[1].Value.ToString();
                    if (GridThongTinDoan.Rows[i].Cells[2].Value == null)
                    {
                        kh.CMND = "";
                    }
                    else
                    {
                        kh.CMND = GridThongTinDoan.Rows[i].Cells[2].Value.ToString();
                    }

                    HE.sp_LuuThongTinKhachHang(kh.ID_GiaoDich, kh.HoTen, kh.CMND);
                    //HE.KhachHangs.Add(kh);
                    //HE.SaveChanges();
                }
                RefreshDuLieu();
                MessageBox.Show(ThongBaoTaiKhoanDoan(gd));
            }
            catch
            {
                MessageBox.Show("Không thể lưu danh sách đoàn!");
            }
        }

        private bool KiemTraTonTaiCMND(String CMND)
        {
            if (CMND == null)
            {
                return false;
            }
            else
            {
                try
                {
                    int ID_KhachHang = (int)HE.sp_LayIDKhachHangTheoCMND(CMND).Max();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private List<KhachHang> KiemTraKhachHangCoCMNDDaTonTai()
        {
            List<KhachHang> CacKhachHangCoCMNDDaTonTai = new List<KhachHang>();

            for (int i = 0; i < GridThongTinDoan.RowCount - 1; i++)
            {
                if (GridThongTinDoan.Rows[i].Cells[2].Value != null)
                {
                    if (KiemTraTonTaiCMND(GridThongTinDoan.Rows[i].Cells[2].Value.ToString().Trim())) //kiểm tra cmnd tồn tại
                    {
                        KhachHang kh = new KhachHang();
                        kh.ID = Int32.Parse(GridThongTinDoan.Rows[i].Cells[0].Value.ToString().Trim());
                        kh.HoTen = GridThongTinDoan.Rows[i].Cells[1].Value.ToString().Trim();
                        kh.CMND = GridThongTinDoan.Rows[i].Cells[2].Value.ToString().Trim();

                        CacKhachHangCoCMNDDaTonTai.Add(kh);
                    }
                }
            }

            return CacKhachHangCoCMNDDaTonTai;
        }

        private void btnTaoGiaoDich_Click(object sender, EventArgs e)
        {
            if (GridThongTinDoan.Rows[0].Cells[2].Value != null && GridThongTinDoan.Rows[0].Cells[1].Value != null)
            {
                //so sánh thời điểm
                int TD = DateTime.Compare((DateTime)ThoiDiemBatDau.Value, (DateTime)ThoiDiemKetThuc.Value);
                if (TD <= 0)
                {
                    List<KhachHang> CacKhachHangCoCMNDDaTonTai = new List<KhachHang>();
                    CacKhachHangCoCMNDDaTonTai = KiemTraKhachHangCoCMNDDaTonTai();
                    if (CacKhachHangCoCMNDDaTonTai.Count <= 0) // kiểm tra xem có khách hàng nào có CMND đã tồn tại hay không
                    {
                        TaoGiaoDichMoi();
                        LuuDanhSachDoanVaCapNhatGiaoDich();
                    }
                    else
                    {
                        String ThongBao = "STT của các khách hàng có CMND đã tồn tại:";
                        for (int i = 0; i < CacKhachHangCoCMNDDaTonTai.Count; i++)
                        {
                            String temp = "\n" + CacKhachHangCoCMNDDaTonTai[i].ID;
                            ThongBao += temp;
                        }
                        MessageBox.Show(ThongBao);
                    }
                }
                else
                {
                    MessageBox.Show("Thời điểm kết thúc phải sau thời điểm bắt đầu!");
                }
            }
            else
            {
                MessageBox.Show("Thông tin trưởng đoàn không được trống!");
            }
            gd = new GiaoDich();
        }

        private void ThayDoiTrangThaiPhong(GiaoDich gd)
        {
            List<ChiTietGiaoDich> chiTietGDs = HE.ChiTietGiaoDiches.Where(t => t.ID_GiaoDich.Equals(gd.ID)).ToList();
            for(int i = 0; i < chiTietGDs.Count; i++)
            {
                Phong p = HE.Phongs.Single(t => t.ID == chiTietGDs[i].ID_MaPhong);
                if (p.TrangThai == 1)
                    p.TrangThai = 2;
                else p.TrangThai = 1;
            }
        }

        private void btn_nhan_phong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridHoatDong.RowCount; i++)
            {
                if (GridHoatDong.Rows[i].Cells[3].Selected)
                {
                    String maDoan = GridHoatDong.Rows[i].Cells[1].Value.ToString();
                    gd = HE.GiaoDiches.Single(t => t.TenDangNhap.Equals(maDoan));
                    if (gd.SoPhong == 0)
                    {
                        MessageBox.Show(maDoan + "Vui lòng đặt phòng trước khi nhận phòng");
                    }
                    else
                    {
                        String trangThai = GridHoatDong.Rows[i].Cells[2].Value.ToString();
                        if (trangThai.Equals("Đã đăng ký") || trangThai.Equals("Đã mướn phòng"))
                        {
                            gd.TinhTrang = 3;
                            ThayDoiTrangThaiPhong(gd);
                            HE.SaveChanges();
                        }
                    }
                }
            }
        }

        private void huyGiaoDich(String maDoan)
        {
            gd = HE.GiaoDiches.Single(t => t.TenDangNhap.Equals(maDoan));
            HE.GiaoDiches.Remove(gd);
            HE.SaveChanges();
        }

        private void btn_huy_phong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridHoatDong.RowCount; i++)
            {
                if (GridHoatDong.Rows[i].Cells[3].Selected)
                {
                    String maDoan = GridHoatDong.Rows[i].Cells[1].Value.ToString();
                    huyGiaoDich(maDoan);
                }
            }
        }
    }
}