using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ManageHotel.Service;
using ManageHotel;
using System.Collections.Generic;
using ManageHotel.Entity;
using ManageHotel.UserControls;

namespace Hotel_Management
{
    public partial class DatPhong : DevComponents.DotNetBar.RibbonForm
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        ComboboxItemService servicecombobox = new ComboboxItemService();
        ServiceSearchRoom servicesearchroom = new ServiceSearchRoom();
        KhachHangService khachHangService = new KhachHangService();
        RoomService phongService = new RoomService();
        int idDoan = -1;
        int tinhTrangGiaoDich = -1;
        sp_LayThongTinDoan_Result thongTinDoan;
        List<KhachHang> listKhachHang = new List<KhachHang>();
        List<sp_LayChiTietGiaoDichTheoDoan_Result> listChiTietGiaoDich;
        Dictionary<String, sp_SearchAvailableRoom_Result> searchRoomList = 
            new Dictionary<string, sp_SearchAvailableRoom_Result>();
        Dictionary<String, sp_SearchAvailableRoom_Result> selectedRoomList = 
            new Dictionary<String, sp_SearchAvailableRoom_Result>();
        Dictionary<String, UserControlGuest> listGuestUserControl = new Dictionary<String, UserControlGuest>();
        Dictionary<String, UserControlRoom> listRoomUserControl = new Dictionary<string, UserControlRoom>();
        BindingList<KhachHang> availableGuestList = new BindingList<KhachHang>();
        Dictionary<String, KhachHang> backupGuestList = new Dictionary<string, KhachHang>();
        public DatPhong(int maDoan)
        {
            InitializeComponent();
            this.idDoan = maDoan;
            dataGridViewDetail.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
            dtp.TextChanged += new EventHandler(dtp_TextChange);

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (dataGridViewDetail.Columns[e.ColumnIndex].Name)
            {
                case "Column1":
                    _Rectangle = dataGridViewDetail.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
                case "Column10":
                    _Rectangle = dataGridViewDetail.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;
                    break;
                case "remove":
                    this.dataGridViewDetail.Rows.RemoveAt(e.RowIndex);
                    break;
            }
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridViewDetail.CurrentCell.Value = dtp.Text.ToString();
        }

        private void DatPhong_Load(object sender, EventArgs e)
        {
            thongTinDoan = khachHangService.layThongTinDoan(GetIdDoan());
            LoadHang();
            LoadTang();
            LoadHinhThuc();
            SetDefaultView();
        }

        private int GetIdDoan()
        {
            //ma doan dang dang nhap
            return 1;
        }

        private void LoadThongTinPhongDaChon()
        {
            GetSelectedRooms();
        }

        private void LoadHinhThuc()
        {
            List<HinhThuc> hinhthucs = servicecombobox.getAllHinhThuc();
            foreach (HinhThuc hinhthuc in hinhthucs)
            {
                ItemCombobox item = new ItemCombobox(hinhthuc.ThongTin, hinhthuc.ID);
                this.cbbSoNguoi.Items.Add(item);
            }

        }

        private void SetDefaultView()
        {
            this.cbbHang.SelectedIndex = 0;
            this.cbbTang.SelectedIndex = 0;
            this.cbbSoNguoi.SelectedIndex = 0;
            this.dateTimeFrom.Value = DateTime.Now;
            this.dateTimeTo.Value = DateTime.Now;
        }

        private void LoadTang()
        {
            List<String> tangs = servicecombobox.getAllTang();
            tangs.Sort();
            List<ItemCombobox> item = new List<ItemCombobox>();
            foreach (String tang in tangs)
            {
                ItemCombobox tmp = new ItemCombobox("Tang " + tang, Int32.Parse(tang));
                item.Add(tmp);
            }
            item.Sort(delegate(ItemCombobox x, ItemCombobox y)
            {
                return Int32.Parse(x.Value.ToString()) > Int32.Parse(y.Value.ToString()) ? 1 : -1;
            });
            foreach (ItemCombobox i in item)
            {
                this.cbbTang.Items.Add(i);
            }
        }

