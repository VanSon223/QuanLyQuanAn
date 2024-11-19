using QuanLyNhaHang.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fLogin1 : Form
    {
        public fLogin1()
        {
            InitializeComponent();
        }

        async void btnlogin_Click(object sender, EventArgs e)
        {
            string userName = txbTen.Text;     // Lấy tên đăng nhập từ TextBox
            string passWord = txbpass.Text;    // Lấy mật khẩu từ TextBox

            // Kiểm tra nếu tên đăng nhập hoặc mật khẩu để trống
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi API kiểm tra đăng nhập
            bool loginSuccess = await StaffDAO.Instance.LoginAsync(userName, passWord);

            if (loginSuccess)
            {
                // Nếu đăng nhập thành công, mở form quản lý fTableManager
                fTableManager f = new fTableManager();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                // Nếu thất bại, hiển thị thông báo lỗi
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //bool Login(string userName, string passWord)
        //{
        //    return AccountDAO.Instance.Login(userName, passWord);
        //}

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?","Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK) 
            {
                e.Cancel=true;
            }
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(20, 0, 0, 0);
            panel2.BackColor = Color.FromArgb(20, 0, 0, 0);
            panel3.BackColor = Color.FromArgb(20, 0, 0, 0);

        }
    }
}

