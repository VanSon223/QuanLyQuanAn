
using QuanLyNhaHang.DAO;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyNhaHang.DTO;


namespace QuanLyNhaHang
{
    public partial class fAdmin : Form
    {
        BindingSource FoodList = new BindingSource();
        BindingSource AccountList = new BindingSource();
        BindingSource CategoryList = new BindingSource();
        BindingSource TableList = new BindingSource();
        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }
        #region methods
        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(name);

            return listFood;
        }

        void Load()
        {
            dtgvFood.DataSource = FoodList;
            dtgvAccount.DataSource = AccountList;
            dtgvCategory.DataSource = CategoryList;
            dtgvTable.DataSource = TableList;
            LoadListFood();
            LoadAccount();
            AddFoodBinding();
            AddAccountBinding();
            LoadCategoryIntoCombobox(cbFoodCaregory);
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListCategory();
            AddCategoryBinding();
            LoadListTable();
            AddTableBinding();
        }
        void AddTableBinding()
        {
            tbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));
            cbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "status", true, DataSourceUpdateMode.Never));
        }
        void AddCategoryBinding()
        {
            tbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
            tbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
        }
        void AddAccountBinding()
        {
            tbUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            tbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nbudTypeAccount.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }

        void LoadAccount()
        {
            AccountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        

        void AddFoodBinding()
        {
            tbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "name", true, DataSourceUpdateMode.Never));
            tbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListFood()
        {
            FoodList.DataSource = FoodDAO.Instance.GetListFood();
        }
        void AddAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }
        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản thất bại");
            }
            LoadAccount();
        }
        void DeleteAccount(string userName)
        {
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Không thể xóa tải khoản cá nhân");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản thất bại");
            }
            LoadAccount();
        }
        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        void LoadListCategory()
        {
            CategoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }
        void LoadListTable()
        {
            TableList.DataSource = TableDAO.Instance.LoadTableList();
        }
        private void btShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }
        private void btAddTable_Click(object sender, EventArgs e)
        {
            string name = tbTableName.Text;
            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListTable();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        private void btEditTable_Click(object sender, EventArgs e)
        {

        }

        private void btDeleteTable_Click(object sender, EventArgs e)
        {
            int tableID = Convert.ToInt32(tbTableID.Text);
            if (TableDAO.Instance.DeleteTable(tableID))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListTable();
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa bàn");
            }
        }
        private void btShowCategory_Click(object sender, EventArgs e)
        {
            LoadListCategory();
        }
       
        private void btAddCategory_Click(object sender, EventArgs e)
        {
            string name = tbCategoryName.Text;
            //    int categoryID = Convert.ToInt32(tbCategoryID.Text);
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm Danh mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm danh mục");
            }
        }
        private void btDeleteCategory_Click(object sender, EventArgs e)
        {
            int categoryID = Convert.ToInt32(tbCategoryID.Text);
            if (CategoryDAO.Instance.DeleteCategory(categoryID))
            {
                MessageBox.Show("Xóa danh mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa danh mục");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string name = tbCategoryName.Text;
            int categoryID = Convert.ToInt32(tbCategoryID.Text);
            if (CategoryDAO.Instance.UpdateCategory(categoryID, name))
            {
                MessageBox.Show("Sửa mục thành công");
                LoadListCategory();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Sửa danh mục");
            }
        }


        private void btShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnSeachFood_Click(object sender, EventArgs e)
        {
            FoodList.DataSource = SearchFoodByName(tbSearchFoodName.Text);
        }

        private void btAddFood_Click(object sender, EventArgs e)
        {
            string name = tbFoodName.Text;
            int CategoryID = (cbFoodCaregory.SelectedItem as Category).ID;
            float Price = (float)nmFoodPrice.Value;

            if (FoodDAO.Instance.InsertFood(name, CategoryID, Price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                //               if (insertFood != null)
                //                  insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món");
            }
        }

        private void btEditFood_Click(object sender, EventArgs e)
        {
            string name = tbFoodName.Text;
            int CategoryID = (cbFoodCaregory.SelectedItem as Category).ID;
            float Price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(tbFoodID.Text);

            if (FoodDAO.Instance.UpdateFood(id, name, CategoryID, Price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                //               if (updateFood != null)
                //                  updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi Sửa món");
            }
        }

        private void btDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbFoodID.Text);

            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                //               if (deleteFood != null)
                //                  deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xóa món");
            }
        }
        #endregion
        #region events


        private void btViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        private void btShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btAddAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string displayName = tbDisplayName.Text;
            int type = (int)nbudTypeAccount.Value;

            AddAccount(userName, displayName, type);
        }

        private void btDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;

            DeleteAccount(userName);
        }

        private void btEditAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string displayName = tbDisplayName.Text;
            int type = (int)nbudTypeAccount.Value;

            EditAccount(userName, displayName, type);
        }
        private void btResetPassWord_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;

            ResetPass(userName);
        }
        private void tcFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tpAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnReEnterAccount_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;

            ResetPass(userName);
        }











        #endregion

       
    }
}
