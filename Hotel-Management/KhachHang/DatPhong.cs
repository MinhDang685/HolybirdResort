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

namespace Hotel_Management
{
    public partial class DatPhong : DevComponents.DotNetBar.RibbonForm
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        ComboboxItemService servicecombobox = new ComboboxItemService();
        ServiceSearchRoom servicesearchroom = new ServiceSearchRoom();
        public DatPhong()
        {
            InitializeComponent();
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
            LoadHang();
            LoadTang();
            LoadHinhThuc();
            SetDefaultView();
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
            FillDateinDridView(result);
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

    }
}