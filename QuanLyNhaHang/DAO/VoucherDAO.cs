using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaHang.DAO
{
    public class VoucherDAO
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiUrl = "https://resmant11111-001-site1.anytempurl.com/Voucher/List";

        /// <summary>
        /// Lấy thông tin voucherType theo voucherId.
        /// </summary>
        /// <param name="voucherId">ID của voucher.</param>
        /// <returns>Giá trị voucherType hoặc -1 nếu không tìm thấy.</returns>
        public async Task<int> GetVoucherTypeByIdAsync(int voucherId)
        {
            try
            {
                // Gửi yêu cầu GET đến API
                HttpResponseMessage response = await client.GetAsync(ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    // Đọc dữ liệu JSON từ API
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize danh sách voucher từ JSON
                    var vouchers = JsonConvert.DeserializeObject<List<Voucher>>(responseBody);

                    // Tìm voucher theo voucherId
                    var voucher = vouchers.FirstOrDefault(v => v.VoucherId == voucherId);

                    // Trả về voucherType nếu tìm thấy
                    return voucher != null ? voucher.VoucherType : -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi gọi API: {ex.Message}");
            }

            // Trả về -1 nếu có lỗi hoặc không tìm thấy
            return -1;
        }
    }
}
