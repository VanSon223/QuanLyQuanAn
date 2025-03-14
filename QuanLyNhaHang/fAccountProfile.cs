using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
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
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;
        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }
        void ChangeAccount(Account acc)
        {
            tbUserName.Text = LoginAccount.UserName;
            tbDisplayName.Text = LoginAccount.DisplayName;

        }
        void UpdateAccountInfo()
        {
            string displayName = tbDisplayName.Text;
            string passWord = tbPassWord.Text;
            string newPass = tbNewPass.Text;
            string reEnterPass = tbReEnterPass.Text;
            string userName = tbUserName.Text;

            if (!newPass.Equals(reEnterPass))
            {
                MessageBox.Show("Vui Lòng Nhập Lại Mật Khẩu Đúng Với Mật Khẩu Mới.");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(userName, displayName, passWord, newPass))
                {
                    MessageBox.Show("Cập Nhật Thành Công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("Vui Lòng Kiểm Tra Lại Mật Khẩu");
                }
            }
        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void tbUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void tbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {

        }       
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }
        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