        private void LoadHang()
        {
            List<Hang> hangs = servicecombobox.getAllHang();
            foreach (Hang hang in hangs)
            {
                ItemCombobox item = new ItemCombobox(hang.ThongTin, hang.ID);
                this.cbbHang.Items.Add(item);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            this.dataGridViewPhongSearch.Rows.Clear();
            int hang = Int32.Parse(((ItemCombobox)this.cbbHang.SelectedItem).Value.ToString());
            int tang = Int32.Parse(((ItemCombobox)this.cbbTang.SelectedItem).Value.ToString());
            int songuoi = Int32.Parse(((ItemCombobox)this.cbbSoNguoi.SelectedItem).Value.ToString());
            int state = 1;
            String dateFrom = this.dateTimeFrom.Value.ToString("yyyy/MM/dd");
            String dateTo = this.dateTimeTo.Value.ToString("yyyy/MM/dd");
            List<sp_SearchAvailableRoom_Result> result = servicesearchroom.SearchAvailableRoom(tang, state, hang, songuoi, dateFrom, dateTo);
            AddToRoomList(result);
            FillDateinDridView(result);
        }

        private void AddToRoomList(List<sp_SearchAvailableRoom_Result> result)
        {
            foreach (var room in result)
            {
                if(!searchRoomList.ContainsKey(room.MaPhong))
                    searchRoomList.Add(room.MaPhong, room);
            }
        }

        private void FillDateinDridView(List<sp_SearchAvailableRoom_Result> result)
        {
            foreach (sp_SearchAvailableRoom_Result item in result)
            {
                String[] row = new String[]{
                    item.ID.ToString(),
                    item.MaPhong,
                    item.roomlevel,
                    item.ViTriTang,
                    item.ThongTin,
                    item.DonGia.ToString()
                };
                this.dataGridViewPhongSearch.Rows.Add(row);
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            AddDataDetail();
        }

        private void AddDataDetail()
        {
            for (int i = 0; i < this.dataGridViewPhongSearch.Rows.Count; i++)
            {
                bool checkCell = this.dataGridViewPhongSearch.Rows[i].Cells[6].Value != null?true:false;
                if (checkCell)
                {
                    String[] row = new String[]{
                            "",  
                            this.dataGridViewPhongSearch.Rows[i].Cells[1].Value.ToString(),
                            "",
                            "",
                            this.dateTimeFrom.Value.ToString("dd/MM/yyyy"),
                            this.dateTimeFrom.Value.ToString("dd/MM/yyyy")
                        };
                    this.dataGridViewDetail.Rows.Add(row);
                }
            }
        }

        private void flowLayoutPanelRoomList_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanelRoomList.Controls.Count % 1 == 0)
                flowLayoutPanelRoomList.SetFlowBreak(e.Control as Control, true);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            ribbonControl1.SelectedRibbonTabItem = ribbonTabItemMapGuestToRoom;
        }

        private void TaoRoomUserControl()
        {
            flowLayoutPanelRoomList.Controls.Clear();
            UserControlRoom roomUserControl = null;
            foreach (var room in selectedRoomList.Values)
            {
                roomUserControl = new UserControlRoom(room, availableGuestList);
                roomUserControl.Add += roomUserControl_Add;
                listRoomUserControl.Add(room.MaPhong, roomUserControl);
                flowLayoutPanelRoomList.Controls.Add(roomUserControl);
            }
        }

        private void GetSelectedRooms()
        {
            int rowCount = dataGridViewDetail.RowCount;
            String roomId;
            sp_SearchAvailableRoom_Result room = null;
            for (int i = 0; i < rowCount; i++)
            {
                roomId = (String) dataGridViewDetail.Rows[i].Cells[1].Value;
                if (searchRoomList.ContainsKey(roomId) && !selectedRoomList.ContainsKey(roomId))
                {
                    room = searchRoomList[roomId];
                    selectedRoomList.Add(room.MaPhong, room);
                }
            }
        }


        /*----------------------Chi tiet dat phong--------------------------*/

        void roomUserControl_Add(object sender, string id)
        {
            if (id == null) return;
            UserControlRoom roomUserControl = (sender as Button).Parent as UserControlRoom;
            addGuest(roomUserControl, listGuestUserControl[id]);
            removeGuestFromList(id);
        }

        private void removeGuestFromList(string id)
        {
            foreach (KhachHang g in availableGuestList)
                if (g.CMND == id)
                {
                    availableGuestList.Remove(g);
                    return;
                }
        }


        void addGuest(UserControlRoom roomUserControl, Control c)
        {
            roomUserControl.addToFlowLayout(c);
        }

        void c_Remove(object guest, string id)
        {
            UserControlRoom roomUserControl = (guest as Button).Parent.Parent.Parent as UserControlRoom;
            roomUserControl.removeFromFlowLayout(listGuestUserControl[id]);
            System.Console.WriteLine("Remove: " + id);
            addGuestToAvailableGuestList(id);
        }

        private void addGuestToAvailableGuestList(string id)
        {
            availableGuestList.Add(backupGuestList[id]);
        }

