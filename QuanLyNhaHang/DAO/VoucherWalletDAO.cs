using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuanLyNhaHang.DTO;
using System;
using System.Text;
using System.Windows.Forms;

namespace QuanLyNhaHang.DAO
{
    public class VoucherWalletDAO
    {
        
        // Khai báo một HttpClient tĩnh để tái sử dụng trong toàn bộ ứng dụng.
        private static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "https://resmant11111-001-site1.anytempurl.com/VoucherWallet/List";

        
        public async Task<List<VoucherWallet>> GetVoucherWalletsByCustomerIdAsync(int customerId)
        {
            try
            {
                // Gửi yêu cầu GET tới API
                HttpResponseMessage response = await client.GetAsync(ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung JSON trả về
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON thành danh sách các đối tượng VoucherWallet
                    var voucherWalletList = JsonConvert.DeserializeObject<List<VoucherWallet>>(responseBody);

                    // Lọc danh sách theo customerId
                    return voucherWalletList.Where(v => v.CustomerId == customerId).ToList();
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode}");
                    return new List<VoucherWallet>();
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi và thông báo khi có sự cố
                Console.WriteLine($"Ngoại lệ: {ex.Message}");
                return new List<VoucherWallet>();
            }
        }

        public async Task UpdateVoucherAsync(int customerId, int voucherId, int newQuantity)
        {
            // URL của API
            string apiUrl = "https://resmant11111-001-site1.anytempurl.com/VoucherWallet/Update";

            // Tạo đối tượng dữ liệu JSON
            var data = new
            {
                CustomerId = customerId, // ID khách hàng
                VoucherId = voucherId,  // ID voucher
                Quantity = newQuantity  // Số lượng mới
            };

            // Chuyển đổi đối tượng thành JSON
            string jsonData = JsonConvert.SerializeObject(data);

            // Sử dụng HttpClient để gửi yêu cầu HTTP
            using (HttpClient client = new HttpClient())
            {
                // Cấu hình nội dung yêu cầu (JSON)
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                try
                {
                    // Gửi yêu cầu HTTP POST tới API
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Xử lý khi thành công
                        MessageBox.Show("Voucher đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Xử lý khi thất bại
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Đã xảy ra lỗi khi cập nhật voucher: {error}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi kết nối hoặc ngoại lệ khác
                    MessageBox.Show($"Lỗi khi kết nối đến API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
