using System;
using System.Web.UI.WebControls;
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
        private void fLogin_Load(object sender, EventArgs e)
        {

        }
        private void  guna2Button1_Click(object sender, EventArgs e)
        {
            string userName = gntxbTen.Text;
            string passWord = gntxbpass.Text;
            if (Login(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                fTableManager f = new fTableManager(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }
        //Ham check
        bool Login(string userName, string PassWord)
        {
            return AccountDAO.Instance.Login(userName, PassWord);
        }
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }
    } 
}
