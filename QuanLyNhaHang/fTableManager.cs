using QuanLyNhaHang.DAO;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyNhaHang
{
    public partial class fTableManager : Form
    {
        private int loggedInStaffID;
        private int loggedInShiftID;
        public fTableManager(int staffID, int shiftID)
        {
            loggedInStaffID = staffID;
            loggedInShiftID = shiftID;
            InitializeComponent();
            LoadTableList();
            //LoadReservations();
            
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
                    case "Blocked":
                        btn.BackColor = Color.Black;
                        break;
                    case "Reserved":
                        btn.BackColor = Color.LightGray; 
                        break;
                    case "Occupied":
                        btn.BackColor = Color.IndianRed; 
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
        #region Event
        private int currentTableID = -1;
        private Customers selectedCustomer;
        private Voucher selectedVoucher;
        private void btn_Click(object sender, EventArgs e)
        {
            lsvBill.Items.Clear();
            currentTableID = ((sender as Button).Tag as Table).ID;

            ShowMenuItemsByTable(currentTableID);
        }
        private void gnbtnAdmin_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }



        private async Task HandleExitAsync()
        {
            if (loggedInStaffID > 0 && loggedInShiftID > 0)
            {
                // Cập nhật thời gian kết thúc khi thoát
                bool isEndTimeUpdated = await ShiftDAO.Instance.UpdateShiftAsync(loggedInShiftID, DateTime.Now);

                if (!isEndTimeUpdated)
                {
                    MessageBox.Show("Không thể ghi nhận thời gian kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Thời gian kết thúc đã được cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Chưa có ca làm việc hoặc nhân viên chưa đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Đóng form sau khi xử lý
            this.Close();
        }

        // Sự kiện nút gnibtnExit
        private async void gnibtnExit_Click(object sender, EventArgs e)
        {
            await HandleExitAsync();
        }

        // Sự kiện nút guna2ControlBox1 (nút X)
        private async void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            await HandleExitAsync();
        }
        private async void gnbtnCheckout_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem đã có bàn nào được chọn chưa
            if (currentTableID == -1)
            {
                MessageBox.Show("Bạn chưa chọn bàn nào để thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra SDT khách hàng
            string customerPhone = textBox1.Text.Trim();
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
                // Gửi IDOrder và IDCustomer lên API
                int customerId = selectedCustomer.CustomerId; // Lấy ID của khách hàng đã chọn
                int orderId = currentOrder.OrderID; // Lấy ID của đơn hàng
                bool isUpdated = await orderDAO.UpdateCustomerIDAsync(orderId, customerId);
                if (!isUpdated)
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng và đơn hàng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Thanh toán và cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Cập nhật trạng thái của bàn thành "Available"
                Table tableToUpdate = new Table
                {
                    ID = currentTableID,  // Sử dụng ID bàn đã chọn
                    Status = "Available"   // Thay đổi trạng thái thành "Available"
                };
                
                bool isTableUpdated = await TableDAO.Instance.UpdateTableStatusAsync(currentTableID, "Available");
                if (!isTableUpdated)
                {
                    MessageBox.Show("Cập nhật trạng thái bàn không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật trạng thái bàn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                
                if (selectedCustomer != null)
                {
                    string username = selectedCustomer.Username;
                    string phoneNumber = selectedCustomer.PhoneNumber;
                    int newPoints = selectedCustomer.Point + (int)(currentOrder.TotalAmount.Value / 100000) * 10; //  điểm là 10% tổng hóa đơn


                    CustomersDAO customerDAO = new CustomersDAO();
                    bool isPointUpdated = await customerDAO.UpdateCustomerPointAsync(phoneNumber, newPoints, username);

                    if (!isPointUpdated)
                    {
                        MessageBox.Show("Cập nhật điểm khách hàng không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Thanh toán và cập nhật điểm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thanh toán thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



                //Hiển thị form hóa đơn sau khi thanh toán
                // Kiểm tra và lấy tổng tiền giảm
                decimal totalAmount = 0;
                decimal discountAmount = 0; // Biến lưu trữ số tiền giảm

                // Tính tổng tiền gốc trước giảm giá
                foreach (ListViewItem item in lsvBill.Items)
                {
                    totalAmount += decimal.Parse(item.SubItems[3].Text);  // Thành tiền của mỗi món
                }

                // Nếu có giảm giá, tính tiền sau giảm
                decimal originalTotal = totalAmount;  // Giả sử tổng tiền gốc bằng tổng tiền ban đầu
                if (decimal.TryParse(txbtotalPrice.Text, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("vi-VN"), out decimal totalAfterDiscount))
                {
                    discountAmount = originalTotal - totalAfterDiscount;  // Số tiền giảm
                    totalAmount = totalAfterDiscount;  // Tổng tiền sau giảm
                }

                // Nếu không có giảm giá, totalAmount sẽ giữ nguyên giá trị gốc (không thay đổi)

                // Tạo form hóa đơn
                fInvoice invoiceForm = new fInvoice();
                invoiceForm.SetInvoiceData(lsvBill, currentOrder.OrderID, "" + currentTableID, textBox1.Text, totalAmount, DateTime.Now, discountAmount);
                invoiceForm.Show();



                lsvBill.Items.Clear();
                txbtotalPrice.Clear();
                flpTable.Controls.Clear();
                LoadTableList();
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private async void lsvKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvKH.SelectedItems.Count > 0)
            {
                // Lấy khách hàng đã chọn
                var selectedItem = lsvKH.SelectedItems[0];
                selectedCustomer = (Customers)selectedItem.Tag; // Gán đối tượng `selectedCustomer`

                // Hiển thị thông tin khách hàng
                MessageBox.Show($"Bạn đã chọn khách hàng: {selectedCustomer.Username} (ID: {selectedCustomer.CustomerId})",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                // Lấy danh sách VoucherWallet
                VoucherWalletDAO voucherWalletDAO = new VoucherWalletDAO();
                var voucherWallets = await voucherWalletDAO.GetVoucherWalletsByCustomerIdAsync(selectedCustomer.CustomerId);

                // Lấy thông tin voucherType cho mỗi voucherWallet
                VoucherDAO voucherDAO = new VoucherDAO();
                lsvVoucher.Items.Clear();

                foreach (var voucherWallet in voucherWallets)
                {
                    // Lấy voucherType từ API Voucher/List
                    int voucherType = await voucherDAO.GetVoucherTypeByIdAsync(voucherWallet.VoucherId);

                    // Thêm vào ListView với cột VoucherType
                    var item = new ListViewItem(voucherWallet.VoucherId.ToString());
                    item.SubItems.Add(voucherWallet.Quantity.ToString());
                    item.SubItems.Add(voucherType != -1 ? voucherType.ToString() : "N/A");
                    lsvVoucher.Items.Add(item);
                }
            }
        }
        async void LoadReservations()
        {
            try
            {
                var reservations = await ReservationDAO.Instance.GetReservationsFromApiAsync();

                // Kiểm tra danh sách có dữ liệu hay không
                if (reservations == null || !reservations.Any())
                {
                    MessageBox.Show("Không có dữ liệu đặt bàn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                
                DateTime todayStart = DateTime.Now.Date; // 00:00:00 hôm nay
                DateTime todayEnd = todayStart.AddDays(1).AddTicks(-1); // 23:59:59 hôm nay

                // Lọc danh sách các đặt chỗ trong ngày hôm nay
                var todayReservations = reservations
                    .Where(r => r.ReservationTime.HasValue &&
                                r.ReservationTime.Value >= todayStart &&
                                r.ReservationTime.Value <= todayEnd)
                    .ToList();

                // Kiểm tra danh sách đặt chỗ trong ngày hôm nay
                if (!todayReservations.Any())
                {
                    MessageBox.Show("Không có bàn nào được đặt trong ngày hôm nay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gắn dữ liệu vào DataGridView
                dtgvRe.DataSource = todayReservations
                    .Select(r => new
                    {
                        r.ReservationId,
                        r.TableId,
                        ReservationTime = r.ReservationTime?.ToString("yyyy-MM-dd HH:mm:ss")
                    })
                    .ToList();

                // Cấu hình tiêu đề cột
                dtgvRe.Columns["ReservationId"].HeaderText = "Mã đặt bàn";
                dtgvRe.Columns["TableId"].HeaderText = "Mã bàn";
                dtgvRe.Columns["ReservationTime"].HeaderText = "Thời gian đặt";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await Task.Delay(1000);
            LoadReservations();
        }
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string customerPhone = textBox1.Text.Trim();
            CustomersDAO customerDAO = new CustomersDAO();
            List<Customers> customers = await customerDAO.GetCustomersByPhoneNumberAsync(customerPhone);

            lsvKH.Items.Clear();

            // Kiểm tra danh sách khách hàng có kết quả hay không
            if (customers != null && customers.Count > 0)
            {
                // Duyệt qua từng khách hàng trong danh sách
                foreach (var customer in customers)
                {
                    var item = new ListViewItem();
                    item.Text = customer.Username;  // Hiển thị tên khách hàng
                    item.Tag = customer;            // Gán đối tượng customer vào Tag
                    item.SubItems.Add(customer.CustomerId.ToString());
                    item.SubItems.Add(customer.Point.ToString());
                    lsvKH.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Customer not found.");
            }
        }
        public void SetName(string fullName)
        {
            lbName.Text = "Tên nhân viên:" + fullName;
        }

        private async void lsvVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lsvVoucher.SelectedItems.Count == 0)
                return; // Thoát sớm nếu không có mục nào được chọn

            ListViewItem selectedItem = lsvVoucher.SelectedItems[0];

            // Lấy giá trị giảm giá từ cột thứ 3
            if (selectedItem.SubItems.Count > 2 && int.TryParse(selectedItem.SubItems[2].Text, out int discountPercent))
            {
                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn áp dụng giảm giá không?",
                    "Xác nhận giảm giá",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return; // Nếu người dùng không đồng ý, thoát sớm

                // Lấy tổng tiền từ TextBox
                if (decimal.TryParse(txbtotalPrice.Text, NumberStyles.Currency, CultureInfo.CreateSpecificCulture("vi-VN"), out decimal originalTotal))
                {
                    // Tính tổng tiền sau khi giảm
                    decimal discountAmount = originalTotal * (1 - discountPercent / 100m);
                    txbtotalPrice.Text = discountAmount.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"));

                    // Hiển thị thông báo cho người dùng
                    MessageBox.Show(
                        $"Tổng tiền sau khi giảm: {discountAmount.ToString("C", CultureInfo.CreateSpecificCulture("vi-VN"))}",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    // Cập nhật số lượng voucher và gọi API
                    //if (int.TryParse(selectedItem.SubItems[1].Text, out int currentQuantity) && currentQuantity > 0)
                    //{
                    //    int newQuantity = currentQuantity - 1;
                    //    selectedItem.SubItems[1].Text = newQuantity.ToString(); // Cập nhật giao diện

                    //    // Gọi API cập nhật số lượng
                    //    if (int.TryParse(selectedItem.SubItems[0].Text, out int voucherID)) // Lấy voucherID từ cột đầu tiên
                    //    {
                    //        await UpdateVoucherAsync(voucherID, newQuantity);
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Không thể cập nhật số lượng voucher.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("Tổng tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Thông tin giảm giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void gnbtnCheck_Click(object sender, EventArgs e)
        {
            plLich.Visible = true;
            guna2Panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plLich.Visible = false;   
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Panel3.Visible = true;
            flpTable.Visible = true;
            button2.Visible = true;
            plLich.Visible = false;
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            flpTable.Visible = false;
            button2.Visible = false;

        }

        #endregion


    }
}
