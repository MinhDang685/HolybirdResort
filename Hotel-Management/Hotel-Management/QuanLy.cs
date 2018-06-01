using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Hotel_Management
{
    public partial class QuanLy : DevComponents.DotNetBar.RibbonForm
    {
        public QuanLy()
        {
            InitializeComponent();
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
    }
}