using ManageHotel;
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
        ComboboxItemService service  = new ComboboxItemService();
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
            List<String> tmp = service.getAllTang();
            int a = 0;
        }
    }
}
