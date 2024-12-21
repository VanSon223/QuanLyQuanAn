using System;

using System.Windows.Forms;
using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;

namespace QuanLyNhaHang
{
    public partial class fLogin : Form
    {
        private int? loggedInStaffID;
        private int? loggedInShiftID;
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

            try
            {
                // Gọi API kiểm tra đăng nhập và lấy thông tin người dùng
                Staff loggedInUser = await StaffDAO.Instance.LoginAsync(userName, passWord);

                if (loggedInUser != null)
                {
                    loggedInStaffID = loggedInUser.StaffID;

                    // Gọi API InsertShift và tạo Shift
                    Shifts shift = await ShiftDAO.Instance.InsertShiftAsync(loggedInStaffID.Value, DateTime.Now);

                    if (shift != null)
                    {
                        
                        MessageBox.Show($"Xin chào, {loggedInUser.FullName},{shift.ShiftID}! ", "Đăng nhập thành công");
                        loggedInShiftID = shift.ShiftID;
                        //ShiftID của bạn: { shift.ShiftID}
                        // Lưu ShiftID để sử dụng khi thoát
                        Properties.Settings.Default.CurrentShiftID = shift.ShiftID;
                        Properties.Settings.Default.Save();

                        // Mở form quản lý
                        fTableManager f = new fTableManager(loggedInStaffID.Value, loggedInShiftID.Value);
                        f.SetName(loggedInUser.FullName);

                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Không thể ghi nhận thời gian bắt đầu ca làm việc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi khi đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel);

            if (result != DialogResult.OK)
            {
                e.Cancel = true; // Hủy đóng form
            }
        }

     
    }
}
