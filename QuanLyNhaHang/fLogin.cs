using System;

using System.Windows.Forms;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            
        }
        async void guna2Button1_Click(object sender, EventArgs e)
        {
            string userName = gntxbTen.Text;     // Lấy tên đăng nhập từ TextBox
            string passWord = gntxbpass.Text;    // Lấy mật khẩu từ TextBox

            // Kiểm tra nếu tên đăng nhập hoặc mật khẩu để trống
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(passWord))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gọi API kiểm tra đăng nhập và lấy thông tin người dùng
            Staff loggedInUser = await StaffDAO.Instance.LoginAsync(userName, passWord);
             
            if (loggedInUser != null)
            {
                // Hiển thị tên đầy đủ của người dùng
                MessageBox.Show($"Xin chào, {loggedInUser.FullName}!", "Đăng nhập thành công");

                // Mở form quản lý
                fTableManager f = new fTableManager();
                f.SetName(loggedInUser.FullName);
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


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
            {
                e.Cancel = true; // Hủy đóng form
            }
        }

    }
}
