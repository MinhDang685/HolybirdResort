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

namespace ManageHotel.UserControls
{
    public partial class UserControlGuest : UserControl
    {
        public event RemoveHandler Remove;
        public string idNumber = "";
        public string name = "";
        public delegate void RemoveHandler(object handler, string id);
        KhachHang guest;
        public UserControlGuest(KhachHang guest)
        {
            InitializeComponent();
            this.guest = guest;
            this.idNumber = guest.CMND;
            this.name = guest.HoTen;
            labelId.Text = this.idNumber;
            labelName.Text = this.name;
        }

        public KhachHang getKhachHang() {
            return guest;
        }

        private void buttonRemoveGuest_Click(object sender, EventArgs e)
        {
            Remove(sender, idNumber);
        }
        public int getGuestId()
        {
            return guest.ID;
        }
    }
}
