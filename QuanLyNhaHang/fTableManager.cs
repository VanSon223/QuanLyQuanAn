using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaHang.DTO;
using QuanLyNhaHang.DAO;
using System.Drawing;
using System.Net.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Globalization;
using System.Text;

namespace QuanLyNhaHang
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTableList();
        }

        #region Method


        async void LoadTableList()
        {
            List<Table> tableList = await TableDAO.Instance.GetTablesFromApiAsync();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.ID + System.Environment.NewLine + item.Name + System.Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;

                switch (item.Status)
                {
                    case "Available":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        async void ShowMenuItemsByTable(int tableID)
        {
            OrdersDAO orderDAO = new OrdersDAO();
            OrderItemsDAO orderItemDAO = new OrderItemsDAO();
            MenuDAO menuDAO = new MenuDAO();

            // Lấy toàn bộ danh sách Orders từ API
            List<Orders> listOrder = await orderDAO.GetListOrderByTableIDAsync();

            if (listOrder == null || listOrder.Count == 0)
            {
                Console.WriteLine("Không tìm thấy đơn hàng nào.");
                return;
            }

            // Lọc đơn hàng theo TableID
            Orders order = listOrder.FirstOrDefault(o => o.TableID == tableID);

            if (order == null)
            {
                Console.WriteLine("Không tìm thấy đơn hàng cho TableID: " + tableID);
                return;
            }
            Console.WriteLine("Đã tìm thấy đơn hàng cho TableID: " + tableID);

            // Lấy tất cả OrderItems theo OrderID
            List<OrderItem> listOrderItem = await orderItemDAO.GetListOrderItemByOrderIDAsync(order.OrderID);

            if (listOrderItem == null || listOrderItem.Count == 0)
            {
                Console.WriteLine("Không tìm thấy món ăn nào trong đơn hàng.");

                return;

            }

            Console.WriteLine("Số lượng món ăn tìm thấy: " + listOrderItem.Count);

            // Lấy danh sách tất cả món ăn từ API
            List<DTO.MenuItem> menuList = await menuDAO.GetMenuListAsync();
            var menuDict = menuList.ToDictionary(m => m.MenuItemID);

            decimal totalPrice = 0;
            foreach (var orderItem in listOrderItem)
            {
                if (menuDict.TryGetValue(orderItem.MenuItemID, out DTO.MenuItem menuItem))
                {
                    ListViewItem lsvItem = new ListViewItem(menuItem.Name);
                    lsvItem.SubItems.Add(orderItem.Quantity.ToString());
                    lsvItem.SubItems.Add(menuItem.Price.ToString());

                    decimal itemTotalPrice = orderItem.Quantity * menuItem.Price;
                    lsvItem.SubItems.Add(itemTotalPrice.ToString());

                    lsvBill.Items.Add(lsvItem);

                    totalPrice += itemTotalPrice;
                }
            }

            txbtotalPrice.Text = totalPrice.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));
        }

        #endregion

        #region event

        private void btn_Click(object sender, EventArgs e)
        {
            lsvBill.Items.Clear();


            Button btn = sender as Button;
            if (btn == null)
            {
                MessageBox.Show("Không tìm thấy nút nhấn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Table table = btn.Tag as Table;
            if (table == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bàn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int TableID = table.ID;


            ShowMenuItemsByTable(TableID);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAcccountProfile f = new fAcccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
        private async void btnCheckout_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Bạn có muốn thanh toán cho bàn này không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lsvBill.Items.Clear();
                int tableID = ((Button)sender).Tag is Table table ? table.ID : 1;

                // Kiểm tra nếu tableID hợp lệ
                if (tableID <= 0)
                {
                    MessageBox.Show("Không tìm thấy thông tin bàn.");
                    return;
                    
                }
                txbtotalPrice.Clear();
                Orders currentOrder = await OrdersDAO.Instance.GetCurrentPendingOrderByTableID(tableID);
                if (currentOrder == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng đang chờ cho bàn này.");
                    return;
                }
                bool isOrderUpdated = await OrdersDAO.Instance.UpdateOrderStatusAsync(currentOrder.OrderID, "Completed");
                if (isOrderUpdated)
                {
                    MessageBox.Show("Đơn hàng đã được cập nhật thành công.");

                    
                    bool isTableUpdated = await TableDAO.Instance.UpdateTableStatusAsync(tableID, "Available");
                    if (isTableUpdated)
                    {
                        MessageBox.Show("Trạng thái bàn đã được cập nhật thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật trạng thái bàn không thành công.");
                    }
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái đơn hàng không thành công.");
                }

                
                 //LoadTableList(); 
            }

            
        }
        #endregion
    }
}



