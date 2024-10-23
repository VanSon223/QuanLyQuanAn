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
                btn.Text = item.Name + System.Environment.NewLine + item.Status;
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
            Orders order = listOrder.FirstOrDefault(o => o.TableID == tableID && o.Status == "Pending");
           
            if (order == null)
            {
                lbOrderID.Text = "#";
                Console.WriteLine("Không tìm thấy đơn hàng cho TableID: " + tableID);
                return;
            }
            else
            {
                lbOrderID.Text = order.OrderID.ToString();
            }
            //Console.WriteLine("Đã tìm thấy đơn hàng cho TableID: " + tableID);

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

        private int currentTableID = -1;
        private void btn_Click(object sender, EventArgs e)
        {
            lsvBill.Items.Clear();
            currentTableID = ((sender as Button).Tag as Table).ID;

            ShowMenuItemsByTable(currentTableID);
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
            // Kiểm tra xem đã có bàn nào được chọn chưa
            if (currentTableID == -1)
            {
                MessageBox.Show("Bạn chưa chọn bàn nào để thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hiển thị hộp thoại xác nhận trước khi thanh toán
            var result = MessageBox.Show("Bạn có muốn thanh toán cho bàn này không?", "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                OrdersDAO orderDAO = new OrdersDAO();

                // Lấy đơn hàng hiện tại của bàn
                Orders currentOrder = await orderDAO.GetCurrentPendingOrderByTableID(currentTableID);
                if (currentOrder == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cho bàn này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Cập nhật trạng thái đơn hàng thành "Completed"
                currentOrder.Status = "Completed";
                bool isOrderUpdated = await orderDAO.UpdateOrderStatusAsync(currentOrder);
                if (!isOrderUpdated)
                {
                    MessageBox.Show("Cập nhật trạng thái đơn hàng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Console.WriteLine("BAN TRUOC KHI CHUYEN THANH COMPLETED" + currentTableID);
                // Cập nhật trạng thái của bàn thành "Available"
                Table tableToUpdate = new Table
                {
                    ID = currentTableID,  // Sử dụng ID bàn đã chọn
                    Status = "Available"   // Thay đổi trạng thái thành "Available"
                };
                //list table // id table // table(tableid ,....) 

                bool isTableUpdated = await TableDAO.Instance.UpdateTableStatusAsync(currentTableID,"Available");
                if (!isTableUpdated)
                {
                    MessageBox.Show("Cập nhật trạng thái bàn không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái bàn thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                // Xóa danh sách hóa đơn và tổng tiền hiển thị
                lsvBill.Items.Clear();
                txbtotalPrice.Clear();

                MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flpTable.Controls.Clear();
                LoadTableList(); // Giả định bạn có một phương thức để tải lại danh sách bàn
            }
        }



        #endregion


    }
}



