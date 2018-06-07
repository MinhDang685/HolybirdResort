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
    public partial class DangNhap : Form
    {
        private HOLYBIRDRESORTEntities HE = new HOLYBIRDRESORTEntities();

        public DangNhap()
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
            //lấy 2 chuỗi mật khẩu + tài khoản người dùng nhập
            String InputUsername = txtSRNM.Text.ToString();
            String InputPassword = txtPWD.Text.ToString();

            try //truy vấn csdl xem tài khoản tồn tại hay không
            {
                NhanVien NV = HE.NhanViens.Single(t => t.TenDangNhap.Equals(InputUsername));
                
                //kiểm tra mật khẩu
                if (!NV.MatKhau.Equals(InputPassword)) // mật khẩu ko chính xác
                {
                    MessageBox.Show("Mật khẩu không chính xác!");
                }
                else //tài khoản đăng nhạp thành công
                {
                    QuanLy ql = new QuanLy(NV);
                    ql.Show();
                    
                }
            }
            catch // tài khoản ko tồn tại
            {
                MessageBox.Show("Tài khoản không tồn tại!");
            }

        }
    }
}
