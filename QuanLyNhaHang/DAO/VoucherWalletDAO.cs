using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using QuanLyNhaHang.DTO;
using System;

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
    }
}
