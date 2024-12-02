using Newtonsoft.Json;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace QuanLyNhaHang.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        private static readonly HttpClient client = new HttpClient(); // Định nghĩa HttpClient ở đây

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        public async Task<int> GetUncheckBillIDByTableIDAsync(int id)
        {
            string url = $"https://resmant1111-001-site1.anytempurl.com/Order/List"; // Lấy danh sách đơn hàng

            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                List<Orders> orders = JsonConvert.DeserializeObject<List<Orders>>(jsonResponse);

                // Tìm đơn hàng không kiểm tra cho bàn
                var uncheckedBill = orders.FirstOrDefault(o => o.TableID == id && o.Status == "");
                if (uncheckedBill != null)
                {
                    return uncheckedBill.OrderID; // Trả về OrderID
                }
            }

            return -1; // Không tìm thấy
        }
    }
}
