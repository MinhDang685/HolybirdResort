using ManageHotel;
using ManageHotel.Entity;
using ManageHotel.Service;
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
    public partial class Form1 : Form
    {
        KhachHangService khachhangservice = new KhachHangService();
        public Form1()
        {
            InitializeComponent();
        }

        private void txtboxUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxPWD_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = this.txtBoxUserName.Text;
            String password = this.txtBoxPassword.Text;
            if (this.khachhangservice.checkLoginUserName(username, password))
            {
                
                GiaoDich giaodich = this.khachhangservice.getAccount(username);
               DatPhong datphong = new DatPhong(giaodich.ID);

               this.Hide();
               datphong.Show();

            }
            else
            {
                MessageBox.Show(this,"Login fail. Please try again", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
