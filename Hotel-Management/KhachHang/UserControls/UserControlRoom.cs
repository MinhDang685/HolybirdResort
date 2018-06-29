using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManageHotel.Entity;
using ManageHotel.Clsss;

namespace ManageHotel.UserControls
{
    public partial class UserControlRoom : UserControl
    {
        public delegate void AddHandler(object sender, string id);
        public event AddHandler Add;
        sp_SearchAvailableRoom_Result room;
        public int max = 4;
        public UserControlRoom(sp_SearchAvailableRoom_Result room, BindingList<KhachHang> list)
        {
            InitializeComponent();
            //BindingList<Country> listCountry = new BindingList<Country>();
            //listCountry.Add(new Country("germany", "1"));
            //listCountry.Add(new Country("england", "2"));
            this.room = room;
            this.max = Helper.calculateRoomCapacity((int)room.HinhThuc);
            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "HoTen";
            comboBox1.ValueMember = "CMND";
            checkRoomStatus();
            this.labelRoomId.Text = room.MaPhong;
            updateGuestCountLabel();
        }
        public List<int> getGuestList()
        {
            List<int> list = new List<int>();
            foreach (var guest in flowLayoutPanel1.Controls)
            {
                list.Add((guest as UserControlGuest).getGuestId());
            }
            return list;
        }
        public sp_SearchAvailableRoom_Result getRoom()
        {
            return room;
        }
        void updateGuestCountLabel()
        {
            labelGuestCount.Text = getGuestCount() + "/" + this.max;
        }
        int getGuestCount()
        {
            return this.flowLayoutPanel1.Controls.Count;
        }
        private bool checkRoomStatus()
        {
            if (getGuestCount() >= this.max)
            {
                setAddGuestState(false);
                return false;
            }
            return true;
        }
        public void setAddGuestState(bool state)
        {
            this.comboBox1.Enabled = state;
            this.buttonAddGuest.Enabled = state;
        }
        public void addToFlowLayout(Control control)
        {
            if (!checkRoomStatus()) return;
            this.flowLayoutPanel1.Controls.Add(control);
            updateGuestCountLabel();
            if (!checkRoomStatus()) return;
        }

        public void removeFromFlowLayout(Control c)
        {
            this.flowLayoutPanel1.Controls.Remove(c);
            updateGuestCountLabel();
            if (checkRoomStatus()) setAddGuestState(true);
        }

        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            string id = (string)comboBox1.SelectedValue;
            Add(sender, id);
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count % 4 == 0)
                flowLayoutPanel1.SetFlowBreak(e.Control as Control, true);
        }
    }
}
