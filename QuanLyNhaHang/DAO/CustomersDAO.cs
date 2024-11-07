using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang.DAO
{
    public class CustomersDAO
    {
        private static CustomersDAO instance;
        public static CustomersDAO Instance
        {
            get { if (instance == null) instance = new CustomersDAO(); return CustomersDAO.instance; }
            private set { CustomersDAO.instance = value; }
        }
        private static readonly HttpClient client = new HttpClient();
        public async Task<List<Customers>> GetCustomersByPhoneNumberAsync(string phoneNumber)
        {
            string url = "https://resmant1111-001-site1.jtempurl.com/Customer/List";

            try
            {
                // Gọi API để lấy danh sách khách hàng
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Chuyển đổi JSON thành danh sách khách hàng
                var customersList = JsonConvert.DeserializeObject<List<Customers>>(jsonResponse);

                // Lọc tất cả khách hàng có số điện thoại trùng khớp
                var matchingCustomers = customersList.FindAll(c => c.PhoneNumber == phoneNumber);

                return matchingCustomers;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy thông tin khách hàng: {ex.Message}");
                return null; // Trả về null nếu có lỗi
            }
        }

        public async Task<bool> UpdateCustomerPointAsync(string phoneNumber, int point, string username)
        {
            // Tạo URL với tham số phone và point
            string url = $"https://resmant1111-001-site1.jtempurl.com/Customer/UpdatePoint?phone={phoneNumber}&point={point}&username={username}";
        

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Gửi yêu cầu PUT tới API
                    HttpResponseMessage response = await client.PutAsync(url, null); // Không cần body, chỉ truyền query string

                    // Kiểm tra nếu yêu cầu thành công
                    return response.IsSuccessStatusCode;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi cập nhật điểm khách hàng: {ex.Message}");
                    return false;
                }
            }
        }
        



    }
}
