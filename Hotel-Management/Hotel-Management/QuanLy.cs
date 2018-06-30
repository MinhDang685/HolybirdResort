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
using System.Data.Entity.Core.Objects;

namespace Hotel_Management
{
    public partial class QuanLy : DevComponents.DotNetBar.RibbonForm
    {
        private HOLYBIRDRESORTEntities HE = new HOLYBIRDRESORTEntities();
        private NhanVien NV = null;
        int idGiaoDichThanhToan = 0;

        public QuanLy()
        {
            InitializeComponent();
        }

        public QuanLy(NhanVien nv)
        {

            InitializeComponent();
            CaiDatFormQuanLy(nv);
            showGridHoatDong();
        }



        private void CaiDatFormQuanLy(NhanVien nv)
        {
            NV = nv;
            lbTenNhanVien.Text = NV.TenDangNhap.ToString();
        }

        private void showGridThanhToan(GiaoDich gd1)
        {
            List<ChiTietGiaoDich> ctgds = HE.sp_LayChiTietGiaoDichTheoIdGiaoDich(gd1.ID).ToList();
            if (GridThanhToan.RowCount > 1)
            {
                GridThanhToan.Rows.Clear();
            }

            for (int i = 0; i < ctgds.Count; i++)
            {
                string stt = (i + 1).ToString();
                string maPhong = HE.sp_LayThongTinPhong(ctgds[i].ID_MaPhong).Single().MaPhong;
                String[] row = new String[]{
                          stt,
                          maPhong
                        };
                GridThanhToan.Rows.Add(row);
            }
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

        private void showGridHoatDong()
        {
            if (GridHoatDong.RowCount > 0)
            {
                GridHoatDong.Rows.Clear();
            }
            
            List<GiaoDich> giaoDichs = HE.sp_LayTatCaGiaoDich().ToList();
            for (int i = 0; i < giaoDichs.Count; i++)
            {
                string stt = (i + 1).ToString();
                string maDoan = giaoDichs[i].MaDoan;
                string tinhTrang = HE.sp_LayTinhTrangGiaoDich(giaoDichs[i].TinhTrang).Single().TinhTrang;
                String[] row = new String[]{
                          stt,
                          maDoan,
                          tinhTrang
                        };
                GridHoatDong.Rows.Add(row);
            }
        }

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {
            showGridHoatDong();
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

                gd.SoPhong = 0;

                gd.TinhTrang = 1;

                gd.TongTien = 0;

                //chưa tính đến tongtien,tinh trang, sophong, id nguoi dai dien
                HE.sp_TaoMoiGiaoDich(gd.MaDoan, gd.TenDangNhap, gd.MatKhau, gd.SoNguoi, gd.SoPhong, gd.NgayBatDau, gd.NgayKetThuc, gd.TinhTrang, gd.TongTien);
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

        private bool KiemTraTenKhachHangTrong()
        {
            for(int i=1; i< GridThongTinDoan.RowCount-1;i++)
            {
                if(GridThongTinDoan.Rows[i].Cells[1].Value == null)
                {
                    return false;
                }
            }
            return true;
        }

        private bool KiemTraCMNDKhachHangTrungNhau()
        {
            for(int i=0 ;i <GridThongTinDoan.RowCount-2;i++)
            {
                for(int u=i+1;u<GridThongTinDoan.RowCount-1;u++)
                {
                    if (GridThongTinDoan.Rows[i].Cells[2].Value != null && GridThongTinDoan.Rows[u].Cells[2].Value != null)
                    {
                        if (GridThongTinDoan.Rows[i].Cells[2].Value.ToString().Trim() == GridThongTinDoan.Rows[u].Cells[2].Value.ToString().Trim())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool KiemTraChuoiCMNDVietBangSo(String CMND)
        {
            for(int i=0;i<CMND.Length;i++)
            {
                if(CMND[i] <48 || CMND[i] > 57)
                {
                    return false;
                }
            }
            return true;
        }

        private bool KiemTraCMNDCacKhachHangVietBangSo()
        {
            for(int i=0;i< GridThongTinDoan.RowCount-1;i++)
            {
                if(GridThongTinDoan.Rows[i].Cells[2].Value != null)
                {
                    if(!KiemTraChuoiCMNDVietBangSo(GridThongTinDoan.Rows[i].Cells[2].Value.ToString()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnTaoGiaoDich_Click(object sender, EventArgs e)
        {
            if (GridThongTinDoan.Rows[0].Cells[2].Value != null && GridThongTinDoan.Rows[0].Cells[1].Value != null)
            {
                if(KiemTraTenKhachHangTrong())//kiểm tra xem có tên khách hàng nào trống không
                {
                    if(!KiemTraCMNDKhachHangTrungNhau())
                    {
                        if(KiemTraCMNDCacKhachHangVietBangSo())
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
                            MessageBox.Show("Có ít nhất một CMND trong danh sách khách hàng không đúng quy định");
                        }
                    }
                    else
                    {
                        MessageBox.Show("trong danh sach khách hàng đang đăng kí, có cặp CMND trùng nhau");
                    }
                }
                else
                {
                    MessageBox.Show("Tên các khách hàng không được bỏ trống");
                }
            }
            else
            {
                MessageBox.Show("Thông tin trưởng đoàn không được trống!");
            }
            gd = new GiaoDich();
        }

        private void ThayDoiTrangThaiPhong(GiaoDich gd1)
        {
            List<ChiTietGiaoDich> chiTietGDs = HE.sp_LayChiTietGiaoDichTheoDoan(gd1.ID).ToList();
            for(int i = 0; i < chiTietGDs.Count; i++)
            {
                sp_LayThongTinPhong_Result p = HE.sp_LayThongTinPhong(chiTietGDs.ElementAt(i).ID_MaPhong).Single();
                if (p.TrangThai == 1)
                    HE.sp_CapNhatTrangThaiPhong(p.ID, 2);
                else HE.sp_CapNhatTrangThaiPhong(p.ID, 1);
            }
        }

        private void btn_nhan_phong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridHoatDong.RowCount - 1; i++)
            {
                if (GridHoatDong.Rows[i].Cells[3].Selected)
                {
                    String maDoan = GridHoatDong.Rows[i].Cells[1].Value.ToString();
                    GiaoDich gd1 = HE.sp_LayGiaoDichTheoMaDoan(maDoan).Single();
                    if (gd1.SoPhong == 0)
                    {
                        MessageBox.Show(maDoan + "Vui lòng đặt phòng trước khi nhận phòng");
                    }
                    else
                    {
                        if (gd1.TinhTrang == 1 || gd1.TinhTrang == 2)
                        {
                            HE.sp_CapNhatTinhTrangGiaoDich(gd1.ID, 3);
                            ThayDoiTrangThaiPhong(gd1);
                        }
                        else
                        {
                            MessageBox.Show("Không thể nhận phòng nữa");
                        }
                    }
                }
            }
            showGridHoatDong();
        }

        private void btn_huy_phong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridHoatDong.RowCount - 1; i++)
            {
                if (GridHoatDong.Rows[i].Cells[3].Selected)
                {
                    String maDoan = GridHoatDong.Rows[i].Cells[1].Value.ToString();
                    GiaoDich gd1 = HE.sp_LayGiaoDichTheoMaDoan(maDoan).Single();
                    if (gd1.TinhTrang == 1 || gd1.TinhTrang == 2)
                        HE.sp_CapNhatTinhTrangGiaoDich(gd1.ID, 5);
                    else
                        MessageBox.Show("Không thể hủy giao dịch này nữa");
                }
            }
            showGridHoatDong();
        }

        private void btn_hoa_don_Click(object sender, EventArgs e)
        {
            if (GridThanhToan.RowCount == 1)
                MessageBox.Show("Chọn đoàn muốn thanh toán");
            else
            {
                if(HE.sp_LayGiaoDichTheoMaDoan(tbTimKiemGiaoDichThanhToan.Text).Single().TinhTrang == 3)
                {
                    int tongTien = 0;
                    for (int i = 0; i < GridThanhToan.RowCount - 1; i++)
                    {
                        int thanhTien = 0;
                        int soNgay = 1;
                        string maPhong = GridThanhToan.Rows[i].Cells[1].Value.ToString();
                        Phong phong = HE.sp_LayPhongTheoMaPhong(maPhong).Single();
                        ChiTietGiaoDich ctgd = HE.sp_LayChiTietGiaoDichTheoIdPhong(phong.ID, idGiaoDichThanhToan).Single();
                        if (ctgd.NgayBatDau != null && ctgd.NgayKetThuc != null)
                        {
                            TimeSpan time = (TimeSpan)(ctgd.NgayKetThuc - ctgd.NgayBatDau);
                            soNgay = time.Days;
                        }
                        if (GridThanhToan.Rows[i].Cells[3].Value != null && !GridThanhToan.Rows[i].Cells[3].Value.ToString().Equals(""))
                        {
                            thanhTien = (int)phong.DonGia * soNgay + Convert.ToInt32(GridThanhToan.Rows[i].Cells[3].Value);
                        }
                        else
                        {
                            thanhTien = (int)phong.DonGia * soNgay;
                        }
                        HE.sp_CapNhatTinhTrangGiaoDich(idGiaoDichThanhToan, 4);
                        HE.sp_CapNhatChiTietGiaoDichKhiThanhToan(idGiaoDichThanhToan, phong.ID, thanhTien);
                        HE.sp_CapNhatTrangThaiPhong(phong.ID, 1);
                        tongTien += thanhTien;
                    }
                    HE.sp_CapNhatTongTienGiaoDich(idGiaoDichThanhToan, tongTien);
                    ThanhToan formThanhToan = new ThanhToan(idGiaoDichThanhToan);
                    formThanhToan.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Giao dịch không thể thanh toán");
                }
            }
        }

        private void QuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnTimKiemGiaoDich_Click(object sender, EventArgs e)
        {
            string timKiem = "%" + tbTimKiemGiaoDich.Text + "%";
            List<GiaoDich> giaoDichs = HE.sp_TimKiemGiaoDich(timKiem).ToList();
            if (GridHoatDong.RowCount > 0)
            {
                GridHoatDong.Rows.Clear();
            }
            for (int i = 0; i < giaoDichs.Count; i++)
            {
                string stt = (i + 1).ToString();
                string maDoan = giaoDichs[i].MaDoan;
                string tinhTrang = HE.sp_LayTinhTrangGiaoDich(giaoDichs[i].TinhTrang).Single().TinhTrang;
                String[] row = new String[]{
                          stt,
                          maDoan,
                          tinhTrang
                        };
                GridHoatDong.Rows.Add(row);
            }
        }

        private void btnTimKiemGiaoDichThanhToan_Click(object sender, EventArgs e)
        {
            string maDoan = tbTimKiemGiaoDichThanhToan.Text;
            if(maDoan != "")
            {
                List<GiaoDich> lgd1 = HE.sp_LayGiaoDichTheoMaDoanDayDu(maDoan).ToList();
                if (lgd1.Count > 0)
                {
                    GiaoDich gd2 = lgd1.Single();
                    idGiaoDichThanhToan = gd2.ID;
                    showGridThanhToan(gd2);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy giao dịch");
                }
            }
            else
                MessageBox.Show("Nhập mã đoàn muốn tìm kiếm");
        }
    }
}