        //load thong tin khi mo tab
        private void ribbonControl1_SelectedRibbonTabChanged(object sender, EventArgs e)
        {
            String tabName = (sender as RibbonControl).SelectedRibbonTabItem.Name;
            if (tabName.Equals("ribbonTabItemMapGuestToRoom"))
            {
                listRoomUserControl.Clear();
                listKhachHang.Clear();
                listGuestUserControl.Clear();
                availableGuestList.Clear();
                backupGuestList.Clear();
                tinhTrangGiaoDich = (int)thongTinDoan.TinhTrang;
                if (tinhTrangGiaoDich > 1)
                {
                    buttonDatPhong.Text = "Cập nhật";
                    listChiTietGiaoDich = khachHangService.layChiTietGiaoDichTheoMaDoan(idDoan);
                    layDanhSachPhongTrongChiTietGiaoDich();
                }
                idDoan = thongTinDoan.ID;
                LoadThongTinPhongDaChon();
                LoadDanhSachDoan(idDoan);
                TaoGuestUserControl(listKhachHang);
                TaoRoomUserControl();
                if (tinhTrangGiaoDich > 1)
                {
                    LoadThongTinChonPhongTrongChiTietGiaoDich();
                }
            }
            if (tabName.Equals("ribbonTabChiTiet"))
            {
                this.dataGridViewDetailGiaoDich.Rows.Clear();
                this.dataGridViewDetailGiaoDich.ReadOnly = true;
                RoomService roomservice = new RoomService();
                List<sp_ChiTietGiaoDich_Result> details = roomservice.getChiTietGiaoDich(this.idDoan);
                for (int i = 0; i < details.Count; i++) {
                    String[] row = new String[]{
                            details[i].MaDoan,
                          details[i].HoTen,
                          details[i].CMND,
                          details[i].MaPhong,
                          details[i].NgayBatDau,
                          details[i].NgayKetThuc,
                          details[i].DonGia.ToString(),
                          details[i].ThanhTien.ToString()

                        };
                    this.dataGridViewDetailGiaoDich.Rows.Add(row);
                }
            }
        }

        private void LoadThongTinChonPhongTrongChiTietGiaoDich()
        {
            foreach (var ct in listChiTietGiaoDich)
            {
                listRoomUserControl[ct.MaPhong].addToFlowLayout(listGuestUserControl[ct.CMND]);
                availableGuestList.Remove(listGuestUserControl[ct.CMND].getKhachHang());
            }
        }

        private void layDanhSachPhongTrongChiTietGiaoDich()
        {
            sp_SearchAvailableRoom_Result p;
            foreach (var ct in listChiTietGiaoDich)
            {
                p = phongService.createPhongSearch((int)ct.ID_MaPhong, ct.MaPhong, ct.ViTriTang, (int)ct.Hang, (int)ct.DonGia, 
                    (int)ct.HinhThuc, (int)ct.TrangThai, 
                    ((DateTime)ct.NgayBatDau).ToString("MM'/'dd'/'yyyy"), 
                    ((DateTime)ct.NgayKetThuc).ToString("MM'/'dd'/'yyyy"));
                if(!selectedRoomList.ContainsKey(p.MaPhong))
                    selectedRoomList.Add(p.MaPhong, p);
            }
        }


        private void LoadDanhSachDoan(int idDoan)
        {
            listKhachHang = khachHangService.getDanhSachDoan(idDoan); 
        }

        private void TaoGuestUserControl(List<KhachHang> listKhachHang)
        {
            UserControlGuest guestUserControl = null;
            foreach (var kh in listKhachHang)
            {
                availableGuestList.Add(kh);
                backupGuestList.Add(kh.CMND, kh);
                guestUserControl = new UserControlGuest(kh);
                guestUserControl.Remove += c_Remove;
                listGuestUserControl.Add(kh.CMND, guestUserControl);
            }
        }

        private void buttonDatPhong_Click(object sender, EventArgs e)
        {
            if (availableGuestList.Count > 0)
            {
                MessageBox.Show("Vui lòng chọn phòng cho tất cả các thành viên trong đoàn");
                return;
            }
            List<ChiTietGiaoDich> listGiaoDich = GetChiTietGiaoDich();
            int tinhTrangGiaoDich = (int)thongTinDoan.TinhTrang;
            if (tinhTrangGiaoDich > 1)
            {
                khachHangService.xoaChiTietGiaoDichTheoMaDoan(idDoan);
            }
            foreach (var giaoDich in listGiaoDich)
            {
                khachHangService.themChiTietGiaoDich(giaoDich);
            }
            khachHangService.capNhatTinhTrangGiaoDich(idDoan, 2);
            MessageBox.Show(buttonDatPhong.Text + " thành công !!!");
        }

        private List<ChiTietGiaoDich> GetChiTietGiaoDich()
        {
            List<ChiTietGiaoDich> listChiTietGiaoDich = new List<ChiTietGiaoDich>();
            List<int> roomGuestList;
            UserControlRoom roomUserControl;
            sp_SearchAvailableRoom_Result room;
            ChiTietGiaoDich ct;
            foreach (var c in flowLayoutPanelRoomList.Controls)
            {
                roomUserControl = (c as UserControlRoom);
                room = roomUserControl.getRoom();
                roomGuestList = roomUserControl.getGuestList();
                foreach (var guestId in roomGuestList)
                {
                    ct = new ChiTietGiaoDich();
                    ct.ID_GiaoDich = idDoan;
                    ct.ID_MaPhong = room.ID;
                    ct.ID_KhachHang = guestId;
                    ct.NgayBatDau = DateTime.Parse(room.ngayBatDau);
                    ct.NgayKetThuc = DateTime.Parse(room.ngayKetThuc);
                    listChiTietGiaoDich.Add(ct);
                }
            }
            return listChiTietGiaoDich;
        }

        private void DatPhong_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ribbonTabItemMapGuestToRoom_Click(object sender, EventArgs e)
        {

        }

    }
}