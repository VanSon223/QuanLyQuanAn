
using QuanLyNhaHang.DAO;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MenuItem = QuanLyNhaHang.DTO.MenuItem;
using QuanLyNhaHang.DTO;
using System.Collections.Specialized;
using System.Net;

namespace QuanLyNhaHang
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadFoodList();
            LoadCustomerList();
            LoadTableList();
            LoadStaffList();
        }

        async void LoadFoodList()
        {
            string apiUrl = "https://resmant1111-001-site1.jtempurl.com/Menu/List"; // Thay thế bằng URL API của bạn

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Đảm bảo phản hồi thành công

                    // Đọc nội dung phản hồi dưới dạng chuỗi
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Giải mã JSON thành danh sách các đối tượng MenuItem
                    List<MenuItem> foodList = JsonConvert.DeserializeObject<List<MenuItem>>(responseBody);

                    // Gán DataSource của dtgvFood là danh sách đã giải mã
                    dtgvFood.DataSource = foodList;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Lỗi yêu cầu: {e.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
        }
        async void LoadTableList()
        {
            string apiUrl = "https://resmant1111-001-site1.jtempurl.com/Table/List"; // Thay thế bằng URL API của bạn

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Đảm bảo phản hồi thành công

                    // Đọc nội dung phản hồi dưới dạng chuỗi
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Giải mã JSON thành danh sách các đối tượng MenuItem
                    List<Table> tableList = JsonConvert.DeserializeObject<List<Table>>(responseBody);

                    // Gán DataSource của dtgvFood là danh sách đã giải mã
                    dtgvTablelist.DataSource = tableList;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Lỗi yêu cầu: {e.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
        }
        async void LoadCustomerList()
        {
            string apiUrl = "https://resmant1111-001-site1.jtempurl.com/Customer/List"; // Thay thế bằng URL API của bạn

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Đảm bảo phản hồi thành công

                    // Đọc nội dung phản hồi dưới dạng chuỗi
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Giải mã JSON thành danh sách các đối tượng MenuItem
                    List<Customers> customerList = JsonConvert.DeserializeObject<List<Customers>>(responseBody);

                    // Gán DataSource của dtgvFood là danh sách đã giải mã
                    dtgvCustomer.DataSource = customerList;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Lỗi yêu cầu: {e.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
        }
        async void LoadStaffList()
        {
            string apiUrl = "https://resmant1111-001-site1.jtempurl.com/Staff/List"; // Thay thế bằng URL API của bạn

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu GET đến API
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode(); // Đảm bảo phản hồi thành công

                    // Đọc nội dung phản hồi dưới dạng chuỗi
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Giải mã JSON thành danh sách các đối tượng MenuItem
                    List<Staff> staffList = JsonConvert.DeserializeObject<List<Staff>>(responseBody);

                    // Gán DataSource của dtgvFood là danh sách đã giải mã
                    dtgvStaff.DataSource = staffList;
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show($"Lỗi yêu cầu: {e.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
                }
            }
        }

       
    }
    
}
